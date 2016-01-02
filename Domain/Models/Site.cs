using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Site
    {
        public Site()
        {
            this.SupportTickets = new List<SupportTicket>();
            this.TrainingSessions = new List<TrainingSession>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Franchise { get; set; }
        public bool HeadQuarters { get; set; }
        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<SupportTicket> SupportTickets { get; set; }
        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}
