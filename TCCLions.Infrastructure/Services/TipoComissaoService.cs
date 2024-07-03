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
        public async Task<Guid> Add(TipoComissaoDto tipoComissaoDto)
        {
            var tipoComissao = new TipoComissao{
                Descricao = tipoComissaoDto.Descricao
            };
            await _repository.Add(tipoComissao);
            return tipoComissao.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var request = await _repository.Delete(id);
            if(!request) return false;
            return true; 
        }

        public async Task<List<TipoComissaoDto>> GetAll()
        {
            var request = await _repository.GetAll();
            if(request.Count() < 1) return null;
            return request.Select(t => new TipoComissaoDto{
                IdTipoComissao = t.Id,
                Descricao = t.Descricao
            }).ToList();
        }

        public async Task<TipoComissaoDto> GetById(Guid id)
        {
            var request = await _repository.GetById(id);
            if(request == null) return null;
            var tipoComissao = new TipoComissaoDto{
                IdTipoComissao = request.Id,
                Descricao = request.Descricao
            };
            return tipoComissao;
        }

        public async Task<bool> Update(Guid id, TipoComissaoDto tipoComissaoDto)
        {
            var tipoComissao = new TipoComissao{
                Descricao = tipoComissaoDto.Descricao
            };
            var request = await _repository.Update(id, tipoComissao);
            if(!request) return false;
            return true;           
        }
    }
}