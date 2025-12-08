using Microsoft.AspNetCore.Mvc;
using PracticaFinal.Controllers;
using PracticaFinal.Models;

namespace PracticaFinal.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAll();
        Task<Service?> GetById(int id);
        Task<Service> Add(Service services);
        Task<Service?> Update(int id, Service services);
        Task<bool> Delete(int id);
    }
}