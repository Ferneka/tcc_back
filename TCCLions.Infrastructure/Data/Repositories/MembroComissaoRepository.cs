using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories
{
    public class MembroComissaoRepository : RepositoryBase<MembroComissao>, IMembroComissaoRepository
    {
        public MembroComissaoRepository(ApplicationDataContext context) : base(context)
        {
            
        }
    }
}