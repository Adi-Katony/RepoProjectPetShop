using Microsoft.AspNetCore.Mvc;
using ProjectPetShop.Models;
using ProjectPetShop.Repositories;

public class AdminController : Controller
{
    private readonly IRepository _repository;

    public AdminController(IRepository repository)
    {
        _repository = repository; // Dependency Injection
    }

    public async Task<IActionResult> Index(int? categoryId)
    {
        var categories = (await _repository.GetCategoriesAsync()).ToList();
        ViewBag.Categories = categories;

        var selectedCategory = categories.FirstOrDefault(c => c.CategoryId == categoryId)?.CategoryName;

        // Check if the categoryId is valid
        if (categoryId.HasValue && selectedCategory == null)
        {
            return RedirectToAction("Index", "Error");
        }

        // Fetch animals based on the categoryId
        var animals = categoryId.HasValue
            ? (await _repository.GetAnimalsByCategoryAsync(categoryId.Value)).ToList()
            : (await _repository.GetAnimalAsync()).ToList();

        ViewBag.SelectedCategoryName = selectedCategory;
        ViewBag.Animals = animals;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Animal animal, IFormFile? pictureName)
    {
        if (ModelState.IsValid)
        {
            // אם נבחרה תמונה חדשה
            if (pictureName != null && pictureName.Length > 0)
            {
                // שמור את התמונה החדשה ושמור את השם שלה ב-PictureName
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureName.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await pictureName.CopyToAsync(stream);
                }

                animal.PictureName = $"Images/{pictureName.FileName}";
            }
            else
            {
                // אם אין תמונה חדשה, שמור את התמונה הישנה
                var existingAnimal = await _repository.GetAnimalByIdAsync(animal.AnimalId);
                if (existingAnimal != null)
                    animal.PictureName = existingAnimal.PictureName;
                
            }

            await _repository.UpdateAnimalAsync(animal.AnimalId, animal);
            return RedirectToAction("Index");
        }
        return RedirectToAction("EditForm", new { Id = animal.AnimalId });
    }

    [HttpGet]
    public async Task<IActionResult> EditForm(int id)
    {
        ViewBag.Categories = (await _repository.GetCategoriesAsync()).ToList();
        var existingAnimal = await _repository.GetAnimalByIdAsync(id);
        if (existingAnimal == null)
        {
            return RedirectToAction("Index", "Error");
        }
        return View(existingAnimal);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAnimalAsync(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> CreateForm()
    {
        ViewBag.Categories = (await _repository.GetCategoriesAsync()).ToList();
        return View(new Animal());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Animal model, IFormFile nameOfPicure)
    {
        if (ModelState.IsValid)
        {
            // טיפול בקובץ אם קיים
            if (nameOfPicure != null && nameOfPicure.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                var filePath = Path.Combine(uploadsFolder, nameOfPicure.FileName);

                // יצירת התיקייה אם אינה קיימת
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // שמירת הקובץ
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await nameOfPicure.CopyToAsync(stream);
                }

                model.PictureName = $"Images/{nameOfPicure.FileName}"; // עדכון המודל עם שם הקובץ
            }

            // הוספת החיה למאגר הנתונים
            await _repository.InsertAnimalAsync(model);
            return RedirectToAction("Index");
        }

        // אם המודל לא תקין, הצג שוב את הטופס עם שגיאות
        ViewBag.Categories = (await _repository.GetCategoriesAsync()).ToList();
        return View("CreateForm");
    }

}
