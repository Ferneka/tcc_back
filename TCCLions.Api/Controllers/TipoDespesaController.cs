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
    public class TipoDespesaController(ITipoDespesaService service) : ControllerBase
    {
        private readonly ITipoDespesaService _service = service;
        [HttpPost]
        public async Task<ActionResult> Add(TipoDespesaViewModel request){
            var result = await _service.Add(
                new TipoDespesaDto{
                    Descricao = request.Descricao
            });
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<TipoDespesaViewModel>>> GetAll(){
            var result = await _service.GetAll();
            if(result.Count() < 1) return NoContent(); 
            var response = result.Select(td => new TipoDespesaViewModel{
                Id = td.Id,
                Descricao = td.Descricao
            }).ToList();
            return Ok(response);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TipoDespesaViewModel>> GetById(Guid id){
            var result = await _service.GetById(id);
            if(result == null) return NotFound();
            var response = new TipoDespesaViewModel{
                Id = result.Id,
                Descricao = result.Descricao
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
        public async Task<ActionResult> Update(Guid id, TipoDespesaViewModel request){
            var result = await _service.Update(id, 
                new TipoDespesaDto{
                    Descricao = request.Descricao
            });
            if(!result) return BadRequest();
            return Ok(result);
        }

        
    }
}