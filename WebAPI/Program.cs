using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.Negotiate;


var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.


//builder.Services
//    .AddAuthentication(HttpSysDefaults.AuthenticationScheme)
//    .AddNegotiate();


//builder.Services
//    .AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//    .AddNegotiate();

//if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
//{
//    builder.WebHost.UseHttpSys(options =>
//    {
//        options.Authentication.Schemes =
//            AuthenticationSchemes.NTLM |
//            AuthenticationSchemes.Negotiate;
//        options.Authentication.AllowAnonymous = false;
//    });
//}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserTestService,UserTestManager> ();
builder.Services.AddSingleton<IUserTestDal,EfUserTestDal> ();
builder.Services.AddSingleton<IVoteLimitDal, EfVoteLimitDal>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsApi",
        builder => builder.WithOrigins( "*")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}


app.UseHttpsRedirection();
app.UseCors("CorsApi");
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
