using BackEndClass.AppServices;
using BackEndClass.AppServices.Interfaces;
using BackEndClass.Helpers;
using BackEndClass.Models;
using BackEndClass.Models.DTOs;
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
        public ActionResult<IEnumerable<UsuarioDTO>> GetAll()
        {
            var result = _usuarioAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _usuarioAppService.GetById(id));
        }


        [HttpPost]
        public async Task<ActionResult<Response>> Post(UsuarioDTO item)
        {
            return Ok(await _usuarioAppService.PostUsuario(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutUsuario(UsuarioDTO item)
        {
            return Ok(await _usuarioAppService.PutUsuario(item));
        }


        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(UsuarioDTO item)
        {
            return Ok(await _usuarioAppService.DeleteUsuario(item));
        }
    }
}
