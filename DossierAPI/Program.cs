using DossierAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DossierContext>(opt =>
    opt.UseSqlite("DefaultConnection"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "API dossier de voyage",
            Description = "API permettant de récupérer les informations et de gérer les dossier de voyage.",
            Contact = new OpenApiContact
            {
                Name = "Gédéon NFONGYELE",
                Email = "g.nfongyele@gmail.com"
            }
        });

        string xmlPath = Path.Combine(AppContext.BaseDirectory, "Swagger.xml");
        c.IncludeXmlComments(xmlPath);
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
