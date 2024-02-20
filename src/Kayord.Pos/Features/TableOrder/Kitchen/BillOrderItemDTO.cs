using Kayord.Pos.DTO;

namespace Kayord.Pos.Features.TableOrder.Kitchen;
public class BillOrderItemDTO
{
    public int OrderItemId { get; set; }
    public int TableBookingId { get; set; }
    public int TableId { get; set; }
    public TableDTO? Table { get; set; } = default!;
    public TableBookingDTO TableBooking { get; set; } = default!;
    public int MenuItemId { get; set; }
    public BillMenuItemDTO MenuItem { get; set; } = default!;
    public List<OptionDTO>? Options { get; set; }
    public List<ExtraDTO>? Extras { get; set; }
    public int DivisionId { get; set; }
    public string? Note { get; set; }
}