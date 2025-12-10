using Microsoft.AspNetCore.Mvc;
using PracticaFinal.DTO;
using PracticaFinal.Interfaces;
using PracticaFinal.Models;

namespace PracticaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _repository;

        public ReservationController(IReservationRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Reservation
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservations = await _repository.GetAll();
            return Ok(reservations);
        }

        // GET: api/Reservation/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservation = await _repository.GetById(id);

            if (reservation == null)
                return NotFound("Reserva no encontrada");

            return Ok(reservation);
        }

        // POST: api/Reservation
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReservationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reservation = new Reservation
            {
                ClienteId = dto.ClienteId,
                ServiceId = dto.ServiceId,
                Date = dto.Date,
                StatusId = dto.StatusId
            };

            var created = await _repository.Add(reservation);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/Reservation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReservationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reservation = new Reservation
            {
                ClienteId = dto.ClienteId,
                ServiceId = dto.ServiceId,
                Date = dto.Date,
				StatusId = dto.StatusId
			};

            var updated = await _repository.Update(id, reservation);

            if (updated == null)
                return NotFound("Reserva no encontrada");

            return Ok(updated);
        }

        // DELETE: api/Reservation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.Delete(id);

            if (!result)
                return NotFound("Reserva no encontrada");

            return Ok("Reserva eliminada correctamente");
        }


    }
}

