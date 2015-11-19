using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Parse
    {
        public string Input { get; set; }
        public int FirstArg { get; set; }
        public int SecondArg { get; set; }
        public string Operand { get; set; }
        private char[] delimiters = new char[] { '+', '-', '*', '/', '%' };

        public Parse(string input)
        {
            this.Input = input;
        }

        public Parse()
        {
        }

        public void GetOperand()
        {
            List<string> ops = new List<string>();
            foreach(var c in Input)
            {
                if (delimiters.Contains(c))
                {
                    ops.Add(c.ToString());
                }
            }
            if(ops.Count == 1)
            {
                Operand = ops[0];
            } else
            {
                throw new ArgumentException("Incorrect operator format");
            }
        }

        public void GetArgs()
        {
            if(Input.Count() > 3)
            {
                string[] args = Input.Split(delimiters, StringSplitOptions.None).Select(a => a.Trim()).ToArray();
                if (args.Count() == 2)
                {
                    FirstArg = int.Parse(args[0]);
                    SecondArg = int.Parse(args[1]);
                } else
                {
                    throw new ArgumentException("Incorrect equation format");
                }
            }
            else
            {
                throw new ArgumentException("Incorrect equation format");
            }
        }
    }
}
