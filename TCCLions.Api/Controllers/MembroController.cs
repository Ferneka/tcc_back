using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCLions.Api.Application;
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
        public async Task<ActionResult<List<MembroDto>>> GetAll(){
            var result = await _service.GetAll();
            if(result.Any()) return Ok(result);
            return NoContent();
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MembroDto>> GetById(Guid id){
            var result = await _service.GetById(id);
            if(result == null) return NotFound();
            return Ok(result);
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