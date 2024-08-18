using Microsoft.AspNetCore.Mvc;
using ProjectPetShop.Repositories;

public class HomeController : Controller
{
    private readonly IRepository _repository;

    public HomeController(IRepository repository)
    {
        _repository = repository; // Dependency Injection
    }

    public async Task<IActionResult> Index()
    {
        var mostReviewedAnimals = (await _repository.GetMostReviewedAsync()).ToList();
        return View(mostReviewedAnimals);
    }
}
