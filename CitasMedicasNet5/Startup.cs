using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CitasMedicasNet5.Data;
using AutoMapper;
using CitasMedicasNet5.Models;
using CitasMedicasNet5.DTOs;
using System.Text.Json.Serialization;

namespace CitasMedicasNet5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;


        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cita, CitaDTO>();
                cfg.CreateMap<Diagnostico, DiagnosticoDTO>();
                cfg.CreateMap<Paciente, PacienteDTO>();
                cfg.CreateMap<Medico, MedicoDTO>();
                cfg.CreateMap<CitaDTO, Cita>();
                cfg.CreateMap<DiagnosticoDTO, Diagnostico>();
                cfg.CreateMap<PacienteDTO, Paciente>();
                cfg.CreateMap<MedicoDTO, Medico>();
            });
            // only during development, validate your mappings; remove it before release
            configuration.AssertConfigurationIsValid();
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CitasMedicasNet5", Version = "v1" });
            });

            services.AddDbContext<CitasMedicasNet5Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CitasMedicasNet5Context")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CitasMedicasNet5 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
