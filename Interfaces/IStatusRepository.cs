using Microsoft.AspNetCore.Mvc;
using PracticaFinal.Controllers;
using PracticaFinal.Models;

namespace PracticaFinal.Interfaces
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetAll();
        Task<Status?> GetById(int id);
        Task<Status> Add(Status status);
        Task<Status?> Update(int id, Status status);
        Task<bool> Delete(int id);
    }
}