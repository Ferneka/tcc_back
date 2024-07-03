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
    public class TipoComissaoController(ITipoComissaoService tipoComissaoService) : ControllerBase
    {
        private readonly ITipoComissaoService _tipoComissaoService = tipoComissaoService;
        [HttpPost]
        public async Task<ActionResult> Add(TipoComissaoViewModel request){
            var tipoComissaoDto = new TipoComissaoDto{
                Descricao = request.Descricao
            };
            var result = await _tipoComissaoService.Add(tipoComissaoDto);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<TipoComissaoDto>>> GetAll(){
            var result = await _tipoComissaoService.GetAll();
            if(result.Count() < 1) return NoContent();
            return Ok(result);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TipoComissaoDto>> GetById(Guid id){
            var result = await _tipoComissaoService.GetById(id);
            if(result == null) return NotFound();
            return Ok(result);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id){
            var result = await _tipoComissaoService.Delete(id);
            if(!result) return BadRequest();
            return Ok(result);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, TipoComissaoViewModel request){
            var tipoComissaoDto = new TipoComissaoDto{
                Descricao = request.Descricao
            };
            var result = await _tipoComissaoService.Update(id, tipoComissaoDto);
            if(!result) return BadRequest();
            return Ok(result);
        }

    }
}