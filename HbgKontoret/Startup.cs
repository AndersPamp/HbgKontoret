using System.Collections.Generic;
using AutoMapper;
using HbgKontoret.Data.Data;
using HbgKontoret.Data.Data.Mapping;
using HbgKontoret.Data.Data.Repositories;
using HbgKontoret.Data.Helpers;
using HbgKontoret.Data.Services;
using HbgKontoret.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;

namespace HbgKontoret
{
    public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddAutoMapper(typeof(EntityToDtoProfile));
      services.AddAutoMapper(typeof(DtoToEntityProfile));

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      #region AddScoped
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IProfileRepository, ProfileRepository>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IProfileService, ProfileService>();
      services.AddScoped<IOfficeRepository, OfficeRepository>();
      services.AddScoped<ICompetenceRepository, CompetenceRepository>();
      //services.AddScoped<IDataSerializer, TicketSerializer>();
      #endregion

      var appSettingsSection = Configuration.GetSection("AppSettings");

      services.Configure<AppSettings>(appSettingsSection);

      var appSettings = appSettingsSection.Get<AppSettings>();
      var key = Encoding.ASCII.GetBytes(appSettings.Secret);

      services.AddMvc(opt => opt.Filters.Add(new RequireHttpsAttribute()));

      #region JwtOnly

      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });

      #endregion

      #region Swagger
      services.AddSwaggerGen(c =>
  {
    c.SwaggerDoc("v1", new Info
    {
      Version = "v1",
      Title = "HbgKontoret"
    });


    c.AddSecurityDefinition("Bearer", new ApiKeyScheme
    {
      Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
      Name = "Authorization",
      In = "header",
      Type = "apiKey"
    });

    var security = new Dictionary<string, IEnumerable<string>>
    {
          {"Bearer", new string[] {  }},
    };

    c.AddSecurityRequirement(security);
  }); 
      #endregion
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      var cookiePolicyOptions = new CookiePolicyOptions();

      app.UseCookiePolicy(cookiePolicyOptions);
      app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
      app.UseAuthentication();
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "default",
          template: "{controller?}/{action?}/{id?}");
      });
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HbgKontoret");
        //c.RoutePrefix = string.Empty;
      });
    }
  }
}
