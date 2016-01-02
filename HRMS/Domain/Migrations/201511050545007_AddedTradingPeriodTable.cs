namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTradingPeriodTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TradingPeriods", newName: "TradingPeriod");
            AddColumn("dbo.SupportStaffShift", "TradingPeriodId", c => c.Int());
            AlterColumn("dbo.TradingPeriod", "Open", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TradingPeriod", "Close", c => c.DateTime(nullable: false));
            CreateIndex("dbo.SupportStaffShift", "TradingPeriodId");
            AddForeignKey("dbo.SupportStaffShift", "TradingPeriodId", "dbo.TradingPeriod", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupportStaffShift", "TradingPeriodId", "dbo.TradingPeriod");
            DropIndex("dbo.SupportStaffShift", new[] { "TradingPeriodId" });
            AlterColumn("dbo.TradingPeriod", "Close", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.TradingPeriod", "Open", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.SupportStaffShift", "TradingPeriodId");
            RenameTable(name: "dbo.TradingPeriod", newName: "TradingPeriods");
        }
    }
}
