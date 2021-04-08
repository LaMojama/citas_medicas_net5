using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CitasMedicasNet5.Models;

namespace CitasMedicasNet5.Data
{
    public class CitasMedicasNet5Context : DbContext
    {

        public CitasMedicasNet5Context (DbContextOptions<CitasMedicasNet5Context> options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<CitasMedicasNet5.Models.Diagnostico> Diagnostico { get; set; }

        public DbSet<CitasMedicasNet5.Models.Cita> Cita { get; set; }

        public DbSet<CitasMedicasNet5.Models.Paciente> Paciente { get; set; }

        public DbSet<CitasMedicasNet5.Models.Medico> Medico { get; set; }
    }


}
