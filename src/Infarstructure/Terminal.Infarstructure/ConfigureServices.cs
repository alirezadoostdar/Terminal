using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Interfaces;
using Terminal.Infarstructure.Repositories;

namespace Terminal.Infarstructure;

public static class ConfigureServices
{
    public static IServiceCollection RegisterInfrastructureService(this IServiceCollection services)
    {
        services.AddScoped<IBusRepository,BusRepository>();
        services.AddScoped<IRouteRepository,RouteRepository>();
        services.AddScoped<ITripRepository,TripRepository>();
        services.AddScoped<ITicketRepository,TicketRepository>();
        return services;
    }
}
