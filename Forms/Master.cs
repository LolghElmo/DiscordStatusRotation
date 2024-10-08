using DiscordStatusRotationUI.Models;
using DiscordStatusRotationUI.Services;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DiscordStatusRotationUI.Forms
{
    public partial class Master : Form
    {
        private readonly StatusDataManager _statusDataManager;
        private readonly AppConfigManager _appConfig;
        private readonly System.Windows.Forms.Timer _updateTimer;
        private int _currentQuoteIndex;
        private StatusData _statusData;

        public Master()
        {
            InitializeComponent();
            _statusDataManager = new StatusDataManager("Status.json");
            _appConfig = new AppConfigManager("AppConfig.json");
            _updateTimer = new System.Windows.Forms.Timer();
            _updateTimer.Tick += UpdateTimer_Tick;
        }

        private void Master_Load(object sender, EventArgs e)
        {
            InitializeMaster();
        }

        private void InitializeMaster()
        {
            try
            {
                notifyIcon1.Visible = true;

                var config = _appConfig.LoadConfigData();
                maskedTextBoxTimer.Text = config.TimerSpan;
                this.Text = $"Version: {config.AppVer}";

                UpdateButtonState(ListBoxStatus.SelectedItem != null);
                ButtonUpdateEnable.BackColor = config.StatusState ? Color.Green : Color.Red;
                ButtonUpdateEnable.Text = config.StatusState ? "Status: ON" : "Status: OFF";

                _statusData = _statusDataManager.LoadStatusData();
                TextBoxTokens.Text = _statusData.DiscordToken;

                foreach (var quote in _statusData.Quotes)
                {
                    ListBoxStatus.Items.Add(quote);
                }

                SelectFirstIndex();

                if (config.StatusState)
                {
                    StartTimer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing application: {ex.Message}", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonUpdateEnable_Click(object sender, EventArgs e)
        {
            if (ButtonUpdateEnable.Text == "Status: OFF")
            {
                StartTimer();
            }
            else
            {
                StopTimer();
            }

            var config = _appConfig.LoadConfigData();
            config.TimerSpan = maskedTextBoxTimer.Text;
            config.StatusState = ButtonUpdateEnable.Text == "Status: ON";
            _appConfig.SaveStatusData(config);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            OpenAddDialog();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            OpenEditDialog();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedStatus();
            SelectFirstIndex();
            SaveStatusData();
        }
        private void pictureBoxKoi_Click(object sender, EventArgs e)
        {
            OpenPage("https://www.instagram.com/koiixhy?igsh=MXE0YnU0bGdha2Z6cQ==\r\n");
        }

        private void labelMadeBy_Click(object sender, EventArgs e)
        {
            OpenPage("https://www.instagram.com/koiixhy?igsh=MXE0YnU0bGdha2Z6cQ==\r\n");
        }
        private void linkLabelToken_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenPage("https://www.youtube.com/watch?v=YEgFvgg7ZPI");
        }
        private void ListBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonState(ListBoxStatus.SelectedItem != null);

            if (ListBoxStatus.SelectedItem != null)
            {
                _currentQuoteIndex = ListBoxStatus.SelectedIndex;
                ChangeStatus(TextBoxTokens.Text, ListBoxStatus.SelectedItem.ToString());
            }
        }
        private void maskedTextBoxTimer_TextChanged(object sender, EventArgs e)
        {
            ValidateTimerInput();
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (ListBoxStatus.Items.Count > 0)
            {
                var quote = ListBoxStatus.Items[_currentQuoteIndex].ToString();
                ChangeStatus(TextBoxTokens.Text, quote);

                _currentQuoteIndex = (_currentQuoteIndex + 1) % ListBoxStatus.Items.Count;
                ListBoxStatus.SelectedIndex = _currentQuoteIndex;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowMainWindow();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMainWindow();
        }

        private void Master_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideMainWindow();
            }
        }

        private void Master_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                HideMainWindow();
            }
        }

        private void StartTimer()
        {
            string input = maskedTextBoxTimer.Text;

            if (TimeSpan.TryParseExact(input, @"hh\:mm\:ss", null, out TimeSpan timeSpan))
            {
                int totalSeconds = (int)timeSpan.TotalSeconds;
                if (totalSeconds == 0)
                {
                    MessageBox.Show("Please enter a valid time greater than 00:00:00.", "Invalid Timer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ChangeStatus(TextBoxTokens.Text, ListBoxStatus.SelectedItem?.ToString());

                ButtonUpdateEnable.BackColor = Color.Green;
                ButtonUpdateEnable.Text = "Status: ON";
                maskedTextBoxTimer.Enabled = false;
                _updateTimer.Interval = totalSeconds * 1000;
                _updateTimer.Start();
                _currentQuoteIndex = ListBoxStatus.SelectedIndex;

                ButtonAdd.Enabled = false;
                ButtonAdd.BackColor = Color.Gray;
                ButtonEdit.Enabled = false;
                ButtonEdit.BackColor = Color.Gray;
                ButtonDelete.Enabled = false;
                ButtonDelete.BackColor = Color.Gray;
            }
            else
            {
                MessageBox.Show("Please enter a valid time in HH:MM:SS format.", "Invalid Timer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopTimer()
        {
            _updateTimer.Stop();
            maskedTextBoxTimer.Enabled = true;
            ButtonUpdateEnable.BackColor = Color.Red;
            ButtonUpdateEnable.Text = "Status: OFF";

            ButtonAdd.Enabled = true;
            ButtonAdd.BackColor = Color.FromArgb(76, 175, 80);
            UpdateButtonState(ListBoxStatus.SelectedItem != null);
        }

        private void OpenAddDialog()
        {
            var addDialog = new EditAdd(ListBoxStatus, SaveStatusData);
            addDialog.Show();
        }

        private void OpenEditDialog()
        {
            if (ListBoxStatus.SelectedItem != null)
            {
                var editDialog = new EditAdd(ListBoxStatus, ListBoxStatus.SelectedItem.ToString(), true, SaveStatusData);
                editDialog.Show();
            }
        }

        private void DeleteSelectedStatus()
        {
            if (ListBoxStatus.SelectedItem != null)
            {
                ListBoxStatus.Items.Remove(ListBoxStatus.SelectedItem);
            }
        }

        private void SaveStatusData()
        {
            try
            {
                _statusData.DiscordToken = TextBoxTokens.Text;
                _statusData.Quotes.Clear();

                foreach (var item in ListBoxStatus.Items)
                {
                    _statusData.Quotes.Add(item.ToString());
                }

                _statusDataManager.SaveStatusData(_statusData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving status data: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeStatus(string token, string quote)
        {
            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(quote))
            {
                try
                {
                    var discordStatusUpdater = new DiscordStatusUpdater(token);
                    discordStatusUpdater.UpdateStatus(quote);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating Discord status: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ValidateTimerInput()
        {
            string input = maskedTextBoxTimer.Text;
            string[] timeParts = input.Split(':');

            if (timeParts.Length == 3 &&
                int.TryParse(timeParts[0], out int hours) &&
                int.TryParse(timeParts[1], out int minutes) &&
                int.TryParse(timeParts[2], out int seconds))
            {
                if (seconds >= 60)
                {
                    minutes += seconds / 60;
                    seconds = seconds % 60;
                }

                if (minutes >= 60)
                {
                    hours += minutes / 60;
                    minutes = minutes % 60;
                }

                if (hours >= 100)
                {
                    MessageBox.Show("Time cannot exceed 99:59:59.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maskedTextBoxTimer.Text = "99:59:59";
                    return;
                }

                int totalSeconds = (hours * 3600) + (minutes * 60) + seconds;
                if (totalSeconds < 3)
                {
                    maskedTextBoxTimer.Text = "00:00:03";
                    maskedTextBoxTimer.BorderStyle = BorderStyle.FixedSingle;
                    ShowWarning("Risk of Ban!", Color.Red);
                }
                else if (totalSeconds < 300)
                {
                    ShowWarning("Recommended: +5 minutes", Color.Yellow);
                }
                else
                {
                    LabelWarning.Visible = false;
                }

                maskedTextBoxTimer.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
            }
            else
            {
                MessageBox.Show("Please enter a valid time in HH:mm:ss format.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowWarning(string message, Color color)
        {
            LabelWarning.Text = message;
            LabelWarning.ForeColor = color;
            LabelWarning.Visible = true;
        }

        private void UpdateButtonState(bool isItemSelected)
        {
            bool isTimerRunning = ButtonUpdateEnable.Text == "Status: ON";

            ButtonEdit.Enabled = isItemSelected && !isTimerRunning;
            ButtonDelete.Enabled = isItemSelected && !isTimerRunning;

            ButtonEdit.BackColor = ButtonEdit.Enabled ? Color.FromArgb(40, 153, 243) : Color.Gray;
            ButtonEdit.ForeColor = ButtonEdit.Enabled ? Color.WhiteSmoke : Color.DarkGray;

            ButtonDelete.BackColor = ButtonDelete.Enabled ? Color.FromArgb(244, 73, 60) : Color.Gray;
            ButtonDelete.ForeColor = ButtonDelete.Enabled ? Color.WhiteSmoke : Color.DarkGray;
        }

        private void SelectFirstIndex()
        {
            if (ListBoxStatus.Items.Count > 0)
            {
                ListBoxStatus.SelectedIndex = 0;
                ChangeStatus(TextBoxTokens.Text, ListBoxStatus.SelectedItem.ToString());

            }
        }
        private void SelectIndex(int index)
        {
            if (ListBoxStatus.Items.Count > 0 && index >= 0 && index < ListBoxStatus.Items.Count)
            {
                ListBoxStatus.SelectedIndex = index;

                ChangeStatus(TextBoxTokens.Text, ListBoxStatus.SelectedItem.ToString());
            }
        }
        private void ShowMainWindow()
        {
            this.Show();
            this.ShowInTaskbar = true;
        }

        private void HideMainWindow()
        {
            this.Hide();
            this.ShowInTaskbar = false;
        }
        private void OpenPage(string page)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = page,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open page: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
