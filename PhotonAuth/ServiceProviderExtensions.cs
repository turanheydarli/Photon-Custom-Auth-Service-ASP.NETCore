using Microsoft.EntityFrameworkCore;
using PhotonAuth.DataAccess;

namespace PhotonAuth;

public static class ServiceProviderExtensions
{
    public static IServiceProvider ApplyMigrations(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ProjectDbContext>();
        try
        {
            context.Database.Migrate();
        }
        catch
        {
            // ignored
        }

        return serviceProvider;
    }
}