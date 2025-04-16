using NeerCore.DependencyInjection.Extensions;
using UDMT.Application.Configure;
using UDMT.Domain;
using UDMT.Domain.Context;

var builder = WebApplication.CreateBuilder(args);
ConfigureBuilder(builder);

var app = builder.Build();
ConfigureWebApp(app);

app.UseRouting();
app.MapControllers();
app.Run();


static void ConfigureBuilder(WebApplicationBuilder builder)
{
    builder.Configuration.AddJsonFile("appsettings.Local.json");
    builder.Configuration.AddJsonFile("appsettings.Development.json");
    
    MapsterConfig.RegisterMappings();
    
    builder.Services.AddOpenApi();
    builder.Services.AddControllers(); 
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(o => { o.UseAllOfToExtendReferenceSchemas(); });
    
    builder.Services.AddDatabase(builder.Configuration);

    // Services registration
    builder.Services.AddScoped<IAppDbContext, AppDbContext>();
    builder.Services.AddAllServices(o => o.ResolveInternalImplementations = true);

}

static void ConfigureWebApp(WebApplication app)
{
    app.UseSwagger();
    
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}