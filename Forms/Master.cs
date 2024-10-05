using DiscordStatusRotationUI.Models;
using DiscordStatusRotationUI.Properties;
using DiscordStatusRotationUI.Services;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace DiscordStatusRotationUI.Forms
{
    public partial class Master : Form
    {
        private readonly StatusDataManager _statusDataManager;
        private readonly System.Windows.Forms.Timer _updateTimer;
        private int _currentQuoteIndex;
        private StatusData _statusData;

        public Master()
        {
            InitializeComponent();
            this.Icon = 
            _statusDataManager = new StatusDataManager("Status.json");
            _updateTimer = new System.Windows.Forms.Timer();
            _updateTimer.Tick += UpdateTimer_Tick;
        }

        private void Master_Load(object sender, EventArgs e)
        {
            InitializeMaster();
            notifyIcon1.Visible = true;
            AppConfigManager appConfig = new AppConfigManager("AppConfig.json");
            var config = appConfig.LoadConfigData();
            this.Text = $"Version: {config.AppVer}";
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

        private void ListBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonState(ListBoxStatus.SelectedItem != null);
        }

        private void maskedTextBoxTimer_Leave(object sender, EventArgs e)
        {
            ValidateTimerInput();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (ListBoxStatus.Items.Count > 0)
            {
                var quote = ListBoxStatus.Items[_currentQuoteIndex].ToString();
                var discordStatusUpdater = new DiscordStatusUpdater(TextBoxTokens.Text);
                discordStatusUpdater.UpdateStatus(quote);

                _currentQuoteIndex = (_currentQuoteIndex + 1) % ListBoxStatus.Items.Count;
                ListBoxStatus.SelectedIndex = _currentQuoteIndex;
            }
        }

        private void InitializeMaster()
        {
            UpdateButtonState(false);
            _statusDataManager.LoadStatusData();
            _statusData = _statusDataManager.LoadStatusData();
            TextBoxTokens.Text = _statusData.DiscordToken;

            foreach (var quote in _statusData.Quotes)
            {
                ListBoxStatus.Items.Add(quote);
            }

            SelectFirstIndex();
        }

        private void SelectFirstIndex()
        {
            if (ListBoxStatus.Items.Count > 0)
            {
                ListBoxStatus.SelectedIndex = 0;
            }
        }

        private void SelectIndex(int index)
        {
            if (ListBoxStatus.Items.Count > 0 && index >= 0 && index < ListBoxStatus.Items.Count)
            {
                ListBoxStatus.SelectedIndex = index;
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
                    MessageBox.Show("Please enter a valid time greater than 00:00:00.");
                    return;
                }

                ChangeStatus(TextBoxTokens.Text, ListBoxStatus.SelectedItem?.ToString());
                ButtonUpdateEnable.BackColor = Color.Green;
                ButtonUpdateEnable.Text = "Status: ON";
                maskedTextBoxTimer.Enabled = false;
                _updateTimer.Interval = totalSeconds * 1000;
                _updateTimer.Start();
                _currentQuoteIndex = ListBoxStatus.SelectedIndex;
            }
            else
            {
                MessageBox.Show("Please enter a valid time in HH:MM:SS format.");
            }
        }

        private void StopTimer()
        {
            _updateTimer.Stop();
            maskedTextBoxTimer.Enabled = true;
            ButtonUpdateEnable.BackColor = Color.Red;
            ButtonUpdateEnable.Text = "Status: OFF";
        }

        private void ValidateTimerInput()
        {
            string input = maskedTextBoxTimer.Text;
            string[] timeParts = input.Split(':');

            if (timeParts.Length == 3 && int.TryParse(timeParts[0], out int hours) &&
                int.TryParse(timeParts[1], out int minutes) &&
                int.TryParse(timeParts[2], out int seconds))
            {
                if (minutes >= 0 && minutes < 60 && seconds >= 0 && seconds < 60)
                {
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

                    if (hours >= 100)
                    {
                        MessageBox.Show("Time cannot exceed 99:59:59.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        maskedTextBoxTimer.Text = "99:59:59";
                        maskedTextBoxTimer.BorderStyle = BorderStyle.FixedSingle;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid time. Minutes and seconds must be between 00 and 59.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            _statusData.DiscordToken = TextBoxTokens.Text;
            _statusData.Quotes.Clear();

            foreach (var item in ListBoxStatus.Items)
            {
                _statusData.Quotes.Add(item.ToString());
            }

            _statusDataManager.SaveStatusData(_statusData);
        }

        private void ChangeStatus(string token, string quote)
        {
            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(quote))
            {
                var discordStatusUpdater = new DiscordStatusUpdater(token);
                discordStatusUpdater.UpdateStatus(quote);
            }
        }

        private void Master_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void Master_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon1.Visible = true;
                return;
            }

            base.OnFormClosing(e);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void UpdateButtonState(bool isItemSelected)
        {
            ButtonEdit.Enabled = isItemSelected;
            ButtonDelete.Enabled = isItemSelected;

            ButtonEdit.BackColor = isItemSelected ? Color.FromArgb(40, 153, 243) : Color.Gray;
            ButtonEdit.ForeColor = isItemSelected ? Color.WhiteSmoke : Color.DarkGray;

            ButtonDelete.BackColor = isItemSelected ? Color.FromArgb(244, 73, 60) : Color.Gray;
            ButtonDelete.ForeColor = isItemSelected ? Color.WhiteSmoke : Color.DarkGray;
        }
    }
}
