using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace target_test
{
    public class StatesMontly(string state, double value)
    {
        public string State { get; set; } = state;
        public double Value { get; set; } = value;
    }
}
