using Microsoft.EntityFrameworkCore;
using PPTWebApiService.DataAccess.Entities;

namespace PPTWebApiService.DataAccess.Data
{

    public class ImageRepo : IImageRepo
    {
        private readonly AppDbContext _context;

        public ImageRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Image> GetAllImages()
        {
            return _context.Images.ToList();
        }

        public async Task<List<Image>> GetAllImagesAsync()
        {
            return await _context.Images.ToListAsync();   
        }

        public Image GetImageById(int id)
        {
            return _context.Images.FirstOrDefault(p => p.Id == id);
        }

        public async Task< Image> GetImageByIdAsync(int id)
        {
            var data = await _context.Images.FirstOrDefaultAsync(p => p.Id == id);
            return data;
        }
    }
}