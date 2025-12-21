namespace PetDB
{
    partial class MedicoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedicoForm));
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            consultasToolStripMenuItem = new ToolStripMenuItem();
            prescricoesToolStripMenuItem = new ToolStripMenuItem();
            perfilToolStripMenuItem = new ToolStripMenuItem();
            consultasPanel = new Panel();
            consultaAnimalText = new TextBox();
            consultaDataText = new TextBox();
            consultaBtnEditarRelatorio = new Button();
            consultaDateTimePicker = new DateTimePicker();
            consultaAnimaisComboBox = new ComboBox();
            consultaDataLabel = new Label();
            consultaBtnEditarTratamentos = new Button();
            consultaAnimalLabel = new Label();
            btnConsultarRelatorio = new Button();
            btnVerTratamentos = new Button();
            listBox1 = new ListBox();
            prescricoesPanel = new Panel();
            prescricaoNumeroText = new TextBox();
            prescricaoNumeroLabel = new Label();
            prescricaoAnimalComboBox = new ComboBox();
            prescricaoDateTimePicker = new DateTimePicker();
            prescricaoBtnVerMedicamentos = new Button();
            prescricaoAnimalText = new TextBox();
            prescricaoAnimalLabel = new Label();
            prescricaoDataText = new TextBox();
            prescricaoDataLabel = new Label();
            prescricaoBtnEditarMedicamentos = new Button();
            perfilPanel = new Panel();
            medicoClinicaComboBox = new ComboBox();
            medicoEspecialidadeComboBox = new ComboBox();
            medicoClinicaText = new TextBox();
            medicoEspecialidadeLabel = new Label();
            medicoEspecialidadeText = new TextBox();
            medicoNomeLabel = new Label();
            medicoNomeText = new TextBox();
            medicoTelefoneLabel = new Label();
            medicoEmailLabel = new Label();
            medicoEmailText = new TextBox();
            medicoTelefoneText = new TextBox();
            medicoClinicaLabel = new Label();
            panelTitleLabel = new Label();
            cancelBtn = new Button();
            okBtn = new Button();
            editBtn = new Button();
            addBtn = new Button();
            menuStrip1.SuspendLayout();
            consultasPanel.SuspendLayout();
            prescricoesPanel.SuspendLayout();
            perfilPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, consultasToolStripMenuItem, prescricoesToolStripMenuItem, perfilToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(700, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(32, 20);
            toolStripMenuItem1.Text = "<-";
            toolStripMenuItem1.Click += backBtn_Click;
            // 
            // consultasToolStripMenuItem
            // 
            consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            consultasToolStripMenuItem.Size = new Size(71, 20);
            consultasToolStripMenuItem.Text = "Consultas";
            consultasToolStripMenuItem.Click += consultasToolStripMenuItem_Click;
            // 
            // prescricoesToolStripMenuItem
            // 
            prescricoesToolStripMenuItem.Name = "prescricoesToolStripMenuItem";
            prescricoesToolStripMenuItem.Size = new Size(78, 20);
            prescricoesToolStripMenuItem.Text = "Prescrições";
            prescricoesToolStripMenuItem.Click += prescricoesToolStripMenuItem_Click;
            // 
            // perfilToolStripMenuItem
            // 
            perfilToolStripMenuItem.Name = "perfilToolStripMenuItem";
            perfilToolStripMenuItem.Size = new Size(46, 20);
            perfilToolStripMenuItem.Text = "Perfil";
            perfilToolStripMenuItem.Click += perfilToolStripMenuItem_Click;
            // 
            // consultasPanel
            // 
            consultasPanel.Controls.Add(consultaAnimalText);
            consultasPanel.Controls.Add(consultaDataText);
            consultasPanel.Controls.Add(consultaBtnEditarRelatorio);
            consultasPanel.Controls.Add(consultaDateTimePicker);
            consultasPanel.Controls.Add(consultaAnimaisComboBox);
            consultasPanel.Controls.Add(consultaDataLabel);
            consultasPanel.Controls.Add(consultaBtnEditarTratamentos);
            consultasPanel.Controls.Add(consultaAnimalLabel);
            consultasPanel.Controls.Add(btnConsultarRelatorio);
            consultasPanel.Controls.Add(btnVerTratamentos);
            consultasPanel.Location = new Point(340, 53);
            consultasPanel.Margin = new Padding(3, 2, 3, 2);
            consultasPanel.Name = "consultasPanel";
            consultasPanel.Size = new Size(318, 190);
            consultasPanel.TabIndex = 1;
            // 
            // consultaAnimalText
            // 
            consultaAnimalText.Location = new Point(161, 32);
            consultaAnimalText.Margin = new Padding(4, 3, 4, 3);
            consultaAnimalText.Name = "consultaAnimalText";
            consultaAnimalText.Size = new Size(146, 23);
            consultaAnimalText.TabIndex = 31;
            // 
            // consultaDataText
            // 
            consultaDataText.Location = new Point(10, 32);
            consultaDataText.Margin = new Padding(4, 3, 4, 3);
            consultaDataText.Name = "consultaDataText";
            consultaDataText.Size = new Size(146, 23);
            consultaDataText.TabIndex = 30;
            // 
            // consultaBtnEditarRelatorio
            // 
            consultaBtnEditarRelatorio.Location = new Point(88, 98);
            consultaBtnEditarRelatorio.Margin = new Padding(4, 3, 4, 3);
            consultaBtnEditarRelatorio.Name = "consultaBtnEditarRelatorio";
            consultaBtnEditarRelatorio.Size = new Size(145, 22);
            consultaBtnEditarRelatorio.TabIndex = 24;
            consultaBtnEditarRelatorio.Text = "Editar Relatório";
            consultaBtnEditarRelatorio.UseVisualStyleBackColor = true;
            consultaBtnEditarRelatorio.Click += consultaBtnEditarRelatorio_Click;
            // 
            // consultaDateTimePicker
            // 
            consultaDateTimePicker.Format = DateTimePickerFormat.Custom;
            consultaDateTimePicker.Location = new Point(10, 30);
            consultaDateTimePicker.Margin = new Padding(4, 3, 4, 3);
            consultaDateTimePicker.Name = "consultaDateTimePicker";
            consultaDateTimePicker.Size = new Size(147, 23);
            consultaDateTimePicker.TabIndex = 23;
            // 
            // consultaAnimaisComboBox
            // 
            consultaAnimaisComboBox.FormattingEnabled = true;
            consultaAnimaisComboBox.Location = new Point(162, 30);
            consultaAnimaisComboBox.Margin = new Padding(4, 3, 4, 3);
            consultaAnimaisComboBox.Name = "consultaAnimaisComboBox";
            consultaAnimaisComboBox.Size = new Size(145, 23);
            consultaAnimaisComboBox.TabIndex = 21;
            // 
            // consultaDataLabel
            // 
            consultaDataLabel.AutoSize = true;
            consultaDataLabel.Location = new Point(10, 12);
            consultaDataLabel.Margin = new Padding(4, 0, 4, 0);
            consultaDataLabel.Name = "consultaDataLabel";
            consultaDataLabel.Size = new Size(31, 15);
            consultaDataLabel.TabIndex = 17;
            consultaDataLabel.Text = "Data";
            // 
            // consultaBtnEditarTratamentos
            // 
            consultaBtnEditarTratamentos.Location = new Point(88, 126);
            consultaBtnEditarTratamentos.Margin = new Padding(4, 3, 4, 3);
            consultaBtnEditarTratamentos.Name = "consultaBtnEditarTratamentos";
            consultaBtnEditarTratamentos.Size = new Size(144, 22);
            consultaBtnEditarTratamentos.TabIndex = 20;
            consultaBtnEditarTratamentos.Text = "Editar Tratamentos";
            consultaBtnEditarTratamentos.UseVisualStyleBackColor = true;
            consultaBtnEditarTratamentos.Click += btnEditarTratamentos_Click;
            // 
            // consultaAnimalLabel
            // 
            consultaAnimalLabel.AutoSize = true;
            consultaAnimalLabel.Location = new Point(161, 12);
            consultaAnimalLabel.Margin = new Padding(4, 0, 4, 0);
            consultaAnimalLabel.Name = "consultaAnimalLabel";
            consultaAnimalLabel.Size = new Size(45, 15);
            consultaAnimalLabel.TabIndex = 18;
            consultaAnimalLabel.Text = "Animal";
            // 
            // btnConsultarRelatorio
            // 
            btnConsultarRelatorio.Location = new Point(88, 98);
            btnConsultarRelatorio.Margin = new Padding(4, 3, 4, 3);
            btnConsultarRelatorio.Name = "btnConsultarRelatorio";
            btnConsultarRelatorio.Size = new Size(144, 22);
            btnConsultarRelatorio.TabIndex = 33;
            btnConsultarRelatorio.Text = "Consultar Relatório";
            btnConsultarRelatorio.UseVisualStyleBackColor = true;
            btnConsultarRelatorio.Click += btnConsultarRelatorio_Click;
            // 
            // btnVerTratamentos
            // 
            btnVerTratamentos.Location = new Point(88, 126);
            btnVerTratamentos.Margin = new Padding(4, 3, 4, 3);
            btnVerTratamentos.Name = "btnVerTratamentos";
            btnVerTratamentos.Size = new Size(145, 22);
            btnVerTratamentos.TabIndex = 32;
            btnVerTratamentos.Text = "Ver Tratamentos";
            btnVerTratamentos.UseVisualStyleBackColor = true;
            btnVerTratamentos.Click += btnVerTratamentos_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(15, 65);
            listBox1.Margin = new Padding(2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(312, 244);
            listBox1.TabIndex = 3;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // prescricoesPanel
            // 
            prescricoesPanel.Controls.Add(prescricaoNumeroText);
            prescricoesPanel.Controls.Add(prescricaoNumeroLabel);
            prescricoesPanel.Controls.Add(prescricaoAnimalComboBox);
            prescricoesPanel.Controls.Add(prescricaoDateTimePicker);
            prescricoesPanel.Controls.Add(prescricaoBtnVerMedicamentos);
            prescricoesPanel.Controls.Add(prescricaoAnimalText);
            prescricoesPanel.Controls.Add(prescricaoAnimalLabel);
            prescricoesPanel.Controls.Add(prescricaoDataText);
            prescricoesPanel.Controls.Add(prescricaoDataLabel);
            prescricoesPanel.Controls.Add(prescricaoBtnEditarMedicamentos);
            prescricoesPanel.Location = new Point(331, 65);
            prescricoesPanel.Margin = new Padding(3, 2, 3, 2);
            prescricoesPanel.Name = "prescricoesPanel";
            prescricoesPanel.Size = new Size(344, 185);
            prescricoesPanel.TabIndex = 0;
            // 
            // prescricaoNumeroText
            // 
            prescricaoNumeroText.Location = new Point(96, 32);
            prescricaoNumeroText.Margin = new Padding(4, 3, 4, 3);
            prescricaoNumeroText.Name = "prescricaoNumeroText";
            prescricaoNumeroText.Size = new Size(148, 23);
            prescricaoNumeroText.TabIndex = 26;
            // 
            // prescricaoNumeroLabel
            // 
            prescricaoNumeroLabel.AutoSize = true;
            prescricaoNumeroLabel.Location = new Point(94, 14);
            prescricaoNumeroLabel.Margin = new Padding(4, 0, 4, 0);
            prescricaoNumeroLabel.Name = "prescricaoNumeroLabel";
            prescricaoNumeroLabel.Size = new Size(51, 15);
            prescricaoNumeroLabel.TabIndex = 25;
            prescricaoNumeroLabel.Text = "Número";
            // 
            // prescricaoAnimalComboBox
            // 
            prescricaoAnimalComboBox.FormattingEnabled = true;
            prescricaoAnimalComboBox.Location = new Point(188, 74);
            prescricaoAnimalComboBox.Margin = new Padding(4, 3, 4, 3);
            prescricaoAnimalComboBox.Name = "prescricaoAnimalComboBox";
            prescricaoAnimalComboBox.Size = new Size(148, 23);
            prescricaoAnimalComboBox.TabIndex = 24;
            // 
            // prescricaoDateTimePicker
            // 
            prescricaoDateTimePicker.Format = DateTimePickerFormat.Short;
            prescricaoDateTimePicker.Location = new Point(9, 74);
            prescricaoDateTimePicker.Margin = new Padding(4, 3, 4, 3);
            prescricaoDateTimePicker.Name = "prescricaoDateTimePicker";
            prescricaoDateTimePicker.Size = new Size(171, 23);
            prescricaoDateTimePicker.TabIndex = 23;
            // 
            // prescricaoBtnVerMedicamentos
            // 
            prescricaoBtnVerMedicamentos.Location = new Point(107, 112);
            prescricaoBtnVerMedicamentos.Margin = new Padding(4, 3, 4, 3);
            prescricaoBtnVerMedicamentos.Name = "prescricaoBtnVerMedicamentos";
            prescricaoBtnVerMedicamentos.Size = new Size(130, 22);
            prescricaoBtnVerMedicamentos.TabIndex = 19;
            prescricaoBtnVerMedicamentos.Text = "Ver Medicamentos";
            prescricaoBtnVerMedicamentos.UseVisualStyleBackColor = true;
            prescricaoBtnVerMedicamentos.Click += btnVerMedicamentos_Click;
            // 
            // prescricaoAnimalText
            // 
            prescricaoAnimalText.Location = new Point(188, 74);
            prescricaoAnimalText.Margin = new Padding(4, 3, 4, 3);
            prescricaoAnimalText.Name = "prescricaoAnimalText";
            prescricaoAnimalText.Size = new Size(148, 23);
            prescricaoAnimalText.TabIndex = 18;
            // 
            // prescricaoAnimalLabel
            // 
            prescricaoAnimalLabel.AutoSize = true;
            prescricaoAnimalLabel.Location = new Point(188, 56);
            prescricaoAnimalLabel.Margin = new Padding(4, 0, 4, 0);
            prescricaoAnimalLabel.Name = "prescricaoAnimalLabel";
            prescricaoAnimalLabel.Size = new Size(45, 15);
            prescricaoAnimalLabel.TabIndex = 17;
            prescricaoAnimalLabel.Text = "Animal";
            // 
            // prescricaoDataText
            // 
            prescricaoDataText.Location = new Point(9, 74);
            prescricaoDataText.Margin = new Padding(4, 3, 4, 3);
            prescricaoDataText.Name = "prescricaoDataText";
            prescricaoDataText.Size = new Size(171, 23);
            prescricaoDataText.TabIndex = 16;
            // 
            // prescricaoDataLabel
            // 
            prescricaoDataLabel.AutoSize = true;
            prescricaoDataLabel.Location = new Point(9, 57);
            prescricaoDataLabel.Margin = new Padding(4, 0, 4, 0);
            prescricaoDataLabel.Name = "prescricaoDataLabel";
            prescricaoDataLabel.Size = new Size(93, 15);
            prescricaoDataLabel.TabIndex = 15;
            prescricaoDataLabel.Text = "Data de Emissão";
            // 
            // prescricaoBtnEditarMedicamentos
            // 
            prescricaoBtnEditarMedicamentos.Location = new Point(96, 112);
            prescricaoBtnEditarMedicamentos.Margin = new Padding(4, 3, 4, 3);
            prescricaoBtnEditarMedicamentos.Name = "prescricaoBtnEditarMedicamentos";
            prescricaoBtnEditarMedicamentos.Size = new Size(156, 22);
            prescricaoBtnEditarMedicamentos.TabIndex = 22;
            prescricaoBtnEditarMedicamentos.Text = "Editar Medicamentos";
            prescricaoBtnEditarMedicamentos.UseVisualStyleBackColor = true;
            prescricaoBtnEditarMedicamentos.Click += prescricaoBtnEditarMedicamentos_Click;
            // 
            // perfilPanel
            // 
            perfilPanel.Controls.Add(medicoClinicaComboBox);
            perfilPanel.Controls.Add(medicoEspecialidadeComboBox);
            perfilPanel.Controls.Add(medicoClinicaText);
            perfilPanel.Controls.Add(medicoEspecialidadeLabel);
            perfilPanel.Controls.Add(medicoEspecialidadeText);
            perfilPanel.Controls.Add(medicoNomeLabel);
            perfilPanel.Controls.Add(medicoNomeText);
            perfilPanel.Controls.Add(medicoTelefoneLabel);
            perfilPanel.Controls.Add(medicoEmailLabel);
            perfilPanel.Controls.Add(medicoEmailText);
            perfilPanel.Controls.Add(medicoTelefoneText);
            perfilPanel.Controls.Add(medicoClinicaLabel);
            perfilPanel.Location = new Point(19, 53);
            perfilPanel.Margin = new Padding(3, 2, 3, 2);
            perfilPanel.Name = "perfilPanel";
            perfilPanel.Size = new Size(342, 220);
            perfilPanel.TabIndex = 1;
            // 
            // medicoClinicaComboBox
            // 
            medicoClinicaComboBox.FormattingEnabled = true;
            medicoClinicaComboBox.Location = new Point(21, 193);
            medicoClinicaComboBox.Margin = new Padding(4, 3, 4, 3);
            medicoClinicaComboBox.Name = "medicoClinicaComboBox";
            medicoClinicaComboBox.Size = new Size(285, 23);
            medicoClinicaComboBox.TabIndex = 49;
            // 
            // medicoEspecialidadeComboBox
            // 
            medicoEspecialidadeComboBox.FormattingEnabled = true;
            medicoEspecialidadeComboBox.Location = new Point(19, 151);
            medicoEspecialidadeComboBox.Margin = new Padding(4, 3, 4, 3);
            medicoEspecialidadeComboBox.Name = "medicoEspecialidadeComboBox";
            medicoEspecialidadeComboBox.Size = new Size(287, 23);
            medicoEspecialidadeComboBox.TabIndex = 48;
            // 
            // medicoClinicaText
            // 
            medicoClinicaText.Location = new Point(20, 194);
            medicoClinicaText.Margin = new Padding(2);
            medicoClinicaText.Name = "medicoClinicaText";
            medicoClinicaText.Size = new Size(286, 23);
            medicoClinicaText.TabIndex = 47;
            // 
            // medicoEspecialidadeLabel
            // 
            medicoEspecialidadeLabel.AutoSize = true;
            medicoEspecialidadeLabel.Location = new Point(18, 133);
            medicoEspecialidadeLabel.Margin = new Padding(2, 0, 2, 0);
            medicoEspecialidadeLabel.Name = "medicoEspecialidadeLabel";
            medicoEspecialidadeLabel.Size = new Size(78, 15);
            medicoEspecialidadeLabel.TabIndex = 46;
            medicoEspecialidadeLabel.Text = "Especialidade";
            // 
            // medicoEspecialidadeText
            // 
            medicoEspecialidadeText.Location = new Point(18, 151);
            medicoEspecialidadeText.Margin = new Padding(2);
            medicoEspecialidadeText.Name = "medicoEspecialidadeText";
            medicoEspecialidadeText.Size = new Size(290, 23);
            medicoEspecialidadeText.TabIndex = 45;
            // 
            // medicoNomeLabel
            // 
            medicoNomeLabel.AutoSize = true;
            medicoNomeLabel.Location = new Point(18, 12);
            medicoNomeLabel.Margin = new Padding(2, 0, 2, 0);
            medicoNomeLabel.Name = "medicoNomeLabel";
            medicoNomeLabel.Size = new Size(40, 15);
            medicoNomeLabel.TabIndex = 40;
            medicoNomeLabel.Text = "Nome";
            // 
            // medicoNomeText
            // 
            medicoNomeText.Location = new Point(18, 30);
            medicoNomeText.Margin = new Padding(2);
            medicoNomeText.Name = "medicoNomeText";
            medicoNomeText.Size = new Size(290, 23);
            medicoNomeText.TabIndex = 38;
            // 
            // medicoTelefoneLabel
            // 
            medicoTelefoneLabel.AutoSize = true;
            medicoTelefoneLabel.Location = new Point(16, 51);
            medicoTelefoneLabel.Margin = new Padding(2, 0, 2, 0);
            medicoTelefoneLabel.Name = "medicoTelefoneLabel";
            medicoTelefoneLabel.Size = new Size(52, 15);
            medicoTelefoneLabel.TabIndex = 42;
            medicoTelefoneLabel.Text = "Telefone";
            // 
            // medicoEmailLabel
            // 
            medicoEmailLabel.AutoSize = true;
            medicoEmailLabel.Location = new Point(16, 94);
            medicoEmailLabel.Margin = new Padding(2, 0, 2, 0);
            medicoEmailLabel.Name = "medicoEmailLabel";
            medicoEmailLabel.Size = new Size(36, 15);
            medicoEmailLabel.TabIndex = 44;
            medicoEmailLabel.Text = "Email";
            // 
            // medicoEmailText
            // 
            medicoEmailText.Location = new Point(16, 112);
            medicoEmailText.Margin = new Padding(2);
            medicoEmailText.Name = "medicoEmailText";
            medicoEmailText.Size = new Size(292, 23);
            medicoEmailText.TabIndex = 43;
            // 
            // medicoTelefoneText
            // 
            medicoTelefoneText.Location = new Point(16, 69);
            medicoTelefoneText.Margin = new Padding(2);
            medicoTelefoneText.Name = "medicoTelefoneText";
            medicoTelefoneText.Size = new Size(292, 23);
            medicoTelefoneText.TabIndex = 41;
            // 
            // medicoClinicaLabel
            // 
            medicoClinicaLabel.AutoSize = true;
            medicoClinicaLabel.Location = new Point(18, 175);
            medicoClinicaLabel.Margin = new Padding(2, 0, 2, 0);
            medicoClinicaLabel.Name = "medicoClinicaLabel";
            medicoClinicaLabel.Size = new Size(43, 15);
            medicoClinicaLabel.TabIndex = 36;
            medicoClinicaLabel.Text = "Clínica";
            // 
            // panelTitleLabel
            // 
            panelTitleLabel.AutoSize = true;
            panelTitleLabel.Font = new Font("Segoe UI", 15F);
            panelTitleLabel.Location = new Point(35, 25);
            panelTitleLabel.Name = "panelTitleLabel";
            panelTitleLabel.Size = new Size(111, 28);
            panelTitleLabel.TabIndex = 0;
            panelTitleLabel.Text = "O seu perfil";
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(398, 279);
            cancelBtn.Margin = new Padding(2);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(82, 22);
            cancelBtn.TabIndex = 33;
            cancelBtn.Text = "Cancelar";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // okBtn
            // 
            okBtn.Location = new Point(508, 279);
            okBtn.Margin = new Padding(2);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(82, 22);
            okBtn.TabIndex = 32;
            okBtn.Text = "OK";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += OkBtn_Click;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(508, 254);
            editBtn.Margin = new Padding(2);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(82, 22);
            editBtn.TabIndex = 31;
            editBtn.Text = "Editar";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(398, 254);
            addBtn.Margin = new Padding(2);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(82, 22);
            addBtn.TabIndex = 30;
            addBtn.Text = "Adicionar";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // MedicoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(cancelBtn);
            Controls.Add(okBtn);
            Controls.Add(editBtn);
            Controls.Add(addBtn);
            Controls.Add(panelTitleLabel);
            Controls.Add(menuStrip1);
            Controls.Add(listBox1);
            Controls.Add(consultasPanel);
            Controls.Add(perfilPanel);
            Controls.Add(prescricoesPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MedicoForm";
            Text = "Bem Vindo Médico";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            consultasPanel.ResumeLayout(false);
            consultasPanel.PerformLayout();
            prescricoesPanel.ResumeLayout(false);
            prescricoesPanel.PerformLayout();
            perfilPanel.ResumeLayout(false);
            perfilPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem consultasToolStripMenuItem;
        private ToolStripMenuItem prescricoesToolStripMenuItem;
        private ToolStripMenuItem perfilToolStripMenuItem;
        private Panel consultasPanel;
        private Panel prescricoesPanel;
        private Panel perfilPanel;
        private Label panelTitleLabel;
        private ListBox listBox1;
        private Button consultaBtnEditarRelatorio;
        private DateTimePicker consultaDateTimePicker;
        private ComboBox consultaAnimaisComboBox;
        private Label consultaDataLabel;
        private Button consultaBtnEditarTratamentos;
        private Label consultaAnimalLabel;
        private TextBox consultaAnimalText;
        private TextBox consultaDataText;
        private Button btnConsultarRelatorio;
        private Button btnVerTratamentos;
        private ComboBox prescricaoAnimalComboBox;
        private DateTimePicker prescricaoDateTimePicker;
        private Button prescricaoBtnEditarMedicamentos;
        private Button prescricaoBtnVerMedicamentos;
        private TextBox prescricaoAnimalText;
        private Label prescricaoAnimalLabel;
        private TextBox prescricaoDataText;
        private Label prescricaoDataLabel;
        private ComboBox medicoClinicaComboBox;
        private ComboBox medicoEspecialidadeComboBox;
        private TextBox medicoClinicaText;
        private Label medicoEspecialidadeLabel;
        private TextBox medicoEspecialidadeText;
        private Label medicoNomeLabel;
        private TextBox medicoNomeText;
        private Label medicoTelefoneLabel;
        private Label medicoEmailLabel;
        private TextBox medicoEmailText;
        private TextBox medicoTelefoneText;
        private Label medicoClinicaLabel;
        private Button cancelBtn;
        private Button okBtn;
        private Button editBtn;
        private Button addBtn;
        private TextBox prescricaoNumeroText;
        private Label prescricaoNumeroLabel;
    }
}