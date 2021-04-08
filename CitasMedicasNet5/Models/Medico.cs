using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CitasMedicasNet5.Models
{
    public class Medico : Usuario
    {
        public Medico()
        {
            Pacientes = new List<Paciente>();
            Citas = new List<Cita>();

        }

    public string NumColegiado { get; set; }
        public List<Cita> Citas { get; set; }
        public List<Paciente> Pacientes { get; set; }
    }
}
