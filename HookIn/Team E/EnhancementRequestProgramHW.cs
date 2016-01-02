using Domain.Models;
using Services.Repositories;
using Services.Repositories.Interfaces;
using SharpRepository.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn.Team_E 
    //ROSALINDA 10/08/15
{
    class EnhancementRequestProgramHW
    {
        static void Method2()
        {
            var db = new HRMSDBContext();

            IEnhancementRequestRepository repoEnhancementRequest = 
                new EnhancementRequestRepository(db);

            var specification = new Specification<EnhancementRequest>(e => e.Id == 1);
            specification.FetchStrategy.Include(e => e.Customer)
                .Include(e => e.Customer)
                .Include(e=> e.Description)
                .Include(e=> e.EnhanceRequestOutcome);
            var EnhancementRequest = repoEnhancementRequest.Find(specification);

            EnhancementRequest E1; 
            if(repoEnhancementRequest.TryFind<EnhancementRequest>(specification, e=> e, out E1))
            {

            }


        }
        

    }
}
