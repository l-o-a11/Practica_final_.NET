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
	public class ServicioController : ControllerBase
	{
		private readonly IServicioRepository _servicioRepository;

		public ServicioController(IServicioRepository servicioRepository)
		{
			_servicioRepository = servicioRepository;
		}
		// GET: api/<ServicioController>
		[HttpGet]
		public async Task<IActionResult> GetAll() =>
			Ok(await _servicioRepository.GetAll());


		// GET: api/<ServicioController>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var servicio = await _servicioRepository.GetById(id);
			if (servicio == null) return NotFound();
			return Ok(servicio);
		}

		// POST api/<ServicioController>
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] ServicioDto servicioDto)
		{
			var newServicio = new Servicio
			{
				Nombre = servicioDto.Nombre,
				Descripcion = servicioDto.Descripcion,
				Precio = servicioDto.Precio,
				Status = servicioDto.Status
			};

			var created = await _servicioRepository.Add(newServicio);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}
		// PUT api/<ServicioController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] ServicioDto servicioDto)
		{
			var UpdateServicio = new Servicio
			{
				Nombre = servicioDto.Nombre,
				Descripcion = servicioDto.Descripcion,
				Precio = servicioDto.Precio,
				Status = servicioDto.Status
			};

			var update = await _servicioRepository.Update(id, UpdateServicio);
			if (update == null) return NotFound();
			return Ok(update);
		}

		// DELETE api/<ServicioController>/5
		[HttpDelete("{id}")]
		public async Task<IAsyncResult> Delete(int id)
		{
			var deleted = await _servicioRepository.Delete(id);
			if (!deleted) return (IAsyncResult)NotFound();
			return (IAsyncResult)NoContent();
		}
	}
}
