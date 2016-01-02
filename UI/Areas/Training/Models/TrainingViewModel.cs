using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.Training.Models
{
    public class TrainingViewModel
    {
        public int Id { get; set; }
        public decimal RatePerHour { get; set; }
        public int TrainingTypeId { get; set; }
        public string TrainingTypeName { get; set; }
    }
    
    //public class TrainingTypeViewModel
    //{
    //    public int Id { get; set; }
    //    public 
    //}
}