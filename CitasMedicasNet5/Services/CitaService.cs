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
    public class CitaService : ICitaService
    {
        private readonly CitasMedicasNet5Context _context;
        public CitaService(CitasMedicasNet5Context context)
        {
            _context = context;
        }

        public async Task<ActionResult<Cita>> CreateCita(Cita cita)
        {
            _context.Cita.Add(cita);
            await _context.SaveChangesAsync();
            return cita;
        }

        public async Task<IActionResult> DeleteCita(int id)
        {
            var cita = await _context.Cita.FindAsync(id);
            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<IEnumerable<Cita>> GetCita()
        {
            IEnumerable<Cita> list = await _context.Cita.ToListAsync();
            return list;
        }

        public async Task<ActionResult<Cita>> GetCita(int id)
        {
            var cita = await _context.Cita.FindAsync(id);
            return cita;
        }

        public async Task<IActionResult> UpdateCita(int id, Cita cita)
        {
            _context.Entry(cita).State = EntityState.Modified;

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
