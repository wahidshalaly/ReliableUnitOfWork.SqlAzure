using ReliableUnitOfWork.SqlAzure.Interfaces;
using Xunit;

namespace ReliableUnitOfWork.SqlAzure.UnitTests
{
    public class UnitOfWorkFactoryFacts
    {
        public class StartNew_WithoutParameters
        {
            private readonly IUnitOfWorkFactory<TestContext> unitOfWorkFactory = new UnitOfWorkFactory<TestContext>();

            [Fact]
            public void ShouldCreateNewUnitOfWork()
            {
                var unitOfWork = unitOfWorkFactory.StartNew();
                Assert.NotNull(unitOfWork);
                Assert.NotNull(unitOfWork.DbContext);
                Assert.IsType<UnitOfWork<TestContext>>(unitOfWork);
                Assert.IsType<TestContext>(unitOfWork.DbContext);
            }
        }

        public class StartNew_WithPlayerHasNoDependencies
        {
            private readonly IUnitOfWorkFactory<TestContext> unitOfWorkFactory = new UnitOfWorkFactory<TestContext>();

            [Fact]
            public void ShouldCreateNewUnitOfWork()
            {
                var testPlayer1 = new TestPlayer1();
                var unitOfWork = unitOfWorkFactory.StartNew(testPlayer1);

                Assert.NotNull(unitOfWork);
                Assert.NotNull(unitOfWork.DbContext);
                Assert.IsType<UnitOfWork<TestContext>>(unitOfWork);
                Assert.IsType<TestContext>(unitOfWork.DbContext);
            }

            [Fact]
            public void ShouldJoinPlayerToTheNewUnitOfWork()
            {
                var testPlayer1 = new TestPlayer1();
                var unitOfWork = unitOfWorkFactory.StartNew(testPlayer1);

                Assert.Equal(unitOfWork.UniqueId, testPlayer1.UnitOfWork.UniqueId);
            }
        }

        public class StartNew_WithPlayerHasDependencies
        {
            private readonly IUnitOfWorkFactory<TestContext> unitOfWorkFactory = new UnitOfWorkFactory<TestContext>();

            [Fact]
            public void ShouldCreateNewUnitOfWork()
            {
                var testPlayer1 = new TestPlayer1();
                var unitOfWork = unitOfWorkFactory.StartNew(testPlayer1);

                Assert.NotNull(unitOfWork);
                Assert.NotNull(unitOfWork.DbContext);
                Assert.IsType<UnitOfWork<TestContext>>(unitOfWork);
                Assert.IsType<TestContext>(unitOfWork.DbContext);
            }

            [Fact]
            public void ShouldJoinPlayerAndDependenciesToTheNewUnitOfWork()
            {
                var testPlayer2 = new TestPlayer2(new TestPlayer1());
                var unitOfWork = unitOfWorkFactory.StartNew(testPlayer2);

                Assert.Equal(unitOfWork.UniqueId, testPlayer2.UnitOfWork.UniqueId);
                Assert.Equal(unitOfWork.UniqueId, testPlayer2.TestPlayer1.UnitOfWork.UniqueId);
            }
        }
    }
}