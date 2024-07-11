using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCLions.Api.Application;
using TCCLions.Api.Application.Models.ViewModels;
using TCCLions.Domain.Data.Models;
using TCCLions.Infrastructure.Data.Dtos;
using TCCLions.Infrastructure.Services.Interfaces;

namespace TCCLions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembroController(IMembroService service) : ControllerBase
    {
        private readonly IMembroService _service = service;
        [HttpPost]
        public async Task<ActionResult> Add(MembroViewModel request){
            var result = await _service.Add(
                new MembroDto{
                    Nome = request.Nome,
                    Endereco = request.Endereco,
                    Bairro = request.Bairro,
                    Cidade = request.Cidade,
                    Cep = request.Cep,
                    Email = request.Email,
                    EstadoCivil = request.EstadoCivil,
                    CPF = request.CPF
                }
            );
            return Ok(result);
        } 
        [HttpGet]
        public async Task<ActionResult<List<MembroViewModel>>> GetAll(){
            var result = await _service.GetAll();
            if(result.Count() < 1) return NoContent();
            var response = result.Select(m => new MembroViewModel{
                Id = m.Id,
                Nome = m.Nome,
                Endereco = m.Endereco,
                Bairro = m.Bairro,
                Cidade = m.Cidade,
                Cep = m.Cep,
                Email = m.Email,
                EstadoCivil = m.EstadoCivil,
                CPF = m.CPF
            }).ToList();
            return Ok(response);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MembroViewModel>> GetById(Guid id){
            var result = await _service.GetById(id);
            if(result == null) return NotFound();
            var response = new MembroViewModel{
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
            return Ok(response);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id){
            var result = await _service.Delete(id);
            if(!result) return BadRequest();
            return Ok(result);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, MembroViewModel request){
            var result = await _service.Update(id,
                new MembroDto{
                    Nome = request.Nome,
                    Endereco = request.Endereco,
                    Bairro = request.Bairro,
                    Cidade = request.Cidade,
                    Cep = request.Cep,
                    Email = request.Email,
                    EstadoCivil = request.EstadoCivil,
                    CPF = request.CPF
                }
            );
            if(!result) return BadRequest();
            return Ok(result);
        }
    }
}