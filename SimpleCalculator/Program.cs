using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            string prompt = $"[{count.ToString()}]> ";
            string answer = "";
            Evaluate eval = new Evaluate();

            while (answer != "exit")
            {
                Console.Write(prompt);
                string response = Console.ReadLine();

                Parse parse = new Parse(response);
                eval.ParsedInput = parse;
                eval.Execute();
                Console.WriteLine($"   = {eval.Answer}");
                answer = eval.Answer;
                count++;
                prompt = $"[{count.ToString()}]> ";
            }
            Console.WriteLine("Bye!!");
        }
    }
}
