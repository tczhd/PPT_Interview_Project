using Microsoft.EntityFrameworkCore;
using Moq;
using System.Data.Entity.Infrastructure;




namespace PPT_WebApi_Test.Common
{
    public class EntityMocker
    {
        public static Mock<DbSet<TEntity>> SetupMockDbSet<TEntity>(IQueryable<TEntity> data, bool isAsync = false) where TEntity : class
        {
            var mockSet = new Mock<DbSet<TEntity>>();
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            return mockSet;
        }
    }
}
