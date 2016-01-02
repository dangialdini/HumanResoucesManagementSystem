namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTradingPeriodMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SupportStaffShift", "TradingPeriod_Id", "dbo.TradingPeriods");
            DropIndex("dbo.SupportStaffShift", new[] { "TradingPeriod_Id" });
            AlterColumn("dbo.TradingPeriods", "Open", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.TradingPeriods", "Close", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.SupportStaffShift", "TradingPeriod_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SupportStaffShift", "TradingPeriod_Id", c => c.Int());
            AlterColumn("dbo.TradingPeriods", "Close", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TradingPeriods", "Open", c => c.DateTime(nullable: false));
            CreateIndex("dbo.SupportStaffShift", "TradingPeriod_Id");
            AddForeignKey("dbo.SupportStaffShift", "TradingPeriod_Id", "dbo.TradingPeriods", "Id");
        }
    }
}
