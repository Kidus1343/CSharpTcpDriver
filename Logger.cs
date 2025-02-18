using System;
using System.IO;

class Logger
{
    private static readonly string logFile = "server_log.txt";

    public static void Log(string message)
    {
        string logEntry = $"{DateTime.Now}: {message}";
        Console.WriteLine(logEntry);
        File.AppendAllText(logFile, logEntry + Environment.NewLine);
    }
}
