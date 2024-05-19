using PPTWebApiService.DataAccess.Entities;

namespace PPTWebApiService.DataAccess.Data
{
    public interface IImageRepo
    {
        IEnumerable<Image> GetAllImages();
        Image GetImageById(int id);
        Task<Image> GetImageByIdAsync(int id);
        Task<List<Image>> GetAllImagesAsync();
    }
}