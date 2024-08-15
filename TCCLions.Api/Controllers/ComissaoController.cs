using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TCCLions.Api.Application;
using TCCLions.Api.Application.Models.ViewModels;
using TCCLions.Api.Application.Models.ViewModels.Extensions;
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
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> Add(ComissaoViewModel request){
            var comissaoId = await _comissaoService.Add( 
                new ComissaoDto { IdTipoComissao = request.IdTipoComissao }
            );

            return CreatedAtAction("GetAll", new { id = comissaoId }, comissaoId);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ComissaoViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll(){
            var result = await _comissaoService.GetAll();

            if(result is null) 
                return NoContent();

            var response = result.Select(_ => _.ToViewModel());

            return Ok(response);
        }
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ComissaoViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(Guid id){
            var result = await _comissaoService.GetById(id);

            if (result == null) 
                return NotFound();

            var response = result.ToViewModel();

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Delete(Guid id){
            var result = await _comissaoService.Delete(id);
            
            if (result is null) 
                return NotFound();

            if (!result.Value)
                return BadRequest();
            
            return Ok();
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Update(Guid id, ComissaoViewModel request){
            var result = await _comissaoService.Update(id,  
                new ComissaoDto{
                    IdTipoComissao = request.IdTipoComissao
            });

            if (result is null) 
                return NotFound();

            if (!result.Value)
                return BadRequest();

            return Ok();
        }
    }
}