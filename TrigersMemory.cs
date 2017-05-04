#define DETAILED_MODE
using System;
using System.IO;

struct TrigersMemory
{
    private readonly String Path;

    public bool IsTrigger(String phrase)
    {
        foreach (var trigger in File.ReadAllText(Path).SplitToWords())
        {
            if (phrase.Contains(trigger))
            {
                return true;
            }
        }
        return false;
    }

    public TrigersMemory(String path)
    {
        Path = path;
#if DETAILED_MODE
        Console.Write("Найдены следующие триггеры: ");
        foreach (var trigger in File.ReadAllText(Path).SplitToWords())
        {
            Console.Write($"'{trigger}' ");
        }
        Console.WriteLine();
#endif
    }
}
