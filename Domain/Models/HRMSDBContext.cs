using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Domain.Models.Mapping;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Domain.Models
{
    public partial class HRMSDBContext : DbContext
    {
        static HRMSDBContext()
        {
            Database.SetInitializer<HRMSDBContext>(null);
        }

        public HRMSDBContext()
            : base("Name=HRMSDBContext")
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        
        public DbSet<EmployeeInPosition> EmployeeInPostions { get; set; }

  
        public DbSet<EmployeeInSupportPosition> EmployeeInSupportPositions { get; set; }
        public DbSet<EmployeeInTrainingPosition> EmployeeInTrainingPostions { get; set; }
        public DbSet<EnhancementRequest> EnhancementRequests { get; set; }
        public DbSet<EnhancementRequestOutcome> EnhanceRequestOutcomes { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Person> People { get; set; }
        
        public DbSet<Product> Products { get; set; }



        public DbSet<Position> Positions { get; set; }

        //public DbSet<Position_Development> Position_Development { get; set; }
        //public DbSet<Position_Sales> Position_Sales { get; set; }
        //public DbSet<Position_Support> Position_Support { get; set; }
        //public DbSet<Position_Training> Position_Training { get; set; }
        public DbSet<Project_Development> Project_Development { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleLead> SaleLeads { get; set; }
        public DbSet<SaleLeadState> SaleLeadStates { get; set; }
        public DbSet<SalePositionLead> SalePositionLeads { get; set; }
        public DbSet<SalePositionLeadAction> SalePostionLeadActions { get; set; }
        public DbSet<SaleLineItem> SaleLineItems { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Suburb> Suburbs { get; set; }
        public DbSet<SupportStaffShift> SupportStaffShifts { get; set; }
        public DbSet<SupportTicket> SupportTickets { get; set; }
        public DbSet<SupportTicketAssignment> SupportTicketAssignments { get; set; }
        public DbSet<Task_Development> Task_Development { get; set; }
        public DbSet<TicketAssignmentAction> TicketAssignmentActions { get; set; }
        public DbSet<TicketState> TicketStates { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<Zone> Zones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new ContactTypeMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new EmployeeInDevelopmentPositionMap());
            modelBuilder.Configurations.Add(new EmployeeInPositionMap());
            modelBuilder.Configurations.Add(new EmployeeInSalePositionMap());
            modelBuilder.Configurations.Add(new EmployeeInSupportPositionMap());
            modelBuilder.Configurations.Add(new EmployeeInTrainingPositionMap());
            modelBuilder.Configurations.Add(new EnhancementRequestMap());
            modelBuilder.Configurations.Add(new EnhancementRequestOutcomeMap());
            modelBuilder.Configurations.Add(new OfficeMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new PositionMap());
            modelBuilder.Configurations.Add(new Position_DevelopmentMap());
            modelBuilder.Configurations.Add(new Position_SalesMap());
            modelBuilder.Configurations.Add(new Position_SupportMap());
            modelBuilder.Configurations.Add(new Position_TrainingMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new Project_DevelopmentMap());
            modelBuilder.Configurations.Add(new SaleMap());
            modelBuilder.Configurations.Add(new SaleLeadMap());
            modelBuilder.Configurations.Add(new SaleLeadStateMap());
            modelBuilder.Configurations.Add(new SaleLineItemMap());
            modelBuilder.Configurations.Add(new SalePositionLeadMap());
            modelBuilder.Configurations.Add(new SalePositionLeadActionMap());
            modelBuilder.Configurations.Add(new SiteMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new SuburbMap());
            modelBuilder.Configurations.Add(new SupportStaffShiftMap());
            modelBuilder.Configurations.Add(new SupportTicketMap());
            modelBuilder.Configurations.Add(new SupportTicketAssignmentMap());
            modelBuilder.Configurations.Add(new Task_DevelopmentMap());
            modelBuilder.Configurations.Add(new TicketAssignmentActionMap());
            modelBuilder.Configurations.Add(new TicketStateMap());
            modelBuilder.Configurations.Add(new TrainingMap());
            modelBuilder.Configurations.Add(new TrainingSessionMap());
            modelBuilder.Configurations.Add(new TrainingTypeMap());
            modelBuilder.Configurations.Add(new ZoneMap());
        }
    }
}
