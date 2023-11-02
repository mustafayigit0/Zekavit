using Microsoft.EntityFrameworkCore;
using Zekavit_MVC.Areas.Identity.Data;
using Zekavit_MVC.Services.Abstract;
using Zekavit_Shared;
using Zekavit_Shared.DTO;
using Zekavit_Shared.Entity;

namespace Zekavit_MVC.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly Zekavit_MVCContext _context;
        
        public ProductService(Zekavit_MVCContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<ProductDTO>> CreateProduct(ProductDTO model)
        {
            ServiceResponse<ProductDTO> _response = new ServiceResponse<ProductDTO>();
            Product _product = new()
            {
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                ProductDescription = model.ProductDescription,
                ProductName = model.ProductName,
            };
            _context.Products.Add(_product);
            if (await _context.SaveChangesAsync()>0)
            {
                _response.Success = true;
                _response.Message = "Product is created";
                return _response;
            }
            else
            {
                _response.Success = false;
                _response.Message = "Product is not created";
                return _response;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            ServiceResponse<bool> _response = new ServiceResponse<bool>();
            if (product != null)
            {
                _context.Products.Remove(product);
                if (await _context.SaveChangesAsync()>0)
                {
                    _response.Success = true;
                    _response.Message = "Product is deleted";
                    return _response;
                }

            }
            _response.Success = false;
            _response.Message = "Operation failed";
            return _response;
        }

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _context.Products.Include(x=>x.Category).Include(x=>x.ProductImages).Include(x=>x.Features).FirstOrDefaultAsync(x=>x.Id == productId);
            ServiceResponse<Product> _response = new ServiceResponse<Product>();
            if (result !=null)
            {
                _response.Data = result;
                return _response;
            }
            _response.Success = false;
            return _response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(int categoryId)
        {
            var result = await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
            ServiceResponse<List<Product>> _response = new ServiceResponse<List<Product>>();
            if (result != null)
            {
                _response.Data = result;
                _response.Success = true;
                _response.Message = "Process is success";
                return _response;
            }
            else
            {
                _response.Success = false;
                _response.Message = "Process is fail";
                return _response;
            }
        }

        public async Task<ServiceResponse<ProductSearchResult>> GetProducts(int page)
        {
            var pageResult = 3f;
            var result = await _context.Products.ToListAsync();
            var pageCount = Math.Ceiling((result).Count / pageResult);
            var products = await _context.Products.Skip((page - 1) * (int)pageResult).Take((int)pageResult).ToListAsync();
            var response = new ServiceResponse<ProductSearchResult>()
            {
                Data = new ProductSearchResult
                {
                    Products = products,
                    CurrentPages = page,
                    Pages = (int)pageResult,
                }
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> ListProduct()
        {
            var result = await _context.Products.ToListAsync();
            ServiceResponse<List<Product>> _response = new ServiceResponse<List<Product>>();
            if (result != null)
            {
                _response.Data = result;
                _response.Success = true;
                _response.Message = "Process is success";
                return _response;
            }
            else
            {
                _response.Success = false;
                _response.Message = "Process is fail";
                return _response;
            }
        }

        public async Task<ServiceResponse<ProductDTO>> UpdateProduct(int productId, ProductDTO product)
        {
            ServiceResponse<ProductDTO> _response = new ServiceResponse<ProductDTO>();
            var _object = await _context.Products.FindAsync(productId);
            if (_object !=null)
            {
                
                _object.ProductDescription = product.ProductDescription;
                _object.ProductName = product.ProductName;
                _object.Price = product.Price;
                _object.CategoryId = product.CategoryId;
                _object.ImageUrl = product.ImageUrl;
                await _context.SaveChangesAsync();
                _response.Success = true;
                _response.Message = "Update process is success";              
                return _response;
            }

            _response.Success = false;
            _response.Message = "Process is fail";
            return _response;
        }
    }
}
