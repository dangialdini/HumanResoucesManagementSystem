namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalePositionLeadActionFurtherChanges : DbMigration
    {
        public override void Up()
        {

            DropForeignKey("dbo.SalePositionLeadAction", "SalePositionLeadId", "dbo.SalePositionLead");
            DropTable("dbo.SalePositionLeadAction");

            CreateTable(
                "dbo.SalePositionLeadAction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalePositionLeadId = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        NextContactDate = c.DateTime(nullable: false),
                        Notes = c.String(nullable: false),
                        EndContact = c.DateTime(nullable: false),
                        IsAllDay = c.Boolean(nullable: false),
                        Frequency = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalePositionLead", t => t.SalePositionLeadId)
                .Index(t => t.SalePositionLeadId);
        }
        
        public override void Down()
        {
        }
    }
}
