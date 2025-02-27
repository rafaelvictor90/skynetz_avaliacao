using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynetz.Application.DTOs
{
    public class PlanFaleMaisDTO
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public string Name { get; set; }
        public int MinuteTime { get; set; }
        public string WithFalaMais { get; set; }
        public string WithoutFalaMais { get; set; }
    }
}
