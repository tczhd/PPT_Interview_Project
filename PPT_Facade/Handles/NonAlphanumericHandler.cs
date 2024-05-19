using Microsoft.Extensions.Configuration;
using PPTWebApiService.DataAccess.Data;
using PPTWebApiService.Facade.Dtos;

namespace PPT_Facade.Handles
{
    public class NonAlphanumericHandler: ImageAbstrastHandler
    {
        public NonAlphanumericHandler(IImageRepo repository, IConfiguration config)
            : base(repository,  config) { }

        // Check non-alphanumeric character
        public async override Task<ImageModel?> Handler(string userIdentifier)
        {
            if (string.IsNullOrEmpty(userIdentifier))
                return null;

            if (!userIdentifier.Where(char.IsLetterOrDigit).Any())
            {
                var random = new Random();
                int index = random.Next(1, MAX_NUMBER + 1);

                var imageModel = new ImageModel();
                imageModel.Url = _diceBaseUrl + index;
                return imageModel;
            }

            return await handleNext(userIdentifier);
        }
    }
}
