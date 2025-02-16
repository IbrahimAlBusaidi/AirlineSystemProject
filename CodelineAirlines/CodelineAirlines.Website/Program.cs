using CodelineAirlines.Shared;
using CodelineAirlines.Website;
using CodelineAirlines.Website.Services;
using CodelineAirlines.Website.Services.AdminServices;
using CodelineAirlines.Website.Services.AppStates;
using CodelineAirlines.Website.Services.Authentication;
using CodelineAirlines.Website.Services.ClientServices;
using CodelineAirlines.Website.Services.NotificationServices;
using CodelineAirlines.Website.Services.WeatherForecast;
using CodelineAirlines.Website.Services.Mapping;
using CodelineAirlines.Shared.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Adding DB Context.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Adding Airport related services.
builder.Services.AddScoped<IAirportRepository, AirportRepository>();
builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IAirportLocationRepository, AirportLocationRepository>();
builder.Services.AddScoped<IAirportLocationService, AirportLocationService>();

// Adding User related services.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Adding Passenger related services.
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IPassengerService, PassengerService>();

// Adding Airplane related servcies.
builder.Services.AddScoped<IAirplaneRepository, AirplaneRepository>();
builder.Services.AddScoped<IAirplaneService, AirplaneService>();

// Adding Airplane specs related services.
builder.Services.AddScoped<IAirplaneSpecRepository, AirplaneSpecRepository>();
builder.Services.AddScoped<IAirplaneSpecService, AirplaneSpecService>();

// Adding Seats Template related services.
builder.Services.AddScoped<ISeatTemplateRepository, SeatTemplateRepository>();
builder.Services.AddScoped<ISeatTemplateService, SeatTemplateService>();

// adding email service
builder.Services.AddSingleton<ISmsService, SmsService>();

// adding email service
builder.Services.AddSingleton<IEmailService, EmailService>();

//adding review related services
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();

//adding booking related services
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();

// Adding Flight related services.
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IFlightService, FlightService>();

// Adding Compound services.
builder.Services.AddScoped<ICompoundService, CompoundService>();

//Adding automapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

//Value Resolvers for AutoMapper
builder.Services.AddScoped<SourceAirportNameResolver>();
builder.Services.AddScoped<DestinationAirportNameResolver>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient<WeatherService>(); // Used for weather forecast.
builder.Services.AddHttpClient<AirportAdditionService>();
builder.Services.AddScoped<SeatSelectionService>();
builder.Services.AddMudServices();

builder.Services.AddSingleton<AppState>();
builder.Services.AddScoped<AuthState>();
builder.Services.AddSingleton<HomePageState>();
builder.Services.AddScoped<BookingState>();
// Add JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
builder.Services.AddSingleton(jwtSettings);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, // You can set this to true if you want to validate the issuer.
        ValidateAudience = false, // You can set this to true if you want to validate the audience.
        ValidateLifetime = true, // Ensures the token hasn't expired.
        ValidateIssuerSigningKey = true, // Ensures the token is properly signed.
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)) // Match with your token generation key.
    };
});
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("user", policy => policy.RequireRole("user"));
    options.AddPolicy("admin", policy => policy.RequireRole("admin"));
    options.AddPolicy("superAdmin", policy => policy.RequireRole("superAdmin"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UseRouting();
app.UseSerilogRequestLogging();

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
