using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skynetz.Application.DTOs
{
    public class FlatRateDTO
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public decimal MinuteValue { get; set; }
    }
}
