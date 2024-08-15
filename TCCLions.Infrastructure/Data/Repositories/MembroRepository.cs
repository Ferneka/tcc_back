using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories
{
    public class MembroRepository : RepositoryBase<Membro>, IMembroRepository
    {
        public MembroRepository(ApplicationDataContext context) : base(context)
        {
            
        }
    }
}