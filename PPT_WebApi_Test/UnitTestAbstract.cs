
using Microsoft.Extensions.Configuration;
using Moq;
using PPTWebApiService.DataAccess.Data;
using PPTWebApiService.DataAccess.Entities;


namespace PPT_WebApi_Test.Facada
{

    public class UnitTestAbstract
    {
        protected readonly Mock<AppDbContext> _dbContextMock;

        protected Mock<IImageRepo> mockImageRepro;

        public UnitTestAbstract()
        {
            _dbContextMock = new Mock<AppDbContext>();
            mockImageRepro = new Mock<IImageRepo>();
        }

        protected IImageRepo GetMockImageRepoById(int id)
        {
            var reurnUrl = $"https://api.dicebear.com/8.x/pixel-art/png?seed=db{id}&size=150";
            object value = mockImageRepro.Setup(x => x.GetImageByIdAsync(It.IsAny<int>())).ReturnsAsync(new Image { Url = reurnUrl });

            return mockImageRepro.Object;
        }

        protected IConfiguration GetMockConfiguration()
        {
            var mockDiceBearUrlSection = new Mock<IConfigurationSection>();
            mockDiceBearUrlSection.Setup(x => x.Value).Returns("https://api.dicebear.com/8.x/pixel-art/png?size=150&seed=");

            var mockTypiCodeUrlSection = new Mock<IConfigurationSection>();
            mockTypiCodeUrlSection.Setup(x => x.Value).Returns("https://my-json-server.typicode.com/ck-pacificdev/tech-test/images/");

            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(x => x.GetSection("DICE_BEAR_URL")).Returns(mockDiceBearUrlSection.Object);
            mockConfig.Setup(x => x.GetSection("TYPI_CODE_URL")).Returns(mockTypiCodeUrlSection.Object);

            return mockConfig.Object;
        }
    }
}