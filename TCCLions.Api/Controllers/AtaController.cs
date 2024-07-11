using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCLions.Infrastructure.Data.Dtos;
using TCCLions.Infrastructure.Services;
using TCCLions.Infrastructure.Services.Interfaces;
using TCCLions.Api.Application.Models.ViewModels;

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
            var result = await _ataService.Add(
                new AtaDto{
                    Titulo = request.Titulo,
                    Descricao = request.Descricao
            });
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<AtaViewModel>>> GetAll(){
            var result = await _ataService.GetAll();
            if(result.Count < 1) return NoContent();
            var response = new List<AtaViewModel>();
            foreach(var ata in result){
                response.Add(new AtaViewModel{
                    Id = ata.Id,
                    Titulo = ata.Titulo,
                    Descricao = ata.Descricao
                });
            }
            return Ok(response);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AtaViewModel>> GetById(Guid id){
            var result = await _ataService.GetById(id);
            if(result == null) return NotFound();
            var response = new AtaViewModel{
                Id = result.Id,
                Titulo = result.Titulo,
                Descricao = result.Descricao
            };
            return Ok(response);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id){
            var result = await _ataService.Delete(id);
            if(!result) return BadRequest();
            return Ok(result);
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