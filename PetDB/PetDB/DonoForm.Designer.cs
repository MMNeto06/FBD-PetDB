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
            animaisToolStripMenuItem = new ToolStripMenuItem();
            pagamentosToolStripMenuItem = new ToolStripMenuItem();
            perfilToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            cardsFlowLayoutPanel = new FlowLayoutPanel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, animaisToolStripMenuItem, pagamentosToolStripMenuItem, perfilToolStripMenuItem });
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
            // animaisToolStripMenuItem
            // 
            animaisToolStripMenuItem.Name = "animaisToolStripMenuItem";
            animaisToolStripMenuItem.Size = new Size(76, 24);
            animaisToolStripMenuItem.Text = "Animais";
            // 
            // pagamentosToolStripMenuItem
            // 
            pagamentosToolStripMenuItem.Name = "pagamentosToolStripMenuItem";
            pagamentosToolStripMenuItem.Size = new Size(104, 24);
            pagamentosToolStripMenuItem.Text = "Pagamentos";
            // 
            // perfilToolStripMenuItem
            // 
            perfilToolStripMenuItem.Name = "perfilToolStripMenuItem";
            perfilToolStripMenuItem.Size = new Size(56, 24);
            perfilToolStripMenuItem.Text = "Perfil";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(52, 37);
            label1.Name = "label1";
            label1.Size = new Size(255, 46);
            label1.TabIndex = 6;
            label1.Text = "Os seus animais";
            // 
            // cardsFlowLayoutPanel
            // 
            cardsFlowLayoutPanel.Location = new Point(52, 86);
            cardsFlowLayoutPanel.Name = "cardsFlowLayoutPanel";
            cardsFlowLayoutPanel.Size = new Size(719, 324);
            cardsFlowLayoutPanel.TabIndex = 7;
            // 
            // DonoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cardsFlowLayoutPanel);
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
        private ToolStripMenuItem animaisToolStripMenuItem;
        private Label label1;
        private FlowLayoutPanel cardsFlowLayoutPanel;
        private ToolStripMenuItem perfilToolStripMenuItem;
        private ToolStripMenuItem pagamentosToolStripMenuItem;
    }
}