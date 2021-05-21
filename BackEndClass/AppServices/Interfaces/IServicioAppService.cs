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
        Task<Response> PostServicio(Servicio servicio);
        Task<Response> PutServicio(Servicio servicio);
        Task<Response> DeleteServicio(int id);
    }
}