    

var builder = WebApplication.CreateBuilder(args);

//add services to container

builder.Services.AddControllers().AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssemblyContaining<Create>();
});
builder.Services.AddApplicationServices(builder.Configuration);

// configure http pipeline
var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv6 v1"));
}

app.UseHttpsRedirection();

//  se remueve porque esta implicitmanete app.UseRouting();

app.UseAuthorization();
app.MapControllers();





using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);
}
catch (Exception ex)
{
    var looger = services.GetRequiredService<ILogger<Program>>();
    looger.LogError(ex, "Error en la migracion");
}

await app.RunAsync();
