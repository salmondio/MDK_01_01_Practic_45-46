var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddMvc(option => option.EnableEndpointRouting = true);
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Пробная версия 1"
    });
    //option.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
    //{
    //    Version = "v2",
    //    Title = "Пробная версия 2"
    //});

    String PathFile = Path.Combine(System.AppContext.BaseDirectory, "Practic_45.xml");
    option.IncludeXmlComments(PathFile);
});

var app = builder.Build();

app.UseSwagger();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Запросы GET");
    //c.SwaggerEndpoint("/swagger/v2/swagger.json", "Запросы POST");
});
app.Run();
