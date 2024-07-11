using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;
using TCCLions.Infrastructure.Data.Dtos;
using TCCLions.Infrastructure.Services.Interfaces;

namespace TCCLions.Infrastructure.Services
{
    public class MembroComissaoService(IMembroComissaoRepository repository) : IMembroComissaoService
    {
        private readonly IMembroComissaoRepository _repository = repository;

        public async Task<Guid> Add(MembroComissaoDto request)
        {
            var membroComissao = new MembroComissao{
                IdMembro = request.IdMembro,
                IdComissao = request.IdComissao,
                DataInicio = request.DataInicio,
                DataFim = request.DataFim
            };
            await _repository.Add(membroComissao);
            return membroComissao.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _repository.Delete(id);
            if(!result) return false;
            return true;
        }

        public async Task<List<MembroComissaoDto>> GetAll()
        {
            var result = await _repository.GetAll();
            if(result.Any()) return result.Select(
                mc => new MembroComissaoDto{
                    Id = mc.Id,
                    IdMembro = mc.IdMembro,
                    IdComissao = mc.IdComissao,
                    DataInicio = mc.DataInicio,
                    DataFim = mc.DataFim
                }).ToList();
            return null;
        }

        public async Task<MembroComissaoDto> GetById(Guid id)
        {
            var result = await _repository.GetById(id);
            if(result == null) return null;
            var membroComissao = new MembroComissaoDto{
                Id = result.Id,
                IdMembro = result.IdMembro,
                IdComissao = result.IdComissao,
                DataInicio = result.DataInicio,
                DataFim = result.DataFim
            };
            return membroComissao;
        }

        public async Task<bool> Update(Guid id, MembroComissaoDto request)
        {
            var result = await _repository.Update(id,
                new MembroComissao{
                    IdMembro = request.IdMembro,
                    IdComissao = request.IdComissao,
                    DataInicio = request.DataInicio,
                    DataFim = request.DataFim
                }
            );
            if(!result) return false;
            return true;
        }
    }
}