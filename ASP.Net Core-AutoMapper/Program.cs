using ASP.Net_Core_AutoMapper.Mapping;
using ASP.Net_Core_AutoMapper.Services.Implementations;
using ASP.Net_Core_AutoMapper.Services.Interfaces;

namespace ASP.Net_Core_AutoMapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IPersonService, PersonService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Person}/{action=ListOfPeople}/{id?}");

            app.Run();
        }
    }
}
