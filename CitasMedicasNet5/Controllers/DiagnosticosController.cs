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
using CitasMedicasNet5.Services;

namespace CitasMedicasNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticosController : ControllerBase
    {
        private readonly CitasMedicasNet5Context _context;

        private readonly IMapper _mapper;

        public DiagnosticosController(CitasMedicasNet5Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Diagnosticos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiagnosticoDTO>>> GetDiagnosticoDTO()
        {
            IEnumerable<Diagnostico> list = await _context.Diagnostico.ToListAsync();
            IEnumerable<DiagnosticoDTO> list2 = list.Select(diagnostico => _mapper.Map<DiagnosticoDTO>(diagnostico));
            return new ActionResult<IEnumerable<DiagnosticoDTO>>(list2);
        }

        // GET: api/Diagnosticos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiagnosticoDTO>> GetDiagnosticoDTO(int id)
        {
            var diagnostico = await _context.Diagnostico.FindAsync(id);

            if (diagnostico == null)
            {
                return NotFound();
            }

            var diagnosticoDTO = _mapper.Map<DiagnosticoDTO>(diagnostico);

            return diagnosticoDTO;
        }

        // PUT: api/Diagnosticos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiagnosticoDTO(int id, DiagnosticoDTO diagnosticoDTO)
        {
            if (id != diagnosticoDTO.Id)
            {
                return BadRequest();
            }

            var diagnostico = await _context.Diagnostico.FindAsync(id);
            diagnostico = _mapper.Map(diagnosticoDTO, diagnostico);

            _context.Entry(diagnostico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagnosticoDTOExists(id))
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

        // POST: api/Diagnosticos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<DiagnosticoDTO>> PostDiagnosticoDTO(DiagnosticoDTO diagnosticoDTO)
        {
            var diagnostico = _mapper.Map<Diagnostico>(diagnosticoDTO);
            _context.Diagnostico.Add(diagnostico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiagnosticoDTO", new { id = diagnostico.Id }, diagnostico);
        }

        // DELETE: api/Diagnosticos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnosticoDTO(int id)
        {
            var diagnostico = await _context.Diagnostico.FindAsync(id);
            if (diagnostico == null)
            {
                return NotFound();
            }

            _context.Diagnostico.Remove(diagnostico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiagnosticoDTOExists(int id)
        {
            return _context.Diagnostico.Any(e => e.Id == id);
        }
    }
}
