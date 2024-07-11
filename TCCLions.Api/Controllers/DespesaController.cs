using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCLions.Api.Application;
using TCCLions.Api.Application.Models.ViewModels;
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
        public async Task<ActionResult<List<DespesaViewModel>>> GetAll(){
            var result = await _service.GetAll();
            if(result.Count() < 1) return NoContent(); 
            var response = result.Select(d => new DespesaViewModel{
                Id = d.Id,
                DataVencimento = d.DataVencimento,
                DataRegistro = d.DataRegistro,
                ValorTotal = d.ValorTotal,
                IdMembro = d.IdMembro
            }).ToList();
            return Ok(response);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DespesaViewModel>> GetById(Guid id){
            var result = await _service.GetById(id);
            if(result == null) return NotFound();
            var response = new DespesaViewModel{
                Id = result.Id,
                DataVencimento = result.DataVencimento,
                DataRegistro = result.DataRegistro,
                ValorTotal = result.ValorTotal,
                IdMembro = result.IdMembro
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