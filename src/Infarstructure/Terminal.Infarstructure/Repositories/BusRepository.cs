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

    public void Delete(int id)
    {
        var bus = context.Buses.First(x => x.Id == id);

        context.Buses.Remove(bus);
        context.SaveChanges();
       
    }

    public Bus Get(int id)
    {
        return context.Buses.First(x => x.Id == id);
    }

    public IEnumerable<Bus> GetAll()
    {
        return context.Buses.ToList();
    }

    public bool IsUsed(int id)
    {
      return  context.Trips.Any(x => x.Bus.Id == id);
    }

    public void Update(Bus bus)
    {
        var data = context.Buses.First(x => x.Id ==  bus.Id);   

        data.Title = bus.Title;
        data.Rate = bus.Rate;
        data.Code = bus.Code;   
        data.Capacity = bus.Capacity;
        data.Model = bus.Model;
        context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        context.SaveChanges();
    }
}
