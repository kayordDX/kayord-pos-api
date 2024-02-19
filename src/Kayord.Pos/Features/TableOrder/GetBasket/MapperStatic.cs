using Kayord.Pos.Entities;
using Riok.Mapperly.Abstractions;

namespace Kayord.Pos.Features.TableOrder.GetBasket;

[Mapper]
public static partial class MapperStatic
{
    public static partial IQueryable<BillOrderItemDTO> ProjectToDto(this IQueryable<OrderItem> q);
}