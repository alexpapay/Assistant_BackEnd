using System.Data.Entity.Migrations;

namespace AssistantWebMySql.Migrations
{
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Surname = c.String(unicode: false),
                        Company = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        KeyHash = c.String(unicode: false),
                        MacAdress = c.String(unicode: false),
                        RegistrationIp = c.String(unicode: false),
                        RegistrationType = c.String(unicode: false),
                        RegistrationDate = c.DateTime(precision: 0),
                        LicenseFinishDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegisteredUsers");
        }
    }
}
