using Microsoft.EntityFrameworkCore;
using WebServer.Data;
using WebServer.Repository.Interfaces;
using WebServer.Repository;
using WebServer.Services;
using WebServer.Services.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using WebServer.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=app.db");
    //options.UseOpenIddict();
});


//builder.Services.AddOpenIddict()
//    .AddCore(options =>
//    {
//        options.UseEntityFrameworkCore()
//               .UseDbContext<AppDbContext>();
//    })
//    .AddServer(options =>
//    {
//        options.SetTokenEndpointUris("/login");  
//        options.AllowPasswordFlow();                       

//        options.AcceptAnonymousClients();               
//        options.DisableAccessTokenEncryption();          

        
//        options.AddEphemeralSigningKey();
//    })
//    .AddValidation(options =>
//    {
//        options.UseLocalServer();                        
//        options.UseAspNetCore();                        
//    });

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
