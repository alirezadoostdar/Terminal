using Terminal.Domain.Entities;
using Terminal.Domain.Interfaces;

namespace Terminal.Infarstructure.Repositories;

public class BusRepository : IBusRepository
{
    private readonly TerminalDbContext context;

    public BusRepository(TerminalDbContext context)
    {
        this.context = context;
    }

    public void Add(Bus bus)
    {
        context.Buses.Add(bus);
        context.SaveChanges();
    }

    public IEnumerable<Bus> GetAll()
    {
        return context.Buses.ToList();
    }
}
