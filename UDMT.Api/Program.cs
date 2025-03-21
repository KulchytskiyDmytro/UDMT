using UDMT.Application.Services;
using UDMT.Domain;

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
    
    builder.Services.AddOpenApi();
    builder.Services.AddControllers(); 
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(o => { o.UseAllOfToExtendReferenceSchemas(); });

    builder.Services.AddDatabase(builder.Configuration);
            
    builder.Services.AddScoped<IPlayerService, PlayerService>();
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