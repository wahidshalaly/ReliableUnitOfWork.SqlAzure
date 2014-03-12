using ReliableUnitOfWork.SqlAzure.Interfaces;
using Xunit;

namespace ReliableUnitOfWork.SqlAzure.UnitTests
{
    public class DomainServiceFacts
    {
        private readonly IUnitOfWorkFactory<TestContext> unitOfWorkFactory = new UnitOfWorkFactory<TestContext>();
        private readonly TestPlayer1 player = new TestPlayer1();

        [Fact]
        public void ShouldCreateUnitOfWorkPerMethodAndJoinPlayersAccordingly()
        {
            var service = new TestService(unitOfWorkFactory, player);

            Assert.True(service.FirstCall());
            Assert.True(service.AnothertCall());
            Assert.True(service.FirstCall());
            Assert.True(service.AnothertCall());
        }
    }
}