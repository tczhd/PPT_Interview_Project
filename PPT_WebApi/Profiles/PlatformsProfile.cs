using AutoMapper;
using PPTWebApiService.Dtos;
using PPTWebApiService.Entities;
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