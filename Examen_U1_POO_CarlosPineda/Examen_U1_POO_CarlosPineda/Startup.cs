using Examen_U1_POO_CarlosPineda.Services;
using Examen_U1_POO_CarlosPineda.Services.Interfaces;

namespace Examen_U1_POO_CarlosPineda
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration; 
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddTransient<ICategoriasService, CategoriasService >(); 
            services.AddTransient<IProductosService,  ProductosService >(); 
        }

        public void configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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
