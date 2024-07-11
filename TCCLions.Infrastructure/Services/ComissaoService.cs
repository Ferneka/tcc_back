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
    public class ComissaoService(IComissaoRepository repository) : IComissaoService
    {
        private readonly IComissaoRepository _repository = repository;
        public async Task<Guid> Add(ComissaoDto request)
        {
            var comissao = new Comissao{
                IdTipoComissao = request.IdTipoComissao
            };
            await _repository.Add(comissao);
            return comissao.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _repository.Delete(id);
            if(result) return true;
            return false;
        }

        public async Task<List<ComissaoDto>> GetAll()
        {
            var result = await _repository.GetAll();
            if(result.Count() < 1) return null;
            return result.Select(c => new ComissaoDto{
                Id = c.Id,
                IdTipoComissao = c.IdTipoComissao
            }).ToList();
        }

        public async Task<ComissaoDto> GetById(Guid id)
        {
            var result = await _repository.GetById(id); 
            if(result == null) return null;
            var comissao = new ComissaoDto{
                Id = result.Id,
                IdTipoComissao = result.IdTipoComissao
            };
            return comissao;
        }

        public async Task<bool> Update(Guid id, ComissaoDto request)
        {
            var comissao = new Comissao {
                IdTipoComissao = request.IdTipoComissao
            };
            var result = await _repository.Update(id, comissao);
            if(result) return true;
            return false;
        }
    }
}