namespace Kayord.Pos.Entities;

public class Inventory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int StockLocationId { get; set; }
    public StockLocation StockLocation { get; set; } = default!;
    public int UnitId { get; set; }
    public Unit Unit { get; set; } = default!;
    public decimal Threshold { get; set; }
    public decimal Actual { get; set; }
}