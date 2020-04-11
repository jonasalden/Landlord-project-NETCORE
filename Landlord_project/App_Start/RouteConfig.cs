using Microsoft.AspNetCore.Builder;

namespace Landlord_project.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "CustomRoute",
                pattern: "hem/{action=Index}/{id?}",
                defaults: new { controller = "Home" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
