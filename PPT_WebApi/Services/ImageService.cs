using PPT_WebApi.Utilities;
using PPTWebApiService.Data;
using PPTWebApiService.Dtos;
using PPTWebApiService.ViewModel;

namespace PPTWebApiService.Services
{
    public class ImageService : IImageService
    {
        private const string DICE_BEAR_URL = "https://api.dicebear.com/8.x/pixel-art/png?size=150&seed=";
        private const string TYPI_CODE_URL =
          "https://my-json-server.typicode.com/ck-pacificdev/tech-test/images/";
        private const int MAX_NUMBER = 5;

        private readonly IImageRepo _repository;
        private HttpClient _client;

        public ImageService(IImageRepo repository)
        {
            _repository = repository;
            _client = new HttpClient();
        }
        public async Task<ImageModel> GetImageUrlByUserIdentifier(string userIdentifier)
        {
            var defaultUrl = DICE_BEAR_URL + "default";
            var imageModel = new ImageModel() { Url = defaultUrl };
        
            if (string.IsNullOrEmpty(userIdentifier))
                return imageModel;

            var lastCharacter = userIdentifier.Substring(userIdentifier.Length - 1);
            if (int.TryParse(lastCharacter, out int number))
            {
                // Check number between 6 - 9
                if (number >= 6 && number <= 9)
                {
                    var path = TYPI_CODE_URL + lastCharacter;
                    var response = await _client.GetAsync(path);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadFromJsonAsync<ImageViewModel>();
                        if (content.Result != null) {
                            imageModel.Url = content.Result.Url;
                            return imageModel;
                        }
                    }
                }

                // Check number between 1 - 5
                else if (number >= 1 && number <= 5)
                {
                    var image = await _repository.GetImageByIdAsync(number);
                    if (image != null)
                    {
                        imageModel.Url = image.Url;
                        return imageModel;
                    }
                }
            }

            // Check any character is Vowel
            if (StringHelper.HasVowel(userIdentifier)) {
                imageModel.Url = DICE_BEAR_URL + "vowel";
                return imageModel;
            }

            // Check non-alphanumeric character
            if (!userIdentifier.Where(char.IsLetterOrDigit).Any())
            {
                var random = new Random();
                int index = random.Next(1, MAX_NUMBER + 1);

                imageModel.Url = DICE_BEAR_URL + index;
                return imageModel;
            }


            // return default image
            return imageModel;
        }
    }
}
