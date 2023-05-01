using Aplicacao.Aplicacoes;
using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.Genericos;
using Dominio.Interfaces.InterfaceServicos;
using Dominio.Servicos;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebAPI
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

            services.AddDbContext<Contexto>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection")));

     
            // INTERFACE E REPOSITORIO
            services.AddSingleton(typeof(IGenericos<>), typeof(RepositorioGenerico<>));
            services.AddSingleton<ITurma, RepositorioTurma>();
            services.AddSingleton<Dominio.Interfaces.IAlunoTurma, RepositorioAlunoTurma>();
            services.AddSingleton<Dominio.Interfaces.IAluno, RepositorioAluno>();

            // SERVIÇO DOMINIO
            services.AddSingleton<IServicoTurma, ServicoTurma>();
            services.AddSingleton<IServicoAluno, ServicoAluno>();
            services.AddSingleton<IServicoAlunoTurma, ServicoAlunoTurma>();

            // INTERFACE APLICAÇÃO
            services.AddSingleton<IAplicacaoTurma, AplicacaoTurma>();
            services.AddSingleton<Aplicacao.Interfaces.IAlunoTurma, AplicacaoAlunoTurma>();
            services.AddSingleton<Aplicacao.Interfaces.IAluno, AplicacaoAluno>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
