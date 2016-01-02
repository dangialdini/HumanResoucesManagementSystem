using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.Development.Models
{
    public class EnhancementRequestViewModel
    {
        public int Id { get; set; }
        public CustomerIdViewModel Customer { get; set; }
        public string Description { get; set; }

        public OutcomeViewModel Outcome { get; set; }
        public int Weight { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
    }

    public class OutcomeViewModel
    {
        public int Id { get; set; }
        public string Result { get; set; }
    }

    public class CustomerIdViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}