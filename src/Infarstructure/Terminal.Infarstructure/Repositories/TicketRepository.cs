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

    }

    public IEnumerable<Ticket> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Ticket ticket)
    {
        throw new NotImplementedException();
    }
}
