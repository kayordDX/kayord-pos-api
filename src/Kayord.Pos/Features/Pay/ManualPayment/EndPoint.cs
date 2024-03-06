using Kayord.Pos.Data;
using Kayord.Pos.Data.Migrations;
using Kayord.Pos.Services;

namespace Kayord.Pos.Features.Pay.ManualPayment
{
    public class Endpoint : Endpoint<Request, Pos.Entities.Payment>
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
            Post("/pay/manual");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            Entities.Payment entity = new();
            var reference =
            entity = new()
            {
                Amount = req.Amount,
                PaymentReference = Guid.NewGuid().ToString(),
                DateReceived = DateTime.UtcNow,
                UserId = _cu.UserId ?? "",
                TableBookingId = req.TableBookingId,
                PaymentTypeId = 2
            };

            await _dbContext.Payment.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
            await SendAsync(entity);
        }
    }
}