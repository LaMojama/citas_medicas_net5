using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CitasMedicasNet5.Models
{
    public class Paciente : Usuario
    {
        public Paciente()
        {
            Medicos = new List<Medico>();
            Citas = new List<Cita>();

        }
        public string NSS { get; set; }
        public string NumTarjeta { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public List<Cita> Citas { get; set; }
        public List<Medico> Medicos { get; set; }
    }
}
