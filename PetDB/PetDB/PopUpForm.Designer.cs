namespace PetDB
{
    partial class PopUpForm
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
            panelContainer = new Panel();
            SuspendLayout();
            // 
            // panelContainer
            // 
            panelContainer.Location = new Point(1, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(417, 247);
            panelContainer.TabIndex = 0;
            // 
            // PopUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 246);
            Controls.Add(panelContainer);
            Name = "PopUpForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContainer;
    }
}