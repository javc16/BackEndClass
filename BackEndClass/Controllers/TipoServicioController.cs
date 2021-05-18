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
    public class TipoServicioController : ControllerBase
    {
        private readonly ITipoServicioAppService _tipoServicioAppService;

        public TipoServicioController(ITipoServicioAppService tipoServicioAppService)
        {
            _tipoServicioAppService = tipoServicioAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<TipoServicio>> GetAll()
        {
            var result = _tipoServicioAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TipoServicio>> GetById(long id)
        {
            return Ok(await _tipoServicioAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<TipoServicio>> PostTipoServicio(TipoServicio item)
        {
            return Ok(await _tipoServicioAppService.PostTipoServicio(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TipoServicio>> PutTipoServicio(TipoServicio item)
        {
            return Ok(await _tipoServicioAppService.PutTipoServicio(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoServicio>> DeleteById(int id)
        {
            return Ok(await _tipoServicioAppService.DeleteTipoServicio(id));
        }
    }
}
