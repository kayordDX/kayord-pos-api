using Kayord.Pos.Entities;

namespace Kayord.Pos.Features.CashUp.User.Detail;

public class Response
{
    public string UserId { get; set; } = string.Empty;
    public Entities.User User { get; set; } = default!;
    public List<ResponseItem> ResponseItems { get; set; } = default!;

}

public class ResponseItem
{
    public CashUpUserItemType CashUpUserItemType { get; set; } = default!;
    public decimal Value { get; set; }

}

public class PaymentTotal
{
    public int PaymentTypeId { get; set; }
    public PaymentType PaymentType { get; set; } = default!;
    public decimal Total { get; set; }
    public decimal Tip { get; set; }
    public decimal Levy { get; set; }

}

