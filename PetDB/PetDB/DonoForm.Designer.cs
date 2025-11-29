namespace PetDB
{
    partial class DonoForm
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
            outrosToolStripMenuItem = new ToolStripMenuItem();
            showNameLabel = new Label();
            showNifLabel = new Label();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, outrosToolStripMenuItem });
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
            // outrosToolStripMenuItem
            // 
            outrosToolStripMenuItem.Name = "outrosToolStripMenuItem";
            outrosToolStripMenuItem.Size = new Size(67, 24);
            outrosToolStripMenuItem.Text = "Outros";
            // 
            // showNameLabel
            // 
            showNameLabel.AutoSize = true;
            showNameLabel.Location = new Point(485, 236);
            showNameLabel.Name = "showNameLabel";
            showNameLabel.Size = new Size(198, 20);
            showNameLabel.TabIndex = 8;
            showNameLabel.Text = "Nome para ver que funciona";
            // 
            // showNifLabel
            // 
            showNifLabel.AutoSize = true;
            showNifLabel.Location = new Point(127, 309);
            showNifLabel.Name = "showNifLabel";
            showNifLabel.Size = new Size(177, 20);
            showNifLabel.TabIndex = 7;
            showNifLabel.Text = "Nif para ver que funciona";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(53, 128);
            label1.Name = "label1";
            label1.Size = new Size(694, 46);
            label1.TabIndex = 6;
            label1.Text = "Esta página do Dono está sobre construção :)";
            // 
            // DonoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(showNameLabel);
            Controls.Add(showNifLabel);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "DonoForm";
            Text = "DonoForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem outrosToolStripMenuItem;
        private Label showNameLabel;
        private Label showNifLabel;
        private Label label1;
    }
}