
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PPTWebApiService.Data;


namespace PPT_WebApi_Test.Facada
{
    /// <summary>
    /// Provides fundamental structure and setup for unit testing
    /// </summary>
    public class UnitTestAbstract
    {
        protected Mock<IImageRepo> mockImageRepro;

        public UnitTestAbstract()
        {
            mockImageRepro = new Mock<IImageRepo>();
        }
    }
}