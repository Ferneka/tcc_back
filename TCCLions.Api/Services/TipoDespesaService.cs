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
    public class TipoDespesaService(ITipoDespesaRepository repository) : ITipoDespesaService
    {
        private readonly ITipoDespesaRepository _repository = repository;

        public async Task<Guid> Add(TipoDespesaDto request)
        {
            var tipoDespesa = new TipoDespesa{
                Descricao = request.Descricao
            };
            await _repository.Add(tipoDespesa);
            return tipoDespesa.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _repository.Delete(id);
            if(!result) return false;
            return true;
        }

        public async Task<List<TipoDespesaDto>> GetAll()
        {
            var result = await _repository.GetAll();
            if(result.Count() < 1) return null;
            return result.Select(t => new TipoDespesaDto{
                Id = t.Id,
                Descricao = t.Descricao
            }).ToList();
        }

        public async Task<TipoDespesaDto> GetById(Guid id)
        {
            var result =await _repository.GetById(id);
            if(result == null) return null;
            var tipoDespesaDto = new TipoDespesaDto{
                Id = result.Id,
                Descricao = result.Descricao
            };
            return tipoDespesaDto;
        }

        public async Task<bool> Update(Guid id, TipoDespesaDto request)
        {
            var tipoDespesa = new TipoDespesa{
                Descricao = request.Descricao
            };
            var result = await _repository.Update(id, tipoDespesa);
            if(!result) return false;
            return true;
        }
    }
}