using Domain.Models;
using SharpRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Repositories.Interfaces
{
    public interface IContactTypeRepository : IRepository<ContactType, int>
    {
    }
}
