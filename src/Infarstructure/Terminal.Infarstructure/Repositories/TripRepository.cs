using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Entities;
using Terminal.Domain.Interfaces;

namespace Terminal.Infarstructure.Repositories;

public class TripRepository : ITripRepository
{
    private readonly TerminalDbContext context;

    public TripRepository(TerminalDbContext context)
    {
        this.context = context;
    }

    public void Add(Trip trip)
    {
        context.Trips.Add(trip);
        context.SaveChanges();
    }

    public Trip Get(int id)
    {
        return context.Trips.First(t => t.Id == id);
    }

    public IEnumerable<Trip> GetAll()
    {
        return context.Trips.ToList();
    }

    public IEnumerable<Trip> GetByRouteId(int id)
    {
        return context.Trips.Where(x => x.Route.Id == id);
    }

    public IEnumerable<Trip> GetValidList()
    {
        return context.Trips.Where(x => x.DateTime > DateTime.Now).ToList();
    }

    public void Remove(int id)
    {
        var trip = context.Trips.First(x => x.Id == id);
        context.Trips.Remove(trip);
        context.SaveChanges();
    }

    public void Update(Trip trip)
    {
        var data = context.Trips.First(x => x.Id == trip.Id);

        data.DateTime = DateTime.Now;
        data.Code = trip.Code;
        data.Bus = trip.Bus;
        data.Route = trip.Route;

        context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        context.SaveChanges();
    }
}
