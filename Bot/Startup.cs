using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Bot.Models;
 
namespace Bot
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string con = "Server=ec2-54-216-17-9.eu-west-1.compute.amazonaws.com:5432; Database = d8res2n8jior24; User ID = mdsbrugikhkypc; PASSWORD = 47722fb09dd22681a70e992db13c58a5dce1eba18ae15a7fa585df05c87cf7b9; Trusted_Connection = True";
            // устанавливаем контекст данных
            services.AddDbContext<UsersContext>(options => options.UseSqlServer(con));
 
            services.AddControllers(); // используем контроллеры без представлений
        }
 
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
 
            app.UseRouting();
 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // подключаем маршрутизацию на контроллеры
            });
        }
    }
}
