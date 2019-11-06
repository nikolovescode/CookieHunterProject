namespace CookieHunterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CalculationCoupon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coupons", "LastDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Coupons", "Year");
            DropColumn("dbo.Coupons", "Month");
            DropColumn("dbo.Coupons", "Day");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coupons", "Day", c => c.Int(nullable: false));
            AddColumn("dbo.Coupons", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.Coupons", "Year", c => c.Int(nullable: false));
            DropColumn("dbo.Coupons", "LastDate");
        }
    }
}
