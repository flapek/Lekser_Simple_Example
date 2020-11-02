using System;

namespace Lekser
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = new[] { "2 + (2 * 34)/1   +323  -  k 1", "2+1+3 +2    /2", "abc", "\t39+5/4*49" };

            foreach (var input in inputs)
            {
                var lekser = new Lekser();
                lekser.Analize(input);
                if (lekser.IsSuccess)
                {
                    Console.WriteLine("A recognized expression.");
                    Console.WriteLine(input);
                    Display(lekser);
                }
                else
                {
                    Console.WriteLine("Unrecognized expression.");
                    Console.WriteLine(input);
                    Console.WriteLine($"Undefined token: {lekser.ExceptionToken}");
                    Display(lekser);
                }
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

        private static void Display(Lekser lekser)
        {
            foreach (var t in lekser.Tokens)
                Console.WriteLine($"<{t.TokenType},{t.Argument}>");
        }
    }
}
