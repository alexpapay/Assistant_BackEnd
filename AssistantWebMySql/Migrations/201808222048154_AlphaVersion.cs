using System.Data.Entity.Migrations;

namespace AssistantWebMySql.Migrations
{
    public partial class AlphaVersion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonitoringValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ip = c.String(unicode: false),
                        Type = c.String(unicode: false),
                        ContinentCode = c.String(unicode: false),
                        ContinentName = c.String(unicode: false),
                        CountryCode = c.String(unicode: false),
                        CountryName = c.String(unicode: false),
                        RegionCode = c.String(unicode: false),
                        RegionName = c.String(unicode: false),
                        City = c.String(unicode: false),
                        Zip = c.String(unicode: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        MacAddress = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        EventDateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Updates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Version = c.String(unicode: false),
                        RussianDescription = c.String(unicode: false),
                        EnglishDescription = c.String(unicode: false),
                        DeutschDescription = c.String(unicode: false),
                        ChineseDescription = c.String(unicode: false),
                        DownLoadLink = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Surname = c.String(unicode: false),
                        Company = c.String(unicode: false),
                        Adress = c.String(unicode: false),
                        MacAdress = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRequests");
            DropTable("dbo.Updates");
            DropTable("dbo.MonitoringValues");
        }
    }
}
