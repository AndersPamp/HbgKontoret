using System.Text;
using AutoMapper;
using HbgKontoret.Data.Helpers;
using HbgKontoret.Infrastructure;
using HbgKontoret.Data.Data;
using HbgKontoret.Data.Data.Repositories;
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
using HbgKontoret.Data.Data.Mapping;
using Swashbuckle.AspNetCore.Swagger;

namespace HbgKontoret
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

<<<<<<< Updated upstream
    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
      services.AddAutoMapper(typeof(Startup));

      services.AddCors();
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddScoped<LoginRepository>();
      services.AddScoped<UserRepository>();
      services.AddScoped<ProfileRepository>();
      services.AddScoped<ILoginService, LoginService>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IProfileService, ProfileService>();


      var appSettingsSection = Configuration.GetSection("AppSettings");
      services.Configure<AppSettings>(appSettingsSection);

      var appSettings = appSettingsSection.Get<AppSettings>();
      //var key = Encoding.ASCII.GetBytes(appSettings.Secret);
      //services.AddAuthentication(x =>
      //{
      //  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      //  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      //}).AddJwtBearer(x =>
      //{
      //  x.RequireHttpsMetadata = false;
      //  x.SaveToken = true;
      //  x.TokenValidationParameters = new TokenValidationParameters
      //  {
      //    ValidateIssuerSigningKey = true,
      //    IssuerSigningKey = new SymmetricSecurityKey(key),
      //    ValidateIssuer = false,
      //    ValidateAudience = false
      //  };
      //})
    ;
=======
        readonly string MySpecificOrigins = "_myspecificOrigins";



        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(MySpecificOrigins,
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:44395",
            //                                "http://localhost:3000");
            //        });
            //});

            services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(DtoToEntityProfile));
            services.AddAutoMapper(typeof(EntityToDtoProfile));

            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "HbgKontoret"
                });
            });

            services.AddScoped<LoginRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<ProfileRepository>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();


            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            //services.AddAuthentication(x =>
            //{
            //  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(x =>
            //{
            //  x.RequireHttpsMetadata = false;
            //  x.SaveToken = true;
            //  x.TokenValidationParameters = new TokenValidationParameters
            //  {
            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = new SymmetricSecurityKey(key),
            //    ValidateIssuer = false,
            //    ValidateAudience = false
            //  };
            //})
            ;

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
>>>>>>> Stashed changes


<<<<<<< Updated upstream
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

      //app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

      //app.UseAuthentication();

      app.UseHttpsRedirection();
      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "default",
          template: "{controller?}/{action?}/{id?}");
      });
=======

            //app.UseAuthentication();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //app.UseCors(MySpecificOrigins);
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
            name: "default",
            template: "{controller?}/{action?}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HbgKontoret V1");
            });
        }
>>>>>>> Stashed changes
    }
}
