using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Application.Dtos;
using Terminal.Domain.Interfaces;
using Terminal.Domain.Entities;
namespace Terminal.Application.Services;

public class TripService
{
    private readonly ITripRepository tripRepository;
    private readonly IRouteRepository routeRepository;
    private readonly IBusRepository busRepository;

    public TripService(ITripRepository tripRepository,
                       IRouteRepository routeRepository, 
                       IBusRepository busRepository)
    {
        this.tripRepository = tripRepository;
        this.routeRepository = routeRepository;
        this.busRepository = busRepository;
    }

    public void Add(TripDto trip)
    {
        var bus = busRepository.Get(trip.BusId);
        var route = routeRepository.Get(trip.RouteId);
        tripRepository.Add(new Trip
        {
            Id = 0,
            Code = GenerateCode(trip.DateTime),
            Bus = bus,
            Route = route,
            DateTime = trip.DateTime,
        });
    }

    public string GenerateCode(DateTime date)
    {
        return $"{date.Year}{date.Month}{date.Day}{date.Hour}";
    }
    public void Update(TripDto trip)
    {
        var bus = busRepository.Get(trip.BusId);
        var route = routeRepository.Get(trip.RouteId);
        tripRepository.Update(new Trip
        {
            Id = trip.Id,
            Code = GenerateCode(trip.DateTime),
            Bus = bus,
            Route = route,
            DateTime = trip.DateTime,
        });
    }

    public void Delete(int id)
    {
        tripRepository.Remove(id);
    }
    public IEnumerable<TripListDto> GetAll()
    {
        return tripRepository.GetAll().Select(x => new TripListDto
        {
            Id = x.Id,
            Capacity = x.Bus.Capacity,
            Destination = x.Route.Destination,
            Origin = x.Route.Origin,
            Bus = $"{x.Bus.Title} - {x.Bus.Model}",
            Code = x.Code,
            DateTime = x.DateTime,
            Price = x.Route.BasePrice * x.Bus.Rate,
            BusId = x.Bus.Id,
            RouteId = x.Route.Id,
        });
    }

    public IEnumerable<TripListDto> GetByRouteId(int routeId)
    {
        return tripRepository.GetByRouteId(routeId).Select(x => new TripListDto
        {
            Id = x.Id,
            Capacity = x.Bus.Capacity,
            Destination = x.Route.Destination,
            Origin = x.Route.Origin,
            Bus = $"{x.Bus.Title} - {x.Bus.Model}",
            Code = x.Code,
            DateTime = x.DateTime,
            Price = x.Route.BasePrice * x.Bus.Rate,
            BusId = x.Bus.Id,
            RouteId = x.Route.Id,
        });
    }
}
