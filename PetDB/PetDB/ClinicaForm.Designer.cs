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
            perfilPanel = new Panel();
            clinicaPerfilBtnOK = new Button();
            clinicaPerfilBtnCancelar = new Button();
            clinicaPerfilBtnEditar = new Button();
            panelTitleLabel = new Label();
            label32 = new Label();
            clinicaPerfilEnderecoText = new TextBox();
            label33 = new Label();
            clinicaPerfilNomeText = new TextBox();
            label34 = new Label();
            label35 = new Label();
            clinicaPerfilEmailText = new TextBox();
            clinicaPerfilTelefoneText = new TextBox();
            registarTabControl.SuspendLayout();
            consultarTabControl.SuspendLayout();
            perfilPanel.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Items.AddRange(new object[] { resources.GetObject("listBox1.Items"), resources.GetObject("listBox1.Items1"), resources.GetObject("listBox1.Items2"), resources.GetObject("listBox1.Items3"), resources.GetObject("listBox1.Items4"), resources.GetObject("listBox1.Items5"), resources.GetObject("listBox1.Items6"), resources.GetObject("listBox1.Items7"), resources.GetObject("listBox1.Items8"), resources.GetObject("listBox1.Items9") });
            listBox1.Size = new Size(355, 224);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(32, 20);
            toolStripMenuItem1.Text = "<-";
            toolStripMenuItem1.Click += backBtn_Click;
            // 
            // perfilPanel
            // 
            perfilPanel.Controls.Add(clinicaPerfilBtnOK);
            perfilPanel.Controls.Add(clinicaPerfilBtnCancelar);
            perfilPanel.Controls.Add(clinicaPerfilBtnEditar);
            perfilPanel.Controls.Add(panelTitleLabel);
            perfilPanel.Controls.Add(label32);
            perfilPanel.Controls.Add(clinicaPerfilEnderecoText);
            perfilPanel.Controls.Add(label33);
            perfilPanel.Controls.Add(clinicaPerfilNomeText);
            perfilPanel.Controls.Add(label34);
            perfilPanel.Controls.Add(label35);
            perfilPanel.Controls.Add(clinicaPerfilEmailText);
            perfilPanel.Controls.Add(clinicaPerfilTelefoneText);
            perfilPanel.Location = new Point(10, 25);
            perfilPanel.Margin = new Padding(3, 2, 3, 2);
            perfilPanel.Name = "perfilPanel";
            perfilPanel.Size = new Size(666, 290);
            perfilPanel.TabIndex = 25;
            // 
            // clinicaPerfilBtnOK
            // 
            clinicaPerfilBtnOK.Location = new Point(548, 229);
            clinicaPerfilBtnOK.Name = "clinicaPerfilBtnOK";
            clinicaPerfilBtnOK.Size = new Size(84, 28);
            clinicaPerfilBtnOK.TabIndex = 50;
            clinicaPerfilBtnOK.Text = "Ok";
            clinicaPerfilBtnOK.UseVisualStyleBackColor = true;
            clinicaPerfilBtnOK.Click += clinicaPerfilBtnOK_Click;
            // 
            // clinicaPerfilBtnCancelar
            // 
            clinicaPerfilBtnCancelar.Location = new Point(375, 229);
            clinicaPerfilBtnCancelar.Name = "clinicaPerfilBtnCancelar";
            clinicaPerfilBtnCancelar.Size = new Size(91, 27);
            clinicaPerfilBtnCancelar.TabIndex = 49;
            clinicaPerfilBtnCancelar.Text = "Cancelar";
            clinicaPerfilBtnCancelar.UseVisualStyleBackColor = true;
            clinicaPerfilBtnCancelar.Click += clinicaPerfilBtnCancelar_Click;
            // 
            // clinicaPerfilBtnEditar
            // 
            clinicaPerfilBtnEditar.Location = new Point(459, 199);
            clinicaPerfilBtnEditar.Name = "clinicaPerfilBtnEditar";
            clinicaPerfilBtnEditar.Size = new Size(86, 28);
            clinicaPerfilBtnEditar.TabIndex = 48;
            clinicaPerfilBtnEditar.Text = "Editar";
            clinicaPerfilBtnEditar.UseVisualStyleBackColor = true;
            clinicaPerfilBtnEditar.Click += clinicaPerfilBtnEditar_Click;
            // 
            // panelTitleLabel
            // 
            panelTitleLabel.AutoSize = true;
            panelTitleLabel.Font = new Font("Segoe UI", 15F);
            panelTitleLabel.Location = new Point(15, 21);
            panelTitleLabel.Name = "panelTitleLabel";
            panelTitleLabel.Size = new Size(143, 35);
            panelTitleLabel.TabIndex = 47;
            panelTitleLabel.Text = "O seu perfil";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(17, 191);
            label32.Margin = new Padding(2, 0, 2, 0);
            label32.Name = "label32";
            label32.Size = new Size(71, 20);
            label32.TabIndex = 46;
            label32.Text = "Endereço";
            // 
            // clinicaPerfilEnderecoText
            // 
            clinicaPerfilEnderecoText.Location = new Point(17, 209);
            clinicaPerfilEnderecoText.Margin = new Padding(2);
            clinicaPerfilEnderecoText.Name = "clinicaPerfilEnderecoText";
            clinicaPerfilEnderecoText.Size = new Size(290, 27);
            clinicaPerfilEnderecoText.TabIndex = 45;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(17, 55);
            label33.Margin = new Padding(2, 0, 2, 0);
            label33.Name = "label33";
            label33.Size = new Size(50, 20);
            label33.TabIndex = 40;
            label33.Text = "Nome";
            // 
            // clinicaPerfilNomeText
            // 
            clinicaPerfilNomeText.Location = new Point(17, 73);
            clinicaPerfilNomeText.Margin = new Padding(2);
            clinicaPerfilNomeText.Name = "clinicaPerfilNomeText";
            clinicaPerfilNomeText.Size = new Size(290, 27);
            clinicaPerfilNomeText.TabIndex = 38;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(15, 98);
            label34.Margin = new Padding(2, 0, 2, 0);
            label34.Name = "label34";
            label34.Size = new Size(66, 20);
            label34.TabIndex = 42;
            label34.Text = "Telefone";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(17, 146);
            label35.Margin = new Padding(2, 0, 2, 0);
            label35.Name = "label35";
            label35.Size = new Size(46, 20);
            label35.TabIndex = 44;
            label35.Text = "Email";
            // 
            // clinicaPerfilEmailText
            // 
            clinicaPerfilEmailText.Location = new Point(17, 164);
            clinicaPerfilEmailText.Margin = new Padding(2);
            clinicaPerfilEmailText.Name = "clinicaPerfilEmailText";
            clinicaPerfilEmailText.Size = new Size(292, 27);
            clinicaPerfilEmailText.TabIndex = 43;
            // 
            // clinicaPerfilTelefoneText
            // 
            clinicaPerfilTelefoneText.Location = new Point(18, 116);
            clinicaPerfilTelefoneText.Margin = new Padding(2);
            clinicaPerfilTelefoneText.Name = "clinicaPerfilTelefoneText";
            clinicaPerfilTelefoneText.Size = new Size(292, 27);
            clinicaPerfilTelefoneText.TabIndex = 41;
            // 
            // ClinicaForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(818, 388);
            Controls.Add(perfilPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClinicaForm";
            Text = "ClinicaForm";
            Controls.SetChildIndex(consultarTabControl, 0);
            Controls.SetChildIndex(registarTabControl, 0);
            Controls.SetChildIndex(listBox1, 0);
            Controls.SetChildIndex(btnRestaurar, 0);
            Controls.SetChildIndex(editBtn, 0);
            Controls.SetChildIndex(addBtn, 0);
            Controls.SetChildIndex(remBtn, 0);
            Controls.SetChildIndex(okBtn, 0);
            Controls.SetChildIndex(cancelBtn, 0);
            Controls.SetChildIndex(perfilPanel, 0);
            registarTabControl.ResumeLayout(false);
            consultarTabControl.ResumeLayout(false);
            perfilPanel.ResumeLayout(false);
            perfilPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripMenuItem toolStripMenuItem1;
        private Panel perfilPanel;
        private Label label32;
        private TextBox clinicaPerfilEnderecoText;
        private Label label33;
        private TextBox clinicaPerfilNomeText;
        private Label label34;
        private Label label35;
        private TextBox clinicaPerfilEmailText;
        private TextBox clinicaPerfilTelefoneText;
        private Label panelTitleLabel;
        private Button clinicaPerfilBtnEditar;
        private Button clinicaPerfilBtnOK;
        private Button clinicaPerfilBtnCancelar;
    }
}