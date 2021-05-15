using BackEndClass.AppServices;
using BackEndClass.Models;
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
        public  ActionResult<IEnumerable<TipoUsuario>> GetAll()
        {
            var result = _tipoUsuarioAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUsuario>> GetById(long id)
        {
            return Ok(await _tipoUsuarioAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<TipoUsuario>> Post(TipoUsuario item)
        {
            return Ok(await _tipoUsuarioAppService.PostTipoUsuario(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TipoUsuario>> PutCiudadano(TipoUsuario item)
        {
            return Ok(await _tipoUsuarioAppService.PutTipoUsuario(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoUsuario>> DeleteById(int id)
        {
            return Ok(await _tipoUsuarioAppService.DeleteTipoUsuario(id));
        }

    }
}
