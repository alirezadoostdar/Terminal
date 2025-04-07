using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Entities;

namespace Terminal.Domain.Interfaces;

public interface IRouteRepository
{
    void Add(Route route);
    void Remove(int id);
    void Update(Route route);
    IEnumerable<Route> GetAll();
    bool IsUsed(int id);
}
