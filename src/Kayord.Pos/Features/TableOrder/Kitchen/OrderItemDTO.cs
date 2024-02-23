using Humanizer;
using Kayord.Pos.DTO;

namespace Kayord.Pos.Features.TableOrder.Kitchen;
public class OrderItemDTO
{
    public int OrderItemId { get; set; }
    public int TableBookingId { get; set; }
    public MenuItemDTO MenuItem { get; set; } = default!;
    public int DivisionId { get; set; }
    public string? Note { get; set; }
    public DateTime OrderReceived { get; set; } = DateTime.Now;
    public string OrderReceivedFormatted
    {
        get => OrderReceived.Humanize();
    }
    public int OrderItemStatusId { get; set; }
    public List<OrderItemOptionDTO>? OrderItemOptions { get; set; }
    public List<OrderItemExtraDTO>? OrderItemExtras { get; set; }
}