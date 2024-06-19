using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Gerenciador.Configurations;
using System.Globalization;
using Dominio.Helpers;
using Dominio.Servicos;
using Dominio.Interfaces;
using Dominio.Repositorios;
using Repositorio.Repositorios;

namespace Gerenciador
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            //Adiciona AutoMapper
            services.RegisterAutoMapper();

            services.AddMvc().AddViewLocalization();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(120);
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.Name = "Gerenciador.Session";
                options.Cookie.HttpOnly = true;
            });

            services.AddHttpContextAccessor();

            //Adiciona AutoMapper
            services.RegisterAutoMapper();

            //Adiciona Serviços
            AddServices(services);

            //Adiciona classe configuração
            Configuracao.AddSettings(Configuration);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Servicos
            services.AddScoped<IServicoUsuario, ServicoUsuario>();
            services.AddScoped<IServicoLoja, ServicoLoja>();
            services.AddScoped<IServicoMenu, ServicoMenu>();

            //Repositorios
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.AddScoped<IRepositorioLoja, RepositorioLoja>();
            services.AddScoped<IRepositorioMenu, RepositorioMenu>();

            services.AddScoped<IRepositorioEndereco, RepositorioEndereco>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            ConfigurarCultureInfo();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=}");
            });


            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            Sessao.Configure(httpContextAccessor);
        }

        private void ConfigurarCultureInfo()
        {
            var cultureInfo = new CultureInfo("pt-BR");
            cultureInfo.NumberFormat.CurrencySymbol = "R$";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}