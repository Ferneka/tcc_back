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
    public class DespesaTipoDespesaService(IDespesaTipoDespesaRepository repository) : IDespesaTipoDespesaService
    {
        private readonly IDespesaTipoDespesaRepository _repository = repository;
        public async Task<Guid> Add(DespesaTipoDespesaDto request)
        {
            var despesaTipoDespesa = new DespesaTipoDespesa{
                IdTipoDespesa = request.IdTipoDespesa, 
                IdDespesa = request.IdDespesa,
                Valor = request.Valor
            };
            await _repository.Add(despesaTipoDespesa);
            return despesaTipoDespesa.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _repository.Delete(id);
            if(!result) return false;
            return true;
        }

        public async Task<List<DespesaTipoDespesaDto>> GetAll()
        {
            var result = await _repository.GetAll();
            if(result.Any()) return result.Select(
                d => new DespesaTipoDespesaDto{
                    Id = d.Id,
                    IdTipoDespesa = d.IdTipoDespesa,
                    IdDespesa = d.IdDespesa,
                    Valor = d.Valor
                }).ToList();
                return null;
        }

        public async Task<DespesaTipoDespesaDto> GetById(Guid id)
        {
            var result = await _repository.GetById(id);
            if(result == null) return null;
            var despesaTipoDespesa = new DespesaTipoDespesaDto{
                Id = result.Id,
                IdTipoDespesa = result.IdTipoDespesa,
                IdDespesa = result.IdDespesa,
                Valor = result.Valor
            };
            return despesaTipoDespesa;
        }

        public async Task<bool> Update(Guid id, DespesaTipoDespesaDto request)
        {
            var result = await _repository.Update(id, new DespesaTipoDespesa{
                IdTipoDespesa = request.IdTipoDespesa,
                IdDespesa = request.IdDespesa,
                Valor = request.Valor
            });
            if(!result) return false;
            return true;
        }
    }
}