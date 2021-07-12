namespace PrintApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pageforms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bothinfos = c.String(),
                        Name = c.String(),
                        Family = c.String(),
                        Father = c.String(),
                        Job = c.String(),
                        Place = c.String(),
                        Request = c.String(),
                        Reoson = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pageinfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageName = c.String(),
                        FormName = c.String(),
                        OnePagePrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pageinfoes");
            DropTable("dbo.Pageforms");
        }
    }
}
