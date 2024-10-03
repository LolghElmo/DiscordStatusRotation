using DiscordStatusRotationUI.Forms;
using DiscordStatusRotationUI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordStatusRotationUI
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Master());
        }
    }
}