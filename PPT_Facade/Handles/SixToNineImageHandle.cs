using Microsoft.Extensions.Configuration;
using PPTWebApiService.DataAccess.Data;
using PPTWebApiService.Facade.Dtos;
using System.Net.Http.Json;

namespace PPT_Facade.Handles
{
    public  class SixToNineImageHandle : ImageAbstrastHandler
    {
        private HttpClient _client;
        public SixToNineImageHandle(IImageRepo repository, IConfiguration config) 
            : base(repository, config) {
            _client = new HttpClient();
        }

        // Check number between 6 - 9
        public async override Task<ImageModel?>? Handler(string userIdentifier)
        {
            if (string.IsNullOrEmpty(userIdentifier))
                return null;

            var lastCharacter = userIdentifier.Substring(userIdentifier.Length - 1);
            if (int.TryParse(lastCharacter, out int number))
            {
                if (number >= 6 && number <= 9)
                {
                    var path = _typiCodeUrl + lastCharacter;
                    var response = await _client.GetAsync(path);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadFromJsonAsync<ImageModel>();
                        if (content != null)
                        {
                            var imageModel = new ImageModel();
                            imageModel.Url = content.Url;
                            return imageModel;
                        }
                    }
                }
            }
            return await handleNext(userIdentifier);
        }
    }
}
