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

        public async Task<Guid> Add(AtaDto ataDto)
        {
            var ata = new Ata {
                Titulo = ataDto.Titulo,
                Descricao = ataDto.Descricao
            };
            await _repository.Add(ata);
            return ata.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var request = await _repository.Delete(id);
            if(request) return true;
            return false;
        }

        public async Task<List<AtaDto>> GetAll()
        {
            var request = await _repository.GetAll();
            if(request.Count() < 1) return null;
            return request.Select(a => new AtaDto{
                IdAta = a.Id,
                Titulo = a.Titulo,
                Descricao = a.Descricao
            }).ToList(); 
        }

        public async Task<AtaDto> GetById(Guid id)
        {
            var request = await _repository.GetById(id);
            var ata = new AtaDto {
                IdAta = request.Id,
                Titulo = request.Titulo,
                Descricao = request.Descricao
            };
            return ata;
        }
        public async Task<bool> Update(Guid id, AtaDto ataDto)
        {
            var ata = new Ata{
                Titulo = ataDto.Titulo,
                Descricao = ataDto.Descricao
            };
            var request = await _repository.Update(id, ata);
            if(request) return true;
            return false;
        }
    }
}