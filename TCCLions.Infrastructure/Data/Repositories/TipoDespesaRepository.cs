using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories;

public class TipoDespesaRepository : RepositoryBase<TipoDespesa>, ITipoDespesaRepository
{
       public TipoDespesaRepository(ApplicationDataContext context) : base(context)
       {
        
       }
}