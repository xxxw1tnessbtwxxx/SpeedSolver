using Microsoft.EntityFrameworkCore;
using SpeedSolverDatabase;

namespace SpeedSolverAPI.MigrationHelper
{
    public static class MigrationsHelper
    {

        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using SpeedContext context = scope.ServiceProvider.GetRequiredService<SpeedContext>();

            context.Database.Migrate();
        }

    }
}
