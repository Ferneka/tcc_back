using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCLions.Api.Application.Models.ViewModels;
using TCCLions.Domain.Data.Models;
using TCCLions.Infrastructure.Data.Dtos;
using TCCLions.Infrastructure.Services.Interfaces;

namespace TCCLions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembroComissaoController(IMembroComissaoService service) : ControllerBase
    {
        private readonly IMembroComissaoService _service = service;
        [HttpPost]
        public async Task<ActionResult> Add(MembroComissaoViewModel request){
            var result = await _service.Add(
                new MembroComissaoDto{
                    IdMembro = request.IdMembro,
                    IdComissao = request.IdComissao,
                    DataInicio = request.DataInicio,
                    DataFim = request.DataFim
                }
            );
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<MembroComissaoViewModel>>> GetAll(){
            var result = await _service.GetAll();
            if(result.Count() < 1) return NoContent();
            var response = result.Select(mc =>
                new MembroComissaoViewModel{
                    Id = mc.Id,
                    IdMembro = mc.IdMembro,
                    IdComissao = mc.IdComissao,
                    DataInicio = mc.DataInicio,
                    DataFim = mc.DataFim
                }).ToList();
            return Ok(response);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MembroComissaoViewModel>> GetById(Guid id){
            var result = await _service.GetById(id);
            if(result == null) return NotFound();
            var response = new MembroComissaoViewModel{
                Id = result.Id,
                IdMembro = result.IdMembro,
                IdComissao = result.IdComissao,
                DataInicio = result.DataInicio,
                DataFim = result.DataFim
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
        public async Task<ActionResult> Update(Guid id, MembroComissaoViewModel request){
            var result = await _service.Update(id,
                new MembroComissaoDto{
                    IdMembro = request.IdMembro,
                    IdComissao = request.IdComissao,
                    DataInicio = request.DataInicio,
                    DataFim = request.DataFim
            });
            if(!result) return BadRequest();
            return Ok(result);
        }
    }
}