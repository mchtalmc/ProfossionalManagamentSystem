using ManagementSystem.WebAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.ConfigureBuilder();



builder.Services.AddHttpContextAccessor();



builder.Services.AddControllers();



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
