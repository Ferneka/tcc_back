using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Domain.Data.Models;
using TCCLions.Infrastructure.Data.Dtos;

namespace TCCLions.Infrastructure.Services.Interfaces
{
    public interface IAtaService
    {
        Task<Guid> Add(AtaDto request);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, AtaDto request);
        Task<List<AtaDto>> GetAll();
        Task<AtaDto> GetById(Guid id);
    }
}