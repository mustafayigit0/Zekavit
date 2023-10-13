using Zekavit_Shared;
using Zekavit_Shared.DTO;
using Zekavit_Shared.Entity;

namespace Zekavit_MVC.Services.Abstract
{
    public interface ICategoryService
    {
        Task<ServiceResponse<CategoryDTO>> CreateCategory(CategoryDTO request);
        Task<ServiceResponse<bool>> DeleteCategory(int categoryId);
        Task<ServiceResponse<CategoryDTO>> GetCategory(int categoryId);
        Task<ServiceResponse<CategoryDTO>> UpdateCategory(int categoryId, CategoryDTO categoryDTO);
        Task<ServiceResponse<List<Category>>> ListCategory();
        List<Category> GetCategories();
        Task<Category> GetCategoryByName(string categoryName);
    }
}
