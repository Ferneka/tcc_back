using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories
{
    public class TipoComissaoRepository : RepositoryBase<TipoComissao>, ITipoComissaoRepository
    {
        public TipoComissaoRepository(ApplicationDataContext context) : base(context)
        {
            
        }
    }
}