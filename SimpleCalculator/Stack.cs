using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Stack
    {
        public string Lastq { get; set; }
        public int Last { get; set; }
        public Stack() { }
        public Stack(string lastq, int last)
        {
            Lastq = lastq;
            Last = last;
        }
    }
}
