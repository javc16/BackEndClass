using BackEndClass.AppServices;
using BackEndClass.AppServices.Interfaces;
using BackEndClass.Helpers;
using BackEndClass.Models;
using BackEndClass.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioAppService _tipoUsuarioAppService;

        public TipoUsuarioController(ITipoUsuarioAppService tipoUsuarioAppService)
        {
            _tipoUsuarioAppService = tipoUsuarioAppService;
        }


        [HttpGet]
        public  ActionResult<IEnumerable<TipoUsuarioDTO>> GetAll()
        {
            var result = _tipoUsuarioAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _tipoUsuarioAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(TipoUsuarioDTO item)
        {
            return Ok(await _tipoUsuarioAppService.PostTipoUsuario(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutCiudadano(TipoUsuarioDTO item)
        {
            return Ok(await _tipoUsuarioAppService.PutTipoUsuario(item));
        }

       
        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(TipoUsuarioDTO item)
        {
            return Ok(await _tipoUsuarioAppService.DeleteTipoUsuario(item));
        }

    }
}
