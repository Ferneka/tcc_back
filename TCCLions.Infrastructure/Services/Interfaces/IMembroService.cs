using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Infrastructure.Data.Dtos;

namespace TCCLions.Infrastructure.Services.Interfaces
{
    public interface IMembroService
    {
        Task<Guid> Add(MembroDto request);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, MembroDto request);
        Task<List<MembroDto>> GetAll();
        Task<MembroDto> GetById(Guid id);
    }
}