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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClinicaForm));
            toolStripMenuItem1 = new ToolStripMenuItem();
            registarTabControl.SuspendLayout();
            consultarTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Items.AddRange(new object[] { resources.GetObject("listBox1.Items"), resources.GetObject("listBox1.Items1"), resources.GetObject("listBox1.Items2"), resources.GetObject("listBox1.Items3"), resources.GetObject("listBox1.Items4"), resources.GetObject("listBox1.Items5"), resources.GetObject("listBox1.Items6"), resources.GetObject("listBox1.Items7"), resources.GetObject("listBox1.Items8"), resources.GetObject("listBox1.Items9") });
            listBox1.Size = new Size(285, 229);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(32, 20);
            toolStripMenuItem1.Text = "<-";
            toolStripMenuItem1.Click += backBtn_Click;
            // 
            // ClinicaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 313);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClinicaForm";
            Text = "ClinicaForm";
            registarTabControl.ResumeLayout(false);
            consultarTabControl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripMenuItem toolStripMenuItem1;
    }
}