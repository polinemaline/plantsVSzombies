using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using projectY.Data;
using projectY.Manager;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//string connection = builder.Configuration["ConnectionStrings:DefaultConnection"];


// Add services to the container.
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure the HTTP request pipeline.



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));


builder.Services.AddScoped<IManagerYear, ManagerYear>();
builder.Services.AddScoped<IManagerAuthor, ManagerAuthor>();
builder.Services.AddScoped<IManagerBook, ManagerBook>();
builder.Services.AddScoped<IManagerBookingBook,ManagerBookingBook>();
builder.Services.AddScoped<IManagerGenre, ManagerGenre>();
builder.Services.AddScoped<IManagerType, ManagerType>();
builder.Services.AddScoped<IManagerUser, ManagerUser>();
builder.Services.AddScoped<IManagerPublisher, ManagerPublisher>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapFallbackToFile("/Views/Index.cshtml");

app.Run();
