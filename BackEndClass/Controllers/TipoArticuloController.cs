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
    public class TipoArticuloController : ControllerBase
    {
        private readonly ITipoArticuloAppService _tipoArticuloAppService;

        public TipoArticuloController(ITipoArticuloAppService tipoArticuloAppService)
        {
            _tipoArticuloAppService = tipoArticuloAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<TipoArticulo>> GetAll()
        {
            var result = _tipoArticuloAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TipoArticulo>> GetById(long id)
        {
            return Ok(await _tipoArticuloAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<TipoArticulo>> PostTipoArticulo(TipoArticulo item)
        {
            return Ok(await _tipoArticuloAppService.PostTipoArticulo(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TipoArticulo>> PutTipoArticulo(TipoArticulo item)
        {
            return Ok(await _tipoArticuloAppService.PutTipoArticulo(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoArticulo>> DeleteById(int id)
        {
            return Ok(await _tipoArticuloAppService.DeleteTipoArticulo(id));
        }
    }
}
