using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCLions.Api.Application;
using TCCLions.Infrastructure.Data.Dtos;
using TCCLions.Infrastructure.Services;
using TCCLions.Infrastructure.Services.Interfaces;

namespace TCCLions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtaController : ControllerBase
    {
       private readonly IAtaService _ataService;
        public AtaController(IAtaService ataService){
            _ataService = ataService;
        }
        [HttpPost]
        public async Task<ActionResult> Add(AtaViewModel request){
            var ataDto = new AtaDto{
                Titulo = request.Titulo,
                Descricao = request.Descricao
            };
            await _ataService.Add(ataDto);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<AtaDto>>> GetAll(){
            var request = await _ataService.GetAll();
            if(request.Count < 0) return NoContent();
            return Ok(request);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AtaDto>> GetById(Guid id){
            var request = await _ataService.GetById(id, ataDto);
            if(request == null) return NotFound();
            return Ok(request);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id){
            var result = await _ataService.Delete(id);
            if(!result) return NotFound();
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update(Guid id, AtaViewModel request){
            var result = await _ataService.Update(id,
                new AtaDto{
                    Titulo = request.Titulo,
                    Descricao = request.Descricao
                }
             );
             if(!result) return BadRequest();
             return Ok(result);
        }

    }
}