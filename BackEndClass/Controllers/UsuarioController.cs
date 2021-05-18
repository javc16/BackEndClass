using BackEndClass.AppServices;
using BackEndClass.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetAll()
        {
            var result = _usuarioAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(long id)
        {
            return Ok(await _usuarioAppService.GetById(id));
        }


        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario item)
        {
            return Ok(await _usuarioAppService.PostUsuario(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> PutUsuario(Usuario item)
        {
            return Ok(await _usuarioAppService.PutUsuario(item));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteById(int id)
        {
            return Ok(await _usuarioAppService.DeleteUsuario(id));
        }
    }
}
