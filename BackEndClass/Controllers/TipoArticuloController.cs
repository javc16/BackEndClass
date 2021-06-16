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
    public class TipoArticuloController : ControllerBase
    {
        private readonly ITipoArticuloAppService _tipoArticuloAppService;

        public TipoArticuloController(ITipoArticuloAppService tipoArticuloAppService)
        {
            _tipoArticuloAppService = tipoArticuloAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<TipoArticuloDTO>> GetAll()
        {
            var result = _tipoArticuloAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _tipoArticuloAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> PostTipoArticulo(TipoArticuloDTO item)
        {
            return Ok(await _tipoArticuloAppService.PostTipoArticulo(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutTipoArticulo(TipoArticuloDTO item)
        {
            return Ok(await _tipoArticuloAppService.PutTipoArticulo(item));
        }

        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(TipoArticuloDTO item)
        {
            return Ok(await _tipoArticuloAppService.DeleteTipoArticulo(item));
        }
    }
}
