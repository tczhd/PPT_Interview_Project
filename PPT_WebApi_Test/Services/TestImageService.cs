
using PPTWebApiService.Services;

namespace PPT_WebApi_Test.Facada
{
    [TestClass]
    public class TestImageService : UnitTestAbstract
    {
        private const int MAX_NUMBER = 5;

        [DataTestMethod]
        [DataRow("AAAA6")]
        [DataRow("BBBB7")]
        [DataRow("YYYY8")]
        [DataRow("ZZZZ9")]
        public void TestUserIdentiferFromSixToNine(string userIdentifier)
        {
            // Arrange
            var lastCharacter = userIdentifier.Substring(userIdentifier.Length - 1);
            int id = int.Parse(lastCharacter);
            var expectedUrl = $"https://api.dicebear.com/8.x/pixel-art/png?seed={lastCharacter}&size=150";

            var mockImageRepo = GetMockImageRepoById(id);
            var imageHandler = new ImageService(mockImageRepo, GetMockConfiguration());

            // Act
            var result = imageHandler.GetImageUrlByUserIdentifier(userIdentifier).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Url, expectedUrl);
        }

        [DataTestMethod]
        [DataRow("AAAA1")]
        [DataRow("BBBB2")]
        [DataRow("YYYY3")]
        [DataRow("ZZZZ4")]
        [DataRow("ZZZZ5")]
        public void TestUserIdentiferFromOneToFive(string userIdentifier)
        {
            // Arrange
            var lastCharacter = userIdentifier.Substring(userIdentifier.Length - 1);
            int id = int.Parse(lastCharacter);
            var expectedUrl = $"https://api.dicebear.com/8.x/pixel-art/png?seed=db{lastCharacter}&size=150";

            var mockImageRepo = GetMockImageRepoById(id);
            var imageHandler = new ImageService(mockImageRepo, GetMockConfiguration());

            // Act
            var result = imageHandler.GetImageUrlByUserIdentifier(userIdentifier).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Url, expectedUrl);
        }

        [DataTestMethod]
        [DataRow("AAAA")]
        [DataRow("ijiji")]
        [DataRow("kloolk")]
        [DataRow("aeiou")]
        public void TestUserIdentiferWithVowelCharacters(string userIdentifier)
        {
            // Arrange
            var expectedUrl = $"https://api.dicebear.com/8.x/pixel-art/png?size=150&seed=vowel";

            var mockImageRepo = GetMockImageRepoById(0);
            var imageHandler = new ImageService(mockImageRepo, GetMockConfiguration());

            // Act
            var result = imageHandler.GetImageUrlByUserIdentifier(userIdentifier).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Url, expectedUrl);
        }

        [DataTestMethod]
        [DataRow("*()")]
        [DataRow("!$*")]
        public void TestUserIdentiferWithNonAlphanumeric(string userIdentifier)
        {
            var random = new Random();
            int id = random.Next(1, MAX_NUMBER + 1);

            // Arrange
            var expectedUrl = $"https://api.dicebear.com/8.x/pixel-art/png?size=150&seed=";

            var mockImageRepo = GetMockImageRepoById(0);
            var imageHandler = new ImageService(mockImageRepo, GetMockConfiguration());

            // Act
            var result = imageHandler.GetImageUrlByUserIdentifier(userIdentifier).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Url);
            Assert.IsTrue(result.Url.Contains(expectedUrl));
        }

        [DataTestMethod]
        [DataRow("2343jkl")]
        [DataRow("prtd0")]
        public void TestUserIdentiferotherConditions(string userIdentifier)
        {
            // Arrange
            var expectedUrl = $"https://api.dicebear.com/8.x/pixel-art/png?size=150&seed=default";

            var mockImageRepo = GetMockImageRepoById(0);
            var imageHandler = new ImageService(mockImageRepo, GetMockConfiguration());

            // Act
            var result = imageHandler.GetImageUrlByUserIdentifier(userIdentifier).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Url);
            Assert.IsTrue(result.Url.Contains(expectedUrl));
        }


    }
}