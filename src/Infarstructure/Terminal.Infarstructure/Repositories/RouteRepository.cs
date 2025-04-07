
using Terminal.Domain.Entities;
using Terminal.Domain.Interfaces;

namespace Terminal.Infarstructure.Repositories;

public class RouteRepository : IRouteRepository
{
    private readonly TerminalDbContext context;

    public RouteRepository(TerminalDbContext context)
    {
        this.context = context;
    }

    public void Add(Route route)
    {
        context.Routes.Add(route);
        context.SaveChanges();
    }

    public Route Get(int id)
    {
        return context.Routes.First(x => x.Id == id);
    }

    public IEnumerable<Route> GetAll()
    {
        return context.Routes.ToList();
    }

    public bool IsUsed(int id)
    {
        return context.Trips.Any(x => x.Route.Id == id);
    }

    public void Remove(int id)
    {
        var route = context.Routes.First(x => x.Id == id);

        context.Routes.Remove(route);
        context.SaveChanges();
    }

    public void Update(Route route)
    {
        var data = context.Routes.First(x => x.Id == route.Id);

        data.Origin = route.Origin;
        data.Destination = route.Destination;
        data.BasePrice = route.BasePrice;

        context.Entry(route).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        context.SaveChanges();
    }
}
