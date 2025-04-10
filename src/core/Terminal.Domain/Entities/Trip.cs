using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Domain.Entities;

public class Trip
{
    public int Id { get; set; }
    public string Code{ get; set; }
    public int RouteId { get; set; }
    public Route Route { get; set; }
    public DateTime DateTime { get; set; }
    public int BusId { get; set; }
    public Bus Bus { get; set; }

}
