using Havalan.Application;
using Havalan.Infrastructure;

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

        services.ConfigureAutoMapper();
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

        app.Run();
    }
}