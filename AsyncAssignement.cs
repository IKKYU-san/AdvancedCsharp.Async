namespace AdvancedCsharp.Async
{
    using System;
    using System.Threading.Tasks;
    class AsyncAssignement
    {
        class ConsoleService
        {
            void ResetColor()
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            void Write(string s, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(s);
                ResetColor();
            }

            public void WriteResponse(string s)
            {
                Write(s, ConsoleColor.DarkGreen);
            }

            public void WriteError(string s)
            {
                Write(s, ConsoleColor.DarkRed);
            }

            public string GetUserInput()
            {
                ResetColor();
                return Console.ReadLine();
            }

        }

        class MagicProblemSolver
        {
            public static long FindPrimeNumber(long position)
            {
                int count = 0;
                long a = 2;
                while (count < position)
                {
                    long b = 2;
                    int prime = 1;
                    while (b * b <= a)
                    {
                        if (a % b == 0)
                        {
                            prime = 0;
                            break;
                        }
                        b++;
                    }
                    if (prime > 0)
                        count++;
                    a++;
                }
                return --a;
            }
          
        }

        void FindPrimeNumberAndRespond(long position)
        {
            long prime = MagicProblemSolver.FindPrimeNumber(position);
            var cs = new ConsoleService();
            cs.WriteResponse($"På position {position} finns primtalet {prime}");
        }

        public void Run()
        {
            var cs = new ConsoleService();
            while (true)
            {
                var input = cs.GetUserInput();

                long position;

                if (long.TryParse(input, out position))
                {
                    if (position <= 0)
                    {
                        cs.WriteError("Ange ett positivt heltal");
                    }
                    else
                    {
                        Task.Run(() => FindPrimeNumberAndRespond(position));
                    }
                }
                else
                {
                    cs.WriteError("Ange ett heltal");
                }
            }
        }

    }
}
