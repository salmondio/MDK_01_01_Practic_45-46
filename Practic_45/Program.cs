var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("get", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "get",
        Title = "GET Запросы",
        Description = "Все GET запросы API"
    });
    option.SwaggerDoc("post", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "post",
        Title = "POST Запросы",
        Description = "Все POST запросы API"
    });
    option.SwaggerDoc("put", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "put",
        Title = "PUT Запросы",
        Description = "Все PUT запросы API"
    });

    string PathFile = Path.Combine(System.AppContext.BaseDirectory, "Practic_45.xml");
    option.IncludeXmlComments(PathFile);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Запросы GET");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Запросы POST");
});
app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});
app.Run();
