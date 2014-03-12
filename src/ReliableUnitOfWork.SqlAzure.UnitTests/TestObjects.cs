using System;

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
}