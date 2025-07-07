using ETickets.Data;
using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Repositories
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            _context.Categories.Add(category);  // Add new category
            await _context.SaveChangesAsync();  // Save changes to the database
            return category;  // Return the created category
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();  // Fetch all categories
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.Movies)  // Include related movies
                .FirstOrDefaultAsync(c => c.Id == id);  // Fetch category by ID
        }
        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);  // Update existing category
            await _context.SaveChangesAsync();  // Save changes to the database
            return category;  // Return the updated category
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);  // Find category by ID
            if (category != null)
            {
                _context.Categories.Remove(category);  // Remove category
                await _context.SaveChangesAsync();  // Save changes to the database
            }
        }

    }
}
