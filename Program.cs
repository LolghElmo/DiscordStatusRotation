using DiscordStatusRotationUI.Forms;
using DiscordStatusRotationUI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Windows.Forms;

namespace DiscordStatusRotationUI
{
    internal static class Program
    {
        static Mutex mutex = new Mutex(true, "{DiscordStatusRotationUI-3214567890213-123-321}");

        [STAThread]
        static async Task Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Master());

                mutex.ReleaseMutex();
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Another instance of DSR is already running.",
                                "Instance Already Running",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                Environment.Exit(1); 
            }
        }
    }
}
