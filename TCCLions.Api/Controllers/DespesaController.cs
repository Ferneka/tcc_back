using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCLions.Api.Application;
using TCCLions.Infrastructure.Data.Dtos;
using TCCLions.Infrastructure.Services.Interfaces;

namespace TCCLions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesaController(IDespesaService service) : ControllerBase
    {
        private readonly IDespesaService _service = service;
        [HttpPost]
        public async Task<ActionResult> Add(DespesaViewModel request){
            var result = await _service.Add(new DespesaDto{
                DataVencimento = request.DataVencimento,
                DataRegistro = request.DataRegistro, 
                ValorTotal = request.ValorTotal,
                IdMembro = request.IdMembro
            });
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<DespesaDto>>> GetAll(){
            var result = await _service.GetAll();
            if(result.Any()) return Ok(result);
            return NoContent();
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DespesaDto>> GetById(Guid id){
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
        public async Task<ActionResult> Update(Guid id, DespesaViewModel request){
            var result = await _service.Update(id, new DespesaDto{
                DataVencimento = request.DataVencimento,
                DataRegistro = request.DataRegistro,
                ValorTotal = request.ValorTotal,
                IdMembro = request.IdMembro
            });
            if(!result) return BadRequest();
            return Ok(result);
        }
    }
}