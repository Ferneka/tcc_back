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
    public class DespesaService(IDespesaRepository repository) : IDespesaService
    {
        private readonly IDespesaRepository _repository = repository;

        public async Task<Guid> Add(DespesaDto request)
        {
           var despesa = new Despesa{
             DataVencimento = request.DataVencimento,
             DataRegistro = request.DataRegistro,
             ValorTotal = request.ValorTotal,
             IdMembro = request.IdMembro
           };
           await _repository.Add(despesa);
           return despesa.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
           var result = await _repository.Delete(id);
           if(!result) return false;
           return true;
        }

        public async Task<List<DespesaDto>> GetAll()
        {
           var result = await _repository.GetAll();
           if(result.Any()) return result.Select(d => new DespesaDto{
                Id = d.Id,
                DataVencimento = d.DataVencimento,
                DataRegistro = d.DataRegistro,
                ValorTotal = d.ValorTotal,
                IdMembro = d.IdMembro
           }).ToList();
           return null;
        }

        public async Task<DespesaDto> GetById(Guid id)
        {
            var result = await _repository.GetById(id);
            if(result == null) return null;
            return new DespesaDto{
                Id = result.Id,
                DataVencimento = result.DataVencimento,
                DataRegistro = result.DataRegistro,
                ValorTotal = result.ValorTotal,
                IdMembro = result.IdMembro
            };
        }

        public async Task<bool> Update(Guid id, DespesaDto request)
        {
            var result = await _repository.Update(id, new Despesa{
                DataVencimento = request.DataVencimento,
                DataRegistro = request.DataRegistro,
                ValorTotal = request.ValorTotal,
                IdMembro = request.IdMembro
            });
            if(!result) return false;
            return true;
        }
    }
}