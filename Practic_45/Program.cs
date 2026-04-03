var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "GET Запросы",
        Description = "Все GET запросы API"
    });
    option.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v2",
        Title = "POST Запросы",
        Description = "Все POST запросы API"
    });
    option.SwaggerDoc("v3", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v3",
        Title = "PUT Запросы",
        Description = "Все PUT запросы API"
    });

    //string PathFile = Path.Combine(System.AppContext.BaseDirectory, "Practic_45.xml");
    //option.IncludeXmlComments(PathFile);
});

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Запросы GET");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Запросы POST");
    c.SwaggerEndpoint("/swagger/v3/swagger.json", "Запросы POST");

    c.DocumentTitle = "API Документация";
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});
app.Run();
