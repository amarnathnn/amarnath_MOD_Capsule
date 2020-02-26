using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MOD.AuthenticationService;
using MOD.AuthenticationService.Models;
using MOD.SearchService.Repository;
using System.Text;

namespace MOD.Authentication
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
            services.AddCors(c => c.AddPolicy("CorsPolicy", options => options.AllowAnyOrigin()
                                                                               .AllowAnyMethod()
                                                                               .AllowAnyHeader()
                                                                               .AllowCredentials()
            ));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<AuthenticationContext>(o => o.UseSqlServer(Configuration.GetConnectionString("MODDB")));
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
            services.Configure<Settings>(options => options.Secret = Configuration.GetSection("AppSettings:SECRET").Value);
            var secret = Configuration.GetValue<string>("AppSettings:SECRET");
            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(x =>
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

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.UseCors(options => options.AllowAnyOrigin());
            app.UseCors("CorsPolicy");

            app.UseMvc();
            app.UseAuthentication();
        }
    }
}
