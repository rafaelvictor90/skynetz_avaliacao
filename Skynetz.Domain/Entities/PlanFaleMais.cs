using Skynetz.Domain.Validation;

namespace Skynetz.Domain.Entities
{
    public sealed class PlanFaleMais : Entity
    {
        public string Name { get; set; }
        public int MinuteTime { get; set; }

        public PlanFaleMais() { }

        public PlanFaleMais(string name, int minuteTime)
        {
            ValidateDomain(name, minuteTime);
        }

        public PlanFaleMais(int id, string name, int minuteTime)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(name, minuteTime);
        }

        public void Update(string name, int minuteTime)
        {
            ValidateDomain(name, minuteTime);
        }

        private void ValidateDomain(string name, int minuteTime)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name is required");

            Name = name;
            MinuteTime = minuteTime;
        }
    }
}