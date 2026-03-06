using BlazorProject.Components;
using BlazorProject.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        const string connectionString = "Server=127.0.0.1;Port=3306;Database=erd_booking_app ;User ID=admin_reset;Password=NieuwSterkWachtwoord123!;";

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString)));


        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate(); 
        }

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
   
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}