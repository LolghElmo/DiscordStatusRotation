using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DiscordStatusRotationUI.Forms
{
    partial class Master : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Master));
            ListBoxStatus = new ListBox();
            TextBoxTokens = new TextBox();
            TokensLabel = new Label();
            ButtonUpdateEnable = new Button();
            TitleLabel = new Label();
            ButtonEdit = new Button();
            ButtonDelete = new Button();
            ButtonAdd = new Button();
            maskedTextBoxTimer = new MaskedTextBox();
            LabelWarning = new Label();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            exitToolStripMenuItem = new ToolStripMenuItem();
            showToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ListBoxStatus
            // 
            ListBoxStatus.BackColor = Color.FromArgb(45, 45, 48);
            ListBoxStatus.BorderStyle = BorderStyle.FixedSingle;
            ListBoxStatus.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ListBoxStatus.ForeColor = Color.WhiteSmoke;
            ListBoxStatus.FormattingEnabled = true;
            ListBoxStatus.HorizontalScrollbar = true;
            ListBoxStatus.ItemHeight = 25;
            ListBoxStatus.Location = new Point(9, 103);
            ListBoxStatus.Margin = new Padding(0, 3, 0, 3);
            ListBoxStatus.Name = "ListBoxStatus";
            ListBoxStatus.Size = new Size(566, 477);
            ListBoxStatus.TabIndex = 0;
            ListBoxStatus.SelectedIndexChanged += ListBoxStatus_SelectedIndexChanged;
            // 
            // TextBoxTokens
            // 
            TextBoxTokens.BackColor = Color.FromArgb(45, 45, 48);
            TextBoxTokens.BorderStyle = BorderStyle.None;
            TextBoxTokens.Font = new Font("Segoe UI", 12F);
            TextBoxTokens.ForeColor = Color.White;
            TextBoxTokens.Location = new Point(121, 65);
            TextBoxTokens.Name = "TextBoxTokens";
            TextBoxTokens.PasswordChar = '•';
            TextBoxTokens.Size = new Size(253, 22);
            TextBoxTokens.TabIndex = 1;
            TextBoxTokens.Enter += TextBoxTokens_Enter;
            TextBoxTokens.Leave += TextBoxTokens_Leave;
            // 
            // TokensLabel
            // 
            TokensLabel.AutoSize = true;
            TokensLabel.BackColor = Color.Transparent;
            TokensLabel.ForeColor = Color.LightGray;
            TokensLabel.Location = new Point(22, 70);
            TokensLabel.Name = "TokensLabel";
            TokensLabel.Size = new Size(84, 15);
            TokensLabel.TabIndex = 2;
            TokensLabel.Text = "Discord Token:";
            // 
            // ButtonUpdateEnable
            // 
            ButtonUpdateEnable.BackColor = Color.Red;
            ButtonUpdateEnable.FlatAppearance.BorderSize = 0;
            ButtonUpdateEnable.FlatStyle = FlatStyle.Flat;
            ButtonUpdateEnable.ForeColor = Color.WhiteSmoke;
            ButtonUpdateEnable.Location = new Point(478, 15);
            ButtonUpdateEnable.Name = "ButtonUpdateEnable";
            ButtonUpdateEnable.Size = new Size(94, 40);
            ButtonUpdateEnable.TabIndex = 3;
            ButtonUpdateEnable.Text = "Status: OFF";
            ButtonUpdateEnable.UseVisualStyleBackColor = false;
            ButtonUpdateEnable.Click += ButtonUpdateEnable_Click;
            ButtonUpdateEnable.Paint += Button_Paint;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.BackColor = Color.Transparent;
            TitleLabel.Font = new Font("Corbel", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TitleLabel.ForeColor = Color.White;
            TitleLabel.Location = new Point(12, 7);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(374, 42);
            TitleLabel.TabIndex = 5;
            TitleLabel.Text = "Discord Status Rotation";
            // 
            // ButtonEdit
            // 
            ButtonEdit.BackColor = Color.FromArgb(40, 153, 243);
            ButtonEdit.FlatAppearance.BorderSize = 0;
            ButtonEdit.FlatStyle = FlatStyle.Flat;
            ButtonEdit.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonEdit.ForeColor = Color.WhiteSmoke;
            ButtonEdit.Image = Properties.Resources.screw_driver__5_;
            ButtonEdit.Location = new Point(460, 61);
            ButtonEdit.Name = "ButtonEdit";
            ButtonEdit.Size = new Size(52, 40);
            ButtonEdit.TabIndex = 6;
            ButtonEdit.TextImageRelation = TextImageRelation.ImageAboveText;
            ButtonEdit.UseVisualStyleBackColor = false;
            ButtonEdit.Click += ButtonEdit_Click;
            // 
            // ButtonDelete
            // 
            ButtonDelete.BackColor = Color.FromArgb(244, 73, 60);
            ButtonDelete.FlatAppearance.BorderSize = 0;
            ButtonDelete.FlatStyle = FlatStyle.Flat;
            ButtonDelete.ForeColor = Color.WhiteSmoke;
            ButtonDelete.Image = Properties.Resources.trashbin;
            ButtonDelete.Location = new Point(394, 61);
            ButtonDelete.Name = "ButtonDelete";
            ButtonDelete.Size = new Size(52, 40);
            ButtonDelete.TabIndex = 7;
            ButtonDelete.TextImageRelation = TextImageRelation.ImageAboveText;
            ButtonDelete.UseVisualStyleBackColor = false;
            ButtonDelete.Click += ButtonDelete_Click;
            // 
            // ButtonAdd
            // 
            ButtonAdd.BackColor = Color.FromArgb(76, 175, 80);
            ButtonAdd.FlatAppearance.BorderSize = 0;
            ButtonAdd.FlatStyle = FlatStyle.Flat;
            ButtonAdd.ForeColor = Color.WhiteSmoke;
            ButtonAdd.Image = Properties.Resources.plus_symbol_button;
            ButtonAdd.Location = new Point(526, 61);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new Size(52, 40);
            ButtonAdd.TabIndex = 8;
            ButtonAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            ButtonAdd.UseVisualStyleBackColor = false;
            ButtonAdd.Click += ButtonAdd_Click;
            // 
            // maskedTextBoxTimer
            // 
            maskedTextBoxTimer.BackColor = Color.FromArgb(50, 50, 54);
            maskedTextBoxTimer.BorderStyle = BorderStyle.FixedSingle;
            maskedTextBoxTimer.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            maskedTextBoxTimer.ForeColor = Color.WhiteSmoke;
            maskedTextBoxTimer.Location = new Point(392, 18);
            maskedTextBoxTimer.Mask = "00:00:00";
            maskedTextBoxTimer.Name = "maskedTextBoxTimer";
            maskedTextBoxTimer.PromptChar = '0';
            maskedTextBoxTimer.Size = new Size(80, 33);
            maskedTextBoxTimer.TabIndex = 2;
            maskedTextBoxTimer.Text = "     3";
            maskedTextBoxTimer.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            maskedTextBoxTimer.TextChanged += maskedTextBoxTimer_Leave;
            // 
            // LabelWarning
            // 
            LabelWarning.AutoSize = true;
            LabelWarning.BackColor = Color.Transparent;
            LabelWarning.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelWarning.ForeColor = Color.Yellow;
            LabelWarning.Location = new Point(392, -2);
            LabelWarning.Name = "LabelWarning";
            LabelWarning.Size = new Size(168, 17);
            LabelWarning.TabIndex = 9;
            LabelWarning.Text = "Recommended: +5 minutes";
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Discord Status Rotator";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.BackColor = Color.FromArgb(45, 45, 48);
            contextMenuStrip1.Font = new Font("Segoe UI", 10F);
            contextMenuStrip1.ForeColor = Color.WhiteSmoke;
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem, showToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip1.Size = new Size(112, 52);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 54);
            exitToolStripMenuItem.ForeColor = Color.WhiteSmoke;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(111, 24);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 54);
            showToolStripMenuItem.ForeColor = Color.WhiteSmoke;
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new Size(111, 24);
            showToolStripMenuItem.Text = "Show";
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            // 
            // Master
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(584, 587);
            Controls.Add(LabelWarning);
            Controls.Add(ButtonUpdateEnable);
            Controls.Add(maskedTextBoxTimer);
            Controls.Add(ButtonAdd);
            Controls.Add(ButtonDelete);
            Controls.Add(ButtonEdit);
            Controls.Add(ListBoxStatus);
            Controls.Add(TokensLabel);
            Controls.Add(TextBoxTokens);
            Controls.Add(TitleLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Master";
            Opacity = 0.99D;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Discord Status Manager";
            FormClosing += Master_FormClosing;
            Load += Master_Load;
            Paint += Master_Paint;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void Master_Paint(object sender, PaintEventArgs e)
        {
            var brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(28, 28, 28), Color.FromArgb(30, 30, 30), 90F);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void DrawGradientButton(object sender, PaintEventArgs e, Color color1, Color color2)
        {
            Button btn = sender as Button;
            using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, color1, color2, 90F))
            {
                e.Graphics.FillRectangle(brush, btn.ClientRectangle);
            }
        }

        private void TextBoxTokens_Enter(object sender, EventArgs e)
        {
            TextBoxTokens.BackColor = Color.FromArgb(60, 60, 64);
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

        private void Circle_Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            int diameter = btn.Width;
            Rectangle rect = new Rectangle(0, 0, diameter, diameter);
            using (GraphicsPath path = new GraphicsPath())
            {

                path.AddEllipse(rect);
                btn.Region = new Region(path);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; 
                e.Graphics.FillPath(new SolidBrush(btn.BackColor), path);

                if (btn.Image != null)
                {
                    e.Graphics.DrawImage(btn.Image, rect); 
                }

                e.Graphics.DrawString(btn.Text, btn.Font, new SolidBrush(btn.ForeColor),
                    new RectangleF(0, 0, diameter, diameter), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
            }
        }
        private void TextBoxTokens_Leave(object sender, EventArgs e)
        {
            SaveStatusData();
            TextBoxTokens.BackColor = Color.FromArgb(45, 45, 48);
        }

        #endregion

        private ListBox ListBoxStatus;
        private TextBox TextBoxTokens;
        private Label TokensLabel;
        private Button ButtonUpdateEnable;
        private Label TitleLabel;
        private Button ButtonEdit;
        private Button ButtonDelete;
        private Button ButtonAdd;
        private MaskedTextBox maskedTextBoxTimer;
        private Label LabelWarning;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem showToolStripMenuItem;
    }
}
