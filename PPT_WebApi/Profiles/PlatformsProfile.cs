using AutoMapper;
using PPTWebApiService.DataAccess.Entities;
using PPTWebApiService.Facade.Dtos;
using PPTWebApiService.ViewModel;

namespace PPTWebApiService.Profiles
{
    public class PPTWebApiProfile : Profile
    {
        public PPTWebApiProfile()
        {
            CreateMap<Image, ImageModel>();
            CreateMap<ImageModel, ImageViewModel>();
        }
    }
}