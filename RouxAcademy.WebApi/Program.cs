using Microsoft.AspNetCore.DataProtection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("RouxAcademy",
        builder =>
        builder.WithOrigins("http://localhost:4171")
            .WithMethods("GET")
            .AllowAnyHeader()
    );
});

builder.Services.AddDataProtection()
               .DisableAutomaticKeyGeneration()
               .SetDefaultKeyLifetime(new TimeSpan(14, 0, 0, 0));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
// app.UseCors("RouxAcademy");
app.MapControllers();

app.Run();
