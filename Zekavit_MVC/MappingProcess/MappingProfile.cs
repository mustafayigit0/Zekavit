using AutoMapper;
using Zekavit_MVC.Models;
using Zekavit_Shared.DTO;
using Zekavit_Shared.Entity;

namespace Zekavit_MVC.MappingProcess
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Order,OrderDTO>().ReverseMap();
            CreateMap<OrderDTO,OrderCheckoutModel>().ReverseMap();
        }
    }
}
