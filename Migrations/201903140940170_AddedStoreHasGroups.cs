namespace CookieHunterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStoreHasGroups : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreHasGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        GroupACategoryId = c.Int(nullable: false),
                        GroupBCategoryId = c.Int(nullable: false),
                        GroupCCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StoreHasGroups");
        }
    }
}
