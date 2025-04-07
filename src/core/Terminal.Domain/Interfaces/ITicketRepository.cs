using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Entities;

namespace Terminal.Domain.Interfaces;

public interface ITicketRepository
{
    void Add(Ticket ticket);
    void Update(Ticket ticket);
    void Remove(int id);
    IEnumerable<Ticket> GetAll();
}
