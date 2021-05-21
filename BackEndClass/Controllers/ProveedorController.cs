using BackEndClass.AppServices;
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
        public async Task<ActionResult<Response>> Post(Proveedor item)
        {
            return Ok(await _proveedorAppService.PostProveedor(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Put(int id, Proveedor item)
        {
            return Ok(await _proveedorAppService.PutProveedor(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteById(int id)
        {
            return Ok(await _proveedorAppService.DeleteProveedor(id));
        }
    }
}