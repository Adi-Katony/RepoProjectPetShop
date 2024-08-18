using ProjectPetShop.Models;
using ProjectPetShop.Repositories;

namespace ProjectPetShop.Tests.FakeRepositories
{
    public class FakeAnimalRepository : IRepository
    {
        private IEnumerable<Animal> _animals;
        private IEnumerable<Comment> _comments;

        public FakeAnimalRepository()
        {
            _animals = new List<Animal>
            {
                new Animal { AnimalId = 1, Name = "Lion", Age = 5, PictureName = "lion.jpg", Description = "King of the jungle", CategoryId = 1 },
                new Animal { AnimalId = 2, Name = "Eagle", Age = 3, PictureName = "eagle.jpg", Description = "A majestic bird", CategoryId = 2 },
                new Animal { AnimalId = 3, Name = "Giraffe", Age = 4, PictureName = "Giraffe.jpg", Description = "Very tall, is colored with yellow and brown.", CategoryId = 1 }
            };

            _comments = new List<Comment>
            {
                new Comment { CommentId = 1, AnimalId = 1, Review = "Amazing animal!" },
                new Comment { CommentId = 2, AnimalId = 2, Review = "Such a majestic bird." },
                new Comment { CommentId = 3, AnimalId = 1, Review = "So scary" },
                new Comment { CommentId = 4, AnimalId = 2, Review = "Sees everything." },
                new Comment { CommentId = 5, AnimalId = 3, Review = "I like it's colors." }
            };
        }
        public Task<IEnumerable<Animal>> GetMostReviewedAsync()
        {
            var mostReviewedAnimals = _animals
                .Select(a => new
                {
                    Animal = a,
                    ReviewCount = _comments.Count(c => c.AnimalId == a.AnimalId)
                })
                .OrderByDescending(a => a.ReviewCount)
                .Take(2)
                .Select(a => a.Animal)
                .ToList();

            return Task.FromResult<IEnumerable<Animal>>(mostReviewedAnimals);
        }

        public Task DeleteAnimalAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Animal>> GetAnimalAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Animal?> GetAnimalByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Animal>> GetAnimalsByCategoryAsync(int? categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task InsertAnimalAsync(Animal animal)
        {
            throw new NotImplementedException();
        }

        public Task InsertCommentAsync(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAnimalAsync(int id, Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
