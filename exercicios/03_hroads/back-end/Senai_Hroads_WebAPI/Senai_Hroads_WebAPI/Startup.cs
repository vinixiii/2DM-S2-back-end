using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Senai_Hroads_WebAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                // Define o uso de Controllers
                .AddControllers()
                // Define as configura��es de looping e valores nulos
                .AddNewtonsoftJson(options =>
                {
                    // Ignora os loopings nas consultas
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                    // Ignora valores nulos ao fazer joins nas consultas
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            // Swagger
            // https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HROADS_API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // Valida��o do Token
            services
               // Define a forma de autentica��o
               .AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = "JwtBearer";
                   options.DefaultChallengeScheme = "JwtBearer";
               })
               // Define os par�metros de valida��o do Token
               .AddJwtBearer("JwtBearer", options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                        // Quem est� emitindo (solicitando)
                        ValidateIssuer = true,
                        // Quem est� recebendo
                        ValidateAudience = true,
                        // Tempo de expira��o
                        ValidateLifetime = true,
                        // Forma de criptografia e a chave de acesso
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-chave-de-acesso")),
                        // Tempo de expira��o do token
                        ClockSkew = TimeSpan.FromMinutes(10),
                        // Nome do issuer, de onde est� vindo
                        ValidIssuer = "HROADS",
                        // Nome do audience, para onde est� indo
                        ValidAudience = "HROADS"
                   };
               });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HROADS API v1");
                c.RoutePrefix = string.Empty;
            });

            // Habilita a autentica��o
            app.UseAuthentication();

            // Habilita as permiss�es
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                // Define o mapeamento dos Controllers
                endpoints.MapControllers();
            });
        }
    }
}
