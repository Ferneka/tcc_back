using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Infrastructure.Data.Dtos;

namespace TCCLions.Infrastructure.Services.Interfaces
{
    public interface IDespesaService
    {
        Task<Guid> Add(DespesaDto request);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, DespesaDto request);
        Task<List<DespesaDto>> GetAll();
        Task<DespesaDto> GetById(Guid id);
    }
}