using System.Drawing.Drawing2D;

namespace DiscordStatusRotationUI.Forms
{
    partial class EditAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAdd));
            TextboxStatus = new TextBox();
            ButtonOk = new Button();
            ButtonCancel = new Button();
            LabelTitle = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // TextboxStatus
            // 
            TextboxStatus.BackColor = Color.FromArgb(45, 45, 48);
            TextboxStatus.BorderStyle = BorderStyle.FixedSingle;
            TextboxStatus.Font = new Font("Segoe UI", 12F);
            TextboxStatus.ForeColor = Color.WhiteSmoke;
            TextboxStatus.Location = new Point(35, 70);
            TextboxStatus.Name = "TextboxStatus";
            TextboxStatus.Size = new Size(220, 29);
            TextboxStatus.TabIndex = 0;
            // 
            // ButtonOk
            // 
            ButtonOk.BackColor = Color.FromArgb(76, 175, 80);
            ButtonOk.FlatAppearance.BorderSize = 0;
            ButtonOk.FlatStyle = FlatStyle.Flat;
            ButtonOk.ForeColor = Color.WhiteSmoke;
            ButtonOk.Location = new Point(40, 120);
            ButtonOk.Name = "ButtonOk";
            ButtonOk.Size = new Size(110, 40);
            ButtonOk.TabIndex = 1;
            ButtonOk.Text = "OK";
            ButtonOk.UseVisualStyleBackColor = false;
            ButtonOk.Click += ButtonOk_Click;
            ButtonOk.Paint += Button_Paint;
            // 
            // ButtonCancel
            // 
            ButtonCancel.BackColor = Color.FromArgb(244, 73, 60);
            ButtonCancel.FlatAppearance.BorderSize = 0;
            ButtonCancel.FlatStyle = FlatStyle.Flat;
            ButtonCancel.ForeColor = Color.WhiteSmoke;
            ButtonCancel.Location = new Point(160, 120);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(110, 40);
            ButtonCancel.TabIndex = 2;
            ButtonCancel.Text = "Cancel";
            ButtonCancel.UseVisualStyleBackColor = false;
            ButtonCancel.Click += ButtonCancel_Click;
            ButtonCancel.Paint += Button_Paint;
            // 
            // LabelTitle
            // 
            LabelTitle.AutoSize = true;
            LabelTitle.BackColor = Color.Transparent;
            LabelTitle.Font = new Font("Corbel", 26.25F, FontStyle.Bold);
            LabelTitle.ForeColor = Color.White;
            LabelTitle.Location = new Point(110, 10);
            LabelTitle.Name = "LabelTitle";
            LabelTitle.Size = new Size(89, 42);
            LabelTitle.TabIndex = 3;
            LabelTitle.Text = "ADD";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(265, 78);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 4;
            label2.Text = "Status";
            // 
            // EditAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(320, 180);
            Controls.Add(label2);
            Controls.Add(LabelTitle);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonOk);
            Controls.Add(TextboxStatus);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditAdd";
            Opacity = 0.99D;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Status";
            Paint += EditAdd_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        private void EditAdd_Paint(object sender, PaintEventArgs e)
        {
            var brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(28, 28, 28), Color.FromArgb(30, 30, 30), 90F);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);

            using (Pen borderPen = new Pen(Color.FromArgb(80, 80, 80), 2)) 
            {
                e.Graphics.DrawRectangle(borderPen, this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
            }
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

        private TextBox TextboxStatus;
        private Button ButtonOk;
        private Button ButtonCancel;
        private Label LabelTitle;
        private Label label2;
    }
}
