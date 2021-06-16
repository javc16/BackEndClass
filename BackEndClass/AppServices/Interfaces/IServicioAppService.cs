using BackEndClass.Helpers;
using BackEndClass.Models;
using BackEndClass.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices.Interfaces
{
    public interface IServicioAppService
    {
        IEnumerable<ServicioDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostServicio(ServicioDTO servicio);
        Task<Response> PutServicio(ServicioDTO servicio);
        Task<Response> DeleteServicio(ServicioDTO servicio);
    }
}