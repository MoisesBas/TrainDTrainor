using Microsoft.AspNetCore.Builder;

namespace TrainDTrainorV2.API.Middleware
{
    public static class ApplicationExtensions
    {
        public static void ConfigureSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Train D Trainor API");
                c.DocExpansion(DocExpansion.None);
                c.DefaultModelExpandDepth(2);
                c.DefaultModelRendering(ModelRendering.Model);
                c.DefaultModelsExpandDepth(-1);
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.EnableDeepLinking();
                c.EnableFilter();
                c.ShowExtensions();
                c.EnableValidator();
                c.InjectStylesheet("/swagger-ui/theme-flattop.css");
            });
        }
    }
}
