using Microsoft.AspNetCore.Mvc;
using PracticaFinal.Controllers;
using PracticaFinal.Models;

namespace PracticaFinal.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Models.Service>> GetAll();
        Task<Models.Service?> GetById(int id);
        Task<Models.Service> Add(Models.Service services);
        Task<Models.Service?> Update(int id, Models.Service services);
        Task<bool> Delete(int id);
    }
}
