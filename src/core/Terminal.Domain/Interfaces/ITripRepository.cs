using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Entities;

namespace Terminal.Domain.Interfaces;

public interface ITripRepository
{
    void Add(Trip trip);
    void Remove(int id);
    void Update(Trip trip);
    IEnumerable<Trip> GetAll();
    Trip Get(int id);
    IEnumerable<Trip> GetValidList();
    IEnumerable<Trip> GetByRouteId(int id);
    bool HasTicket(int id);
}
