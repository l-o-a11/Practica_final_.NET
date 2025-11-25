using Microsoft.AspNetCore.Mvc;
using PracticaFinal.Models;

namespace PracticaFinal.Interfaces
{
    public interface ISevicioRepository
    {
        Task<IEnumerable<Servicio>> GetAll();
        Task<Servicio?> GetById(int id);
        Task<Servicio> Add(Servicio servicios);
        Task<Servicio?> Update(int id, Servicio servicios);
        Task<bool> Delete(int id);
    }
}
