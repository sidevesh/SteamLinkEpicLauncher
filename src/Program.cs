using System;
using System.Diagnostics;
using System.Threading;

namespace SteamLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                System.Console.WriteLine("ERROR: Needs launch URL and EXE Name");
                return;
            }

            var epicUrl = args[0];
            var exeName = args[1];

            var ps = new ProcessStartInfo(epicUrl)
            {
                UseShellExecute = true,
                Verb = "open"
            };

            System.Console.WriteLine($"Starting url: {epicUrl}");
            Process.Start(ps);

            var gameProcesses = Process.GetProcessesByName(exeName);

            System.Console.WriteLine($"Checking if game process: {exeName} has started");
            while (gameProcesses.Length == 0)
            {
                System.Console.WriteLine($"Game process not found, checking again in 1 second");
                Thread.Sleep(1000);
                gameProcesses = Process.GetProcessesByName(exeName);
            }
            
            System.Console.WriteLine($"Game started");
            gameProcesses[0].WaitForExit();
            System.Console.WriteLine($"Game closed, Exiting.");

        }
    }
}