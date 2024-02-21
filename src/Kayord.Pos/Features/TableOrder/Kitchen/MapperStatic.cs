using Riok.Mapperly.Abstractions;

namespace Kayord.Pos.Features.TableOrder.Kitchen;

[Mapper]
public static partial class MapperStatic
{
    public static partial IQueryable<TableBookingDTO> ProjectToDto(this IQueryable<Entities.TableBooking> q);
    public static partial IQueryable<TableDTO> ProjectToDto(this IQueryable<Entities.Table> q);
}