namespace CookieHunterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGroupBCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupBCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        StandardCategoryId = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        PercentOff = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GroupBCategories");
        }
    }
}
