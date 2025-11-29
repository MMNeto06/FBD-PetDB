namespace PetDB
{
    partial class ClinicaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            outrasOpçõesToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            showNifLabel = new Label();
            showNameLabel = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, outrasOpçõesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(39, 24);
            toolStripMenuItem1.Text = "<-";
            toolStripMenuItem1.Click += backBtn_Click;
            // 
            // outrasOpçõesToolStripMenuItem
            // 
            outrasOpçõesToolStripMenuItem.Name = "outrasOpçõesToolStripMenuItem";
            outrasOpçõesToolStripMenuItem.Size = new Size(118, 24);
            outrasOpçõesToolStripMenuItem.Text = "Outras opções";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(52, 180);
            label1.Name = "label1";
            label1.Size = new Size(705, 46);
            label1.TabIndex = 1;
            label1.Text = "Esta página da Clinica está sobre construção :)";
            // 
            // showNifLabel
            // 
            showNifLabel.AutoSize = true;
            showNifLabel.Location = new Point(219, 259);
            showNifLabel.Name = "showNifLabel";
            showNifLabel.Size = new Size(177, 20);
            showNifLabel.TabIndex = 2;
            showNifLabel.Text = "Nif para ver que funciona";
            // 
            // showNameLabel
            // 
            showNameLabel.AutoSize = true;
            showNameLabel.Location = new Point(252, 310);
            showNameLabel.Name = "showNameLabel";
            showNameLabel.Size = new Size(198, 20);
            showNameLabel.TabIndex = 3;
            showNameLabel.Text = "Nome para ver que funciona";
            // 
            // ClinicaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(showNameLabel);
            Controls.Add(showNifLabel);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ClinicaForm";
            Text = "ClinicaForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem outrasOpçõesToolStripMenuItem;
        private Label label1;
        private Label showNifLabel;
        private Label showNameLabel;
    }
}