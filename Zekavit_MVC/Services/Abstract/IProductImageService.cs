using Zekavit_Shared.Entity;
using Zekavit_Shared;
using Zekavit_Shared.DTO;

namespace Zekavit_MVC.Services.Abstract
{
    public interface IProductImageService
    {
        Task<ServiceResponse<List<ProductImage>>> CreateMultipleImageProduct(List<ProductImageDTO> model, int productId);
    }
}
