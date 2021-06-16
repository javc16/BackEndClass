using BackEndClass.AppServices.Interfaces;
using BackEndClass.Helpers;
using BackEndClass.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BackEndClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorAppService _proveedorAppService;

        public ProveedorController(IProveedorAppService proveedorAppService)
        {
            _proveedorAppService = proveedorAppService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProveedorDTO>> GetAll()
        {
            var result = _proveedorAppService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(long id)
        {
            return Ok(await _proveedorAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(ProveedorDTO item)
        {
            return Ok(await _proveedorAppService.PostProveedor(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutProveedor(ProveedorDTO item)
        {
            return Ok(await _proveedorAppService.PutProveedor(item));
        }

        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(ProveedorDTO item)
        {
            return Ok(await _proveedorAppService.DeleteProveedor(item));
        }
    }
}