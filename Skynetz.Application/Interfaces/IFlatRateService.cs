using Skynetz.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skynetz.Application.Interfaces
{
    public interface IFlatRateService
    {
        IEnumerable<FlatRateDTO> GetFlatRates();
        IEnumerable<FlatRateDTO> GetByOriginAndDestiny(string origin, string destiny);
        FlatRateDTO GetById(int? id);
        void Add(FlatRateDTO flatRateDTO);
        void Update(FlatRateDTO flatRateDTO);
        void Remove(int? id);
    }
}
