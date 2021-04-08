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
    public class MedicosController : ControllerBase
    {
        private readonly CitasMedicasNet5Context _context;

        private readonly IMapper _mapper;

        public MedicosController(CitasMedicasNet5Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Medicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicoDTO>>> GetMedicoDTO()
        {
            IEnumerable<Medico> list = await _context.Medico.Include(m => m.Pacientes).Include(m => m.Citas).ToListAsync();
            IEnumerable<MedicoDTO> list2 = list.Select(medico => _mapper.Map<MedicoDTO>(medico));
            return new ActionResult<IEnumerable<MedicoDTO>>(list2);
        }

        // GET: api/Medicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicoDTO>> GetMedicoDTO(int id)
        {
            var medico = await _context.Medico.FindAsync(id);
            _context.Entry(medico).Collection(m => m.Pacientes).Query().Load();
            _context.Entry(medico).Collection(m => m.Citas).Query().Load();

            if (medico == null)
            {
                return NotFound();
            }
          //  var medico2 = _context.Medico.Include(m => m.Pacientes).Include(m => m.Citas).Where(m => m.Id == id);
            var medicoDTO = _mapper.Map<MedicoDTO>(medico);
           
            return medicoDTO;
        }

        // PUT: api/Medicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicoDTO(int id, MedicoDTO medicoDTO)
        {
            if (id != medicoDTO.Id)
            {
                return BadRequest();
            }

            var medico = await _context.Medico.FindAsync(id);
            medico = _mapper.Map(medicoDTO, medico);

            _context.Entry(medico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicoDTOExists(id))
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

        // POST: api/Medicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicoDTO>> PostMedicoDTO(MedicoDTO medicoDTO)
        {
            var medico = _mapper.Map<Medico>(medicoDTO);
            _context.Medico.Add(medico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicoDTO", new { id = medicoDTO.Id }, medicoDTO);
        }

        // DELETE: api/Medicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicoDTO(int id)
        {
            var medico = await _context.Medico.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            _context.Medico.Remove(medico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Medicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{idMedico}/addCita/{idPaciente}")]
        public async Task<ActionResult<MedicoDTO>> addCita(int idMedico, int idPaciente, CitaDTO citaDTO)
        {
            var cita = _mapper.Map<Cita>(citaDTO);
            var medico = _context.Medico.Find(idMedico);
            var paciente = _context.Paciente.Find(idPaciente);
            _context.Cita.Add(cita);
            medico.Citas.Add(cita);
            paciente.Citas.Add(cita);
            _context.Entry(medico).State = EntityState.Modified;
            _context.Entry(paciente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var medicoDTO = _mapper.Map<MedicoDTO>(medico);

            return CreatedAtAction("GetMedicoDTO", new { id = medicoDTO.Id }, medicoDTO);
        }

        // POST: api/Medicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{idMedico}/addDiagnostico/{idCita}")]
        public async Task<ActionResult<MedicoDTO>> addDiagnosticoToCita(int idMedico, int idCita, DiagnosticoDTO diagnosticoDTO)
        {
            var diagnostico = _mapper.Map<Diagnostico>(diagnosticoDTO);
            var medico = _context.Medico.Find(idMedico);
            var cita = _context.Cita.Find(idCita);
            _context.Diagnostico.Add(diagnostico);
            cita.Diagnostico = diagnostico;
            _context.Entry(cita).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var medicoDTO = _mapper.Map<MedicoDTO>(medico);

            return CreatedAtAction("GetMedicoDTO", new { id = medicoDTO.Id }, medicoDTO);
        }

        // POST: api/Medicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{idMedico}/addPaciente/{idPaciente}")]
        public async Task<ActionResult<MedicoDTO>> addPaciente(int idMedico, int idPaciente, MedicoDTO medicoDTO)
        {
            var medico = _context.Medico.Find(idMedico);
            var paciente = _context.Paciente.Find(idPaciente);
            medico.Pacientes.Add(paciente);
            paciente.Medicos.Add(medico);
            _context.Entry(medico).State = EntityState.Modified;
            _context.Entry(paciente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var medicoDTO2 = _mapper.Map <MedicoDTO>(medico);

            return CreatedAtAction("GetMedicoDTO", new { id = medicoDTO2.Id }, medicoDTO2);
        }

        private bool MedicoDTOExists(int id)
        {
            return _context.Medico.Any(e => e.Id == id);
        }
    }
}
