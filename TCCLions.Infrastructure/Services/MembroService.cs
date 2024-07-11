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
    public class MembroService(IMembroRepository repository) : IMembroService
    {
        private readonly IMembroRepository _repository = repository;

        public async Task<Guid> Add(MembroDto request)
        {
            var membro = new Membro{
                Nome = request.Nome,
                Endereco = request.Endereco,
                Bairro = request.Bairro,
                Cidade = request.Cidade,
                Cep = request.Cep,
                Email = request.Email,
                EstadoCivil = request.EstadoCivil,
                CPF = request.CPF
            };
            await _repository.Add(membro);
            return membro.Id;
        }
        public async Task<bool> Delete(Guid id)
        {
            var result = await _repository.Delete(id);
            if(!result) return false;
            return true;
        }

        public async Task<List<MembroDto>> GetAll()
        {
            var result = await  _repository.GetAll();
            if(result.Any()) return result.Select(m => new MembroDto{
                Id = m.Id,
                Nome= m.Nome,
                Endereco = m.Endereco,
                Bairro = m.Bairro,
                Cidade = m.Cidade,
                Cep = m.Cep,
                Email = m.Email,
                EstadoCivil = m.EstadoCivil,
                CPF = m.CPF}).ToList();
           else
            return null;
        }

        public async Task<MembroDto> GetById(Guid id)
        {
           var result = await _repository.GetById(id);
           if(result == null) return null;
           var membro = new MembroDto{
             Id = result.Id,
             Nome = result.Nome,
             Endereco = result.Endereco,
             Bairro = result.Bairro,
             Cidade = result.Cidade,
             Cep = result.Cep,
             Email = result.Email,
             EstadoCivil = result.EstadoCivil,
             CPF = result.CPF
           };
           return membro;
        }

        public async Task<bool> Update(Guid id, MembroDto request)
        {
            var membro = new Membro{
                Nome = request.Nome,
                Endereco = request.Endereco,
                Bairro = request.Bairro,
                Cidade = request.Cidade,
                Cep = request.Cep,
                Email = request.Email,
                EstadoCivil = request.EstadoCivil,
                CPF = request.CPF
            };
            var result = await _repository.Update(id, membro);
            if(!result) return false;
            return true;
        }
    }
}