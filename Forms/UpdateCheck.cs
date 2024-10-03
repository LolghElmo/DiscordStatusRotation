using DiscordStatusRotationUI.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordStatusRotationUI.Forms
{
    public partial class UpdateCheck : Form
    {
        private int _dotCount = 0;
        private UpdateChecker _updateChecker;

        public UpdateCheck()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            CloseUpdateCheck();
        }

        private async void UpdateCheck_Load(object sender, EventArgs e)
        {
            await CheckForUpdates();
        }

        private async Task CheckForUpdates()
        {
            var configManager = new AppConfigManager("AppConfig.json");
            _updateChecker = new UpdateChecker();

            var appConfig = configManager.LoadConfigData();
            string currentVersion = appConfig.AppVer;

            ButtonClose.Enabled = false;
            ProgressBarDownload.Style = ProgressBarStyle.Marquee;
            LabelCheckingForUpdates.Text = "Checking for updates...";

            try
            {
                var (isNewVersionAvailable, downloadUrl, latestVersion) = await _updateChecker.CheckForUpdates(currentVersion);

                if (isNewVersionAvailable)
                {
                    LabelCheckingForUpdates.Text = "A newer version is available.";
                    DialogResult result = MessageBox.Show("\nDo you want to download the update?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool downloadSuccess = await _updateChecker.DownloadAndUpdate(downloadUrl);
                        if (downloadSuccess)
                        {
                            appConfig.AppVer = latestVersion;
                            configManager.SaveStatusData(appConfig);  
                            MessageBox.Show("Update downloaded successfully. Please restart the application to apply changes.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Restart();
                        }
                        else
                        {
                            MessageBox.Show("Failed to download the update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    LabelCheckingForUpdates.Text = "You are using the latest version.";
                }
            }
            catch (Exception ex)
            {
                LabelCheckingForUpdates.Text = "Error checking for updates: " + ex.Message;
            }
            finally
            {
                TimerLabelAnimate.Stop();
                ButtonClose.Enabled = true;
                ProgressBarDownload.Style = ProgressBarStyle.Blocks;
                CloseUpdateCheck();
            }
        }

        private void CloseUpdateCheck()
        {
            var master = new Master();
            master.Show();
            master.FormClosed += (s, e) => this.Close();
            this.Hide();
        }

        private void TimerLabelAnimate_Tick(object sender, EventArgs e)
        {
            _dotCount = (_dotCount + 1) % 4;
            LabelCheckingForUpdates.Text = $"Checking for updates{new string('.', _dotCount)}";
        }
    }
}
