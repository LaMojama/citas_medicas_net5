using CitasMedicasNet5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CitasMedicasNet5.DTOs
{
    public class PacienteDTO
    {

        public PacienteDTO()
        {
            Medicos = new List<Medico>();
            Citas = new List<Cita>();

        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string NSS { get; set; }
        public string NumTarjeta { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public List<Cita> Citas { get; set; }
        public List<Medico> Medicos { get; set; }
    }
}
