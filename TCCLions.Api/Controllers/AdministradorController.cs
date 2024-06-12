using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCCLions.Api.Application;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorRepository _administradorRepository;
        public AdministradorController(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        // [HttpGet]
        // public Task<ActionResult<IEnumerable<AdministradorViewModel>>> GetAll(){
        //     try{
        //         var listAdm = _administradorRepository.GetAll();
        //         var response = new AdministradorViewModel{
        //             Id = listAdm.Id,
        //             AdminLogin = listAdm.
        //         }
        //     }
        // }

    }
}