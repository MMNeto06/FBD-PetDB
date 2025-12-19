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
            SuspendLayout();
            // 
            // clinicaTabPage
            // 
            clinicaTabPage.Location = new Point(4, 79);
            clinicaTabPage.Size = new Size(406, 197);
            // 
            // listBox1
            // 
            listBox1.Size = new Size(356, 324);
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
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 313);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClinicaForm";
            Text = "ClinicaForm";
            registarTabControl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripMenuItem toolStripMenuItem1;
    }
}