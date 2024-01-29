namespace Kayord.Pos.Entities;


public class MenuItem
{
    public int MenuItemId { get; set; }
    public Menu Menu { get; set; } 
    public int MenuId { get; set; }
    public string? Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ICollection<Option>? Options { get; set; } 
    public ICollection<Tag>? Tags { get; set; } 
    public ICollection<Extra>? Extras { get; set; } 
    public Kayord.Pos.Common.Enums.Division Division { get; set; }
}
