using Microsoft.Extensions.Configuration;
using PPTWebApiService.DataAccess.Data;
using PPTWebApiService.Facade.Dtos;

namespace PPT_Facade.Handles
{
    public abstract class ImageAbstrastHandler
    {
        protected  string _diceBaseUrl;
        protected  string _typiCodeUrl;
        protected const int MAX_NUMBER = 5;

        protected readonly IImageRepo _repository;

        public ImageAbstrastHandler(IImageRepo repository, IConfiguration config)
        {
            _repository = repository;
            _diceBaseUrl = config.GetSection("DICE_BEAR_URL").Value;
            _typiCodeUrl = config.GetSection("TYPI_CODE_URL").Value;
        }

    private ImageAbstrastHandler next;

        public ImageAbstrastHandler setNextHandler(ImageAbstrastHandler next)
        {
            this.next = next;
            return next;
        }

        public abstract Task<ImageModel?>? Handler(string userIdenfifier);

        protected async Task<ImageModel?>? handleNext(string userIdenfifier)
        {
            if (next == null)
                return null;

            return await next.Handler(userIdenfifier);

        }
    }
}
