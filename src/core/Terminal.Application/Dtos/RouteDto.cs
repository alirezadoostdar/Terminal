﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Application.Dtos;

public class RouteDto
{
    public int Id { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public decimal BasePrice { get; set; }
}


public class RouteComboDto
{
    public int Id { get; set; }
    public string Title { get; set; }
}