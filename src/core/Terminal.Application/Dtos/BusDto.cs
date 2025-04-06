using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Application.Dtos;

public class BusDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Capacity { get; set; }
    public int Code { get; set; }
    public decimal Rate { get; set; }
    public string Model { get; set; }
}
