
using PPT_WebApi_Test.Common;
using PPT_WebApi_Test.Facada;
using PPTWebApiService.DataAccess.Data;
using PPTWebApiService.DataAccess.Entities;


namespace PPT_WebApi_Test
{
    [TestClass]
    public  class ImageRepoTest : UnitTestAbstract
    {
        
        private readonly IImageRepo _imageRepo;

        public ImageRepoTest()
        {
            _imageRepo = new ImageRepo(_dbContextMock.Object);
        }

        [TestMethod]
        public void TestGetImageById()
        {
            var data = new List<Image>
            {
                new Image { Id = 1, Url="AAA" },
               new Image { Id = 2, Url="BBB" },
                new Image { Id =3, Url="CCC" }
            }.AsQueryable();

            var mockSet = EntityMocker.SetupMockDbSet(data);

            _dbContextMock.Setup(c => c.Images).Returns(mockSet.Object);

            var expected = _imageRepo.GetImageById(1);

            Assert.IsNotNull(expected);
        }
    }
}
