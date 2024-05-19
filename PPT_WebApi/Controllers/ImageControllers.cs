using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PPTWebApiService.DataAccess.Data;
using PPTWebApiService.Services;
using PPTWebApiService.ViewModel;

namespace PPTWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepo _repository;
        private IMapper _mapper;
        private IConfiguration _config;

        public ImageController(
            IImageRepo repository,
             IMapper mapper,
             IConfiguration config
        )
        {
            _repository = repository;
            _mapper = mapper;
            _config = config;
        }

        [HttpGet("{userIdentifier}", Name = "GetImageByUserIdentifier")]
        public async  Task<ActionResult<ImageViewModel>> GetImageByUserIdentifier(string userIdentifier)
        {
            var imageService = new ImageService(_repository, _config);
            var imageModel = await imageService.GetImageUrlByUserIdentifier(userIdentifier);
            return _mapper.Map<ImageViewModel>(imageModel);
        }
    }
}
