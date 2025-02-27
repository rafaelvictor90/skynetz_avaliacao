using Skynetz.Domain.Entities;
using Skynetz.Domain.Validation;
using System;
using System.Collections.Generic;

namespace Skynetz.Domain.Entities
{
    public sealed class FlatRate : Entity
    {
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public decimal MinuteValue { get; set; }

        public FlatRate() { }

        public FlatRate(string origin, string destiny, decimal minuteValue)
        {
            ValidateDomain(origin, destiny, minuteValue);
        }

        public FlatRate(int id, string origin, string destiny, decimal minuteValue)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(origin, destiny, minuteValue);
        }

        public void Update(string origin, string destiny, decimal minuteValue)
        {
            ValidateDomain(origin, destiny, minuteValue);
        }

        private void ValidateDomain(string origin, string destiny, decimal minuteValue)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(origin),
                "Invalid origin is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(destiny),
                "Invalid destiny is required");

            Origin = origin;
            Destiny = destiny;
            MinuteValue = minuteValue;
        }
    }
}