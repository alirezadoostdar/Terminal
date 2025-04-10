using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Entities;
using Terminal.Infarstructure.Configurations;

namespace Terminal.Infarstructure;

public class TerminalDbContext : DbContext
{
    public TerminalDbContext(DbContextOptions<TerminalDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new BusConfig());
        modelBuilder.ApplyConfiguration(new RouteConfig());
        modelBuilder.ApplyConfiguration(new TripConfig());
        modelBuilder.ApplyConfiguration(new TicketCongig());
    }

    public DbSet<Bus> Buses { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}
