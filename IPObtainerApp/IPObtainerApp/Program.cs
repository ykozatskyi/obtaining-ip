using System;

namespace IPObtainerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                Console.WriteLine($"input\t\tbyte 1\tbyte 2\tbyte 3\tbyte 4");

                for (int i = 0; i < args.Length; i++)
                {
                    var address = new IPv4Address(args[i]);
                    Console.WriteLine($"{args[i]}:\t{address.Byte1}\t{address.Byte2}\t{address.Byte3}\t{address.Byte4}");
                }
            }
            else
                Console.WriteLine("0 strings arguments were provided");

            Console.WriteLine("\nPresss any key to exit");
            Console.ReadKey();
        }
    }
}
