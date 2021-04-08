using CitasMedicasNet5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasMedicasNet5.Data
{
    public class DbInitializer
    {
        public static void Initialize(CitasMedicasNet5Context context)
        {
            if (context.Medico.Any())
            {
                return;   // DB has been seeded
            }
            
            var medicos = new Medico[]
{
                new Medico { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumColegiado = "123456789" },
                new Medico { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumColegiado = "123456789" },
                new Medico { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumColegiado = "123456789" },
                new Medico { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumColegiado = "123456789" },
                new Medico { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumColegiado = "123456789" },
                new Medico { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumColegiado = "123456789" },
                new Medico { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumColegiado = "123456789" },
                new Medico { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumColegiado = "123456789" },
};

            foreach (Medico s in medicos)
            {
                context.Medico.Add(s);
            }
            context.SaveChanges();


            var pacientes = new Paciente[]
{
                new Paciente { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumTarjeta = "123456789", NSS = "123456789", Telefono = "666666666", Direccion = "Calle Covid, N19"},
                new Paciente { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumTarjeta = "123456789", NSS = "123456789", Telefono = "666666666", Direccion = "Calle Covid, N19"},
                new Paciente { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumTarjeta = "123456789", NSS = "123456789", Telefono = "666666666", Direccion = "Calle Covid, N19"},
                new Paciente { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumTarjeta = "123456789", NSS = "123456789", Telefono = "666666666", Direccion = "Calle Covid, N19"},
                new Paciente { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumTarjeta = "123456789", NSS = "123456789", Telefono = "666666666", Direccion = "Calle Covid, N19"},
                new Paciente { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumTarjeta = "123456789", NSS = "123456789", Telefono = "666666666", Direccion = "Calle Covid, N19"},
                new Paciente { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumTarjeta = "123456789", NSS = "123456789", Telefono = "666666666", Direccion = "Calle Covid, N19"},
                new Paciente { Nombre = "Juan",   Apellidos = "Castillo Cava",
                    NombreUsuario = "cavamedico", Clave = "1234", NumTarjeta = "123456789", NSS = "123456789", Telefono = "666666666", Direccion = "Calle Covid, N19"},
};

            foreach (Paciente s in pacientes)
            {
                context.Paciente.Add(s);
            }
            context.SaveChanges();


            var citas = new Cita[]
{
                new Cita { FechaHora = DateTime.Parse("2021-03-15"),   MotivoCita = "Revision"},
                new Cita { FechaHora = DateTime.Parse("2021-03-15"),   MotivoCita = "Revision"},
                new Cita { FechaHora = DateTime.Parse("2021-03-15"),   MotivoCita = "Revision"},
                new Cita { FechaHora = DateTime.Parse("2021-03-15"),   MotivoCita = "Revision"},
                new Cita { FechaHora = DateTime.Parse("2021-03-15"),   MotivoCita = "Revision"},
                new Cita { FechaHora = DateTime.Parse("2021-03-15"),   MotivoCita = "Revision"},
                new Cita { FechaHora = DateTime.Parse("2021-03-15"),   MotivoCita = "Revision"},
                new Cita { FechaHora = DateTime.Parse("2021-03-15"),   MotivoCita = "Revision"},
};

            foreach (Cita s in citas)
            {
                context.Cita.Add(s);
            }

            context.SaveChanges();

        }
    }
}
