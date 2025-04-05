using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Entities;

namespace Terminal.Infarstructure;

public class TerminalDbContext : DbContext
{
    public TerminalDbContext(DbContextOptions options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
       
    }

    public DbSet<Bus> Buses { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}
