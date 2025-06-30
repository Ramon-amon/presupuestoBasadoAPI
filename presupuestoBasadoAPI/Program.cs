using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Registrar DbContext con SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// 3. Agregar Identity con soporte de roles
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// 4. Agregar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 5. Habilitar autenticación y autorización (para uso posterior con JWT)
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ⚠️ Importante: primero Autenticación, luego Autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
