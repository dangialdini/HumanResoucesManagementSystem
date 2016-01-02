using Domain.Models;
using System.Data.Entity;
using Services.Repositories;
using System;
using System.Collections.Generic;
using Services.Repositories.Interfaces;
using SharpRepository.Repository.Specifications;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn.Team_E
{
    //class ISupportTicketRepository
    //{
    //    var db = new HRMSDBContext();

    //    public SupportTicket CreateNewTicket(int SiteId, int StateId, string Description, int Priority)
    //    {
    //        ISupportTicketRepository repoSupportTicket = new SupportTicketRepository(db);
    //        var supportTicket = new SupportTicket
    //        { 
    //            SiteId = SiteId,
    //            StateId = StateId,
    //            Description = Description, 
    //            Priority = Priority, 
    //            Timestamp = DateTime.Now 
    //        };
    //            repoSupportTicket.Add(supportTicket);

    //        return supportTicket;
    //    }
    
}
