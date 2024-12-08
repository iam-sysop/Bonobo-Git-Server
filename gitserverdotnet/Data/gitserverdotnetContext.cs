using System.Data.Common;
using gitserverdotnet.Data.Mapping;
using System.Data.Entity;

namespace gitserverdotnet.Data
{
    public partial class gitserverdotnetContext : DbContext
    {
        public DbSet<Repository> Repositories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }


        static gitserverdotnetContext()
        {
            Database.SetInitializer<gitserverdotnetContext>(null);
        }

        public gitserverdotnetContext()
            : base("Name=gitserverdotnetContext")
        {
        }

        // Don't make this public because it confuses Unity
        private gitserverdotnetContext(DbConnection databaseConnection) : base(databaseConnection, false)
        {
        }

        public static gitserverdotnetContext FromDatabase(DbConnection databaseConnection)
        {
            return new gitserverdotnetContext(databaseConnection);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RepositoryMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new TeamMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
