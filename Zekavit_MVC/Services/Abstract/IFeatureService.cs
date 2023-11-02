using Zekavit_Shared.Entity;
using Zekavit_Shared;
using Zekavit_Shared.DTO;

namespace Zekavit_MVC.Services.Abstract
{
    public interface IFeatureService
    {
        Task<ServiceResponse<List<Feature>>> CreateFeatureForProduct(List<FeatureDTO> featureDTO, int productId);
    }
}
