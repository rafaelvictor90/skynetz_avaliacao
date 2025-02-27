using Skynetz.Application.DTOs;
using System.Collections.Generic;

namespace Skynetz.Application.Interfaces
{
    public interface IPlanFaleMaisService
    {
        IEnumerable<PlanFaleMaisDTO> GetPlanFaleMais();
        IEnumerable<PlanFaleMaisDTO> GetBySearch(string origin, string destiny, int minutes, int idFalaMais);
        PlanFaleMaisDTO GetById(int? id);
        void Add(PlanFaleMaisDTO planFaleMaisDTO);
        void Update(PlanFaleMaisDTO planFaleMaisDTO);
        void Remove(int? id);
    }
}