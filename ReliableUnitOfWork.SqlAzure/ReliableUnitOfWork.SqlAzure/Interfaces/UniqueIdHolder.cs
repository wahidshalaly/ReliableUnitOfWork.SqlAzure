using System;

namespace ReliableUnitOfWork.SqlAzure.Interfaces
{
    public abstract class UniqueIdHolder : IUniqueIdHolder
    {
        public long UniqueId { get; private set; }

        protected UniqueIdHolder()
        {
            // careless/lazy unique id :( It's used for debugging only.
            //UniqueId = Guid.NewGuid();
            // not very readable - too long 635288178809934423 (18 digits)
            //UniqueId = DateTime.UtcNow.Ticks;
            // more readable - e.g. 614480106121 (12 digits) at 5pm & at early morning it'll be much shorter.
            UniqueId = DateTime.Now.Subtract(DateTime.Today).Ticks;
        }
    }
}