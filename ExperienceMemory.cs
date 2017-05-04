using System;
using System.Text;
using System.IO;

struct ExperienceMemory
{
    private readonly String Path;
    private readonly StreamWriter Writer;

    public String GetAnswer(String phrase)
    {
        StringBuilder result = new StringBuilder();
        foreach (var association in File.ReadAllText(Path).ToLower().Split(";\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
        {
            foreach (var savedPhrase in association.Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (var trigger in phrase.SplitToWords())
                {
                    if (trigger.Length < 3)
                    {
                        continue;
                    }
                    if (savedPhrase.Contains(trigger))
                    {
                        result.AppendLine(savedPhrase);
                        break;
                    }
                }
            }
        }
        foreach (var i in phrase.ToLower().Split(new[] { ";", " значит ", ".", " это ", "=", "->", "=>", "-" },
            StringSplitOptions.RemoveEmptyEntries))
        {
            Writer.Write(i);
            Writer.Write(" = ");
        }
        Writer.WriteLine(";");
        return result.Length > 0 ? result.ToString() : "Чё сказал?";
    }

    public ExperienceMemory(String filePath)
    {
        Path = filePath;
        Writer = File.AppendText(filePath);
    }
}
