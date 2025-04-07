using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Application.Dtos;
using Terminal.Domain.Interfaces;
using Terminal.Domain.Entities;
namespace Terminal.Application.Services;

public class RouteService
{
    private readonly IRouteRepository routeRepository;

    public RouteService(IRouteRepository routeRepository)
    {
        this.routeRepository = routeRepository;
    }

    public void Add(RouteDto route)
    {
        if (route == null) 
            throw new ArgumentNullException(nameof(route));

        routeRepository.Add(new Route
        {
            Id = route.Id,
            Destination = route.Destination,
            BasePrice = route.BasePrice,
            Origin = route.Origin,
        });
    }

    public void Remove(int id)
    {
        if (routeRepository.IsUsed(id))
            throw new Exception("You can not delete this Route, Because is used already in some Trips");

        routeRepository.Remove(id);
    }

    public void Update(RouteDto route)
    {
        routeRepository.Update(new Route
        {
            Id = route.Id,
            Destination = route.Destination,
            BasePrice = route.BasePrice,
            Origin = route.Origin,

        });
    }

    public IEnumerable<RouteDto> GetAll()
    {
        return routeRepository.GetAll().Select(x => new RouteDto
        {
            Id = x.Id,
            Destination = x.Destination,
            BasePrice = x.BasePrice,
            Origin = x.Origin
        });
    }

    public IEnumerable<RouteComboDto> ComboList()
    {
        return routeRepository.GetAll().Select(x => new RouteComboDto
        {
            Id = x.Id,
            Title = $"{x.Origin} To {x.Destination} - Base Price: {x.BasePrice.ToString("c")}",
        });
    }
}
