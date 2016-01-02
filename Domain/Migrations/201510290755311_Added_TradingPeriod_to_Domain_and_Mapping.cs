namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Added_TradingPeriod_to_Domain_and_Mapping : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Office");
            CreateTable(
                "dbo.TradingPeriods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfficeId = c.Int(nullable: false),
                        Open = c.Time(nullable: false),
                        Close = c.Time(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Office", t => t.OfficeId)
                .Index(t => t.OfficeId);
            
            AddColumn("dbo.SupportStaffShift", "TradingPeriod_Id", c => c.Int());
            AddPrimaryKey("dbo.Office", "Id");
            CreateIndex("dbo.SupportStaffShift", "TradingPeriod_Id");
            AddForeignKey("dbo.SupportStaffShift", "TradingPeriod_Id", "dbo.TradingPeriods", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupportStaffShift", "TradingPeriod_Id", "dbo.TradingPeriods");
            DropForeignKey("dbo.TradingPeriods", "OfficeId", "dbo.Office");
            DropIndex("dbo.TradingPeriods", new[] { "OfficeId" });
            DropIndex("dbo.SupportStaffShift", new[] { "TradingPeriod_Id" });
            DropPrimaryKey("dbo.Office");
            DropColumn("dbo.SupportStaffShift", "TradingPeriod_Id");
            DropTable("dbo.TradingPeriods");
            AddPrimaryKey("dbo.Office", new[] { "Id", "CompanyId", "Phone", "AddressId" });
        }
    }
}
