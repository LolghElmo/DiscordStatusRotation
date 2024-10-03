using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DiscordStatusRotationUI.Forms
{
    partial class UpdateCheck : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            LabelCheckingForUpdates = new Label();
            TimerLabelAnimate = new System.Windows.Forms.Timer(components);
            ProgressBarDownload = new ProgressBar();
            ButtonClose = new Button();
            SuspendLayout();
            // 
            // LabelCheckingForUpdates
            // 
            LabelCheckingForUpdates.AutoSize = true;
            LabelCheckingForUpdates.BackColor = Color.Transparent;
            LabelCheckingForUpdates.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelCheckingForUpdates.ForeColor = Color.WhiteSmoke;
            LabelCheckingForUpdates.Location = new Point(12, 20);
            LabelCheckingForUpdates.Name = "LabelCheckingForUpdates";
            LabelCheckingForUpdates.Size = new Size(203, 25);
            LabelCheckingForUpdates.TabIndex = 0;
            LabelCheckingForUpdates.Text = "Checking for updates...";
            // 
            // TimerLabelAnimate
            // 
            TimerLabelAnimate.Enabled = true;
            TimerLabelAnimate.Interval = 1000;
            TimerLabelAnimate.Tick += TimerLabelAnimate_Tick;
            // 
            // ProgressBarDownload
            // 
            ProgressBarDownload.BackColor = Color.FromArgb(45, 45, 48);
            ProgressBarDownload.ForeColor = Color.FromArgb(76, 175, 80);
            ProgressBarDownload.Location = new Point(12, 60);
            ProgressBarDownload.MarqueeAnimationSpeed = 30;
            ProgressBarDownload.Name = "ProgressBarDownload";
            ProgressBarDownload.Size = new Size(360, 30);
            ProgressBarDownload.Style = ProgressBarStyle.Marquee;
            ProgressBarDownload.TabIndex = 1;
            // 
            // ButtonClose
            // 
            ButtonClose.BackColor = Color.FromArgb(244, 73, 60);
            ButtonClose.FlatAppearance.BorderSize = 0;
            ButtonClose.FlatStyle = FlatStyle.Flat;
            ButtonClose.ForeColor = Color.WhiteSmoke;
            ButtonClose.Location = new Point(280, 100);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(92, 35);
            ButtonClose.TabIndex = 1;
            ButtonClose.Text = "Close";
            ButtonClose.UseVisualStyleBackColor = false;
            ButtonClose.Click += ButtonClose_Click;
            ButtonClose.Paint += Button_Paint;
            // 
            // UpdateCheck
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(384, 150);
            Controls.Add(LabelCheckingForUpdates);
            Controls.Add(ProgressBarDownload);
            Controls.Add(ButtonClose);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UpdateCheck";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Update Check";
            Load += UpdateCheck_Load;
            Paint += UpdateCheck_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        private void UpdateCheck_Paint(object sender, PaintEventArgs e)
        {
            var brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(28, 28, 28), Color.FromArgb(30, 30, 30), 90F);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 20;
                path.StartFigure();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                btn.Region = new Region(path);
            }
        }
        #endregion

        private Label LabelCheckingForUpdates;
        private ProgressBar ProgressBarDownload;
        private Button ButtonClose;
        private System.Windows.Forms.Timer TimerLabelAnimate;
    }
}
