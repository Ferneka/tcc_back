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
    public class AtaService(IAtaRepository repository) : IAtaService
    {
        private readonly IAtaRepository _repository = repository;

        public async Task<Guid> Add(AtaDto request)
        {
            var ata = new Ata {
                Titulo = request.Titulo,
                Descricao = request.Descricao
            };
            await _repository.Add(ata);
            return ata.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _repository.Delete(id);
            if(result) return true;
            return false;
        }

        public async Task<List<AtaDto>> GetAll()
        {
            var result = await _repository.GetAll();
            if(result.Count() < 1) return null;
            return result.Select(a => new AtaDto{
                IdAta = a.Id,
                Titulo = a.Titulo,
                Descricao = a.Descricao
            }).ToList(); 
        }

        public async Task<AtaDto> GetById(Guid id)
        {
            var result = await _repository.GetById(id);
            var ata = new AtaDto {
                IdAta = result.Id,
                Titulo = result.Titulo,
                Descricao = result.Descricao
            };
            return ata;
        }
        public async Task<bool> Update(Guid id, AtaDto request)
        {
            var ata = new Ata{
                Titulo = request.Titulo,
                Descricao = request.Descricao
            };
            var result = await _repository.Update(id, ata);
            if(result) return true;
            return false;
        }
    }
}