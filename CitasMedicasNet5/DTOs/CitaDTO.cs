using CitasMedicasNet5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasMedicasNet5.DTOs
{
    public class CitaDTO
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string MotivoCita { get; set; }
        public Diagnostico Diagnostico { get; set; }
    }
}
