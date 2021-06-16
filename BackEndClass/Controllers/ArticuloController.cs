using BackEndClass.AppServices.Interfaces;
using BackEndClass.Helpers;
using BackEndClass.Models;
using BackEndClass.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloAppService _articuloAppService;

        public ArticuloController(IArticuloAppService articuloAppService)
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
        public async Task<ActionResult<Response>> Post(ArticuloDTO item)
        {
            return Ok(await _articuloAppService.PostArticulo(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutCiudadano(ArticuloDTO item)
        {
            return Ok(await _articuloAppService.PutArticulo(item));
        }

        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(ArticuloDTO item)
        {
            return Ok(await _articuloAppService.DeleteArticulo(item));
        }

    }
}