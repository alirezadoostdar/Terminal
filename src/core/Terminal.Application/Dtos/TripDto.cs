using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Application.Dtos;

public class TripDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public int RouteId { get; set; }
    public int BusId { get; set; }
    public DateTime DateTime { get; set; }
}

public class TripListDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Bus { get; set; }
    public int Capacity { get; set; }
    public decimal Price { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime DateTime { get; set; }
    public int BusId { get; set; }
    public int RouteId { get; set; }
}
