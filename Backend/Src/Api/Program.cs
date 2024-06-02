using System.Text;
using AmazonShop.Domain.Models.System;
using AmazonShop.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Internal;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AmazonShopDbContext>((opt)=>{
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("DBConnectionString"),
        (x)=>x.MigrationsAssembly(typeof(AmazonShopDbContext).Assembly.FullName) //consultas por consola
    );
});

builder.Services.AddControllers((opt)=>{
    //hara que todos los usuarios accedan si estan logueados
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});

//IDENTITY AND SECURITY
//===========================================================================================

IdentityBuilder identityBuilder = builder.Services.AddIdentityCore<User>();
identityBuilder = new IdentityBuilder(identityBuilder.UserType, identityBuilder.Services);

identityBuilder.AddRoles<IdentityRole>().AddDefaultTokenProviders();
identityBuilder.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<User, IdentityRole>>();

identityBuilder.AddEntityFrameworkStores<AmazonShopDbContext>();
identityBuilder.AddSignInManager<SignInManager<User>>();

builder.Services.TryAddSingleton<Microsoft.Extensions.Internal.ISystemClock, Microsoft.Extensions.Internal.SystemClock>();

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer((opt)=>{
                    opt.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });

builder.Services.AddCors((opt)=>{
    opt.AddPolicy(
        "CorsPolicy", 
        (b)=>b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});

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

// app.UseHttpsRedirection();

app.UseAuthentication(); //added
app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
