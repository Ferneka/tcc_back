using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Infrastructure.Data.Dtos;

namespace TCCLions.Infrastructure.Services.Interfaces
{
    public interface ITipoComissaoService
    {
        Task<Guid> Add(TipoComissaoDto request);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, TipoComissaoDto request);
        Task<TipoComissaoDto> GetById(Guid id);
        Task<List<TipoComissaoDto>> GetAll();

    }
}