using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RevendaVeicular;
using RevendaVeicular.Infra;
using RevendaVeicular.Model;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configuração do SwaggerGen
builder.Services.AddSwaggerGen(c =>
{ 

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
    {
        new OpenApiSecurityScheme
        {
        Reference = new OpenApiReference
            {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,

        },
        new List<string>()
        }
    });


});


builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IEmployerRepository, EmployerRepository>();
var key = Encoding.ASCII.GetBytes(Key.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ManagerPolicy", policy =>
        policy.RequireClaim("Role", "manager"));

    options.AddPolicy("SalesPolicy", policy =>
        policy.RequireClaim("Role", "seller"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Middleware para servir o documento Swagger gerado como um endpoint JSON
    app.UseSwagger();

    // Middleware para servir a UI Swagger gerada
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RevendaVeicular API V1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

