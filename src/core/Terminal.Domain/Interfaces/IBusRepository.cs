using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Domain.Entities;

namespace Terminal.Domain.Interfaces;

public interface IBusRepository
{
    void Add(Bus bus);
    IEnumerable<Bus> GetAll();
    void Delete(int id);
    bool IsUsed(int id);
    void Update(Bus bus);
    Bus Get(int id);
}
