using System;
using ReliableUnitOfWork.SqlAzure.Interfaces;

namespace ReliableUnitOfWork.SqlAzure.UnitTests
{
    public class TestContext : UnitDbContext
    {
    }

    public class TestPlayer1 : UnitOfWorkPlayer<TestContext>
    {
        protected override void HandlePlayerJoinedUnit(object sender, EventArgs e)
        {
        }
    }

    public class TestPlayer2 : UnitOfWorkPlayer<TestContext>
    {
        public readonly TestPlayer1 TestPlayer1;

        public TestPlayer2(TestPlayer1 testPlayer1)
        {
            TestPlayer1 = testPlayer1;
        }

        protected override void HandlePlayerJoinedUnit(object sender, EventArgs e)
        {
            TestPlayer1.Join(UnitOfWork);
        }
    }

    public class TestService : DomainService<TestContext>
    {
        private readonly TestPlayer1 player;

        public TestService(IUnitOfWorkFactory<TestContext> unitOfWorkFactory, TestPlayer1 testPlayer1)
            : base(unitOfWorkFactory, testPlayer1)
        {
            player = testPlayer1;
        }

        public bool FirstCall()
        {
            using (var uow = StartNewUnit())
            {
                return uow.UniqueId == player.UnitOfWork.UniqueId;
            }
        }

        public bool AnothertCall()
        {
            using (var uow = StartNewUnit())
            {
                return uow.UniqueId == player.UnitOfWork.UniqueId;
            }
        }
    }
}