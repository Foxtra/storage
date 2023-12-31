﻿using Storage.Interfaces;

namespace Storage.Services;
internal class ConsoleOutputService : IOutput
{
    public void WriteList<T>(List<T> ListToOutput)
    {
        foreach (var item in ListToOutput)
        {
            Console.WriteLine(item);
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public void WriteString(string stringToOutput)
    {
        Console.WriteLine(stringToOutput);
    }

    public void WriteEmptyLine()
    {
        Console.WriteLine();
    }
}
