namespace PetDB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            ficheiroToolStripMenuItem = new ToolStripMenuItem();
            carregarFicheiroToolStripMenuItem = new ToolStripMenuItem();
            registarToolStripMenuItem = new ToolStripMenuItem();
            clinicaVeterinariaToolStripMenuItem = new ToolStripMenuItem();
            médicoVeterinárioToolStripMenuItem = new ToolStripMenuItem();
            donoToolStripMenuItem = new ToolStripMenuItem();
            animalToolStripMenuItem = new ToolStripMenuItem();
            medicamentoToolStripMenuItem = new ToolStripMenuItem();
            pagamentoToolStripMenuItem = new ToolStripMenuItem();
            prescricaoToolStripMenuItem = new ToolStripMenuItem();
            consultaToolStripMenuItem = new ToolStripMenuItem();
            listBox1 = new ListBox();
            adBtn = new Button();
            editBtn = new Button();
            remBtn = new Button();
            okBtn = new Button();
            cancelBtn = new Button();
            idText = new TextBox();
            idLabel = new Label();
            nomeLabel = new Label();
            nomeText = new TextBox();
            novoMédicoToolStripMenuItem = new ToolStripMenuItem();
            novaEspecialidadeToolStripMenuItem = new ToolStripMenuItem();
            novoAnimalToolStripMenuItem = new ToolStripMenuItem();
            novaEspécieToolStripMenuItem = new ToolStripMenuItem();
            consultarToolStripMenuItem = new ToolStripMenuItem();
            médicosPorClínicaToolStripMenuItem = new ToolStripMenuItem();
            animaisPorDonoToolStripMenuItem = new ToolStripMenuItem();
            consultasToolStripMenuItem = new ToolStripMenuItem();
            consultasPorAnimalToolStripMenuItem = new ToolStripMenuItem();
            consultasPorMVToolStripMenuItem = new ToolStripMenuItem();
            pagamentosPorDonoToolStripMenuItem = new ToolStripMenuItem();
            guardarFicheiroToolStripMenuItem = new ToolStripMenuItem();
            animaisPorDonoToolStripMenuItem1 = new ToolStripMenuItem();
            animaisPorClínicaToolStripMenuItem = new ToolStripMenuItem();
            prescriçõesPorAnimalToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, ficheiroToolStripMenuItem, registarToolStripMenuItem, consultarToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // ficheiroToolStripMenuItem
            // 
            ficheiroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { carregarFicheiroToolStripMenuItem, guardarFicheiroToolStripMenuItem });
            ficheiroToolStripMenuItem.Name = "ficheiroToolStripMenuItem";
            ficheiroToolStripMenuItem.Size = new Size(75, 24);
            ficheiroToolStripMenuItem.Text = "Ficheiro";
            // 
            // carregarFicheiroToolStripMenuItem
            // 
            carregarFicheiroToolStripMenuItem.Name = "carregarFicheiroToolStripMenuItem";
            carregarFicheiroToolStripMenuItem.Size = new Size(224, 26);
            carregarFicheiroToolStripMenuItem.Text = "Carregar ficheiro";
            // 
            // registarToolStripMenuItem
            // 
            registarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clinicaVeterinariaToolStripMenuItem, médicoVeterinárioToolStripMenuItem, donoToolStripMenuItem, animalToolStripMenuItem, medicamentoToolStripMenuItem, consultaToolStripMenuItem, pagamentoToolStripMenuItem, prescricaoToolStripMenuItem });
            registarToolStripMenuItem.Name = "registarToolStripMenuItem";
            registarToolStripMenuItem.Size = new Size(77, 24);
            registarToolStripMenuItem.Text = "Registar";
            // 
            // clinicaVeterinariaToolStripMenuItem
            // 
            clinicaVeterinariaToolStripMenuItem.Name = "clinicaVeterinariaToolStripMenuItem";
            clinicaVeterinariaToolStripMenuItem.Size = new Size(218, 26);
            clinicaVeterinariaToolStripMenuItem.Text = "Clinica Veterinaria";
            clinicaVeterinariaToolStripMenuItem.Click += clinicaVeterinariaToolStripMenuItem_Click;
            // 
            // médicoVeterinárioToolStripMenuItem
            // 
            médicoVeterinárioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoMédicoToolStripMenuItem, novaEspecialidadeToolStripMenuItem });
            médicoVeterinárioToolStripMenuItem.Name = "médicoVeterinárioToolStripMenuItem";
            médicoVeterinárioToolStripMenuItem.Size = new Size(218, 26);
            médicoVeterinárioToolStripMenuItem.Text = "Médico Veterinário";
            // 
            // donoToolStripMenuItem
            // 
            donoToolStripMenuItem.Name = "donoToolStripMenuItem";
            donoToolStripMenuItem.Size = new Size(218, 26);
            donoToolStripMenuItem.Text = "Dono";
            // 
            // animalToolStripMenuItem
            // 
            animalToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoAnimalToolStripMenuItem, novaEspécieToolStripMenuItem });
            animalToolStripMenuItem.Name = "animalToolStripMenuItem";
            animalToolStripMenuItem.Size = new Size(218, 26);
            animalToolStripMenuItem.Text = "Animal";
            // 
            // medicamentoToolStripMenuItem
            // 
            medicamentoToolStripMenuItem.Name = "medicamentoToolStripMenuItem";
            medicamentoToolStripMenuItem.Size = new Size(218, 26);
            medicamentoToolStripMenuItem.Text = "Medicamento";
            // 
            // pagamentoToolStripMenuItem
            // 
            pagamentoToolStripMenuItem.Name = "pagamentoToolStripMenuItem";
            pagamentoToolStripMenuItem.Size = new Size(218, 26);
            pagamentoToolStripMenuItem.Text = "Pagamento";
            // 
            // prescricaoToolStripMenuItem
            // 
            prescricaoToolStripMenuItem.Name = "prescricaoToolStripMenuItem";
            prescricaoToolStripMenuItem.Size = new Size(218, 26);
            prescricaoToolStripMenuItem.Text = "Prescrição";
            // 
            // consultaToolStripMenuItem
            // 
            consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            consultaToolStripMenuItem.Size = new Size(218, 26);
            consultaToolStripMenuItem.Text = "Consulta";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 31);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(356, 444);
            listBox1.TabIndex = 2;
            // 
            // adBtn
            // 
            adBtn.Location = new Point(399, 403);
            adBtn.Name = "adBtn";
            adBtn.Size = new Size(94, 29);
            adBtn.TabIndex = 3;
            adBtn.Text = "Adicionar";
            adBtn.UseVisualStyleBackColor = true;
            adBtn.Click += button1_Click_1;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(524, 403);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(94, 29);
            editBtn.TabIndex = 4;
            editBtn.Text = "Editar";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += button1_Click_2;
            // 
            // remBtn
            // 
            remBtn.Location = new Point(648, 403);
            remBtn.Name = "remBtn";
            remBtn.Size = new Size(94, 29);
            remBtn.TabIndex = 5;
            remBtn.Text = "Remover";
            remBtn.UseVisualStyleBackColor = true;
            remBtn.Click += button2_Click;
            // 
            // okBtn
            // 
            okBtn.Location = new Point(583, 438);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(94, 29);
            okBtn.TabIndex = 6;
            okBtn.Text = "OK";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += button1_Click_3;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(458, 438);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 29);
            cancelBtn.TabIndex = 7;
            cancelBtn.Text = "Cancelar";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += button1_Click_4;
            // 
            // idText
            // 
            idText.Location = new Point(399, 65);
            idText.Name = "idText";
            idText.Size = new Size(94, 27);
            idText.TabIndex = 8;
            idText.TextChanged += textBox1_TextChanged;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(399, 42);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(24, 20);
            idLabel.TabIndex = 9;
            idLabel.Text = "ID";
            idLabel.Click += this.label1_Click;
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new Point(399, 119);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new Size(50, 20);
            nomeLabel.TabIndex = 11;
            nomeLabel.Text = "Nome";
            nomeLabel.Click += this.label1_Click_1;
            // 
            // nomeText
            // 
            nomeText.Location = new Point(399, 142);
            nomeText.Name = "nomeText";
            nomeText.Size = new Size(219, 27);
            nomeText.TabIndex = 10;
            nomeText.TextChanged += textBox1_TextChanged_1;
            // 
            // novoMédicoToolStripMenuItem
            // 
            novoMédicoToolStripMenuItem.Name = "novoMédicoToolStripMenuItem";
            novoMédicoToolStripMenuItem.Size = new Size(224, 26);
            novoMédicoToolStripMenuItem.Text = "Médico";
            // 
            // novaEspecialidadeToolStripMenuItem
            // 
            novaEspecialidadeToolStripMenuItem.Name = "novaEspecialidadeToolStripMenuItem";
            novaEspecialidadeToolStripMenuItem.Size = new Size(224, 26);
            novaEspecialidadeToolStripMenuItem.Text = "Especialidade";
            // 
            // novoAnimalToolStripMenuItem
            // 
            novoAnimalToolStripMenuItem.Name = "novoAnimalToolStripMenuItem";
            novoAnimalToolStripMenuItem.Size = new Size(224, 26);
            novoAnimalToolStripMenuItem.Text = "Animal";
            // 
            // novaEspécieToolStripMenuItem
            // 
            novaEspécieToolStripMenuItem.Name = "novaEspécieToolStripMenuItem";
            novaEspécieToolStripMenuItem.Size = new Size(224, 26);
            novaEspécieToolStripMenuItem.Text = "Espécie";
            // 
            // consultarToolStripMenuItem
            // 
            consultarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { médicosPorClínicaToolStripMenuItem, animaisPorDonoToolStripMenuItem, consultasToolStripMenuItem, prescriçõesPorAnimalToolStripMenuItem, pagamentosPorDonoToolStripMenuItem });
            consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            consultarToolStripMenuItem.Size = new Size(85, 24);
            consultarToolStripMenuItem.Text = "Consultar";
            // 
            // médicosPorClínicaToolStripMenuItem
            // 
            médicosPorClínicaToolStripMenuItem.Name = "médicosPorClínicaToolStripMenuItem";
            médicosPorClínicaToolStripMenuItem.Size = new Size(241, 26);
            médicosPorClínicaToolStripMenuItem.Text = "Médicos por Clínica";
            // 
            // animaisPorDonoToolStripMenuItem
            // 
            animaisPorDonoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { animaisPorDonoToolStripMenuItem1, animaisPorClínicaToolStripMenuItem });
            animaisPorDonoToolStripMenuItem.Name = "animaisPorDonoToolStripMenuItem";
            animaisPorDonoToolStripMenuItem.Size = new Size(241, 26);
            animaisPorDonoToolStripMenuItem.Text = "Animais";
            // 
            // consultasToolStripMenuItem
            // 
            consultasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { consultasPorAnimalToolStripMenuItem, consultasPorMVToolStripMenuItem });
            consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            consultasToolStripMenuItem.Size = new Size(241, 26);
            consultasToolStripMenuItem.Text = "Consultas";
            // 
            // consultasPorAnimalToolStripMenuItem
            // 
            consultasPorAnimalToolStripMenuItem.Name = "consultasPorAnimalToolStripMenuItem";
            consultasPorAnimalToolStripMenuItem.Size = new Size(233, 26);
            consultasPorAnimalToolStripMenuItem.Text = "Consultas por Animal";
            // 
            // consultasPorMVToolStripMenuItem
            // 
            consultasPorMVToolStripMenuItem.Name = "consultasPorMVToolStripMenuItem";
            consultasPorMVToolStripMenuItem.Size = new Size(233, 26);
            consultasPorMVToolStripMenuItem.Text = "Consultas por MV";
            // 
            // pagamentosPorDonoToolStripMenuItem
            // 
            pagamentosPorDonoToolStripMenuItem.Name = "pagamentosPorDonoToolStripMenuItem";
            pagamentosPorDonoToolStripMenuItem.Size = new Size(241, 26);
            pagamentosPorDonoToolStripMenuItem.Text = "Pagamentos por Dono";
            // 
            // guardarFicheiroToolStripMenuItem
            // 
            guardarFicheiroToolStripMenuItem.Name = "guardarFicheiroToolStripMenuItem";
            guardarFicheiroToolStripMenuItem.Size = new Size(224, 26);
            guardarFicheiroToolStripMenuItem.Text = "Guardar ficheiro";
            // 
            // animaisPorDonoToolStripMenuItem1
            // 
            animaisPorDonoToolStripMenuItem1.Name = "animaisPorDonoToolStripMenuItem1";
            animaisPorDonoToolStripMenuItem1.Size = new Size(224, 26);
            animaisPorDonoToolStripMenuItem1.Text = "Animais por Dono";
            // 
            // animaisPorClínicaToolStripMenuItem
            // 
            animaisPorClínicaToolStripMenuItem.Name = "animaisPorClínicaToolStripMenuItem";
            animaisPorClínicaToolStripMenuItem.Size = new Size(224, 26);
            animaisPorClínicaToolStripMenuItem.Text = "Animais por Clínica";
            // 
            // prescriçõesPorAnimalToolStripMenuItem
            // 
            prescriçõesPorAnimalToolStripMenuItem.Name = "prescriçõesPorAnimalToolStripMenuItem";
            prescriçõesPorAnimalToolStripMenuItem.Size = new Size(243, 26);
            prescriçõesPorAnimalToolStripMenuItem.Text = "Prescrições por Animal";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(39, 24);
            toolStripMenuItem1.Text = "<-";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 482);
            Controls.Add(nomeLabel);
            Controls.Add(nomeText);
            Controls.Add(idLabel);
            Controls.Add(idText);
            Controls.Add(cancelBtn);
            Controls.Add(okBtn);
            Controls.Add(remBtn);
            Controls.Add(editBtn);
            Controls.Add(adBtn);
            Controls.Add(listBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ficheiroToolStripMenuItem;
        private ToolStripMenuItem carregarFicheiroToolStripMenuItem;
        private ToolStripMenuItem registarToolStripMenuItem;
        private ToolStripMenuItem clinicaVeterinariaToolStripMenuItem;
        private ToolStripMenuItem médicoVeterinárioToolStripMenuItem;
        private ToolStripMenuItem donoToolStripMenuItem;
        private ToolStripMenuItem animalToolStripMenuItem;
        private ToolStripMenuItem medicamentoToolStripMenuItem;
        private ToolStripMenuItem pagamentoToolStripMenuItem;
        private ToolStripMenuItem prescricaoToolStripMenuItem;
        private ToolStripMenuItem consultaToolStripMenuItem;
        private ListBox listBox1;
        private Button adBtn;
        private Button editBtn;
        private Button remBtn;
        private Button okBtn;
        private Button cancelBtn;
        private TextBox idText;
        private Label idLabel;
        private Label nomeLabel;
        private TextBox nomeText;
        private ToolStripMenuItem novoMédicoToolStripMenuItem;
        private ToolStripMenuItem novaEspecialidadeToolStripMenuItem;
        private ToolStripMenuItem novoAnimalToolStripMenuItem;
        private ToolStripMenuItem novaEspécieToolStripMenuItem;
        private ToolStripMenuItem consultarToolStripMenuItem;
        private ToolStripMenuItem médicosPorClínicaToolStripMenuItem;
        private ToolStripMenuItem animaisPorDonoToolStripMenuItem;
        private ToolStripMenuItem consultasToolStripMenuItem;
        private ToolStripMenuItem consultasPorAnimalToolStripMenuItem;
        private ToolStripMenuItem consultasPorMVToolStripMenuItem;
        private ToolStripMenuItem pagamentosPorDonoToolStripMenuItem;
        private ToolStripMenuItem guardarFicheiroToolStripMenuItem;
        private ToolStripMenuItem animaisPorDonoToolStripMenuItem1;
        private ToolStripMenuItem animaisPorClínicaToolStripMenuItem;
        private ToolStripMenuItem prescriçõesPorAnimalToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}
