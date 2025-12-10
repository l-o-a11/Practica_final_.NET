using Microsoft.AspNetCore.Mvc;
using PracticaFinal.DTO;
using PracticaFinal.Interfaces;
using PracticaFinal.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        // GET: api/<ServicesController>
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _serviceRepository.GetAll());

        // GET api/<ServicesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _serviceRepository.GetById(id);
            if (service == null) return NotFound();
            return Ok(service);
        }

        // POST api/<ServicesController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ServiceDto serviceDto)
        {
            var newService = new Service
            {
                Name = serviceDto.Name,
                Price = serviceDto.Price,
				StatusId = serviceDto.StatusId
			};
            var created = await _serviceRepository.Add(newService);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT api/<ServicesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceDto serviceDto)
        {
            var updateService = new Service
            {
                Name = serviceDto.Name,
                Price = serviceDto.Price,
				StatusId = serviceDto.StatusId
			};
            var updated = await _serviceRepository.Update(id, updateService);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE api/<ServicesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _serviceRepository.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}