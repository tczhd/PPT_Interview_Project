
using PPTWebApiService.Facade.Dtos;

namespace PPTWebApiService.Services
{
    public interface IImageService
    {
        Task<ImageModel> GetImageUrlByUserIdentifier(string userIdentifier);
    }
}