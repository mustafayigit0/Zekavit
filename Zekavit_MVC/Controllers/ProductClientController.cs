using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zekavit_MVC.Areas.Identity.Data;
using Zekavit_MVC.Services.Abstract;

namespace Zekavit_MVC.Controllers
{
    public class ProductClientController : Controller

    {
        private readonly IProductService _productService;
        private readonly Zekavit_MVCContext _context;
        

    
        public ProductClientController(Zekavit_MVCContext context, IProductService productService)
        {
            _productService = productService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productService.ListProduct();
            if (result != null)
            {
                return View(result.Data);
            }
            return View("Error");
        }
        [HttpGet("productById/{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute]int productId)
        {
            var result = await _productService.GetProduct(productId);
           // var resultPro = await _context.Products.Include(x=>x.Category).Include(x=>x.Features).FirstOrDefaultAsync(x=>x.Id == productId);
            if (result.Data != null)
            {
                return View(result.Data);
            }
            return View("Error");
        }


        [HttpGet("GetProducts/{page}")]
        public async Task<IActionResult> GetAll([FromRoute]int page)
        {
            var result = await _productService.GetProducts(page);
            if (result.Data != null) 
            {
                return View(result.Data);
            }
            return View("Error");
        }

        [HttpGet("GetProductsByCategory/{categoryId}")]
        public async Task<IActionResult> GetProductByCategory([FromRoute]int categoryId)
        {
            var result = await _productService.GetProductsByCategory(categoryId);
            if (result.Data != null) 
            {
                return View(result.Data);
            }
            return View("Error");
        }

}
}
