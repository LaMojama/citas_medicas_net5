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
    public class DiagnosticoService : IDiagnosticoService
    {
        private readonly CitasMedicasNet5Context _context;
        public DiagnosticoService(CitasMedicasNet5Context context)
        {
            _context = context;
        }

        public async Task<ActionResult<Diagnostico>> CreateDiagnostico(Diagnostico diagnostico)
        {
            _context.Diagnostico.Add(diagnostico);
            await _context.SaveChangesAsync();
            return diagnostico;
        }

        public async Task<IActionResult> DeleteDiagnostico(int id)
        {
            var diagnostico = await _context.Diagnostico.FindAsync(id);
            _context.Diagnostico.Remove(diagnostico);
            await _context.SaveChangesAsync();
            return new NoContentResult();

        }

        public async Task<IEnumerable<Diagnostico>> GetDiagnostico()
        {
            IEnumerable<Diagnostico> list = await _context.Diagnostico.ToListAsync();
            return list;
        }

        public async Task<ActionResult<Diagnostico>> GetDiagnostico(int id)
        {
            var diagnostico = await _context.Diagnostico.FindAsync(id);
            return diagnostico;
        }

        public async Task<IActionResult> UpdateDiagnostico(int id, Diagnostico diagnostico)
        {
            _context.Entry(diagnostico).State = EntityState.Modified;

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
