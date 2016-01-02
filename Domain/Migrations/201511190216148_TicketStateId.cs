namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketStateId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SupportTicket", name: "StateId", newName: "TicketStateId");
            RenameIndex(table: "dbo.SupportTicket", name: "IX_StateId", newName: "IX_TicketStateId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SupportTicket", name: "IX_TicketStateId", newName: "IX_StateId");
            RenameColumn(table: "dbo.SupportTicket", name: "TicketStateId", newName: "StateId");
        }
    }
}
