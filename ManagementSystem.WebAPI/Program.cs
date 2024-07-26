using ManagamentSystem.Persistance;
using ManagementSystem.WebAPI.Infrastructure.Extensions.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddPersistenceServices(builder.Configuration);

// Add Swagger services
builder.Services.AddSwaggerServices();

var app = builder.Build();

// Configure middleware
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Configure Swagger UI
app.AddSwaggerUIServices(app.Environment);

app.MapControllers();
app.Run();
