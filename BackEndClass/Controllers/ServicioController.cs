using BackEndClass.AppServices;
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
    public class ServicioController : ControllerBase
    {
        private readonly IServicioAppService _servicioAppService;

        public ServicioController(IServicioAppService servicioAppService)
        {
            _servicioAppService = servicioAppService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ServicioDTO>> GetAll()
        {
            var result = _servicioAppService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> GetById(long id)
        {
            return Ok(await _servicioAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Servicio>> PostServicio(Servicio item)
        {
            return Ok(await _servicioAppService.PostServicio(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Servicio>> PutServicio(Servicio item)
        {
            return Ok(await _servicioAppService.PutServicio(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Servicio>> DeleteServicio(int id)
        {
            return Ok(await _servicioAppService.DeleteServicio(id));
        }
    }
}