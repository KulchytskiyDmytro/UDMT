using Microsoft.EntityFrameworkCore;
using NeerCore.Api.Extensions;
using NeerCore.Api.Swagger.Extensions;
using UDMT.Application.Services;
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
    builder.Services.AddOpenApi();
    builder.Services.AddControllers(); 
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(o => { o.UseAllOfToExtendReferenceSchemas(); });
    
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer("Data Source=localhost;Initial Catalog=UDMT;User Id=admin;Password=admin;MultipleActiveResultSets=true;TrustServerCertificate=True"));
            
    builder.Services.AddScoped<IPlayerService, PlayerService>();
}

static void ConfigureWebApp(WebApplication app)
{
    app.UseSwagger();
    
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Если хотите, чтобы UI отображался на корне сайта
    });
}