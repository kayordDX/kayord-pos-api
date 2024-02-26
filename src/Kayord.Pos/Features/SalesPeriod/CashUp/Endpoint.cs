using Kayord.Pos.Data;
using Kayord.Pos.Services;
using Kayord.Pos.DTO;

using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Kayord.Pos.Features.SalesPeriod.CashUp;


public class Endpoint : Endpoint<Request, CashUp>
{
    private readonly AppDbContext _dbContext;
    private readonly CurrentUserService _cu;

    public Endpoint(AppDbContext dbContext, CurrentUserService cu)
    {
        _dbContext = dbContext;
        _cu = cu;
    }

    public override void Configure()
    {
        Get("/salesperiod/cashup");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        Entities.SalesPeriod? sp = await _dbContext.SalesPeriod.FirstOrDefaultAsync(x => x.Id == req.SalesPeriodId);
        if (sp == null)
            await SendNotFoundAsync();
        List<TableCashUp> salesPeriodTableCashUps = new();
        List<UserCashUp> salesPeriodUserCashUps = new();
        UserCashUp userCashUp = new();
        CashUp cashUp = new();
        cashUp.TableCount = 0;
        List<Entities.TableBooking> bookings = new();
        var userIdsCashedUp = _dbContext.CashUp.Where(x => x.SalesPeriodId == req.SalesPeriodId && x.SignOffDate != null).Select(rd => rd.UserId).ToList();

        if (req.UserId == string.Empty)
            bookings = await _dbContext.TableBooking.Where(x => x.SalesPeriodId == req.SalesPeriodId).Where(oi => !userIdsCashedUp.Contains(oi.UserId)).ToListAsync();
        else
            bookings = await _dbContext.TableBooking.Where(x => x.SalesPeriodId == req.SalesPeriodId).ToListAsync();

        foreach (Entities.TableBooking tb in bookings)
        {
            cashUp.TableCount++;
            TableCashUp tableCashUp = new();
            tableCashUp.Total = 0;
            decimal TotalPayments = 0m;

            var paymentStatusIds = _dbContext.OrderItemStatus.Where(x => x.isBillable == true).Select(rd => rd.OrderItemStatusId).ToList();

            tableCashUp.OrderItems = await _dbContext.OrderItem
            .Where(x => paymentStatusIds.Contains(x.OrderItemStatusId) && x.TableBookingId == tb.Id)
            .ProjectToDto()
            .ToListAsync();
            tableCashUp.UserId = tb.UserId;
            tableCashUp.PaymentsReceived = await _dbContext.Payment.Where(x => x.TableBookingId == tb.Id).ToListAsync();

            tableCashUp.Total += tableCashUp.OrderItems.Sum(item => item.MenuItem.Price);

            tableCashUp.Total += tableCashUp.OrderItems.Where(item => item.OrderItemOptions != null)
                                          .Sum(item => item.OrderItemOptions!.Sum(option => option.Option.Price));

            tableCashUp.Total += tableCashUp.OrderItems.Where(item => item.OrderItemExtras != null)
                                          .Sum(item => item.OrderItemExtras!.Sum(extra => extra.Extra.Price));

            tableCashUp.TablePaymentTotal += tableCashUp.PaymentsReceived.Where(item => item.TableBookingId! == tb.Id)
                                          .Sum(item => item.Amount);
            tableCashUp.Balance = tableCashUp.Total - TotalPayments;

            salesPeriodTableCashUps.Add(tableCashUp);
        }
        var distinctUserIds = salesPeriodTableCashUps.Select(cashUp => cashUp.UserId).Distinct();
        foreach (var userId in distinctUserIds)
        {
            UserCashUp u = new();
            u.UserId = userId;
            u.UserTotal += salesPeriodTableCashUps.Where(item => item.UserId! == userId)
                                          .Sum(item => item.Total);
            u.UserBalance += salesPeriodTableCashUps.Where(item => item.UserId! == userId)
                                          .Sum(item => item.Balance);
            u.UserPaymentTotal += salesPeriodTableCashUps.Where(item => item.UserId! == userId)
                                          .Sum(item => item.TablePaymentTotal);
            u.TableCashUps.AddRange(salesPeriodTableCashUps.Where(item => item.UserId! == userId).ToList());

            salesPeriodUserCashUps.Add(u);
        }
        cashUp.UserCashUps.AddRange(salesPeriodUserCashUps);
        cashUp.CashUpBalance += salesPeriodUserCashUps.Sum(item => item.UserBalance);
        cashUp.CashUpTotal += salesPeriodUserCashUps.Sum(item => item.UserTotal);
        cashUp.CashUpTotalPayments += cashUp.UserCashUps.Sum(item => item.UserPaymentTotal);
        cashUp.SalesPeriodId = req.SalesPeriodId;
        cashUp.UserId = req.UserId;
        await SendAsync(cashUp);
    }
}