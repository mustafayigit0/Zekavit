using Microsoft.AspNetCore.Mvc;
using Zekavit_MVC.Services.Abstract;
using Zekavit_Shared.DTO;

namespace Zekavit_MVC.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }





        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.ListCategory();
            if (result.Data == null)
            {
                return View(result.Data);
            }
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDTO model)
        {
            var result = await _categoryService.CreateCategory(model);
            if (result.Success == true)
            {
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
