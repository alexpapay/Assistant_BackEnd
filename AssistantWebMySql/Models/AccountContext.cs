using System.Data.Entity;
using AssistantWebMySql.Models.Accounts;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AssistantWebMySql.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class AccountContext : IdentityDbContext<ApplicationUser>
    {
        public AccountContext() : base("AssistantUsers") { }
        
        public static AccountContext Create()
        {
            return new AccountContext();
        }

        /// <summary>
        /// Some database fixup / model constraints
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Fix asp.net identity 2.0 tables under MySQL
            // Explanations: primary keys can easily get too long for MySQL's 
            // (InnoDB's) stupid 767 bytes limit.
            // With the two following lines we rewrite the generation to keep
            // those columns "short" enough
            modelBuilder.Entity<IdentityRole>()
                .Property(c => c.Name)
                .HasMaxLength(128)
                .IsRequired();

            // We have to declare the table name here, otherwise IdentityUser 
            // will be created
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("AspNetUsers")
                .Property(c => c.UserName)
                .HasMaxLength(128)
                .IsRequired();
            #endregion
        }
    }
}