using Skynetz.Domain.Entities;
using Skynetz.Domain.Interfaces;
using Skynetz.Infra.Data.Context;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Skynetz.Infra.Data.Repositories
{
    public class PlanFaleMaisRepository : IPlanFaleMaisRepository
    {
        private ApplicationDbContext _context;

        public PlanFaleMaisRepository()
        {
            _context = new ApplicationDbContext();
        }

        public PlanFaleMais Create(PlanFaleMais planFaleMais)
        {
           _context.planFaleMais.Add(planFaleMais);
            _context.SaveChanges();
            return planFaleMais;
        }

        public PlanFaleMais GetById(int? id)
        {
            var planFaleMais = _context.planFaleMais.SingleOrDefault(p => p.Id == id);
            return planFaleMais;
        }

        public IEnumerable<PlanFaleMais> GetPlanFaleMais()
        {
            return _context.planFaleMais.ToList();
        }

        public PlanFaleMais Remove(PlanFaleMais planFaleMais)
        {
            _context.planFaleMais.Remove(planFaleMais);
            _context.SaveChanges();
            return planFaleMais;
        }

        public PlanFaleMais Update(PlanFaleMais planFaleMais)
        {
            _context.planFaleMais.AddOrUpdate(planFaleMais);
            _context.SaveChanges();
            return planFaleMais;
        }
    }
}