using BackEndClass.Helpers;
using BackEndClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndClass.AppServices
{
    public interface IServicioAppService
    {
        IEnumerable<Servicio> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostServicio(Servicio servicio);
        Task<Response> PutServicio(Servicio servicio);
        Task<Response> DeleteServicio(int id);
    }
}