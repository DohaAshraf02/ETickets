using ETickets.Data;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Repositories
{
    public class ActorRepository
    {
        private readonly ApplicationDbContext _context;
        public ActorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Models.Actor>> GetAllActorsAsync()
        {
            return await _context.Actors
                .Include(a => a.ActorMovies)
                    .ThenInclude(am => am.Movie)
                .ToListAsync();
        }
        public async Task<Models.Actor> GetActorByIdAsync(int id)
        {
            return await _context.Actors
                .Include(a => a.ActorMovies)
                    .ThenInclude(am => am.Movie)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<Models.Actor> CreateActorAsync(Models.Actor actor)
        {
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();
            return actor;
        }
        public async Task<Models.Actor> UpdateActorAsync(Models.Actor actor)
        {
            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();
            return actor;
        }
        public async Task DeleteActorAsync(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
                await _context.SaveChangesAsync();
            }
        }


    }
}
