using Microsoft.AspNetCore.Mvc;
using ProjectPetShop.Models;
using ProjectPetShop.Repositories;

public class CatalogController : Controller
{
    private readonly IRepository _repository;

    public CatalogController(IRepository repository)
    {
        _repository = repository; // Dependency Injection
    }
    [HttpGet]
    public async Task<IActionResult> Index(int? categoryId)
    {
        var categories = (await _repository.GetCategoriesAsync()).ToList();
        ViewBag.Categories = categories;
        if (categoryId.HasValue && !categories.Any(c => c.CategoryId == categoryId.Value))
        {
            return RedirectToAction("Index", "Error");
        }

        var selectedCategory = categories.FirstOrDefault(c => c.CategoryId == categoryId)?.CategoryName;
        ViewBag.SelectedCategoryName = selectedCategory;

        var animals = categoryId.HasValue
            ? (await _repository.GetAnimalsByCategoryAsync(categoryId.Value)).ToList()
            : (await _repository.GetAnimalAsync()).ToList();
        ViewBag.Animals = animals;

        return View(animals);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var animal = await _repository.GetAnimalByIdAsync(id);
        if (animal == null)
        {
            return RedirectToAction("Index", "Error");
        }
        return View(animal);
    }

    [HttpPost]
    public async Task<IActionResult> AddComment(int id, string review)
    {
        if (ModelState.IsValid)
        {
            var comment = new Comment
            {
                AnimalId = id,
                Review = review
            };
            await _repository.InsertCommentAsync(comment);
        }
        return RedirectToAction("Details", new { id = id });
    }
}
