using PPTWebApiService.Dtos;

namespace PPTWebApiService.Services
{
    public interface IImageService
    {
        Task<ImageModel> GetImageUrlByUserIdentifier(string userIdentifier);
    }
}