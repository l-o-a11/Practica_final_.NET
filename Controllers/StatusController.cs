using Microsoft.AspNetCore.Mvc;
using PracticaFinal.DTO;
using PracticaFinal.DTOs;
using PracticaFinal.Interfaces;
using PracticaFinal.Models;
using PracticaFinal.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        // GET: api/<StatusController>
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _statusRepository.GetAll());

        // GET api/<StatusController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var status = await _statusRepository.GetById(id);
            if (status == null) return NotFound();
            return Ok(status);
        }

        // POST api/<StatusController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StatusDto statusDto)
        {
            var newStatus = new Status
            {
                Descripcion = statusDto.Descripcion
            };
            var created = await _statusRepository.Add(newStatus);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT api/<StatusController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StatusDto statusDto)
        {
            var UpdateStatus = new Status
            {
                Descripcion = statusDto.Descripcion
            };
            var update = await _statusRepository.Update(id, UpdateStatus);
            if (update == null) return NotFound();
            return Ok(update);
        }


        // DELETE api/<StatusController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _statusRepository.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}