using Skynetz.Domain.Entities;
using System.Collections.Generic;

namespace Skynetz.Domain.Interfaces
{
    public interface IPlanFaleMaisRepository
    {
        IEnumerable<PlanFaleMais> GetPlanFaleMais();
        PlanFaleMais GetById(int? id);

        PlanFaleMais Create(PlanFaleMais planFaleMais);
        PlanFaleMais Update(PlanFaleMais planFaleMais);
        PlanFaleMais Remove(PlanFaleMais planFaleMais);
    }
}
