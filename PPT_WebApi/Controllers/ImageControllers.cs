using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PPTWebApiService.Data;
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

        public ImageController(
            IImageRepo repository,
             IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{userIdentifier}", Name = "GetImageByUserIdentifier")]
        public async  Task<ActionResult<ImageViewModel>> GetImageByUserIdentifier(string userIdentifier)
        {
            var imageHandler = new ImageService(_repository);
            var imageModel = await imageHandler.GetImageUrlByUserIdentifier(userIdentifier);
            return _mapper.Map<ImageViewModel>(imageModel);
        }
    }
}
