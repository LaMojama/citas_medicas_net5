using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitasMedicasNet5.DTOs;
using CitasMedicasNet5.Data;
using AutoMapper;
using CitasMedicasNet5.Models;

namespace CitasMedicasNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly CitasMedicasNet5Context _context;

        private readonly IMapper _mapper;

        public CitasController(CitasMedicasNet5Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Citas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitaDTO>>> GetCitaDTO()
        {
            IEnumerable<Cita> list = await _context.Cita.ToListAsync();
            IEnumerable<CitaDTO> list2 = list.Select(cita => _mapper.Map<CitaDTO>(cita));
            return new ActionResult<IEnumerable<CitaDTO>>(list2);
        }

        // GET: api/Citas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CitaDTO>> GetCitaDTO(int id)
        {
            var cita = await _context.Cita.FindAsync(id);

            if (cita == null)
            {
                return NotFound();
            }

            var citaDTO = _mapper.Map<CitaDTO>(cita);

            return citaDTO;
        }

        // PUT: api/Citas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitaDTO(int id, CitaDTO citaDTO)
        {
            if (id != citaDTO.Id)
            {
                return BadRequest();
            }
            var cita = await _context.Cita.FindAsync(id);
            cita = _mapper.Map(citaDTO, cita);

            _context.Entry(cita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaDTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Citas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CitaDTO>> PostCitaDTO(CitaDTO citaDTO)
        {
            var cita = _mapper.Map<Cita>(citaDTO);
            _context.Cita.Add(cita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCitaDTO", new { id = citaDTO.Id }, citaDTO);
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCitaDTO(int id)
        {
            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }

            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CitaDTOExists(int id)
        {
            return _context.Cita.Any(e => e.Id == id);
        }
    }
}
