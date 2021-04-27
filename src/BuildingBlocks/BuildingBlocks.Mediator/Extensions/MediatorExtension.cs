using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Mediator.Extensions
{
    public static class MediatorExtension
    {
        public static IServiceCollection AddMediator<TStartup>(this IServiceCollection services)
        {

            services.AddScoped<IMediator, Requests.Implementation.Mediator>();
            return services.AddMediatR(typeof(TStartup).Assembly);

        }
        public static IApplicationBuilder ConfigureMediator(IApplicationBuilder builder)
        {
            return builder;
            //return builder
            //    .RegisterAssemblyTypes(typeof(IRequestHandler<>).Assembly)
            //    .Where(t => t.IsClosedTypeOf(typeof(IRequestHandler<>)))
            //    .AsImplementedInterfaces();
        }
    }
}
