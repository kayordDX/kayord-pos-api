using Kayord.Pos.Data;

namespace Kayord.Pos.Features.Table.Create
{
    public class Endpoint : Endpoint<Request, Pos.Entities.Table>
    {
        private readonly AppDbContext _dbContext;

        public Endpoint(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Post("/table");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            Pos.Entities.Table entity = new Pos.Entities.Table()
            {
                Name = req.Name,
                SectionId = req.SectionId,
                Capacity = req.Capacity
            };
            await _dbContext.Table.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            var result = await _dbContext.Table.FindAsync(entity.TableId);
            if (result == null)
            {
                await SendNotFoundAsync();
                return;
            }

            await SendAsync(result);
        }
    }
}