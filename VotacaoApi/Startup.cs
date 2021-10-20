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
using Votacao.Domain.Handlers;
using Votacao.Domain.Interfaces.Repositories;
using Votacao.Infra.Data.DataContexts;
using Votacao.Infra.Data.Repositories;
using Votacao.Infra.Settings;

namespace VotacaoApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            #region AppSettings
            AppSettings appSettings = new AppSettings();
            Configuration.GetSection("AppSettings").Bind(appSettings);
            services.AddSingleton(appSettings);
            #endregion

            #region DataContexts
            services.AddScoped<DataContext>();
            #endregion

            #region Repositories
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IFilmeRepository, FilmeRepository>();
            services.AddTransient<IVotoRepository, VotoRepository>();
            #endregion

            #region Handlers
            services.AddTransient<UsuarioHandler, UsuarioHandler>();
            services.AddTransient<FilmeHandler, FilmeHandler>();
            services.AddTransient<VotoHandler, VotoHandler>();
            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VotacaoApi", Version = "v1" });
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VotacaoApi v1"));
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
