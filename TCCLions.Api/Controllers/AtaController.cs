using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCLions.Api.Application;
using TCCLions.Infrastructure.Data.Dtos;
using TCCLions.Infrastructure.Services;

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
        public async Task<ActionResult> Add(AtaViewModel ataViewModel){
            var ataDto = new AtaDto{
                Titulo = ataViewModel.Titulo,
                Descricao = ataViewModel.Descricao
            };
            await _ataService.Add(ataDto);
            return Ok();
        }
        [HttpGet]
        public async Task<List<AtaDto>> GetAll(){
            return await _ataService.GetAll();
        }
        [HttpGet("{id:guid}")]
        public async Task<AtaDto> GetById(Guid id){
            return await _ataService.GetById(id);
        }
    }
}