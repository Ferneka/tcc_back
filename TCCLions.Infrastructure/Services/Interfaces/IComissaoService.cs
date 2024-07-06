using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Domain.Data.Models;
using TCCLions.Infrastructure.Data.Dtos;

namespace TCCLions.Infrastructure.Services.Interfaces
{
    public interface IComissaoService
    {
        Task<Guid> Add(ComissaoDto request);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, ComissaoDto request);
        Task<ComissaoDto> GetById(Guid id);
        Task<List<ComissaoDto>> GetAll();
    }
}