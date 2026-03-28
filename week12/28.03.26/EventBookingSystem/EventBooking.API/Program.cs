using EventBooking.API.Data;
using EventBooking.API.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

var jwtKey = builder.Configuration["Jwt:Key"]!;
var jwtIssuer = builder.Configuration["Jwt:Issuer"]!;
var jwtAudience = builder.Configuration["Jwt:Audience"]!;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWeb", policy =>
    {
        policy.WithOrigins("http://localhost:5213", "https://localhost:7213")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowWeb");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();

    if (!db.Events.Any())
    {
        db.Events.AddRange(
            new EventBooking.API.Entities.Event
            {
                Title = "Sunburn Music Festival",
                Description = "India's biggest electronic music festival with top DJs from around the world.",
                Date = DateTime.Now.AddDays(15),
                Location = "Pune, Maharashtra",
                TotalSeats = 500,
                AvailableSeats = 500,
                TicketPrice = 1999,
                Category = "Music",
                ImageUrl = "",
                IsActive = true
            },
            new EventBooking.API.Entities.Event
            {
                Title = "Google I/O Extended",
                Description = "A tech conference covering the latest in AI, Android, and Google Cloud.",
                Date = DateTime.Now.AddDays(22),
                Location = "Bangalore, Karnataka",
                TotalSeats = 300,
                AvailableSeats = 300,
                TicketPrice = 999,
                Category = "Tech",
                ImageUrl = "",
                IsActive = true
            },
            new EventBooking.API.Entities.Event
            {
                Title = "IPL Watch Party",
                Description = "Watch the IPL finals live on a giant screen with food and drinks.",
                Date = DateTime.Now.AddDays(8),
                Location = "Mumbai, Maharashtra",
                TotalSeats = 200,
                AvailableSeats = 200,
                TicketPrice = 599,
                Category = "Sports",
                ImageUrl = "",
                IsActive = true
            },
            new EventBooking.API.Entities.Event
            {
                Title = "Delhi Food Festival",
                Description = "Explore 100+ food stalls with cuisines from across India and the world.",
                Date = DateTime.Now.AddDays(30),
                Location = "New Delhi",
                TotalSeats = 1000,
                AvailableSeats = 1000,
                TicketPrice = 299,
                Category = "Food",
                ImageUrl = "",
                IsActive = true
            },
            new EventBooking.API.Entities.Event
            {
                Title = "Modern Art Exhibition",
                Description = "A curated exhibition featuring paintings and sculptures by emerging Indian artists.",
                Date = DateTime.Now.AddDays(10),
                Location = "Hyderabad, Telangana",
                TotalSeats = 150,
                AvailableSeats = 150,
                TicketPrice = 499,
                Category = "Art",
                ImageUrl = "",
                IsActive = true
            },
            new EventBooking.API.Entities.Event
            {
                Title = "Startup Summit 2024",
                Description = "Meet 200+ startups, investors and industry leaders in one place.",
                Date = DateTime.Now.AddDays(45),
                Location = "Chennai, Tamil Nadu",
                TotalSeats = 400,
                AvailableSeats = 400,
                TicketPrice = 1499,
                Category = "Tech",
                ImageUrl = "",
                IsActive = true
            }
        );
        db.SaveChanges();
    }
}

app.Run();