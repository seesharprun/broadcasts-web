using System.Data.Entity;

namespace SeeSharpRun.Broadcast.Data
{
    public class BroadcastContext : DbContext
    {
        static BroadcastContext()
        {
            Database.SetInitializer<BroadcastContext>(null);
        }

        public BroadcastContext()
            : base("name=BroadcastDBConnectionString")
        { }

        public DbSet<Models.Broadcast> Broadcasts { get; set; }
    }
}
