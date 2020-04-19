using Database;
using Identity;
using Identity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketApp.Service.PassageService;
using TicketApp.Service.PassageService.Abstractions;
using TicketApp.Service.TicketService;
using TicketApp.Service.TicketService.Abstractions;
using TicketApp.Service.UserService;
using TicketApp.Service.UserService.Abstractions;

namespace TicketApp
{
    public class Startup
    {
        private IdentityOptions IdentityOptions { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            IdentityOptions = new IdentityOptions
            {
                TokenIssuer = "Server",
                TokenAudience = "Audience",
                LifeTime = TimeSpan.FromDays(90),
                SigningKey = "b12e1814-957c-44a9-aa34-d366b6450682"
            };
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Session

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(IdentityOptions.SigningKey)),

                        ValidateIssuer = true,
                        ValidIssuer = IdentityOptions.TokenIssuer,

                        ValidateAudience = true,
                        ValidAudience = IdentityOptions.TokenAudience,

                        ValidateLifetime = true,

                        ClockSkew = TimeSpan.Zero
                    };
                });
            services.AddIdentityServices(options =>
            {
                options.TokenIssuer = IdentityOptions.TokenIssuer;
                options.TokenAudience = IdentityOptions.TokenAudience;
                options.LifeTime = IdentityOptions.LifeTime;
                options.SigningKey = IdentityOptions.SigningKey;
            });

            #endregion

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Авторизация с помощью JWT токена. Пример: Bearer -token-",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                //добавил только это
                options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                    { "Bearer", Enumerable.Empty<string>() }
                });
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPassageService, PassageService>();
            services.AddScoped<ITicketService, TicketService>();

            services.AddDbContext<DatabaseContext>(
                options =>
                    options.UseNpgsql(Configuration["Data:DatabaseConnection:ConnectionString"],
                        o => o.MigrationsAssembly("TicketApp")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}