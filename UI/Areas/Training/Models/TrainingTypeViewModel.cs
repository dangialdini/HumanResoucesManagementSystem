using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.Training.Models
{
    public class TrainingTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationInMinutes { get; set; }
       
    }
}