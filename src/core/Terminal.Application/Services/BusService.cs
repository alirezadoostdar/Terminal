using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Application.Dtos;
using Terminal.Domain.Interfaces;
using Terminal.Domain.Entities;

namespace Terminal.Application.Services;

public class BusService
{
    private readonly IBusRepository busRepository;

    public BusService(IBusRepository busRepository)
    {
        this.busRepository = busRepository;
    }

    public void Add(BusDto bus)
    {
        if (bus == null)
            throw new ArgumentNullException(nameof(bus));

        busRepository.Add(new Bus
        {
            Id = bus.Id,
            Title = bus.Title,
            Capacity = bus.Capacity,
            Code = bus.Code,
            Model = bus.Model,
            Rate = bus.Rate,
        });
    }

    public void Update(BusDto bus)
    {
        if(bus == null)
            throw new ArgumentNullException(nameof(bus));

        busRepository.Update(new Bus
        {
            Id= bus.Id,
            Title = bus.Title,
            Capacity = bus.Capacity,
            Code = bus.Code,
            Model = bus.Model,
            Rate = bus.Rate,
        });
    }

    public void Delete(int id)
    {
        if (busRepository.IsUsed(id))
            throw new Exception("you can not delete this item because used another part of app");

        busRepository.Delete(id);

    }
    public List<BusDto> GetAll()
    {
        return busRepository.GetAll().Select(x => new BusDto
        {
            Id = x.Id,
            Capacity = x.Capacity,
            Code = x.Code,
            Model = x.Model,
            Rate = x.Rate,
            Title = x.Title
        }).ToList();
    }
}
