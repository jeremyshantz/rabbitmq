
namespace RabbitTest
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Publisher";
            Console.WriteLine("Any key to publish");
            Console.ReadKey();

            new Publisher("localhost", "..\\images\\source\\").Run();
            
            Console.WriteLine("Any key to exit");
            Console.ReadKey();
        }
    }
}
