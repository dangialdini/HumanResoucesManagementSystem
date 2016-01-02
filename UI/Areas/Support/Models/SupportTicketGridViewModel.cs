using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo.Mvc.UI;

namespace UI.Areas.Support.Models
{
    public class SupportTicketGridViewModel
    {
        public int Id { get; set; }
        public int TicketStateId { get; set; }
        public int SiteId { get; set; }
        public SiteViewModel Site { get; set; }
        public TicketStateViewModel TicketState { get; set; }
        public int Priority { get; set; }
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }
    }

    public class SiteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TicketStateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}