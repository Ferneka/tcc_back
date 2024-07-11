using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Infrastructure.Data.Dtos;

namespace TCCLions.Infrastructure.Services.Interfaces
{
    public interface IMembroComissaoService
    {
        Task<Guid> Add(MembroComissaoDto request);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, MembroComissaoDto request);
        Task<List<MembroComissaoDto>> GetAll();
        Task<MembroComissaoDto> GetById(Guid id);
    }
}