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
    public class MedicoService : IMedicoService
    {
        private readonly CitasMedicasNet5Context _context;
        public MedicoService(CitasMedicasNet5Context context)
        {
            _context = context;
        }

        public async Task<ActionResult<Medico>> CreateMedico(Medico medico)
        {
            _context.Medico.Add(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<IActionResult> DeleteMedico(int id)
        {
            var medico = await _context.Medico.FindAsync(id);
            _context.Medico.Remove(medico);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<IEnumerable<Medico>> GetMedico()
        {
            IEnumerable<Medico> list = await _context.Medico.Include(m => m.Pacientes).Include(m => m.Citas).ToListAsync();
            return list;
        }

        public async Task<ActionResult<Medico>> GetMedico(int id)
        {
            var medico = await _context.Medico.FindAsync(id);
            _context.Entry(medico).Collection(m => m.Pacientes).Query().Load();
            _context.Entry(medico).Collection(m => m.Citas).Query().Load();
            return medico;
        }

        public async Task<IActionResult> UpdateMedico(int id, Medico medico)
        {
            _context.Entry(medico).State = EntityState.Modified;

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

        public async Task<ActionResult<Medico>> AddCita(int idMedico, int idPaciente, Cita cita)
        {
            var medico = _context.Medico.Find(idMedico);
            var paciente = _context.Paciente.Find(idPaciente);
            _context.Cita.Add(cita);
            medico.Citas.Add(cita);
            paciente.Citas.Add(cita);
            _context.Entry(medico).State = EntityState.Modified;
            _context.Entry(paciente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<ActionResult<Medico>> addDiagnosticoToCita(int idMedico, int idCita, Diagnostico diagnostico)
        {
            var medico = _context.Medico.Find(idMedico);
            var cita = _context.Cita.Find(idCita);
            _context.Diagnostico.Add(diagnostico);
            cita.Diagnostico = diagnostico;
            _context.Entry(cita).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<ActionResult<Medico>> addPaciente(int idMedico, int idPaciente)
        {
            var medico = _context.Medico.Find(idMedico);
            var paciente = _context.Paciente.Find(idPaciente);
            medico.Pacientes.Add(paciente);
            paciente.Medicos.Add(medico);
            _context.Entry(medico).State = EntityState.Modified;
            _context.Entry(paciente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return medico;
        }
    }
}
