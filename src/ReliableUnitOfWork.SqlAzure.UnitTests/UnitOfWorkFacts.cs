using Xunit;

namespace ReliableUnitOfWork.SqlAzure.UnitTests
{
    public class UnitOfWorkFacts
    {
        public class Constructor
        {
            [Fact]
            public void ShouldCreateNewInstanceFromUnitDbContext()
            {
                var unitOfWork = new UnitOfWork<TestContext>();
                Assert.NotNull(unitOfWork.DbContext);
            }
        }

        public class Dispose
        {
            [Fact]
            public void ShouldDisposeTheUnitDbContextToo()
            {
                var unitOfWork = new UnitOfWork<TestContext>();

                unitOfWork.Dispose();

                Assert.Null(unitOfWork.DbContext);
            }
        }
    }
}
