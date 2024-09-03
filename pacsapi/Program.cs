using Mahas.Components;
using Mahas.Extensions;
using Mahas.Helpers;
using pacsapi.Repository;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();

builder.Services.AddCors(o => o.AddPolicy("AllowAllOrigin", builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
}));


builder.Services.Configure<AppSettings>(builder.Configuration.GetSection((nameof(AppSettings))));

var appSettings = builder.Configuration.GetSection((nameof(AppSettings))).Get<AppSettings>();

builder.Services.ConfigureSwagger();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSingleton<IAuthorizationHandler, AllowAnonymous>();

};
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<RepositoryWrapper>();


var app = builder.Build();

string namaApi = appSettings.SwaggerEndpointPrefix;


app.UseCors("AllowAllOrigin");
app.UseSwagger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{


    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", namaApi));
}
else
{
    var prefix = string.IsNullOrEmpty(appSettings.SwaggerEndpointPrefix) ? "" : $"/{appSettings.SwaggerEndpointPrefix}";
    app.UseSwaggerUI(c => c.SwaggerEndpoint($"{prefix}/swagger/v1/swagger.json", namaApi));
}

app.UseHttpsRedirection();


app.Use(async (context, next) => {
    context.Request.EnableBuffering();
    await next();
});

app.UseRouting();

app.UseErrorHandlingMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
