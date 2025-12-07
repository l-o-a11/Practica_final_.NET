using Microsoft.AspNetCore.Mvc;
using PracticaFinal.Models;

namespace PracticaFinal.Interfaces
{
    public interface IServicioRepository
    {
        Task<IEnumerable<Servicios>> GetAll();
        Task<Servicios?> GetById(int id);
        Task<Servicios> Add(Servicios servicios);
        Task<Servicios?> Update(int id, Servicios servicios);
        Task<bool> Delete(int id);
    }
}
