using System.Data.Entity;
using AssistantWebMySql.Models.DbSets;

namespace AssistantWebMySql.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class AssistantContext : DbContext
    {
        public AssistantContext() : base("AssistantDb") { }

        public static AssistantContext Create()
        {
            return new AssistantContext();
        }

        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<MonitoringValue> MonitoringValues { get; set; }
        public DbSet<UserRequest> UserRequests { get; set; }
        public DbSet<Update> Updates { get; set; }
    }
}