using System;
using System.Text;


class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Console.InputEncoding = Encoding.UTF8;
        try
        {
            var bot = new AIBot("", "memory.txt", "triggers.txt", i => Console.WriteLine(i));
            Console.Title = $"@{bot.Name}";
            Console.WriteLine($"{Console.Title} is working now.\nPress any key to stop.\n");
            Console.ReadKey();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
