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
    public class TipoComissaoService(ITipoComissaoRepository repository) : ITipoComissaoService
    {
        private readonly ITipoComissaoRepository _repository = repository;
        public async Task<Guid> Add(TipoComissaoDto request)
        {
            var tipoComissao = new TipoComissao{
                Descricao = request.Descricao
            };
            await _repository.Add(tipoComissao);
            return tipoComissao.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _repository.Delete(id);
            if(!result) return false;
            return true; 
        }

        public async Task<List<TipoComissaoDto>> GetAll()
        {
            var result = await _repository.GetAll();
            if(result.Count() < 1) return null;
            return result.Select(t => new TipoComissaoDto{
                IdTipoComissao = t.Id,
                Descricao = t.Descricao
            }).ToList();
        }

        public async Task<TipoComissaoDto> GetById(Guid id)
        {
            var result = await _repository.GetById(id);
            if(result == null) return null;
            var tipoComissao = new TipoComissaoDto{
                IdTipoComissao = result.Id,
                Descricao = result.Descricao
            };
            return tipoComissao;
        }

        public async Task<bool> Update(Guid id, TipoComissaoDto request)
        {
            var tipoComissao = new TipoComissao{
                Descricao = request.Descricao
            };
            var result = await _repository.Update(id, tipoComissao);
            if(!result) return false;
            return true;           
        }
    }
}