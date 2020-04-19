using Identity.Abstractions;
using Identity.Models;
using Identity.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Identity
{
    public static class ServiceExtensions
    {
        ///<summary>
        /// Добавление сервисов авторизации
        /// </summary>
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, Action<IdentityOptions> configure)
        {
            var options = new IdentityOptions();
            configure(options);
            services.AddSingleton(options);

            //Services
            services.AddScoped<ITokenAuthorization, JwtTokenAuthService>();

            //SessionContext
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
