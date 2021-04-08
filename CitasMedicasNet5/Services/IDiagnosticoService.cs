using CitasMedicasNet5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasMedicasNet5.Services
{
    interface IDiagnosticoService
    {
        public Task<IEnumerable<Diagnostico>> GetDiagnostico();
        public Task<ActionResult<Diagnostico>> GetDiagnostico(int id);
        public Task<IActionResult> UpdateDiagnostico(int id, Diagnostico diagnostico);
        public Task<ActionResult<Diagnostico>> CreateDiagnostico(Diagnostico diagnostico);
        public Task<IActionResult> DeleteDiagnostico(int id);

    }
}
