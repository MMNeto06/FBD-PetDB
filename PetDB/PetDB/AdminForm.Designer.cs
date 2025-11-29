
namespace PetDB
{
    partial class AdminForm
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
            toolStripMenuItem1 = new ToolStripMenuItem();
            registarToolStripMenuItem = new ToolStripMenuItem();
            clinicaVeterinariaToolStripMenuItem = new ToolStripMenuItem();
            médicoVeterinárioToolStripMenuItem = new ToolStripMenuItem();
            novoMédicoToolStripMenuItem = new ToolStripMenuItem();
            novaEspecialidadeToolStripMenuItem = new ToolStripMenuItem();
            donoToolStripMenuItem = new ToolStripMenuItem();
            animalToolStripMenuItem = new ToolStripMenuItem();
            novoAnimalToolStripMenuItem = new ToolStripMenuItem();
            novaEspécieToolStripMenuItem = new ToolStripMenuItem();
            medicamentoToolStripMenuItem = new ToolStripMenuItem();
            consultaToolStripMenuItem = new ToolStripMenuItem();
            pagamentoToolStripMenuItem = new ToolStripMenuItem();
            prescricaoToolStripMenuItem = new ToolStripMenuItem();
            consultarToolStripMenuItem = new ToolStripMenuItem();
            médicosPorClínicaToolStripMenuItem = new ToolStripMenuItem();
            animaisPorDonoToolStripMenuItem = new ToolStripMenuItem();
            animaisPorDonoToolStripMenuItem1 = new ToolStripMenuItem();
            animaisPorClínicaToolStripMenuItem = new ToolStripMenuItem();
            consultasToolStripMenuItem = new ToolStripMenuItem();
            consultasPorAnimalToolStripMenuItem = new ToolStripMenuItem();
            consultasPorMVToolStripMenuItem = new ToolStripMenuItem();
            prescriçõesPorAnimalToolStripMenuItem = new ToolStripMenuItem();
            pagamentosPorDonoToolStripMenuItem = new ToolStripMenuItem();
            listBox1 = new ListBox();
            adBtn = new Button();
            editBtn = new Button();
            remBtn = new Button();
            okBtn = new Button();
            cancelBtn = new Button();
            nifText = new TextBox();
            nifLabel = new Label();
            nomeLabel = new Label();
            nomeText = new TextBox();
            telefoneLabel = new Label();
            telefoneText = new TextBox();
            emailLabel = new Label();
            emailText = new TextBox();
            enderecoLabel = new Label();
            enderecoText = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, registarToolStripMenuItem, consultarToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(813, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(39, 24);
            toolStripMenuItem1.Text = "<-";
            toolStripMenuItem1.Click += backBtn_Click;
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
            // novoMédicoToolStripMenuItem
            // 
            novoMédicoToolStripMenuItem.Name = "novoMédicoToolStripMenuItem";
            novoMédicoToolStripMenuItem.Size = new Size(184, 26);
            novoMédicoToolStripMenuItem.Text = "Médico";
            // 
            // novaEspecialidadeToolStripMenuItem
            // 
            novaEspecialidadeToolStripMenuItem.Name = "novaEspecialidadeToolStripMenuItem";
            novaEspecialidadeToolStripMenuItem.Size = new Size(184, 26);
            novaEspecialidadeToolStripMenuItem.Text = "Especialidade";
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
            // novoAnimalToolStripMenuItem
            // 
            novoAnimalToolStripMenuItem.Name = "novoAnimalToolStripMenuItem";
            novoAnimalToolStripMenuItem.Size = new Size(142, 26);
            novoAnimalToolStripMenuItem.Text = "Animal";
            // 
            // novaEspécieToolStripMenuItem
            // 
            novaEspécieToolStripMenuItem.Name = "novaEspécieToolStripMenuItem";
            novaEspécieToolStripMenuItem.Size = new Size(142, 26);
            novaEspécieToolStripMenuItem.Text = "Espécie";
            // 
            // medicamentoToolStripMenuItem
            // 
            medicamentoToolStripMenuItem.Name = "medicamentoToolStripMenuItem";
            medicamentoToolStripMenuItem.Size = new Size(218, 26);
            medicamentoToolStripMenuItem.Text = "Medicamento";
            // 
            // consultaToolStripMenuItem
            // 
            consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            consultaToolStripMenuItem.Size = new Size(218, 26);
            consultaToolStripMenuItem.Text = "Consulta";
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
            médicosPorClínicaToolStripMenuItem.Size = new Size(243, 26);
            médicosPorClínicaToolStripMenuItem.Text = "Médicos por Clínica";
            // 
            // animaisPorDonoToolStripMenuItem
            // 
            animaisPorDonoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { animaisPorDonoToolStripMenuItem1, animaisPorClínicaToolStripMenuItem });
            animaisPorDonoToolStripMenuItem.Name = "animaisPorDonoToolStripMenuItem";
            animaisPorDonoToolStripMenuItem.Size = new Size(243, 26);
            animaisPorDonoToolStripMenuItem.Text = "Animais";
            // 
            // animaisPorDonoToolStripMenuItem1
            // 
            animaisPorDonoToolStripMenuItem1.Name = "animaisPorDonoToolStripMenuItem1";
            animaisPorDonoToolStripMenuItem1.Size = new Size(220, 26);
            animaisPorDonoToolStripMenuItem1.Text = "Animais por Dono";
            // 
            // animaisPorClínicaToolStripMenuItem
            // 
            animaisPorClínicaToolStripMenuItem.Name = "animaisPorClínicaToolStripMenuItem";
            animaisPorClínicaToolStripMenuItem.Size = new Size(220, 26);
            animaisPorClínicaToolStripMenuItem.Text = "Animais por Clínica";
            // 
            // consultasToolStripMenuItem
            // 
            consultasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { consultasPorAnimalToolStripMenuItem, consultasPorMVToolStripMenuItem });
            consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            consultasToolStripMenuItem.Size = new Size(243, 26);
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
            // prescriçõesPorAnimalToolStripMenuItem
            // 
            prescriçõesPorAnimalToolStripMenuItem.Name = "prescriçõesPorAnimalToolStripMenuItem";
            prescriçõesPorAnimalToolStripMenuItem.Size = new Size(243, 26);
            prescriçõesPorAnimalToolStripMenuItem.Text = "Prescrições por Animal";
            // 
            // pagamentosPorDonoToolStripMenuItem
            // 
            pagamentosPorDonoToolStripMenuItem.Name = "pagamentosPorDonoToolStripMenuItem";
            pagamentosPorDonoToolStripMenuItem.Size = new Size(243, 26);
            pagamentosPorDonoToolStripMenuItem.Text = "Pagamentos por Dono";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 31);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(356, 304);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // adBtn
            // 
            adBtn.Location = new Point(400, 260);
            adBtn.Name = "adBtn";
            adBtn.Size = new Size(94, 29);
            adBtn.TabIndex = 3;
            adBtn.Text = "Adicionar";
            adBtn.UseVisualStyleBackColor = true;
            adBtn.Click += button1_Click_1;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(525, 260);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(94, 29);
            editBtn.TabIndex = 4;
            editBtn.Text = "Editar";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += button1_Click_2;
            // 
            // remBtn
            // 
            remBtn.Location = new Point(649, 260);
            remBtn.Name = "remBtn";
            remBtn.Size = new Size(94, 29);
            remBtn.TabIndex = 5;
            remBtn.Text = "Remover";
            remBtn.UseVisualStyleBackColor = true;
            remBtn.Click += button2_Click;
            // 
            // okBtn
            // 
            okBtn.Location = new Point(584, 295);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(94, 29);
            okBtn.TabIndex = 6;
            okBtn.Text = "OK";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += button1_Click_3;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(459, 295);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 29);
            cancelBtn.TabIndex = 7;
            cancelBtn.Text = "Cancelar";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += button1_Click_4;
            // 
            // nifText
            // 
            nifText.Location = new Point(399, 65);
            nifText.Name = "nifText";
            nifText.Size = new Size(95, 27);
            nifText.TabIndex = 8;
            nifText.TextChanged += textBox1_TextChanged;
            // 
            // nifLabel
            // 
            nifLabel.AutoSize = true;
            nifLabel.Location = new Point(399, 42);
            nifLabel.Name = "nifLabel";
            nifLabel.Size = new Size(31, 20);
            nifLabel.TabIndex = 9;
            nifLabel.Text = "NIF";
            nifLabel.Click += label1_Click;
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new Point(524, 42);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new Size(50, 20);
            nomeLabel.TabIndex = 11;
            nomeLabel.Text = "Nome";
            nomeLabel.Click += label1_Click;
            // 
            // nomeText
            // 
            nomeText.Location = new Point(525, 65);
            nomeText.Name = "nomeText";
            nomeText.Size = new Size(276, 27);
            nomeText.TabIndex = 10;
            nomeText.TextChanged += textBox1_TextChanged_1;
            // 
            // telefoneLabel
            // 
            telefoneLabel.AutoSize = true;
            telefoneLabel.Location = new Point(399, 114);
            telefoneLabel.Name = "telefoneLabel";
            telefoneLabel.Size = new Size(66, 20);
            telefoneLabel.TabIndex = 13;
            telefoneLabel.Text = "Telefone";
            telefoneLabel.Click += label1_Click;
            // 
            // telefoneText
            // 
            telefoneText.Location = new Point(399, 137);
            telefoneText.Name = "telefoneText";
            telefoneText.Size = new Size(95, 27);
            telefoneText.TabIndex = 12;
            telefoneText.TextChanged += textBox1_TextChanged_2;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(528, 114);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(46, 20);
            emailLabel.TabIndex = 15;
            emailLabel.Text = "Email";
            emailLabel.Click += label1_Click;
            // 
            // emailText
            // 
            emailText.Location = new Point(524, 137);
            emailText.Name = "emailText";
            emailText.Size = new Size(277, 27);
            emailText.TabIndex = 14;
            emailText.TextChanged += emailText_TextChanged;
            // 
            // enderecoLabel
            // 
            enderecoLabel.AutoSize = true;
            enderecoLabel.Location = new Point(399, 188);
            enderecoLabel.Name = "enderecoLabel";
            enderecoLabel.Size = new Size(71, 20);
            enderecoLabel.TabIndex = 17;
            enderecoLabel.Text = "Endereço";
            // 
            // enderecoText
            // 
            enderecoText.Location = new Point(399, 211);
            enderecoText.Name = "enderecoText";
            enderecoText.Size = new Size(402, 27);
            enderecoText.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(813, 349);
            Controls.Add(enderecoLabel);
            Controls.Add(enderecoText);
            Controls.Add(emailLabel);
            Controls.Add(emailText);
            Controls.Add(telefoneLabel);
            Controls.Add(telefoneText);
            Controls.Add(nomeLabel);
            Controls.Add(nomeText);
            Controls.Add(nifLabel);
            Controls.Add(nifText);
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
            Load += Form1_Load_1;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Haha carreguei por aciddente no label :)");
        }

        #endregion
        private MenuStrip menuStrip1;
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
        private TextBox nifText;
        private Label nifLabel;
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
        private ToolStripMenuItem animaisPorDonoToolStripMenuItem1;
        private ToolStripMenuItem animaisPorClínicaToolStripMenuItem;
        private ToolStripMenuItem prescriçõesPorAnimalToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private Label telefoneLabel;
        private TextBox telefoneText;
        private Label emailLabel;
        private TextBox emailText;
        private Label enderecoLabel;
        private TextBox enderecoText;
    }
}
