using CitasMedicasNet5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasMedicasNet5.Services
{
    public interface IMedicoService
    {
        public Task<IEnumerable<Medico>> GetMedico();
        public Task<ActionResult<Medico>> GetMedico(int id);
        public Task<IActionResult> UpdateMedico(int id, Medico medico);
        public Task<ActionResult<Medico>> CreateMedico(Medico medico);
        public Task<IActionResult> DeleteMedico(int id);
        public Task<ActionResult<Medico>> AddCita(int idMedico, int idPaciente, Cita cita);
        public Task<ActionResult<Medico>> addDiagnosticoToCita(int idMedico, int idCita, Diagnostico diagnostico);
        public Task<ActionResult<Medico>> addPaciente(int idMedico, int idPaciente);
    }
}
