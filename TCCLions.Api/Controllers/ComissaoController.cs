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
    public class ComissaoController(IComissaoService comissaoService ) : ControllerBase
    {
        private readonly IComissaoService _comissaoService = comissaoService;
        [HttpPost]
        public async Task<ActionResult> Add(ComissaoViewModel request){
            var result = await _comissaoService.Add( 
                new ComissaoDto{
                    IdTipoComissao = request.IdTipoComissao
            });
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<ComissaoViewModel>>> GetAll(){
            var result = await _comissaoService.GetAll();
            if(result.Count() < 1 ) return NoContent();
            var response = result.Select(c => new ComissaoViewModel{
                 Id = c.Id,
                 IdTipoComissao = c.IdTipoComissao
            }).ToList();
            return Ok(response);
            // foreach(var comissao in result){
            //     response.Add(new ComissaoViewModel{
            //         Id = comissao.IdComissao,
            //         IdTipoComissao = comissao.IdTipoComissao,
            //     });
            // }
            //return Ok(response);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ComissaoViewModel>> GetById(Guid id){
            var result = await _comissaoService.GetById(id);
            if(result == null) return NotFound();
            var response = new ComissaoViewModel{
                Id = result.Id,
                IdTipoComissao = result.IdTipoComissao
            };
            return Ok(response);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id){
            var result = await _comissaoService.Delete(id);
            if(!result) return BadRequest();
            return Ok(result);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, ComissaoViewModel request){
            var result = await _comissaoService.Update(id,  
                new ComissaoDto{
                    IdTipoComissao = request.IdTipoComissao
            });
            if(!result) return BadRequest();
            return Ok();
        }
    }
}