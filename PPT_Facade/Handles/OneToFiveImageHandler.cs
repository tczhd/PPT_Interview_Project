using Microsoft.Extensions.Configuration;
using PPTWebApiService.DataAccess.Data;
using PPTWebApiService.Facade.Dtos;

namespace PPT_Facade.Handles
{
    public class OneToFiveImageHandler : ImageAbstrastHandler
    {
        private HttpClient _client;

        public OneToFiveImageHandler(IImageRepo repository, IConfiguration config) 
            : base(repository,  config)
        {
            _client = new HttpClient();
        }

        // Check number between 1 - 5
        public async override Task<ImageModel?>? Handler(string userIdentifier)
        {
            if (string.IsNullOrEmpty(userIdentifier))
                return null;

            var lastCharacter = userIdentifier.Substring(userIdentifier.Length - 1);
            if (int.TryParse(lastCharacter, out int number))
            {
                if (number >= 1 && number <= 5)
                {
                    var image = await _repository.GetImageByIdAsync(number);
                    if (image != null)
                    {
                        var imageModel = new ImageModel();
                        imageModel.Url = image.Url;
                        return imageModel;
                    }
                }
            }
            return await handleNext(userIdentifier);
        }
    }
}
