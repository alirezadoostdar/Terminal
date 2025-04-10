using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Application.Dtos;
using Terminal.Domain.Interfaces;
using Terminal.Domain.Entities;

namespace Terminal.Application.Services;

public class TicketService
{
    private readonly ITicketRepository ticketRepository;
    private readonly ITripRepository tripRepository;

    public TicketService(ITicketRepository ticketRepository,ITripRepository tripRepository)
    {
        this.ticketRepository = ticketRepository;
        this.tripRepository = tripRepository;
    }

    public IEnumerable<TicketListDto> GetAll()
    {
        return ticketRepository.GetAll().Select(x => new TicketListDto
        {
            Id = x.Id,
            FristName = x.FirstName,
            LastName = x.LastName,
            Origin = x.Trip.Route.Origin,
            Destination = x.Trip.Route.Destination, 
            TripDate = x.Trip.DateTime,
            Bus = x.Trip.Bus.Title,
            Price = x.Trip.Route.BasePrice * x.Trip.Bus.Rate,
            TripId = x.Trip.Id
        });
    }

    public void Add(TicketDto ticket) 
    {
        ticketRepository.Add(new Ticket
        {
            Id = ticket.Id,
            FirstName = ticket.FirstName,
            LastName = ticket.LastName,
            TripId = ticket.TripId,
        });
    }

    public void Remove(int id)
    {
        ticketRepository.Remove(id);
    }

    public void Update(TicketDto ticket)
    {
        ticketRepository.Update(new Ticket
        {
            Id = ticket.Id,
            FirstName = ticket.FirstName,
            LastName = ticket.LastName,
            TripId = ticket.TripId
        });
    }
}
