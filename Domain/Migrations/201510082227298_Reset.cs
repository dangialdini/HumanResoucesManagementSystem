namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reset : DbMigration
    {
        public override void Up()
        {
        //    CreateTable(
        //        "dbo.Address",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                Street1 = c.String(nullable: false, maxLength: 50),
        //                Street2 = c.String(maxLength: 50),
        //                SuburbId = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Suburb", t => t.SuburbId)
        //        .Index(t => t.SuburbId);
            
        //    CreateTable(
        //        "dbo.Office",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //                CompanyId = c.Int(nullable: false),
        //                Phone = c.String(nullable: false, maxLength: 50),
        //                AddressId = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => new { t.Id, t.CompanyId, t.Phone, t.AddressId })
        //        .ForeignKey("dbo.Address", t => t.AddressId)
        //        .ForeignKey("dbo.Company", t => t.CompanyId)
        //        .Index(t => t.CompanyId)
        //        .Index(t => t.AddressId);
            
        //    CreateTable(
        //        "dbo.Company",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                Name = c.String(nullable: false, maxLength: 50),
        //                ABN = c.String(nullable: false, maxLength: 12),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    CreateTable(
        //        "dbo.Customer",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                CompanyId = c.Int(nullable: false),
        //                Name = c.String(nullable: false, maxLength: 50),
        //                Franchise = c.Boolean(nullable: false),
        //                Phone = c.String(nullable: false, maxLength: 50),
        //                Email = c.String(nullable: false, maxLength: 50),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Company", t => t.CompanyId)
        //        .Index(t => t.CompanyId);
            
        //    CreateTable(
        //        "dbo.Contact",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //                CustomerId = c.Int(nullable: false),
        //                ContactTypeId = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.ContactType", t => t.ContactTypeId)
        //        .ForeignKey("dbo.Customer", t => t.CustomerId)
        //        .ForeignKey("dbo.Person", t => t.Id)
        //        .Index(t => t.Id)
        //        .Index(t => t.CustomerId)
        //        .Index(t => t.ContactTypeId);
            
        //    CreateTable(
        //        "dbo.ContactType",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                Description = c.String(nullable: false, maxLength: 50),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    CreateTable(
        //        "dbo.Person",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                CompanyId = c.Int(nullable: false),
        //                Firstname = c.String(nullable: false, maxLength: 50),
        //                Lastname = c.String(nullable: false, maxLength: 50),
        //                DateOfBirth = c.DateTime(nullable: false),
        //                Phone = c.String(nullable: false, maxLength: 50),
        //                Email = c.String(nullable: false, maxLength: 50),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Company", t => t.CompanyId)
        //        .Index(t => t.CompanyId);
            
        //    CreateTable(
        //        "dbo.EmployeeInPosition",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                EmployeeId = c.Int(nullable: false),
        //                PositionId = c.Int(nullable: false),
        //                Active = c.Boolean(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Employee", t => t.EmployeeId)
        //        .ForeignKey("dbo.Position", t => t.PositionId)
        //        .Index(t => t.EmployeeId)
        //        .Index(t => t.PositionId);
            
        //    CreateTable(
        //        "dbo.Position",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //                Name = c.String(nullable: false, maxLength: 50),
        //                Description = c.String(nullable: false, maxLength: 50),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    CreateTable(
        //        "dbo.State",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                CountryId = c.Int(nullable: false),
        //                Name = c.String(nullable: false, maxLength: 50),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Country", t => t.CountryId)
        //        .Index(t => t.CountryId);
            
        //    CreateTable(
        //        "dbo.Country",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                Name = c.String(nullable: false, maxLength: 50),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    CreateTable(
        //        "dbo.Suburb",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                StateId = c.Int(nullable: false),
        //                Postcode = c.String(nullable: false, maxLength: 5),
        //                Name = c.String(nullable: false, maxLength: 100),
        //                Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                ZoneId = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.State", t => t.StateId)
        //        .ForeignKey("dbo.Zone", t => t.ZoneId)
        //        .Index(t => t.StateId)
        //        .Index(t => t.ZoneId);
            
        //    CreateTable(
        //        "dbo.Zone",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //                Description = c.String(nullable: false, maxLength: 50),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    CreateTable(
        //        "dbo.SupportTicketAssignment",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //                EmployeeId = c.Int(nullable: false),
        //                TicketId = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.EmployeeInPosition", t => t.EmployeeId)
        //        .ForeignKey("dbo.SupportTicket", t => t.TicketId)
        //        .Index(t => t.EmployeeId)
        //        .Index(t => t.TicketId);
            
        //    CreateTable(
        //        "dbo.SupportTicket",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                StateId = c.Int(nullable: false),
        //                SiteId = c.Int(nullable: false),
        //                Priority = c.Int(nullable: false),
        //                Timestamp = c.DateTime(nullable: false),
        //                Description = c.String(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Site", t => t.SiteId)
        //        .ForeignKey("dbo.TicketState", t => t.StateId)
        //        .Index(t => t.StateId)
        //        .Index(t => t.SiteId);
            
        //    CreateTable(
        //        "dbo.Site",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                CustomerId = c.Int(nullable: false),
        //                AddressId = c.Int(nullable: false),
        //                Name = c.String(nullable: false, maxLength: 50),
        //                Phone = c.String(nullable: false, maxLength: 50),
        //                Email = c.String(nullable: false, maxLength: 50),
        //                Franchise = c.Boolean(nullable: false),
        //                HeadQuarters = c.Boolean(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Address", t => t.AddressId)
        //        .ForeignKey("dbo.Customer", t => t.CustomerId)
        //        .Index(t => t.CustomerId)
        //        .Index(t => t.AddressId);
            
        //    CreateTable(
        //        "dbo.TrainingSession",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                SiteId = c.Int(nullable: false),
        //                TrainingId = c.Int(nullable: false),
        //                EmployeeTrainerId = c.Int(),
        //                Start = c.DateTime(nullable: false),
        //                DurationInMinutes = c.Int(nullable: false),
        //                Delivered = c.Boolean(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.EmployeeInTrainingPosition", t => t.EmployeeTrainerId)
        //        .ForeignKey("dbo.Site", t => t.SiteId)
        //        .ForeignKey("dbo.Training", t => t.TrainingId)
        //        .Index(t => t.SiteId)
        //        .Index(t => t.TrainingId)
        //        .Index(t => t.EmployeeTrainerId);
            
        //    CreateTable(
        //        "dbo.Training",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //                TrainingTypeId = c.Int(nullable: false),
        //                RatePerHour = c.Decimal(nullable: false, precision: 18, scale: 2),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.TrainingType", t => t.TrainingTypeId)
        //        .Index(t => t.TrainingTypeId);
            
        //    CreateTable(
        //        "dbo.TrainingType",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //                Name = c.String(nullable: false, maxLength: 50),
        //                Description = c.String(nullable: false),
        //                DurationInMinutes = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    CreateTable(
        //        "dbo.TicketState",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //                Name = c.String(nullable: false, maxLength: 50),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    CreateTable(
        //        "dbo.TicketAssignmentAction",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //                AssignmentId = c.Int(nullable: false),
        //                Notes = c.String(nullable: false),
        //                Timestamp = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.SupportTicketAssignment", t => t.AssignmentId)
        //        .Index(t => t.AssignmentId);
            
        //    CreateTable(
        //        "dbo.Project_Development",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                EnhancementRequestId = c.Int(nullable: false),
        //                ManagerId = c.Int(nullable: false),
        //                Start = c.DateTime(nullable: false),
        //                Finish = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.EmployeeInDevelopmentPosition", t => t.ManagerId)
        //        .ForeignKey("dbo.EnhancementRequest", t => t.EnhancementRequestId)
        //        .Index(t => t.EnhancementRequestId)
        //        .Index(t => t.ManagerId);
            
        //    CreateTable(
        //        "dbo.EnhancementRequest",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                CustomerId = c.Int(nullable: false),
        //                Description = c.String(nullable: false),
        //                Weight = c.Int(nullable: false),
        //                OutcomeId = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Customer", t => t.CustomerId)
        //        .ForeignKey("dbo.EnhancementRequestOutcome", t => t.OutcomeId)
        //        .Index(t => t.CustomerId)
        //        .Index(t => t.OutcomeId);
            
        //    CreateTable(
        //        "dbo.EnhancementRequestOutcome",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //                Result = c.String(nullable: false, maxLength: 50),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    CreateTable(
        //        "dbo.Task_Development",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                ProjectId = c.Int(nullable: false),
        //                DeveloperId = c.Int(nullable: false),
        //                Description = c.String(nullable: false, maxLength: 50),
        //                Start = c.DateTime(nullable: false),
        //                Finish = c.DateTime(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.EmployeeInDevelopmentPosition", t => t.DeveloperId)
        //        .ForeignKey("dbo.Project_Development", t => t.ProjectId)
        //        .Index(t => t.ProjectId)
        //        .Index(t => t.DeveloperId);
            
        //    CreateTable(
        //        "dbo.SalePositionLead",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                EmployeeInSalePostionId = c.Int(nullable: false),
        //                SaleLeadId = c.Int(nullable: false),
        //                FinalisedSale = c.Boolean(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.EmployeeInSalePosition", t => t.EmployeeInSalePostionId)
        //        .ForeignKey("dbo.SaleLead", t => t.SaleLeadId)
        //        .Index(t => t.EmployeeInSalePostionId)
        //        .Index(t => t.SaleLeadId);
            
        //    CreateTable(
        //        "dbo.SaleLead",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                StateId = c.Int(nullable: false),
        //                SaleId = c.Int(nullable: false),
        //                CustomerId = c.Int(nullable: false),
        //                Timestamp = c.DateTime(),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Customer", t => t.CustomerId)
        //        .ForeignKey("dbo.Sale", t => t.SaleId)
        //        .ForeignKey("dbo.SaleLeadState", t => t.StateId)
        //        .Index(t => t.StateId)
        //        .Index(t => t.SaleId)
        //        .Index(t => t.CustomerId);
            
        //    CreateTable(
        //        "dbo.Sale",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                Date = c.DateTime(nullable: false),
        //                OrderNumber = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    CreateTable(
        //        "dbo.SaleLineItem",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                ProductId = c.Int(nullable: false),
        //                SaleId = c.Int(nullable: false),
        //                Qty = c.Int(nullable: false),
        //                Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Product", t => t.ProductId)
        //        .ForeignKey("dbo.Sale", t => t.SaleId)
        //        .Index(t => t.ProductId)
        //        .Index(t => t.SaleId);
            
        //    CreateTable(
        //        "dbo.Product",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                ProductName = c.String(nullable: false, maxLength: 100),
        //                UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
        //                Description = c.String(nullable: false, maxLength: 250),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    CreateTable(
        //        "dbo.SaleLeadState",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //                Name = c.String(nullable: false, maxLength: 50),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    CreateTable(
        //        "dbo.SalePositionLeadAction",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                SalePositionLeadId = c.Int(nullable: false),
        //                Timestamp = c.DateTime(nullable: false),
        //                NextContactDate = c.DateTime(nullable: false),
        //                Notes = c.String(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.SalePositionLead", t => t.SalePositionLeadId)
        //        .Index(t => t.SalePositionLeadId);
            
        //    CreateTable(
        //        "dbo.SupportStaffShift",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                EmployeeInSupportPositionId = c.Int(nullable: false),
        //                StartTime = c.DateTime(nullable: false),
        //                EndTime = c.DateTime(nullable: false),
        //                Description = c.String(),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.EmployeeInSupportPosition", t => t.EmployeeInSupportPositionId)
        //        .Index(t => t.EmployeeInSupportPositionId);
            
        //    CreateTable(
        //        "dbo.PositionInState",
        //        c => new
        //            {
        //                EmployeeInPositionId = c.Int(nullable: false),
        //                StateId = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => new { t.EmployeeInPositionId, t.StateId })
        //        .ForeignKey("dbo.EmployeeInPosition", t => t.EmployeeInPositionId, cascadeDelete: true)
        //        .ForeignKey("dbo.State", t => t.StateId, cascadeDelete: true)
        //        .Index(t => t.EmployeeInPositionId)
        //        .Index(t => t.StateId);
            
        //    CreateTable(
        //        "dbo.Task_Parent",
        //        c => new
        //            {
        //                ParentId = c.Int(nullable: false),
        //                ChildId = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => new { t.ParentId, t.ChildId })
        //        .ForeignKey("dbo.Task_Development", t => t.ParentId)
        //        .ForeignKey("dbo.Task_Development", t => t.ChildId)
        //        .Index(t => t.ParentId)
        //        .Index(t => t.ChildId);
            
        //    CreateTable(
        //        "dbo.EmployeeInSupportPosition",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.EmployeeInPosition", t => t.Id)
        //        .Index(t => t.Id);
            
        //    CreateTable(
        //        "dbo.EmployeeInTrainingPosition",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.EmployeeInPosition", t => t.Id)
        //        .Index(t => t.Id);
            
        //    CreateTable(
        //        "dbo.Employee",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Person", t => t.Id)
        //        .Index(t => t.Id);
            
        //    CreateTable(
        //        "dbo.EmployeeInDevelopmentPosition",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.EmployeeInPosition", t => t.Id)
        //        .Index(t => t.Id);
            
        //    CreateTable(
        //        "dbo.EmployeeInSalePosition",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.EmployeeInPosition", t => t.Id)
        //        .Index(t => t.Id);
            
        //    CreateTable(
        //        "dbo.Position_Development",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Position", t => t.Id)
        //        .Index(t => t.Id);
            
        //    CreateTable(
        //        "dbo.Position_Sales",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Position", t => t.Id)
        //        .Index(t => t.Id);
            
        //    CreateTable(
        //        "dbo.Position_Support",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Position", t => t.Id)
        //        .Index(t => t.Id);
            
        //    CreateTable(
        //        "dbo.Position_Training",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false),
        //            })
        //        .PrimaryKey(t => t.Id)
        //        .ForeignKey("dbo.Position", t => t.Id)
        //        .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Position_Training", "Id", "dbo.Position");
            DropForeignKey("dbo.Position_Support", "Id", "dbo.Position");
            DropForeignKey("dbo.Position_Sales", "Id", "dbo.Position");
            DropForeignKey("dbo.Position_Development", "Id", "dbo.Position");
            DropForeignKey("dbo.EmployeeInSalePosition", "Id", "dbo.EmployeeInPosition");
            DropForeignKey("dbo.EmployeeInDevelopmentPosition", "Id", "dbo.EmployeeInPosition");
            DropForeignKey("dbo.Employee", "Id", "dbo.Person");
            DropForeignKey("dbo.EmployeeInTrainingPosition", "Id", "dbo.EmployeeInPosition");
            DropForeignKey("dbo.EmployeeInSupportPosition", "Id", "dbo.EmployeeInPosition");
            DropForeignKey("dbo.Address", "SuburbId", "dbo.Suburb");
            DropForeignKey("dbo.Office", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Contact", "Id", "dbo.Person");
            DropForeignKey("dbo.SupportStaffShift", "EmployeeInSupportPositionId", "dbo.EmployeeInSupportPosition");
            DropForeignKey("dbo.SalePositionLeadAction", "SalePositionLeadId", "dbo.SalePositionLead");
            DropForeignKey("dbo.SalePositionLead", "SaleLeadId", "dbo.SaleLead");
            DropForeignKey("dbo.SaleLead", "StateId", "dbo.SaleLeadState");
            DropForeignKey("dbo.SaleLead", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.SaleLineItem", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.SaleLineItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.SaleLead", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.SalePositionLead", "EmployeeInSalePostionId", "dbo.EmployeeInSalePosition");
            DropForeignKey("dbo.Task_Parent", "ChildId", "dbo.Task_Development");
            DropForeignKey("dbo.Task_Parent", "ParentId", "dbo.Task_Development");
            DropForeignKey("dbo.Task_Development", "ProjectId", "dbo.Project_Development");
            DropForeignKey("dbo.Task_Development", "DeveloperId", "dbo.EmployeeInDevelopmentPosition");
            DropForeignKey("dbo.Project_Development", "EnhancementRequestId", "dbo.EnhancementRequest");
            DropForeignKey("dbo.EnhancementRequest", "OutcomeId", "dbo.EnhancementRequestOutcome");
            DropForeignKey("dbo.EnhancementRequest", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Project_Development", "ManagerId", "dbo.EmployeeInDevelopmentPosition");
            DropForeignKey("dbo.TicketAssignmentAction", "AssignmentId", "dbo.SupportTicketAssignment");
            DropForeignKey("dbo.SupportTicketAssignment", "TicketId", "dbo.SupportTicket");
            DropForeignKey("dbo.SupportTicket", "StateId", "dbo.TicketState");
            DropForeignKey("dbo.SupportTicket", "SiteId", "dbo.Site");
            DropForeignKey("dbo.TrainingSession", "TrainingId", "dbo.Training");
            DropForeignKey("dbo.Training", "TrainingTypeId", "dbo.TrainingType");
            DropForeignKey("dbo.TrainingSession", "SiteId", "dbo.Site");
            DropForeignKey("dbo.TrainingSession", "EmployeeTrainerId", "dbo.EmployeeInTrainingPosition");
            DropForeignKey("dbo.Site", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Site", "AddressId", "dbo.Address");
            DropForeignKey("dbo.SupportTicketAssignment", "EmployeeId", "dbo.EmployeeInPosition");
            DropForeignKey("dbo.PositionInState", "StateId", "dbo.State");
            DropForeignKey("dbo.PositionInState", "EmployeeInPositionId", "dbo.EmployeeInPosition");
            DropForeignKey("dbo.Suburb", "ZoneId", "dbo.Zone");
            DropForeignKey("dbo.Suburb", "StateId", "dbo.State");
            DropForeignKey("dbo.State", "CountryId", "dbo.Country");
            DropForeignKey("dbo.EmployeeInPosition", "PositionId", "dbo.Position");
            DropForeignKey("dbo.EmployeeInPosition", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Person", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Contact", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Contact", "ContactTypeId", "dbo.ContactType");
            DropForeignKey("dbo.Customer", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Office", "AddressId", "dbo.Address");
            DropIndex("dbo.Position_Training", new[] { "Id" });
            DropIndex("dbo.Position_Support", new[] { "Id" });
            DropIndex("dbo.Position_Sales", new[] { "Id" });
            DropIndex("dbo.Position_Development", new[] { "Id" });
            DropIndex("dbo.EmployeeInSalePosition", new[] { "Id" });
            DropIndex("dbo.EmployeeInDevelopmentPosition", new[] { "Id" });
            DropIndex("dbo.Employee", new[] { "Id" });
            DropIndex("dbo.EmployeeInTrainingPosition", new[] { "Id" });
            DropIndex("dbo.EmployeeInSupportPosition", new[] { "Id" });
            DropIndex("dbo.Task_Parent", new[] { "ChildId" });
            DropIndex("dbo.Task_Parent", new[] { "ParentId" });
            DropIndex("dbo.PositionInState", new[] { "StateId" });
            DropIndex("dbo.PositionInState", new[] { "EmployeeInPositionId" });
            DropIndex("dbo.SupportStaffShift", new[] { "EmployeeInSupportPositionId" });
            DropIndex("dbo.SalePositionLeadAction", new[] { "SalePositionLeadId" });
            DropIndex("dbo.SaleLineItem", new[] { "SaleId" });
            DropIndex("dbo.SaleLineItem", new[] { "ProductId" });
            DropIndex("dbo.SaleLead", new[] { "CustomerId" });
            DropIndex("dbo.SaleLead", new[] { "SaleId" });
            DropIndex("dbo.SaleLead", new[] { "StateId" });
            DropIndex("dbo.SalePositionLead", new[] { "SaleLeadId" });
            DropIndex("dbo.SalePositionLead", new[] { "EmployeeInSalePostionId" });
            DropIndex("dbo.Task_Development", new[] { "DeveloperId" });
            DropIndex("dbo.Task_Development", new[] { "ProjectId" });
            DropIndex("dbo.EnhancementRequest", new[] { "OutcomeId" });
            DropIndex("dbo.EnhancementRequest", new[] { "CustomerId" });
            DropIndex("dbo.Project_Development", new[] { "ManagerId" });
            DropIndex("dbo.Project_Development", new[] { "EnhancementRequestId" });
            DropIndex("dbo.TicketAssignmentAction", new[] { "AssignmentId" });
            DropIndex("dbo.Training", new[] { "TrainingTypeId" });
            DropIndex("dbo.TrainingSession", new[] { "EmployeeTrainerId" });
            DropIndex("dbo.TrainingSession", new[] { "TrainingId" });
            DropIndex("dbo.TrainingSession", new[] { "SiteId" });
            DropIndex("dbo.Site", new[] { "AddressId" });
            DropIndex("dbo.Site", new[] { "CustomerId" });
            DropIndex("dbo.SupportTicket", new[] { "SiteId" });
            DropIndex("dbo.SupportTicket", new[] { "StateId" });
            DropIndex("dbo.SupportTicketAssignment", new[] { "TicketId" });
            DropIndex("dbo.SupportTicketAssignment", new[] { "EmployeeId" });
            DropIndex("dbo.Suburb", new[] { "ZoneId" });
            DropIndex("dbo.Suburb", new[] { "StateId" });
            DropIndex("dbo.State", new[] { "CountryId" });
            DropIndex("dbo.EmployeeInPosition", new[] { "PositionId" });
            DropIndex("dbo.EmployeeInPosition", new[] { "EmployeeId" });
            DropIndex("dbo.Person", new[] { "CompanyId" });
            DropIndex("dbo.Contact", new[] { "ContactTypeId" });
            DropIndex("dbo.Contact", new[] { "CustomerId" });
            DropIndex("dbo.Contact", new[] { "Id" });
            DropIndex("dbo.Customer", new[] { "CompanyId" });
            DropIndex("dbo.Office", new[] { "AddressId" });
            DropIndex("dbo.Office", new[] { "CompanyId" });
            DropIndex("dbo.Address", new[] { "SuburbId" });
            DropTable("dbo.Position_Training");
            DropTable("dbo.Position_Support");
            DropTable("dbo.Position_Sales");
            DropTable("dbo.Position_Development");
            DropTable("dbo.EmployeeInSalePosition");
            DropTable("dbo.EmployeeInDevelopmentPosition");
            DropTable("dbo.Employee");
            DropTable("dbo.EmployeeInTrainingPosition");
            DropTable("dbo.EmployeeInSupportPosition");
            DropTable("dbo.Task_Parent");
            DropTable("dbo.PositionInState");
            DropTable("dbo.SupportStaffShift");
            DropTable("dbo.SalePositionLeadAction");
            DropTable("dbo.SaleLeadState");
            DropTable("dbo.Product");
            DropTable("dbo.SaleLineItem");
            DropTable("dbo.Sale");
            DropTable("dbo.SaleLead");
            DropTable("dbo.SalePositionLead");
            DropTable("dbo.Task_Development");
            DropTable("dbo.EnhancementRequestOutcome");
            DropTable("dbo.EnhancementRequest");
            DropTable("dbo.Project_Development");
            DropTable("dbo.TicketAssignmentAction");
            DropTable("dbo.TicketState");
            DropTable("dbo.TrainingType");
            DropTable("dbo.Training");
            DropTable("dbo.TrainingSession");
            DropTable("dbo.Site");
            DropTable("dbo.SupportTicket");
            DropTable("dbo.SupportTicketAssignment");
            DropTable("dbo.Zone");
            DropTable("dbo.Suburb");
            DropTable("dbo.Country");
            DropTable("dbo.State");
            DropTable("dbo.Position");
            DropTable("dbo.EmployeeInPosition");
            DropTable("dbo.Person");
            DropTable("dbo.ContactType");
            DropTable("dbo.Contact");
            DropTable("dbo.Customer");
            DropTable("dbo.Company");
            DropTable("dbo.Office");
            DropTable("dbo.Address");
        }
    }
}
