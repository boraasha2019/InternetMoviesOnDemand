using InternetMoviesOnDemand.BusinessAccessLayer.BAL;
using InternetMoviesOnDemand.Data;
using InternetMoviesOnDemand.Helper;
using InternetMoviesOnDemand.Repository.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace InternetMoviesOnDemand
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<UserHelper>();

            services.AddDbContext<InMemoryDataContext>(context => { context.UseInMemoryDatabase("InternetMovies"); });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserBAL, UserBAL>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryBAL, CategoryBAL>();

            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IVideoBAL, VideoBAL>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var signingKey = Convert.FromBase64String(Configuration["Jwt:SigningSecret"]);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKey)
                };
            });

               services.AddAuthorization(option => option.AddPolicy("Role", auth => auth.RequireClaim("role", new string[] { "Administrator", "Viewer" })));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
