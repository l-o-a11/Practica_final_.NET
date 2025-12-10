using PracticaFinal.DTOs;
using PracticaFinal.Interfaces;
using PracticaFinal.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientsController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _clienteRepository.GetAll());


        // GET: api/<ClienteController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteRepository.GetById(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ClienteDto clienteDto)
        {
            var newCliente = new Cliente
            {
                DT = clienteDto.DT,
                Document = clienteDto.Document,
                First_Name = clienteDto.First_Name,
                Last_Name = clienteDto.Last_Name,
                Whatsapp = clienteDto. Whatsapp,
                Address = clienteDto.Address,
				StatusId = clienteDto.StatusId
			};

            var created = await _clienteRepository.Add(newCliente);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteDto clienteDto)
        {
            var UpdateCliente = new Cliente
            {
                DT = clienteDto.DT,
                Document = clienteDto.Document,
                First_Name = clienteDto.First_Name,
                Last_Name = clienteDto.Last_Name,
                Whatsapp = clienteDto.Whatsapp,
                Address = clienteDto.Address,
				StatusId = clienteDto.StatusId
			};

            var update = await _clienteRepository.Update(id, UpdateCliente);
            if (update == null) return NotFound();
            return Ok(update);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IAsyncResult> Delete(int id)
        {
            var deleted = await _clienteRepository.Delete(id);
            if (!deleted) return (IAsyncResult)NotFound();
            return (IAsyncResult)NoContent();
        }
    }
}
