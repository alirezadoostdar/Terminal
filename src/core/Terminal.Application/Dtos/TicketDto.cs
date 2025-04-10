using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Application.Dtos;

public class TicketDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int TripId { get; set; }
}

public class TicketListDto
{
    public int Id { get; set; }
    public string FristName { get; set; }
    public string LastName { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public string Bus { get; set; }
    public decimal Price { get; set; }
    public DateTime TripDate { get; set; }
    public int TripId { get; set; }
}

