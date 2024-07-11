using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCLions.Api.Application.Models.ViewModels;
using TCCLions.Infrastructure.Data.Dtos;
using TCCLions.Infrastructure.Services.Interfaces;

namespace TCCLions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesaTipoDespesaController(IDespesaTipoDespesaService service) : ControllerBase
    {
        private readonly IDespesaTipoDespesaService _service = service;
        [HttpPost]
        public async Task<ActionResult> Add(DespesaTipoDespesaViewModel request){
            var result = await _service.Add(new DespesaTipoDespesaDto{
                IdDespesa = request.IdDespesa,
                IdTipoDespesa = request.IdTipoDespesa,
                Valor = request.Valor
            });
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<DespesaTipoDespesaViewModel>>> GetAll(){
            var result = await _service.GetAll();
            if(result.Count() < 1 ) return NoContent();
            var response = result.Select(dt => new DespesaTipoDespesaViewModel{
                Id = dt.Id,
                IdDespesa = dt.IdDespesa,
                IdTipoDespesa = dt.IdTipoDespesa,
                Valor = dt.Valor
            });
            return Ok(response);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DespesaTipoDespesaViewModel>> GetById(Guid id){
            var result = await _service.GetById(id);
            if(result == null) return NoContent();
            var response = new DespesaTipoDespesaViewModel{
                Id = result.Id,
                IdDespesa = result.IdDespesa,
                IdTipoDespesa = result.IdTipoDespesa,
                Valor = result.Valor
            };
            return Ok(response);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id){
            var result = await _service.Delete(id);
            if(!result) return BadRequest();
            return Ok();
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, DespesaTipoDespesaViewModel request){
            var result = await _service.Update(id,
                new DespesaTipoDespesaDto{
                    IdDespesa = request.IdDespesa,
                    IdTipoDespesa = request.IdTipoDespesa,
                    Valor = request.Valor
                }
            );
            if(!result) return BadRequest();
            return Ok();
        }
    }
}