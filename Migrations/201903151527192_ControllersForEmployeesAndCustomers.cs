namespace CookieHunterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ControllersForEmployeesAndCustomers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        StandardCategoryId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        PointsWorth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StoreId = c.Int(nullable: false),
                        StandardCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserHasRoleEmail = c.String(),
                        StoreId = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserHasRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Role = c.String(),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserHasSubscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserHasRoleEmail = c.String(),
                        StandardCategoryId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserHasSubscriptions");
            DropTable("dbo.UserHasRoles");
            DropTable("dbo.PurchaseHistories");
            DropTable("dbo.Items");
            DropTable("dbo.Coupons");
        }
    }
}
