using CitasMedicasNet5.Data;
using CitasMedicasNet5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasMedicasNet5.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly CitasMedicasNet5Context _context;
        public PacienteService(CitasMedicasNet5Context context)
        {
            _context = context;
        }

        public async Task<ActionResult<Paciente>> CreatePaciente(Paciente paciente)
        {
            _context.Paciente.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<IActionResult> DeletePaciente(int id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<IEnumerable<Paciente>> GetPaciente()
        {
            IEnumerable<Paciente> list = await _context.Paciente.ToListAsync();
            return list;
        }

        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            var paciente = await _context.Paciente.FindAsync(id);
            return paciente;
        }

        public async Task<IActionResult> UpdatePaciente(int id, Paciente paciente)
        {
            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            return new NoContentResult();
        }
    }
}
