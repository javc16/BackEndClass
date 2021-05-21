using BackEndClass.AppServices;
using BackEndClass.Helpers;
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
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloAppService _articuloAppService;

        public ArticuloController(ArticuloAppService articuloAppService)
        {
            _articuloAppService = articuloAppService;
        }


        [HttpGet]
        public  ActionResult<IEnumerable<ArticuloDTO>> GetAll()
        {
            var result = _articuloAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _articuloAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Articulo item)
        {
            return Ok(await _articuloAppService.PostArticulo(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutCiudadano(Articulo item)
        {
            return Ok(await _articuloAppService.PutArticulo(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteById(int id)
        {
            return Ok(await _articuloAppService.DeleteArticulo(id));
        }

    }
}