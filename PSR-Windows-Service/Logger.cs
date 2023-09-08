using System;
using System.ComponentModel;
using System.IO;
using System.ServiceProcess;
using System.Timers;

class ServiceLogger
{
    public static void Log(string system, string title, string text = "")
    {
        string path = System.Reflection.Assembly.GetExecutingAssembly()
               .Location + @"\..\..\..\..\PSR-Windows-Service\Resources\Log";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        DateTime now = DateTime.Now;

        string logDescription = $"{now:yyyy-MM-dd HH:mm:ss} - {system} - {title} - {text}";
        string logName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
        string logPath = Path.Combine(path, logName);

        try
        {
            File.AppendAllText(logPath, logDescription + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while saving log: {ex.Message}");
        }
    }
}