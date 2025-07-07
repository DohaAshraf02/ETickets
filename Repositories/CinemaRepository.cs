using ETickets.Data;
using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Repositories
{
    public class CinemaRepository
    {
        private readonly ApplicationDbContext _context;
        public CinemaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cinema>> GetAllCinemasAsync()
        {
            return await _context.Cinemas.ToListAsync();
        }
        public async Task<Cinema> GetCinemaByIdAsync(int id)
        {
            return await _context.Cinemas
                .Include(c => c.Movies)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Cinema> CreateCinemaAsync(Models.Cinema cinema)
        {
            _context.Cinemas.Add(cinema);
            await _context.SaveChangesAsync();
            return cinema;
        }
        public async Task<Cinema> UpdateCinemaAsync(Models.Cinema cinema)
        {
            _context.Cinemas.Update(cinema);
            await _context.SaveChangesAsync();
            return cinema;
        }
        public async Task DeleteCinemaAsync(int id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema != null)
            {
                _context.Cinemas.Remove(cinema);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Cinema>> GetCinemasWithMoviesAsync()
        {
            return await _context.Cinemas
                .Include(c => c.Movies)
                .ToListAsync();
        }
    }
}
