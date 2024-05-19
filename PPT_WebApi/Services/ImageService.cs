using PPT_Facade.Handles;
using PPTWebApiService.DataAccess.Data;
using PPTWebApiService.Facade.Dtos;

namespace PPTWebApiService.Services
{
    public class ImageService : IImageService
    {
        private  string _diceBaseUrl;
        private readonly IImageRepo _repository;
        private IConfiguration _config;

        public ImageService(IImageRepo  repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
            _diceBaseUrl = config.GetSection("DICE_BEAR_URL").Value;
        }

        public async Task<ImageModel?> GetImageUrlByUserIdentifier(string userIdentifier)
        {
            var defaultUrl = _diceBaseUrl + "default";
            var imageModel = new ImageModel() { Url = defaultUrl };

            if (string.IsNullOrEmpty(userIdentifier))
                return imageModel;

            var handler = new SixToNineImageHandle(_repository, _config);
            handler.setNextHandler(new OneToFiveImageHandler(_repository, _config))
            .setNextHandler(new VowelmageHandler(_repository, _config))
            .setNextHandler(new NonAlphanumericHandler(_repository, _config));

            var result = await handler.Handler(userIdentifier);

            if (result != null)
            {
                return result;
            }

            return imageModel;
        } 
    }
}
