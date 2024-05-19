using Microsoft.Extensions.Configuration;
using PPT_WebApi.Utilities;
using PPTWebApiService.DataAccess.Data;
using PPTWebApiService.Facade.Dtos;

namespace PPT_Facade.Handles
{
    public class VowelmageHandler : ImageAbstrastHandler
    {
        public VowelmageHandler(IImageRepo repository, IConfiguration config)
            : base(repository, config) { }

        // Check any character is Vowel
        public async override Task<ImageModel?>? Handler(string userIdentifier)
        {
            if (string.IsNullOrEmpty(userIdentifier))
                return null;


            if (StringHelper.HasVowel(userIdentifier))
            {
                var imageModel = new ImageModel();
                imageModel.Url = _diceBaseUrl + "vowel";
                return imageModel;
            }

            return await handleNext(userIdentifier);
        }

    }
}
