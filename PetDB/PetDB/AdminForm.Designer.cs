
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
            clinicaNomeLabel = new Label();
            clinicaNomeText = new TextBox();
            clinicaTelefoneLabel = new Label();
            clinicaTelefoneText = new TextBox();
            clinicaEmailLabel = new Label();
            clinicaEmailText = new TextBox();
            registarTabControl = new TabControl();
            clinicaTabPage = new TabPage();
            clinicaEnderecoLabel = new Label();
            clinicaEnderecoText = new TextBox();
            clinicaNifLabel = new Label();
            clinicaNifText = new TextBox();
            medicoTabPage = new TabPage();
            medicoEspecialidadeLabel = new Label();
            medicoEspecialidadeText = new TextBox();
            medicoOMVLabel = new Label();
            medicoOMVText = new TextBox();
            medicoNomeLabel = new Label();
            medicoNomeText = new TextBox();
            medicoTelefoneLabel = new Label();
            medicoEmailLabel = new Label();
            medicoEmailText = new TextBox();
            medicoTelefoneText = new TextBox();
            medicoClinicaLabel = new Label();
            medicoClinicaComboBox = new ComboBox();
            donoTabPage = new TabPage();
            donoEnderecoLabel = new Label();
            donoEnderecoText = new TextBox();
            donoNifLabel = new Label();
            donoNifText = new TextBox();
            donoNomeLabel = new Label();
            donoNomeText = new TextBox();
            donoTelefoneLabel = new Label();
            donoEmailLabel = new Label();
            donoEmailText = new TextBox();
            donoTelefoneText = new TextBox();
            menuStrip1.SuspendLayout();
            registarTabControl.SuspendLayout();
            clinicaTabPage.SuspendLayout();
            medicoTabPage.SuspendLayout();
            donoTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, registarToolStripMenuItem, consultarToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(812, 28);
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
            novoMédicoToolStripMenuItem.Click += medicoVeterinarioToolStripMenuItem_Click;
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
            donoToolStripMenuItem.Click += donoToolStripMenuItem_Click;
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
            listBox1.Margin = new Padding(2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(356, 304);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(400, 260);
            addBtn.Margin = new Padding(2);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(94, 29);
            addBtn.TabIndex = 3;
            addBtn.Text = "Adicionar";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(525, 260);
            editBtn.Margin = new Padding(2);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(94, 29);
            editBtn.TabIndex = 4;
            editBtn.Text = "Editar";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // remBtn
            // 
            remBtn.Location = new Point(649, 260);
            remBtn.Margin = new Padding(2);
            remBtn.Name = "remBtn";
            remBtn.Size = new Size(94, 29);
            remBtn.TabIndex = 5;
            remBtn.Text = "Remover";
            remBtn.UseVisualStyleBackColor = true;
            remBtn.Click += remBtn_Click;
            // 
            // okBtn
            // 
            okBtn.Location = new Point(584, 295);
            okBtn.Margin = new Padding(2);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(94, 29);
            okBtn.TabIndex = 6;
            okBtn.Text = "OK";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += okBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(459, 295);
            cancelBtn.Margin = new Padding(2);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 29);
            cancelBtn.TabIndex = 7;
            cancelBtn.Text = "Cancelar";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // clinicaNomeLabel
            // 
            clinicaNomeLabel.AutoSize = true;
            clinicaNomeLabel.Location = new Point(164, 4);
            clinicaNomeLabel.Margin = new Padding(2, 0, 2, 0);
            clinicaNomeLabel.Name = "clinicaNomeLabel";
            clinicaNomeLabel.Size = new Size(50, 20);
            clinicaNomeLabel.TabIndex = 11;
            clinicaNomeLabel.Text = "Nome";
            // 
            // clinicaNomeText
            // 
            clinicaNomeText.Location = new Point(164, 27);
            clinicaNomeText.Margin = new Padding(2);
            clinicaNomeText.Name = "clinicaNomeText";
            clinicaNomeText.Size = new Size(230, 27);
            clinicaNomeText.TabIndex = 10;
            // 
            // clinicaTelefoneLabel
            // 
            clinicaTelefoneLabel.AutoSize = true;
            clinicaTelefoneLabel.Location = new Point(6, 56);
            clinicaTelefoneLabel.Margin = new Padding(2, 0, 2, 0);
            clinicaTelefoneLabel.Name = "clinicaTelefoneLabel";
            clinicaTelefoneLabel.Size = new Size(66, 20);
            clinicaTelefoneLabel.TabIndex = 13;
            clinicaTelefoneLabel.Text = "Telefone";
            // 
            // clinicaTelefoneText
            // 
            clinicaTelefoneText.Location = new Point(6, 80);
            clinicaTelefoneText.Margin = new Padding(2);
            clinicaTelefoneText.Name = "clinicaTelefoneText";
            clinicaTelefoneText.Size = new Size(154, 27);
            clinicaTelefoneText.TabIndex = 12;
            // 
            // clinicaEmailLabel
            // 
            clinicaEmailLabel.AutoSize = true;
            clinicaEmailLabel.Location = new Point(164, 56);
            clinicaEmailLabel.Margin = new Padding(2, 0, 2, 0);
            clinicaEmailLabel.Name = "clinicaEmailLabel";
            clinicaEmailLabel.Size = new Size(46, 20);
            clinicaEmailLabel.TabIndex = 15;
            clinicaEmailLabel.Text = "Email";
            // 
            // clinicaEmailText
            // 
            clinicaEmailText.Location = new Point(164, 80);
            clinicaEmailText.Margin = new Padding(2);
            clinicaEmailText.Name = "clinicaEmailText";
            clinicaEmailText.Size = new Size(229, 27);
            clinicaEmailText.TabIndex = 14;
            // 
            // registarTabControl
            // 
            registarTabControl.Controls.Add(clinicaTabPage);
            registarTabControl.Controls.Add(medicoTabPage);
            registarTabControl.Controls.Add(donoTabPage);
            registarTabControl.Location = new Point(374, 31);
            registarTabControl.Margin = new Padding(4);
            registarTabControl.Name = "registarTabControl";
            registarTabControl.SelectedIndex = 0;
            registarTabControl.Size = new Size(409, 222);
            registarTabControl.TabIndex = 20;
            registarTabControl.SelectedIndexChanged += registarTabControl_onSelectedIndexChange;
            // 
            // clinicaTabPage
            // 
            clinicaTabPage.Controls.Add(clinicaEnderecoLabel);
            clinicaTabPage.Controls.Add(clinicaEnderecoText);
            clinicaTabPage.Controls.Add(clinicaNifLabel);
            clinicaTabPage.Controls.Add(clinicaNifText);
            clinicaTabPage.Controls.Add(clinicaNomeLabel);
            clinicaTabPage.Controls.Add(clinicaNomeText);
            clinicaTabPage.Controls.Add(clinicaTelefoneLabel);
            clinicaTabPage.Controls.Add(clinicaEmailLabel);
            clinicaTabPage.Controls.Add(clinicaEmailText);
            clinicaTabPage.Controls.Add(clinicaTelefoneText);
            clinicaTabPage.Location = new Point(4, 29);
            clinicaTabPage.Margin = new Padding(4);
            clinicaTabPage.Name = "clinicaTabPage";
            clinicaTabPage.Padding = new Padding(4);
            clinicaTabPage.Size = new Size(401, 189);
            clinicaTabPage.TabIndex = 0;
            clinicaTabPage.Text = "Clinica";
            clinicaTabPage.UseVisualStyleBackColor = true;
            clinicaTabPage.Click += clinicaVeterinariaToolStripMenuItem_Click;
            // 
            // clinicaEnderecoLabel
            // 
            clinicaEnderecoLabel.AutoSize = true;
            clinicaEnderecoLabel.Location = new Point(6, 114);
            clinicaEnderecoLabel.Margin = new Padding(2, 0, 2, 0);
            clinicaEnderecoLabel.Name = "clinicaEnderecoLabel";
            clinicaEnderecoLabel.Size = new Size(71, 20);
            clinicaEnderecoLabel.TabIndex = 19;
            clinicaEnderecoLabel.Text = "Endereço";
            // 
            // clinicaEnderecoText
            // 
            clinicaEnderecoText.Location = new Point(6, 137);
            clinicaEnderecoText.Margin = new Padding(2);
            clinicaEnderecoText.Name = "clinicaEnderecoText";
            clinicaEnderecoText.Size = new Size(387, 27);
            clinicaEnderecoText.TabIndex = 18;
            // 
            // clinicaNifLabel
            // 
            clinicaNifLabel.AutoSize = true;
            clinicaNifLabel.Location = new Point(6, 4);
            clinicaNifLabel.Margin = new Padding(2, 0, 2, 0);
            clinicaNifLabel.Name = "clinicaNifLabel";
            clinicaNifLabel.Size = new Size(31, 20);
            clinicaNifLabel.TabIndex = 11;
            clinicaNifLabel.Text = "NIF";
            // 
            // clinicaNifText
            // 
            clinicaNifText.Location = new Point(6, 27);
            clinicaNifText.Margin = new Padding(2);
            clinicaNifText.Name = "clinicaNifText";
            clinicaNifText.Size = new Size(154, 27);
            clinicaNifText.TabIndex = 10;
            // 
            // medicoTabPage
            // 
            medicoTabPage.Controls.Add(medicoEspecialidadeLabel);
            medicoTabPage.Controls.Add(medicoEspecialidadeText);
            medicoTabPage.Controls.Add(medicoOMVLabel);
            medicoTabPage.Controls.Add(medicoOMVText);
            medicoTabPage.Controls.Add(medicoNomeLabel);
            medicoTabPage.Controls.Add(medicoNomeText);
            medicoTabPage.Controls.Add(medicoTelefoneLabel);
            medicoTabPage.Controls.Add(medicoEmailLabel);
            medicoTabPage.Controls.Add(medicoEmailText);
            medicoTabPage.Controls.Add(medicoTelefoneText);
            medicoTabPage.Controls.Add(medicoClinicaLabel);
            medicoTabPage.Controls.Add(medicoClinicaComboBox);
            medicoTabPage.Location = new Point(4, 29);
            medicoTabPage.Margin = new Padding(4);
            medicoTabPage.Name = "medicoTabPage";
            medicoTabPage.Padding = new Padding(4);
            medicoTabPage.Size = new Size(401, 189);
            medicoTabPage.TabIndex = 1;
            medicoTabPage.Text = "Medico";
            medicoTabPage.UseVisualStyleBackColor = true;
            // 
            // medicoEspecialidadeLabel
            // 
            medicoEspecialidadeLabel.AutoSize = true;
            medicoEspecialidadeLabel.Location = new Point(6, 114);
            medicoEspecialidadeLabel.Margin = new Padding(2, 0, 2, 0);
            medicoEspecialidadeLabel.Name = "medicoEspecialidadeLabel";
            medicoEspecialidadeLabel.Size = new Size(101, 20);
            medicoEspecialidadeLabel.TabIndex = 32;
            medicoEspecialidadeLabel.Text = "Especialidade";
            // 
            // medicoEspecialidadeText
            // 
            medicoEspecialidadeText.Location = new Point(6, 137);
            medicoEspecialidadeText.Margin = new Padding(2);
            medicoEspecialidadeText.Name = "medicoEspecialidadeText";
            medicoEspecialidadeText.Size = new Size(154, 27);
            medicoEspecialidadeText.TabIndex = 31;
            // 
            // medicoOMVLabel
            // 
            medicoOMVLabel.AutoSize = true;
            medicoOMVLabel.Location = new Point(6, 4);
            medicoOMVLabel.Margin = new Padding(2, 0, 2, 0);
            medicoOMVLabel.Name = "medicoOMVLabel";
            medicoOMVLabel.Size = new Size(100, 20);
            medicoOMVLabel.TabIndex = 25;
            medicoOMVLabel.Text = "Numero OMV";
            // 
            // medicoOMVText
            // 
            medicoOMVText.Location = new Point(6, 27);
            medicoOMVText.Margin = new Padding(2);
            medicoOMVText.Name = "medicoOMVText";
            medicoOMVText.Size = new Size(154, 27);
            medicoOMVText.TabIndex = 23;
            // 
            // medicoNomeLabel
            // 
            medicoNomeLabel.AutoSize = true;
            medicoNomeLabel.Location = new Point(164, 4);
            medicoNomeLabel.Margin = new Padding(2, 0, 2, 0);
            medicoNomeLabel.Name = "medicoNomeLabel";
            medicoNomeLabel.Size = new Size(50, 20);
            medicoNomeLabel.TabIndex = 26;
            medicoNomeLabel.Text = "Nome";
            // 
            // medicoNomeText
            // 
            medicoNomeText.Location = new Point(164, 27);
            medicoNomeText.Margin = new Padding(2);
            medicoNomeText.Name = "medicoNomeText";
            medicoNomeText.Size = new Size(230, 27);
            medicoNomeText.TabIndex = 24;
            // 
            // medicoTelefoneLabel
            // 
            medicoTelefoneLabel.AutoSize = true;
            medicoTelefoneLabel.Location = new Point(6, 56);
            medicoTelefoneLabel.Margin = new Padding(2, 0, 2, 0);
            medicoTelefoneLabel.Name = "medicoTelefoneLabel";
            medicoTelefoneLabel.Size = new Size(66, 20);
            medicoTelefoneLabel.TabIndex = 28;
            medicoTelefoneLabel.Text = "Telefone";
            // 
            // medicoEmailLabel
            // 
            medicoEmailLabel.AutoSize = true;
            medicoEmailLabel.Location = new Point(164, 56);
            medicoEmailLabel.Margin = new Padding(2, 0, 2, 0);
            medicoEmailLabel.Name = "medicoEmailLabel";
            medicoEmailLabel.Size = new Size(46, 20);
            medicoEmailLabel.TabIndex = 30;
            medicoEmailLabel.Text = "Email";
            // 
            // medicoEmailText
            // 
            medicoEmailText.Location = new Point(164, 80);
            medicoEmailText.Margin = new Padding(2);
            medicoEmailText.Name = "medicoEmailText";
            medicoEmailText.Size = new Size(229, 27);
            medicoEmailText.TabIndex = 29;
            // 
            // medicoTelefoneText
            // 
            medicoTelefoneText.Location = new Point(6, 80);
            medicoTelefoneText.Margin = new Padding(2);
            medicoTelefoneText.Name = "medicoTelefoneText";
            medicoTelefoneText.Size = new Size(154, 27);
            medicoTelefoneText.TabIndex = 27;
            // 
            // medicoClinicaLabel
            // 
            medicoClinicaLabel.AutoSize = true;
            medicoClinicaLabel.Location = new Point(164, 114);
            medicoClinicaLabel.Margin = new Padding(2, 0, 2, 0);
            medicoClinicaLabel.Name = "medicoClinicaLabel";
            medicoClinicaLabel.Size = new Size(53, 20);
            medicoClinicaLabel.TabIndex = 22;
            medicoClinicaLabel.Text = "Clínica";
            // 
            // medicoClinicaComboBox
            // 
            medicoClinicaComboBox.FormattingEnabled = true;
            medicoClinicaComboBox.Location = new Point(163, 136);
            medicoClinicaComboBox.Margin = new Padding(4);
            medicoClinicaComboBox.Name = "medicoClinicaComboBox";
            medicoClinicaComboBox.Size = new Size(230, 28);
            medicoClinicaComboBox.TabIndex = 21;
            // 
            // donoTabPage
            // 
            donoTabPage.Controls.Add(donoEnderecoLabel);
            donoTabPage.Controls.Add(donoEnderecoText);
            donoTabPage.Controls.Add(donoNifLabel);
            donoTabPage.Controls.Add(donoNifText);
            donoTabPage.Controls.Add(donoNomeLabel);
            donoTabPage.Controls.Add(donoNomeText);
            donoTabPage.Controls.Add(donoTelefoneLabel);
            donoTabPage.Controls.Add(donoEmailLabel);
            donoTabPage.Controls.Add(donoEmailText);
            donoTabPage.Controls.Add(donoTelefoneText);
            donoTabPage.Location = new Point(4, 29);
            donoTabPage.Name = "donoTabPage";
            donoTabPage.Padding = new Padding(3);
            donoTabPage.Size = new Size(401, 189);
            donoTabPage.TabIndex = 2;
            donoTabPage.Text = "Dono";
            donoTabPage.UseVisualStyleBackColor = true;
            // 
            // donoEnderecoLabel
            // 
            donoEnderecoLabel.AutoSize = true;
            donoEnderecoLabel.Location = new Point(5, 113);
            donoEnderecoLabel.Margin = new Padding(2, 0, 2, 0);
            donoEnderecoLabel.Name = "donoEnderecoLabel";
            donoEnderecoLabel.Size = new Size(71, 20);
            donoEnderecoLabel.TabIndex = 29;
            donoEnderecoLabel.Text = "Endereço";
            // 
            // donoEnderecoText
            // 
            donoEnderecoText.Location = new Point(5, 136);
            donoEnderecoText.Margin = new Padding(2);
            donoEnderecoText.Name = "donoEnderecoText";
            donoEnderecoText.Size = new Size(387, 27);
            donoEnderecoText.TabIndex = 28;
            // 
            // donoNifLabel
            // 
            donoNifLabel.AutoSize = true;
            donoNifLabel.Location = new Point(5, 3);
            donoNifLabel.Margin = new Padding(2, 0, 2, 0);
            donoNifLabel.Name = "donoNifLabel";
            donoNifLabel.Size = new Size(31, 20);
            donoNifLabel.TabIndex = 22;
            donoNifLabel.Text = "NIF";
            // 
            // donoNifText
            // 
            donoNifText.Location = new Point(5, 26);
            donoNifText.Margin = new Padding(2);
            donoNifText.Name = "donoNifText";
            donoNifText.Size = new Size(154, 27);
            donoNifText.TabIndex = 20;
            // 
            // donoNomeLabel
            // 
            donoNomeLabel.AutoSize = true;
            donoNomeLabel.Location = new Point(163, 3);
            donoNomeLabel.Margin = new Padding(2, 0, 2, 0);
            donoNomeLabel.Name = "donoNomeLabel";
            donoNomeLabel.Size = new Size(50, 20);
            donoNomeLabel.TabIndex = 23;
            donoNomeLabel.Text = "Nome";
            // 
            // donoNomeText
            // 
            donoNomeText.Location = new Point(163, 26);
            donoNomeText.Margin = new Padding(2);
            donoNomeText.Name = "donoNomeText";
            donoNomeText.Size = new Size(230, 27);
            donoNomeText.TabIndex = 21;
            // 
            // donoTelefoneLabel
            // 
            donoTelefoneLabel.AutoSize = true;
            donoTelefoneLabel.Location = new Point(5, 55);
            donoTelefoneLabel.Margin = new Padding(2, 0, 2, 0);
            donoTelefoneLabel.Name = "donoTelefoneLabel";
            donoTelefoneLabel.Size = new Size(66, 20);
            donoTelefoneLabel.TabIndex = 25;
            donoTelefoneLabel.Text = "Telefone";
            // 
            // donoEmailLabel
            // 
            donoEmailLabel.AutoSize = true;
            donoEmailLabel.Location = new Point(163, 55);
            donoEmailLabel.Margin = new Padding(2, 0, 2, 0);
            donoEmailLabel.Name = "donoEmailLabel";
            donoEmailLabel.Size = new Size(46, 20);
            donoEmailLabel.TabIndex = 27;
            donoEmailLabel.Text = "Email";
            // 
            // donoEmailText
            // 
            donoEmailText.Location = new Point(163, 79);
            donoEmailText.Margin = new Padding(2);
            donoEmailText.Name = "donoEmailText";
            donoEmailText.Size = new Size(229, 27);
            donoEmailText.TabIndex = 26;
            // 
            // donoTelefoneText
            // 
            donoTelefoneText.Location = new Point(5, 79);
            donoTelefoneText.Margin = new Padding(2);
            donoTelefoneText.Name = "donoTelefoneText";
            donoTelefoneText.Size = new Size(154, 27);
            donoTelefoneText.TabIndex = 24;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(812, 349);
            Controls.Add(registarTabControl);
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
            registarTabControl.ResumeLayout(false);
            clinicaTabPage.ResumeLayout(false);
            clinicaTabPage.PerformLayout();
            medicoTabPage.ResumeLayout(false);
            medicoTabPage.PerformLayout();
            donoTabPage.ResumeLayout(false);
            donoTabPage.PerformLayout();
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
        private Label clinicaNomeLabel;
        private TextBox clinicaNomeText;
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
        private Label clinicaTelefoneLabel;
        private TextBox clinicaTelefoneText;
        private Label clinicaEmailLabel;
        private TextBox clinicaEmailText;
        private TabControl registarTabControl;
        private TabPage clinicaTabPage;
        private TabPage medicoTabPage;
        private Label clinicaEnderecoLabel;
        private TextBox clinicaEnderecoText;
        private Label clinicaNifLabel;
        private TextBox clinicaNifText;
        private Label medicoClinicaLabel;
        private ComboBox medicoClinicaComboBox;
        private Label medicoEspecialidadeLabel;
        private TextBox medicoEspecialidadeText;
        private Label medicoOMVLabel;
        private TextBox medicoOMVText;
        private Label medicoNomeLabel;
        private TextBox medicoNomeText;
        private Label medicoTelefoneLabel;
        private Label medicoEmailLabel;
        private TextBox medicoEmailText;
        private TextBox medicoTelefoneText;
        private TabPage donoTabPage;
        private TabControl tabControl2;
        private TabPage tabPage4;
        private Label donoEnderecoLabel;
        private TextBox donoEnderecoText;
        private Label donoNifLabel;
        private TextBox donoNifText;
        private Label donoNomeLabel;
        private TextBox donoNomeText;
        private Label donoTelefoneLabel;
        private Label donoEmailLabel;
        private TextBox donoEmailText;
        private TextBox donoTelefoneText;
    }
}
