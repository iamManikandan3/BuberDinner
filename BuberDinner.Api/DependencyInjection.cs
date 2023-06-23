using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Common.Mappings;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

            services.AddMappingsServices();
            return services;
        }
    }
}
