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
    public class TipoServicioController : ControllerBase
    {
        private readonly ITipoServicioAppService _tipoServicioAppService;

        public TipoServicioController(ITipoServicioAppService tipoServicioAppService)
        {
            _tipoServicioAppService = tipoServicioAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<TipoServicioDTO>> GetAll()
        {
            var result = _tipoServicioAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _tipoServicioAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> PostTipoServicio(TipoServicio item)
        {
            return Ok(await _tipoServicioAppService.PostTipoServicio(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutTipoServicio(TipoServicio item)
        {
            return Ok(await _tipoServicioAppService.PutTipoServicio(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteById(int id)
        {
            return Ok(await _tipoServicioAppService.DeleteTipoServicio(id));
        }
    }
}
