using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.Development.Models
{
    public class EnhancementRequestOutcomeViewModel
    {
        public int Id { get; set; }
        public string Result { get; set; }

        public virtual ICollection<EnhancementRequestViewModel> EnhancementRequests { get; set; }
    }
}