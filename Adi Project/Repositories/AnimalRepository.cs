using Microsoft.EntityFrameworkCore;
using ProjectPetShop.Data;
using ProjectPetShop.Models;

namespace ProjectPetShop.Repositories
{
    public class AnimalRepository : IRepository
    {
        private readonly PetShopContext _context;

        public AnimalRepository(PetShopContext context)
        {
            _context = context;
        }

        public async Task DeleteAnimalAsync(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Animal>> GetAnimalAsync()
        {
            return await _context.Animals.ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetMostReviewedAsync()
        {
            return await _context.Animals
                .OrderByDescending(a => a.Comments!.Count)
                .Take(2)
                .ToListAsync();
        }

        public async Task InsertAnimalAsync(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAnimalAsync(int id, Animal animal)
        {
            var existingAnimal = await _context.Animals.FindAsync(id);
            if (existingAnimal != null)
            {
                existingAnimal.Name = animal.Name;
                existingAnimal.Age = animal.Age;
                existingAnimal.PictureName = animal.PictureName;
                existingAnimal.Description = animal.Description;
                existingAnimal.CategoryId = animal.CategoryId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Animal?> GetAnimalByIdAsync(int id)
        {
            return await _context.Animals
                .FirstOrDefaultAsync(a => a.AnimalId == id);
        }

        public async Task<IEnumerable<Animal>> GetAnimalsByCategoryAsync(int? categoryId)
        {
            return await _context.Animals
                .Where(a => !categoryId.HasValue || a.CategoryId == categoryId.Value)
                .ToListAsync();
        }

        public async Task InsertCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
    }
}
