namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnhancementRequestTimestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnhancementRequest", "Timestamp", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EnhancementRequest", "Timestamp");
        }
    }
}
