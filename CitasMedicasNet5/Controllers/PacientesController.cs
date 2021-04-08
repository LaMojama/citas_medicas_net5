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
    public class PacientesController : ControllerBase
    {
        private readonly CitasMedicasNet5Context _context;

        private readonly IMapper _mapper;

        public PacientesController(CitasMedicasNet5Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteDTO>>> GetPacienteDTO()
        {
            IEnumerable<Paciente> list = await _context.Paciente.Include(m => m.Medicos).Include(m => m.Citas).ToListAsync();
            IEnumerable<PacienteDTO> list2 = list.Select(paciente => _mapper.Map<PacienteDTO>(paciente));
            return new ActionResult<IEnumerable<PacienteDTO>>(list2);
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteDTO>> GetPacienteDTO(int id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            _context.Entry(paciente).Collection(m => m.Medicos).Query().Load();
            _context.Entry(paciente).Collection(m => m.Citas).Query().Load();

            if (paciente == null)
            {
                return NotFound();
            }

            var pacienteDTO = _mapper.Map<PacienteDTO>(paciente);

            return pacienteDTO;
        }

        // PUT: api/Pacientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacienteDTO(int id, PacienteDTO pacienteDTO)
        {
            if (id != pacienteDTO.Id)
            {
                return BadRequest();
            }
            var paciente = await _context.Paciente.FindAsync(id);
            paciente = _mapper.Map(pacienteDTO, paciente);
            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteDTOExists(id))
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

        // POST: api/Pacientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PacienteDTO>> PostPacienteDTO(PacienteDTO pacienteDTO)
        {
            var paciente = _mapper.Map<Paciente>(pacienteDTO);
            _context.Paciente.Add(paciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPacienteDTO", new { id = pacienteDTO.Id }, pacienteDTO);
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacienteDTO(int id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PacienteDTOExists(int id)
        {
            return _context.Paciente.Any(e => e.Id == id);
        }
    }
}
