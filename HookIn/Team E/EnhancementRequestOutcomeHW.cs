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
    class EnhancementRequestOutcomeHW
    {
        static void Method1()
        {
            var db = new HRMSDBContext();

            IEnhancementRequestOutcomeRepository repoEnhancementRequestOutcome 
                = new EnhancementRequestOutcomeRepository(db);
            var specification = new Specification<EnhancementRequestOutcome>(e => e.Id == 1);
            specification.FetchStrategy.Include(e => e.EnhancementRequests)
                .Include(e => e.Result);
            var enhancementRequestOutcome = repoEnhancementRequestOutcome.Find(specification);

            EnhancementRequestOutcome E1; 
            if(repoEnhancementRequestOutcome.TryFind<EnhancementRequestOutcome>
                (specification, e => e, out E1))
            {

            }


        }
    }
}
