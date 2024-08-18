using ProjectPetShop.Models;

namespace ProjectPetShop.Repositories
{
    public interface IRepository
    {
        Task<IEnumerable<Animal>> GetMostReviewedAsync();
        Task<IEnumerable<Animal>> GetAnimalAsync();
        Task InsertAnimalAsync(Animal animal);
        Task InsertCommentAsync(Comment comment);
        Task UpdateAnimalAsync(int id, Animal animal);
        Task DeleteAnimalAsync(int id);
        Task<IEnumerable<Animal>> GetAnimalsByCategoryAsync(int? categoryId);

        // הוספת מתודה לקבלת קטגוריות
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Animal?> GetAnimalByIdAsync(int id);
    }
}
