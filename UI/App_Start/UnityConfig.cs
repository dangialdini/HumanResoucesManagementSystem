using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Data.Entity;
using Domain.Models;
using SharpRepository.Repository;
using SharpRepository.EfRepository;
using Services.Repositories.Interfaces;
using Services.Repositories;
using SharpRepository.Repository.Caching;
using Services.Service.Interfaces;
using Services.Service;
using System.Web.Mvc;

namespace UI.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            //Registered DbContext as a Dependency (use HRMSDBContext) 
            container.RegisterType<DbContext, HRMSDBContext>(new PerRequestLifetimeManager(), new InjectionMember[] { });
            //Register 
            //container.RegisterType<AccountController>(new InjectionConstructor());

            #region Address

            container.RegisterType<IRepository<Address>, EfRepository<Address>>(
              new PerRequestLifetimeManager(),
              new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<Address, int>>()));

            container.RegisterType<IAddressRepository, AddressRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<Address, int>>(null)));

            container.RegisterType<IAddressService, AddressService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region Company

            container.RegisterType<IRepository<Company>, EfRepository<Company>>(
              new PerRequestLifetimeManager(),
              new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<Company, int>>()));

            container.RegisterType<ICompanyRepository, CompanyRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<Company, int>>(null)));

            container.RegisterType<ICompanyService, CompanyService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion
            
            #region Customer
            
            container.RegisterType<IRepository<Customer>, EfRepository<Customer>>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<Customer, int>>()));

            container.RegisterType<ICustomerRepository, CustomerRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<Customer, int>>(null)));
                                    
            container.RegisterType<ICustomerService, CustomerService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region Employee

            container.RegisterType<IRepository<Employee>, EfRepository<Employee>>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<Employee, int>>()));

            container.RegisterType<IEmployeeRepository, EmployeeRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<Employee, int>>(null)));

            container.RegisterType<IEmployeeService, EmployeeService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region EnhancementRequest

            container.RegisterType<IRepository<EnhancementRequest>, EfRepository<EnhancementRequest>>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<HRMSDBContext>(), new OptionalParameter<ICachingStrategy<EnhancementRequest, int>>()));

            container.RegisterType<IEnhancementRequestRepository, EnhancementRequestRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<HRMSDBContext>(), new InjectionParameter<ICachingStrategy<EnhancementRequest, int>>(null)));


            container.RegisterType<IRepository<EnhancementRequestOutcome>, EfRepository<EnhancementRequestOutcome>>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<HRMSDBContext>(), new OptionalParameter<ICachingStrategy<EnhancementRequestOutcome, int>>()));

            container.RegisterType<IEnhancementRequestOutcomeRepository, EnhancementRequestOutcomeRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<HRMSDBContext>(), new InjectionParameter<ICachingStrategy<EnhancementRequestOutcome, int>>(null)));

            //container.RegisterType<IEnhancementRequestOutcomeService, EnhancementRequestOutcomeService>(new PerRequestLifetimeManager(), new InjectionMember[] { });
            container.RegisterType<IEnhancementRequestService, EnhancementRequestService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region EmployeeInPosition

            container.RegisterType<IRepository<EmployeeInPosition>, EfRepository<EmployeeInPosition>>(
              new PerRequestLifetimeManager(),
              new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<EmployeeInPosition, int>>()));

            container.RegisterType<IEmployeeInPositionRepository, EmployeeInPositionRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<EmployeeInPosition, int>>(null)));

            container.RegisterType<ISaleLeadService, SaleLeadService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region Office

            container.RegisterType<IRepository<Office>, EfRepository<Office>>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<Office, int>>()));

            container.RegisterType<IOfficeRepository, OfficeRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<Office, int>>(null)));

            #endregion

            #region Position

            container.RegisterType<IRepository<Position>, EfRepository<Position>>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<Position, int>>()));

            container.RegisterType<IPositionRepository, PositionRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<Position, int>>(null)));

            container.RegisterType<IPositionService, PositionService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region Product
            container.RegisterType<IRepository<Product>, EfRepository<Product>>(
              new PerRequestLifetimeManager(),
              new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<Product, int>>()));

            container.RegisterType<IProductRepository, ProductRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<Product, int>>(null)));

            container.RegisterType<ISaleService, SaleService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region Project

            container.RegisterType<IProjectDevelopmentRepository, ProjectDevelopmentRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<Project_Development, int>>()));

            container.RegisterType<IProjectDevelopmentService, ProjectDevelopmentService>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<IProjectDevelopmentRepository>(), new ResolvedParameter<ITaskDevelopmentRepository>()));

            #endregion

            #region Sale

            container.RegisterType<IRepository<Sale>, EfRepository<Sale>>(
              new PerRequestLifetimeManager(),
              new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<Sale, int>>()));

            container.RegisterType<ISaleRepository, SaleRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<Sale, int>>(null)));

            container.RegisterType<ISaleLeadService, SaleLeadService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region SaleLead

            container.RegisterType<IRepository<SaleLead>, EfRepository<SaleLead>>(
              new PerRequestLifetimeManager(),
              new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<SaleLead, int>>()));

            container.RegisterType<ISaleLeadRepository, SaleLeadRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<SaleLead, int>>(null)));

            container.RegisterType<ISaleLeadService, SaleLeadService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region SaleLeadState

            container.RegisterType<IRepository<SaleLeadState>, EfRepository<SaleLeadState>>(
              new PerRequestLifetimeManager(),
              new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<SaleLeadState, int>>()));

            container.RegisterType<ISaleLeadStateRepository, SaleLeadStateRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<SaleLeadState, int>>(null)));

            container.RegisterType<ISaleLeadService, SaleLeadService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region SaleLineItem
            container.RegisterType<IRepository<SaleLineItem>, EfRepository<SaleLineItem>>(
              new PerRequestLifetimeManager(),
              new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<SaleLineItem, int>>()));

            container.RegisterType<ISaleLineItemRepository, SaleLineItemRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<SaleLineItem, int>>(null)));

            container.RegisterType<ISaleService, SaleService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region SalePositionLead

            container.RegisterType<IRepository<SalePositionLead>, EfRepository<SalePositionLead>>(
              new PerRequestLifetimeManager(),
              new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<SalePositionLead, int>>()));

            container.RegisterType<ISalePositionLeadRepository, SalePositionLeadRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<SalePositionLead, int>>(null)));

            container.RegisterType<ISaleLeadService, SaleLeadService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region SalePositionLeadAction

            container.RegisterType<IRepository<SalePositionLeadAction>, EfRepository<SalePositionLeadAction>>(
              new PerRequestLifetimeManager(),
              new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<SalePositionLeadAction, int>>()));

            container.RegisterType<ISalePositionLeadActionRepository, SalePositionLeadActionRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<SalePositionLeadAction, int>>(null)));

            container.RegisterType<ISaleLeadService, SaleLeadService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region Site

            container.RegisterType<IRepository<Site>, EfRepository<Site>>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<Site, int>>(null)));

            container.RegisterType<ISiteRepository, SiteRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<Site, int>>(null)));

            container.RegisterType<ISiteService, SiteService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region Suburb

            container.RegisterType<IRepository<Suburb>, EfRepository<Suburb>>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<Suburb, int>>(null)));

            container.RegisterType<ISuburbRepository, SuburbRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<Suburb, int>>(null)));

            container.RegisterType<IAddressService, AddressService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region SupportStaffShift

            container.RegisterType<IRepository<SupportStaffShift>, EfRepository<SupportStaffShift>>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<SupportStaffShift, int>>()));

            container.RegisterType<ISupportStaffShiftRepository, SupportStaffShiftRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<SupportStaffShift, int>>(null)));

            container.RegisterType<ISupportStaffShiftService, SupportStaffShiftService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region SupportTicket

            container.RegisterType<IRepository<SupportTicket>, EfRepository<SupportTicket>>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<SupportTicket, int>>()));

            container.RegisterType<ISupportTicketRepository, SupportTicketRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<SupportTicket, int>>(null)));

            container.RegisterType<ISupportTicketService, SupportTicketService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region SupportTicketState

            container.RegisterType<IRepository<TicketState>, EfRepository<TicketState>>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<TicketState, int>>()));

            container.RegisterType<ITicketStateRepository, TicketStateRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new InjectionParameter<ICachingStrategy<TicketState, int>>(null)));

            container.RegisterType<ISupportTicketStateService, SupportTicketStateService>(new PerRequestLifetimeManager());

            #endregion

            #region Tasks

            container.RegisterType<ITaskDevelopmentRepository, TaskDevelopmentRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<Task_Development, int>>()));

            #endregion

            #region Training & Training Type



            //Register the Training Repository 
            container.RegisterType<IRepository<Training>, EfRepository<Training>>(
              new PerRequestLifetimeManager(),
              new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<Training, int>>()));

            container.RegisterType<ITrainingRepository, TrainingRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<Training, int>>(null)));


            //Register the TrainingType Repository 
            container.RegisterType<IRepository<TrainingType>, EfRepository<TrainingType>>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<TrainingType, int>>()));

            container.RegisterType<ITrainingTypeRepository, TrainingTypeRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<TrainingType, int>>(null)));


            //Training Service handles operations for Training & TrainingType
            container.RegisterType<ITrainingService, TrainingService>(new PerRequestLifetimeManager(), new InjectionMember[] { });

            #endregion

            #region Training Session

            container.RegisterType<ITrainingSessionRepository, TrainingSessionRepository>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<DbContext>(), new OptionalParameter<ICachingStrategy<TrainingSession, int>>()));

            container.RegisterType<ITrainingSessionService, TrainingSessionService>(
                new PerRequestLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<ITrainingSessionRepository>(), new ResolvedParameter<IEmployeeInPositionRepository>()));

            #endregion

            DependencyResolver.SetResolver(new Microsoft.Practices.Unity.Mvc.UnityDependencyResolver(container)); 
        }
    }
}
