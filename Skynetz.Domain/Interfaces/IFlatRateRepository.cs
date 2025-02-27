using Skynetz.Domain.Entities;
using System.Collections.Generic;

namespace Skynetz.Domain.Interfaces
{
    public interface IFlatRateRepository
    {
         IEnumerable<FlatRate> GetFlatRate();
         IEnumerable<FlatRate> GetByOriginAndDestiny(string origin, string destiny);

         FlatRate GetById(int? id);
         FlatRate Create(FlatRate flatRate);
         FlatRate Update(FlatRate flatRate);
         FlatRate Remove(FlatRate flatRate);
    }
}
