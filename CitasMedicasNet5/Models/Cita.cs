using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CitasMedicasNet5.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string MotivoCita { get; set; }
        public Diagnostico Diagnostico { get; set; }
    }
}
