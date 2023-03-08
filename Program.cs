using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

ConfigurationManager Configuration = builder.Configuration;

builder.Services.AddCors(options =>
                    {
                        options.AddPolicy("OpenPolicy",
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                        });
                    });

builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication(); // Should always be above Authorization

app.UseAuthorization();

app.UseCors("OpenPolicy");

app.MapControllers();

app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

// app.Run("http://localhost:7123");
app.Run();
