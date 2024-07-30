using ManagamentSystem.Core.Constant;
using ManagementSystem.WebAPI.Infrastructure;
using ManagementSystem.WebAPI.Infrastructure.Extensions.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
	o.TokenValidationParameters = new TokenValidationParameters
	{
		ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
		ValidAudience = builder.Configuration["JWT:ValidAudience"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]?.ToString() ?? "_noconfiguration")),
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = false,
		ValidateIssuerSigningKey = true
	};
});
builder.Services.AddAuthorization(options =>
{
	foreach (string item in Permissions.GetPermissions())
	{
		options.AddPolicy(item, policy =>
		{
			policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
			policy.RequireClaim("CustomPermissions", item);
		});
	}
});


builder.ConfigureBuilder();



builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.AddSwaggerUIServices(app.Environment);

app.MapControllers();
app.Run();
