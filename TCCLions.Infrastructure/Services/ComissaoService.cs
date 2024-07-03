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
        public async Task<Guid> Add(ComissaoDto comissaoDto)
        {
            var comissao = new Comissao{
                IdTipoComissao = comissaoDto.IdTipoComissao
            };
            await _repository.Add(comissao);
            return comissao.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var request = await _repository.Delete(id);
            if(request) return true;
            return false;
        }

        public async Task<List<ComissaoDto>> GetAll()
        {
            var request = await _repository.GetAll();
            if(request.Count() < 1) return null;
            return request.Select(c => new ComissaoDto{
                IdComissao = c.Id,
                IdTipoComissao = c.IdTipoComissao
            }).ToList();
        }

        public async Task<ComissaoDto> GetById(Guid id)
        {
            var request = await _repository.GetById(id); 
            if(request == null) return null;
            var comissao = new ComissaoDto{
                IdComissao = request.Id,
                IdTipoComissao = request.IdTipoComissao
            };
            return comissao;
        }

        public async Task<bool> Update(Guid id, ComissaoDto comissaoDto)
        {
            var comissao = new Comissao {
                IdTipoComissao = comissaoDto.IdTipoComissao
            };
            var request = await _repository.Update(id, comissao);
            if(request) return true;
            return false;
        }
    }
}