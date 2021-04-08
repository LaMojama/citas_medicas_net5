using CitasMedicasNet5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasMedicasNet5.Services
{
    interface IPacienteService
    {
        public Task<IEnumerable<Paciente>> GetPaciente();
        public Task<ActionResult<Paciente>> GetPaciente(int id);
        public Task<IActionResult> UpdatePaciente(int id, Paciente paciente);
        public Task<ActionResult<Paciente>> CreatePaciente(Paciente paciente);
        public Task<IActionResult> DeletePaciente(int id);
    }
}
