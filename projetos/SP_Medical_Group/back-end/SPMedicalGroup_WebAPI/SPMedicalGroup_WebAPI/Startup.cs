using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace SPMedicalGroup_WebAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                // Adiciona o serviço dos Controllers
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    // Ignora os loopings das consultas
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                    // Ignora os valores nulos ao fazer joins nas consultas
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
            
            // Swagger =========

            // Adiciona o serviço do Swagger
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SP Medical Group API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // ========= Swagger

            // Validação do Token =========

            services
               // Define a forma de autenticação
               .AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = "JwtBearer";
                   options.DefaultChallengeScheme = "JwtBearer";
               })
               // Define os parâmetros de validação do Token
               .AddJwtBearer("JwtBearer", options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       // Quem está emitindo (solicitando)
                       ValidateIssuer = true,
                       // Quem está recebendo
                       ValidateAudience = true,
                       // Tempo de expiração
                       ValidateLifetime = true,
                       // Forma de criptografia e a chave de acesso
                       IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmed-chave-de-acesso")),
                       // Tempo de expiração do token
                       ClockSkew = TimeSpan.FromMinutes(10),
                       // Nome do issuer, de onde está vindo
                       ValidIssuer = "SPMedicalGroup",
                       // Nome do audience, para onde está indo
                       ValidAudience = "SPMedicalGroup"
                   };
               });

            // ========= Validação do Token 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Swagger =========

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SP Medical Group API");
                c.RoutePrefix = string.Empty;
            });

            // ========= Swagger

            app.UseRouting();

            // Habilita a autenticação
            app.UseAuthentication();

            // Habilita as permissões
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
