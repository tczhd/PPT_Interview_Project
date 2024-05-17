using PPTWebApiService.Entities;

namespace PPTWebApiService.Data
{
    public interface IImageRepo
    {
        IEnumerable<Image> GetAllImages();
        Image GetImageById(int id);
        Task<Image> GetImageByIdAsync(int id);
    }
}