using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Memory
    {
        private List<string> commands;
        private List<string> answers;
        private Dictionary<string, int> constants;

        public Memory()
        {
            commands = new List<string>();
            answers = new List<string>();
            constants = new Dictionary<string, int>();
        }

        public string Lastq
        {
            get
            {
                if(commands.Count() == 0)
                {
                    return "There are no commands stored.";
                } else
                {
                return commands[commands.Count - 1];
                }
            }
            set
            {
                 commands.Add(value);
            }
        }
        public string Last
        {
            get
            {
                if (answers.Count() == 0)
                {
                    return "There are no answers stored.";
                }
                return answers[answers.Count - 1];
            }
            set
            {
                answers.Add(value);
            }
        }

        public Dictionary<string, int> Constants
        {
            get
            {
                return constants;
            }
        }

        public void AddConstant(string s, int i)
        {
            if (constants.ContainsKey(s))
            {
                throw new ArgumentException();
            }
            else
            {
                constants[s] = i;
            }
        }
    }
}
