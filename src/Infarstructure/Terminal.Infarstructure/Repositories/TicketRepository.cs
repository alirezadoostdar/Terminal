using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Entities;
using Terminal.Domain.Interfaces;

namespace Terminal.Infarstructure.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly TerminalDbContext context;

    public TicketRepository(TerminalDbContext context)
    {
        this.context = context;
    }

    public void Add(Ticket ticket)
    {
        context.Add(ticket);
        context.SaveChanges();
    }

    public IEnumerable<Ticket> GetAll()
    {
        return context.Tickets.ToList();
    }

    public void Remove(int id)
    {
        var ticket = context.Tickets.First(t => t.Id == id);
        context.Remove(ticket);
        context.SaveChanges();
    }

    public void Update(Ticket ticket)
    {
        var data = context.Tickets.First(x => x.Id == ticket.Id);

        data.FirstName = ticket.FirstName;
        data.LastName = ticket.LastName;
        data.TripId = ticket.TripId;
        context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        context.SaveChanges();
    }
}
