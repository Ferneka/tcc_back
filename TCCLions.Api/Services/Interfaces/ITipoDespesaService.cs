using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Infrastructure.Data.Dtos;

namespace TCCLions.Infrastructure.Services.Interfaces
{
    public interface ITipoDespesaService
    {
        Task<Guid> Add(TipoDespesaDto request);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, TipoDespesaDto request);
        Task<List<TipoDespesaDto>> GetAll();
        Task<TipoDespesaDto> GetById(Guid id);
    }
}