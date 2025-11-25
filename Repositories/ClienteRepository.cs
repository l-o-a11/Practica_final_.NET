using PracticaFinal.Data;
using PracticaFinal.Interfaces;
using PracticaFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace PracticaFinal.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll() =>
            await _context.Clientes.ToListAsync();

        public async Task<Cliente?> GetById(int id) =>
            await _context.Clientes.FindAsync(id);

        public async Task<Cliente> Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente?> Update(int id, Cliente cliente)
        {
            var existing = await _context.Clientes.FindAsync(id);
            if (existing == null) return null;
            existing.DT = cliente.DT;
            existing.Document = cliente.Document;
            existing.First_Name = cliente.First_Name;
            existing.Last_Name = cliente.Last_Name;
            existing.Whatsapp = cliente.Whatsapp;
            existing.Address = cliente.Address;
            existing.Status = cliente.Status;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var existing = await _context.Clientes.FindAsync(id);
            if (existing == null) return false;

            _context.Clientes.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}