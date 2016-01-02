namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalDbFields_SupportStaffShift : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SupportStaffShift", "Color", c => c.String());
            AddColumn("dbo.SupportStaffShift", "Title", c => c.String());
            AddColumn("dbo.SupportStaffShift", "IsAllDay", c => c.Boolean());
            AddColumn("dbo.SupportStaffShift", "RecurrenceId", c => c.Int());
            AddColumn("dbo.SupportStaffShift", "RecurrenceException", c => c.String());
            AddColumn("dbo.SupportStaffShift", "RecurrenceRule", c => c.String());
            AddColumn("dbo.SupportStaffShift", "StartTimezone", c => c.String());
            AddColumn("dbo.SupportStaffShift", "EndTimezone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SupportStaffShift", "EndTimezone");
            DropColumn("dbo.SupportStaffShift", "StartTimezone");
            DropColumn("dbo.SupportStaffShift", "RecurrenceRule");
            DropColumn("dbo.SupportStaffShift", "RecurrenceException");
            DropColumn("dbo.SupportStaffShift", "RecurrenceId");
            DropColumn("dbo.SupportStaffShift", "IsAllDay");
            DropColumn("dbo.SupportStaffShift", "Title");
            DropColumn("dbo.SupportStaffShift", "Color");
        }
    }
}
