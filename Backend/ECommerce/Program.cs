using ECommerce.Database;
using ECommerce.Models;
using ECommerce.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// CORS Policy
var CORSPolicy = "MyCORSPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORSPolicy, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();

// add DBContext
builder.Services.AddDbContext<Entity>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// add identity package
builder.Services.AddAuthorization();
//builder.Services.AddIdentityApiEndpoints<ApplicationUser>().AddEntityFrameworkStores<Entity>();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<Entity>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapIdentityApi<ApplicationUser>();

app.UseHttpsRedirection();

app.UseCors(CORSPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
