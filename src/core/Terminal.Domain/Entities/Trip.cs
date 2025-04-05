using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Domain.Entities;

public class Trip
{
    public int Id { get; set; }
    public Route Route { get; set; }
    public DateTime DateTime { get; set; }
    public Bus Bus { get; set; }
    private List<Ticket> Tickets = new();
}
