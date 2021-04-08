using CitasMedicasNet5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CitasMedicasNet5.DTOs
{
    public class MedicoDTO
    {
        public MedicoDTO()
        {
            Pacientes = new List<Paciente>();
            Citas = new List<Cita>();

        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string NumColegiado { get; set; }
        public List<Cita> Citas { get; set; }
        public List<Paciente> Pacientes { get; set; }
    }
}
