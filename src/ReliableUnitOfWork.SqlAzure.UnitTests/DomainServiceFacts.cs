using ReliableUnitOfWork.SqlAzure.Interfaces;
using Xunit;

namespace ReliableUnitOfWork.SqlAzure.UnitTests
{
    static class DomainServiceFacts
    {
        public class Constructor
        {
            private readonly IUnitOfWorkFactory<TestContext> unitOfWorkFactory = new UnitOfWorkFactory<TestContext>();
            private readonly TestPlayer1 player = new TestPlayer1();

            [Fact]
            public void ShouldCreateUnitOfWorkPerMethodAndJoinPlayersAccordingly()
            {
                var service = new TestService(unitOfWorkFactory, player);

                Assert.True(service.FirstCall());
                Assert.True(service.AnotherCall());
                Assert.True(service.FirstCall());
                Assert.True(service.AnotherCall());
            }
        }
    }
}