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
    public class TipoComissaoController(ITipoComissaoService tipoComissaoService) : ControllerBase
    {
        private readonly ITipoComissaoService _tipoComissaoService = tipoComissaoService;
        [HttpPost]
        public async Task<ActionResult> Add(TipoComissaoViewModel request){
            var result = await _tipoComissaoService.Add(
                new TipoComissaoDto{
                    Descricao = request.Descricao
            });
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<TipoComissaoViewModel>>> GetAll(){
            var result = await _tipoComissaoService.GetAll();
            if(result.Count() < 1) return NoContent();
            var response = result.Select(tc => new TipoComissaoViewModel{
                Id = tc.Id,
                Descricao = tc.Descricao
            }).ToList();
            return Ok(response);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TipoComissaoViewModel>> GetById(Guid id){
            var result = await _tipoComissaoService.GetById(id);
            if(result == null) return NotFound();
            var response = new TipoComissaoViewModel{
                Id = result.Id,
                Descricao = result.Descricao
            };
            return Ok(response);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id){
            var result = await _tipoComissaoService.Delete(id);
            if(!result) return BadRequest();
            return Ok(result);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, TipoComissaoViewModel request){
            var result = await _tipoComissaoService.Update(id, 
                new TipoComissaoDto{
                    Descricao = request.Descricao
            });
            if(!result) return BadRequest();
            return Ok(result);
        }

    }
}