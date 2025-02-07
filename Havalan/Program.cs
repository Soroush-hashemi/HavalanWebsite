using Havalan.Application;
using Havalan.Infrastructure;
using Havalan.Web.Configurations;

namespace Havalan;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;

        services.AddRazorPages();

        var ConnectionString = builder.Configuration.GetConnectionString("Default");
        if (ConnectionString is null)
            throw new NullReferenceException("ConnectionString is null");

        services.ConfigureMapper();
        services.AddApplication();
        services.AddInfrastructure(ConnectionString);

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();

        app.MapControllerRoute(
            name: "Admin",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}