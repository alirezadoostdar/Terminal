using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Application.Services;

namespace Terminal.Application;

public static class ConfigureServices
{
    public static IServiceCollection RegisterApplicationService(this IServiceCollection services)
    {
        services.AddScoped<BusService>();
        services.AddScoped<RouteService>();
        services.AddScoped<TripService>();
        services.AddScoped<TicketService>();
        return services;
    }
}
