using Skynetz.Domain.Entities;
using Skynetz.Domain.Interfaces;
using Skynetz.Infra.Data.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Skynetz.Infra.Data.Repositories
{
    public class FlatRateRepository : IFlatRateRepository
    {
        private ApplicationDbContext _context;

        public FlatRateRepository()
        {
            _context = new ApplicationDbContext();
        }

        public FlatRate Create(FlatRate flatRate)
        {
            _context.flatRates.Add(flatRate);
            _context.SaveChanges();
            return flatRate;
        }

        public FlatRate GetById(int? id)
        {
            var flatRate = _context.flatRates.SingleOrDefault(f => f.Id == id);
            return flatRate;
        }

        public IEnumerable<FlatRate> GetByOriginAndDestiny(string origin, string destiny)
        {
            var flatRates = _context.flatRates.Where(f => f.Origin.Equals(origin) && f.Destiny.Equals(destiny)).ToList();
            return flatRates;
        }

        public IEnumerable<FlatRate> GetFlatRate()
        {
            return _context.flatRates.ToList();
        }

        public FlatRate Remove(FlatRate flatRate)
        {
            _context.flatRates.Remove(flatRate);
            _context.SaveChanges();
            return flatRate;
        }

        public FlatRate Update(FlatRate flatRate)
        {
            _context.flatRates.AddOrUpdate(flatRate);
            _context.SaveChanges();
            return flatRate;
        }
    }
}