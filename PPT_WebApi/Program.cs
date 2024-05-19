using Microsoft.EntityFrameworkCore;
using PPTWebApiService.DataAccess.Data;
var PPTAllowSpecificOrigins = "_PPTAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
var allowedOrigines = builder.Configuration.GetSection("AllowedCrossDomainHosts").Value;
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: PPTAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(allowedOrigines)
                           .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<AppDbContext>
       (o => o.UseSqlite(builder.Configuration.GetConnectionString("PPTWebApiConn")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IImageRepo, ImageRepo>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(PPTAllowSpecificOrigins);

app.UseAuthorization();
app.MapControllers();

app.Run();

