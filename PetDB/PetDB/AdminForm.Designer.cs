
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
            addBtn = new Button();
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
            clinicaComboBox = new ComboBox();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, registarToolStripMenuItem, consultarToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(650, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(32, 20);
            toolStripMenuItem1.Text = "<-";
            toolStripMenuItem1.Click += backBtn_Click;
            // 
            // registarToolStripMenuItem
            // 
            registarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clinicaVeterinariaToolStripMenuItem, médicoVeterinárioToolStripMenuItem, donoToolStripMenuItem, animalToolStripMenuItem, medicamentoToolStripMenuItem, consultaToolStripMenuItem, pagamentoToolStripMenuItem, prescricaoToolStripMenuItem });
            registarToolStripMenuItem.Name = "registarToolStripMenuItem";
            registarToolStripMenuItem.Size = new Size(61, 20);
            registarToolStripMenuItem.Text = "Registar";
            // 
            // clinicaVeterinariaToolStripMenuItem
            // 
            clinicaVeterinariaToolStripMenuItem.Name = "clinicaVeterinariaToolStripMenuItem";
            clinicaVeterinariaToolStripMenuItem.Size = new Size(173, 22);
            clinicaVeterinariaToolStripMenuItem.Text = "Clinica Veterinaria";
            clinicaVeterinariaToolStripMenuItem.Click += clinicaVeterinariaToolStripMenuItem_Click;
            // 
            // médicoVeterinárioToolStripMenuItem
            // 
            médicoVeterinárioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoMédicoToolStripMenuItem, novaEspecialidadeToolStripMenuItem });
            médicoVeterinárioToolStripMenuItem.Name = "médicoVeterinárioToolStripMenuItem";
            médicoVeterinárioToolStripMenuItem.Size = new Size(173, 22);
            médicoVeterinárioToolStripMenuItem.Text = "Médico Veterinário";
            // 
            // novoMédicoToolStripMenuItem
            // 
            novoMédicoToolStripMenuItem.Name = "novoMédicoToolStripMenuItem";
            novoMédicoToolStripMenuItem.Size = new Size(145, 22);
            novoMédicoToolStripMenuItem.Text = "Médico";
            novoMédicoToolStripMenuItem.Click += medicoVeterinarioToolStripMenuItem_Click;
            // 
            // novaEspecialidadeToolStripMenuItem
            // 
            novaEspecialidadeToolStripMenuItem.Name = "novaEspecialidadeToolStripMenuItem";
            novaEspecialidadeToolStripMenuItem.Size = new Size(145, 22);
            novaEspecialidadeToolStripMenuItem.Text = "Especialidade";
            // 
            // donoToolStripMenuItem
            // 
            donoToolStripMenuItem.Name = "donoToolStripMenuItem";
            donoToolStripMenuItem.Size = new Size(173, 22);
            donoToolStripMenuItem.Text = "Dono";
            donoToolStripMenuItem.Click += donoToolStripMenuItem_Click;
            // 
            // animalToolStripMenuItem
            // 
            animalToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { novoAnimalToolStripMenuItem, novaEspécieToolStripMenuItem });
            animalToolStripMenuItem.Name = "animalToolStripMenuItem";
            animalToolStripMenuItem.Size = new Size(173, 22);
            animalToolStripMenuItem.Text = "Animal";
            // 
            // novoAnimalToolStripMenuItem
            // 
            novoAnimalToolStripMenuItem.Name = "novoAnimalToolStripMenuItem";
            novoAnimalToolStripMenuItem.Size = new Size(113, 22);
            novoAnimalToolStripMenuItem.Text = "Animal";
            // 
            // novaEspécieToolStripMenuItem
            // 
            novaEspécieToolStripMenuItem.Name = "novaEspécieToolStripMenuItem";
            novaEspécieToolStripMenuItem.Size = new Size(113, 22);
            novaEspécieToolStripMenuItem.Text = "Espécie";
            // 
            // medicamentoToolStripMenuItem
            // 
            medicamentoToolStripMenuItem.Name = "medicamentoToolStripMenuItem";
            medicamentoToolStripMenuItem.Size = new Size(173, 22);
            medicamentoToolStripMenuItem.Text = "Medicamento";
            // 
            // consultaToolStripMenuItem
            // 
            consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            consultaToolStripMenuItem.Size = new Size(173, 22);
            consultaToolStripMenuItem.Text = "Consulta";
            // 
            // pagamentoToolStripMenuItem
            // 
            pagamentoToolStripMenuItem.Name = "pagamentoToolStripMenuItem";
            pagamentoToolStripMenuItem.Size = new Size(173, 22);
            pagamentoToolStripMenuItem.Text = "Pagamento";
            // 
            // prescricaoToolStripMenuItem
            // 
            prescricaoToolStripMenuItem.Name = "prescricaoToolStripMenuItem";
            prescricaoToolStripMenuItem.Size = new Size(173, 22);
            prescricaoToolStripMenuItem.Text = "Prescrição";
            // 
            // consultarToolStripMenuItem
            // 
            consultarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { médicosPorClínicaToolStripMenuItem, animaisPorDonoToolStripMenuItem, consultasToolStripMenuItem, prescriçõesPorAnimalToolStripMenuItem, pagamentosPorDonoToolStripMenuItem });
            consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            consultarToolStripMenuItem.Size = new Size(70, 20);
            consultarToolStripMenuItem.Text = "Consultar";
            // 
            // médicosPorClínicaToolStripMenuItem
            // 
            médicosPorClínicaToolStripMenuItem.Name = "médicosPorClínicaToolStripMenuItem";
            médicosPorClínicaToolStripMenuItem.Size = new Size(195, 22);
            médicosPorClínicaToolStripMenuItem.Text = "Médicos por Clínica";
            // 
            // animaisPorDonoToolStripMenuItem
            // 
            animaisPorDonoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { animaisPorDonoToolStripMenuItem1, animaisPorClínicaToolStripMenuItem });
            animaisPorDonoToolStripMenuItem.Name = "animaisPorDonoToolStripMenuItem";
            animaisPorDonoToolStripMenuItem.Size = new Size(195, 22);
            animaisPorDonoToolStripMenuItem.Text = "Animais";
            // 
            // animaisPorDonoToolStripMenuItem1
            // 
            animaisPorDonoToolStripMenuItem1.Name = "animaisPorDonoToolStripMenuItem1";
            animaisPorDonoToolStripMenuItem1.Size = new Size(177, 22);
            animaisPorDonoToolStripMenuItem1.Text = "Animais por Dono";
            // 
            // animaisPorClínicaToolStripMenuItem
            // 
            animaisPorClínicaToolStripMenuItem.Name = "animaisPorClínicaToolStripMenuItem";
            animaisPorClínicaToolStripMenuItem.Size = new Size(177, 22);
            animaisPorClínicaToolStripMenuItem.Text = "Animais por Clínica";
            // 
            // consultasToolStripMenuItem
            // 
            consultasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { consultasPorAnimalToolStripMenuItem, consultasPorMVToolStripMenuItem });
            consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            consultasToolStripMenuItem.Size = new Size(195, 22);
            consultasToolStripMenuItem.Text = "Consultas";
            // 
            // consultasPorAnimalToolStripMenuItem
            // 
            consultasPorAnimalToolStripMenuItem.Name = "consultasPorAnimalToolStripMenuItem";
            consultasPorAnimalToolStripMenuItem.Size = new Size(188, 22);
            consultasPorAnimalToolStripMenuItem.Text = "Consultas por Animal";
            // 
            // consultasPorMVToolStripMenuItem
            // 
            consultasPorMVToolStripMenuItem.Name = "consultasPorMVToolStripMenuItem";
            consultasPorMVToolStripMenuItem.Size = new Size(188, 22);
            consultasPorMVToolStripMenuItem.Text = "Consultas por MV";
            // 
            // prescriçõesPorAnimalToolStripMenuItem
            // 
            prescriçõesPorAnimalToolStripMenuItem.Name = "prescriçõesPorAnimalToolStripMenuItem";
            prescriçõesPorAnimalToolStripMenuItem.Size = new Size(195, 22);
            prescriçõesPorAnimalToolStripMenuItem.Text = "Prescrições por Animal";
            // 
            // pagamentosPorDonoToolStripMenuItem
            // 
            pagamentosPorDonoToolStripMenuItem.Name = "pagamentosPorDonoToolStripMenuItem";
            pagamentosPorDonoToolStripMenuItem.Size = new Size(195, 22);
            pagamentosPorDonoToolStripMenuItem.Text = "Pagamentos por Dono";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(10, 25);
            listBox1.Margin = new Padding(2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(286, 244);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(320, 208);
            addBtn.Margin = new Padding(2);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(75, 23);
            addBtn.TabIndex = 3;
            addBtn.Text = "Adicionar";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(420, 208);
            editBtn.Margin = new Padding(2);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(75, 23);
            editBtn.TabIndex = 4;
            editBtn.Text = "Editar";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // remBtn
            // 
            remBtn.Location = new Point(519, 208);
            remBtn.Margin = new Padding(2);
            remBtn.Name = "remBtn";
            remBtn.Size = new Size(75, 23);
            remBtn.TabIndex = 5;
            remBtn.Text = "Remover";
            remBtn.UseVisualStyleBackColor = true;
            remBtn.Click += remBtn_Click;
            // 
            // okBtn
            // 
            okBtn.Location = new Point(467, 236);
            okBtn.Margin = new Padding(2);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(75, 23);
            okBtn.TabIndex = 6;
            okBtn.Text = "OK";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += okBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(367, 236);
            cancelBtn.Margin = new Padding(2);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 7;
            cancelBtn.Text = "Cancelar";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // nifText
            // 
            nifText.Location = new Point(319, 52);
            nifText.Margin = new Padding(2);
            nifText.Name = "nifText";
            nifText.Size = new Size(124, 23);
            nifText.TabIndex = 8;
            // 
            // nifLabel
            // 
            nifLabel.AutoSize = true;
            nifLabel.Location = new Point(319, 34);
            nifLabel.Margin = new Padding(2, 0, 2, 0);
            nifLabel.Name = "nifLabel";
            nifLabel.Size = new Size(25, 15);
            nifLabel.TabIndex = 9;
            nifLabel.Text = "NIF";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new Point(457, 34);
            nomeLabel.Margin = new Padding(2, 0, 2, 0);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new Size(40, 15);
            nomeLabel.TabIndex = 11;
            nomeLabel.Text = "Nome";
            // 
            // nomeText
            // 
            nomeText.Location = new Point(457, 52);
            nomeText.Margin = new Padding(2);
            nomeText.Name = "nomeText";
            nomeText.Size = new Size(185, 23);
            nomeText.TabIndex = 10;
            // 
            // telefoneLabel
            // 
            telefoneLabel.AutoSize = true;
            telefoneLabel.Location = new Point(319, 91);
            telefoneLabel.Margin = new Padding(2, 0, 2, 0);
            telefoneLabel.Name = "telefoneLabel";
            telefoneLabel.Size = new Size(52, 15);
            telefoneLabel.TabIndex = 13;
            telefoneLabel.Text = "Telefone";
            // 
            // telefoneText
            // 
            telefoneText.Location = new Point(319, 110);
            telefoneText.Margin = new Padding(2);
            telefoneText.Name = "telefoneText";
            telefoneText.Size = new Size(124, 23);
            telefoneText.TabIndex = 12;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(457, 93);
            emailLabel.Margin = new Padding(2, 0, 2, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(36, 15);
            emailLabel.TabIndex = 15;
            emailLabel.Text = "Email";
            // 
            // emailText
            // 
            emailText.Location = new Point(457, 110);
            emailText.Margin = new Padding(2);
            emailText.Name = "emailText";
            emailText.Size = new Size(184, 23);
            emailText.TabIndex = 14;
            // 
            // enderecoLabel
            // 
            enderecoLabel.AutoSize = true;
            enderecoLabel.Location = new Point(319, 150);
            enderecoLabel.Margin = new Padding(2, 0, 2, 0);
            enderecoLabel.Name = "enderecoLabel";
            enderecoLabel.Size = new Size(56, 15);
            enderecoLabel.TabIndex = 17;
            enderecoLabel.Text = "Endereço";
            // 
            // enderecoText
            // 
            enderecoText.Location = new Point(319, 169);
            enderecoText.Margin = new Padding(2);
            enderecoText.Name = "enderecoText";
            enderecoText.Size = new Size(322, 23);
            enderecoText.TabIndex = 16;
            // 
            // clinicaComboBox
            // 
            clinicaComboBox.FormattingEnabled = true;
            clinicaComboBox.Location = new Point(457, 169);
            clinicaComboBox.Name = "clinicaComboBox";
            clinicaComboBox.Size = new Size(185, 23);
            clinicaComboBox.TabIndex = 18;
            clinicaComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(457, 152);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 19;
            label1.Text = "Clínica";
            label1.Click += label1_Click_1;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(650, 279);
            Controls.Add(label1);
            Controls.Add(clinicaComboBox);
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
            Controls.Add(addBtn);
            Controls.Add(listBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "AdminForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Form1";
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
        private Button addBtn;
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
        private ComboBox clinicaComboBox;
        private Label label1;
    }
}
