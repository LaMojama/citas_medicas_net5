using CitasMedicasNet5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasMedicasNet5.Services
{
    interface ICitaService
    {
        public Task<IEnumerable<Cita>> GetCita();
        public Task<ActionResult<Cita>> GetCita(int id);
        public Task<IActionResult> UpdateCita(int id, Cita cita);
        public Task<ActionResult<Cita>> CreateCita(Cita cita);
        public Task<IActionResult> DeleteCita(int id);
    }
}
