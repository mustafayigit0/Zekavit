using Zekavit_MVC.Areas.Identity.Data;
using Zekavit_MVC.Services.Abstract;
using Zekavit_Shared;
using Zekavit_Shared.DTO;
using Zekavit_Shared.Entity;

namespace Zekavit_MVC.Services.Concrete
{
    public class FeatureService : IFeatureService
    {

        private readonly Zekavit_MVCContext _context;
        private readonly IProductService _productservice;

        public FeatureService(Zekavit_MVCContext context,IProductService productService )
        {
            _productservice = productService;
            _context = context;
        }

        public async Task<ServiceResponse<List<Feature>>> CreateFeatureForProduct(List<FeatureDTO> featureDTO, int productId)
        {
            var result = await _productservice.GetProduct(productId);
            ServiceResponse<List<Feature>> _response = new ServiceResponse<List<Feature>>();
            if (result != null)
            {
                List<Feature> features = new List<Feature>();
                foreach (var item in featureDTO)
                {
                    Feature feature = new Feature();
                    feature.ProductId = item.ProductId;
                    feature.FeatureName = item.FeatureName;
                    features.Add(feature);
                }
                await _context.Features.AddRangeAsync(features);
                if (await _context.SaveChangesAsync() > 0 )
                {
                    _response.Success = true;
                    _response.Message = "Operation Successfull";
                    _response.Data = features;
                    return _response;
                }
            }
            return null;
        }
    }
}
