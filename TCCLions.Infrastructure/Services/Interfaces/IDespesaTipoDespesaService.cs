using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Infrastructure.Data.Dtos;

namespace TCCLions.Infrastructure.Services.Interfaces
{
    public interface IDespesaTipoDespesaService
    {
        Task<Guid> Add(DespesaTipoDespesaDto request);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, DespesaTipoDespesaDto request);
        Task<List<DespesaTipoDespesaDto>> GetAll();
        Task<DespesaTipoDespesaDto> GetById(Guid id);
    }
}