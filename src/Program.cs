using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace SteamLauncher
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int Handle, int showState);

        [DllImport("kernel32.dll")]
        public static extern int GetConsoleWindow();

        static void Main(string[] args)
        {

            int win = GetConsoleWindow();
            ShowWindow(win, 0);

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

            // System.Console.WriteLine($"Starting url: {epicUrl}");
            Process.Start(ps);

            Thread.Sleep(5000);

            var gameProcesses = Process.GetProcessesByName(exeName);

            if (gameProcesses.Length != 1)
            {
                System.Console.WriteLine($"Could not find a single process with name: {exeName}");
                return;
            }
            
            System.Console.WriteLine($"Game started.");
            gameProcesses[0].WaitForExit();

        }
    }
}