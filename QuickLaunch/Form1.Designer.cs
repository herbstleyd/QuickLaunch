namespace QuickLaunch
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton addProgramButton;
        private System.Windows.Forms.ToolStripButton exitButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addProgramButton = new System.Windows.Forms.ToolStripButton();
            this.exitButton = new System.Windows.Forms.ToolStripButton();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown; // Anordnung von oben nach unten
            this.flowLayoutPanel.WrapContents = false; // Kein Zeilenumbruch
            this.flowLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0); // Abstand hinzufügen
            this.Controls.Add(this.flowLayoutPanel);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProgramButton,
            this.exitButton});
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.Controls.Add(this.toolStrip);
            // 
            // addProgramButton
            // 
            this.addProgramButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addProgramButton.Image = Properties.Resources.gear_icon; // Zahnrad-Icon hinzufügen
            this.addProgramButton.Click += new System.EventHandler(this.AddProgramButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitButton.Image = Properties.Resources.exit_icon; // Exit-Icon hinzufügen
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "MainForm";
            this.Text = "Schnellstart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}