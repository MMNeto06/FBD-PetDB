
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
            medicoClinicaText = new TextBox();
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
            animalTabPage = new TabPage();
            animalDonoLabel = new Label();
            animalEspecieLabel = new Label();
            animalPesoLabel = new Label();
            animalDataNascimentoLabel = new Label();
            animalSexoLabel = new Label();
            animalNomeLabel = new Label();
            animalNumeroLabel = new Label();
            animalDonoText = new TextBox();
            animalNomeText = new TextBox();
            animalDataNascimentoText = new TextBox();
            animalEspecieText = new TextBox();
            animalPesoText = new TextBox();
            animalSexoText = new TextBox();
            animalNumeroText = new TextBox();
            medicamentoTabPage = new TabPage();
            consultaTabPage = new TabPage();
            pagamentoTabPage = new TabPage();
            prescricaoTabPage = new TabPage();
            especialidadeTabPage = new TabPage();
            especieTabPage = new TabPage();
            menuStrip1.SuspendLayout();
            registarTabControl.SuspendLayout();
            clinicaTabPage.SuspendLayout();
            medicoTabPage.SuspendLayout();
            donoTabPage.SuspendLayout();
            animalTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, registarToolStripMenuItem, consultarToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(628, 24);
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
            listBox1.Size = new Size(286, 289);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(322, 254);
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
            editBtn.Location = new Point(422, 254);
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
            remBtn.Location = new Point(521, 254);
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
            okBtn.Location = new Point(469, 282);
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
            cancelBtn.Location = new Point(369, 282);
            cancelBtn.Margin = new Padding(2);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 7;
            cancelBtn.Text = "Cancelar";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // clinicaNomeLabel
            // 
            clinicaNomeLabel.AutoSize = true;
            clinicaNomeLabel.Location = new Point(131, 3);
            clinicaNomeLabel.Margin = new Padding(2, 0, 2, 0);
            clinicaNomeLabel.Name = "clinicaNomeLabel";
            clinicaNomeLabel.Size = new Size(40, 15);
            clinicaNomeLabel.TabIndex = 11;
            clinicaNomeLabel.Text = "Nome";
            // 
            // clinicaNomeText
            // 
            clinicaNomeText.Location = new Point(131, 22);
            clinicaNomeText.Margin = new Padding(2);
            clinicaNomeText.Name = "clinicaNomeText";
            clinicaNomeText.Size = new Size(185, 23);
            clinicaNomeText.TabIndex = 10;
            // 
            // clinicaTelefoneLabel
            // 
            clinicaTelefoneLabel.AutoSize = true;
            clinicaTelefoneLabel.Location = new Point(5, 45);
            clinicaTelefoneLabel.Margin = new Padding(2, 0, 2, 0);
            clinicaTelefoneLabel.Name = "clinicaTelefoneLabel";
            clinicaTelefoneLabel.Size = new Size(52, 15);
            clinicaTelefoneLabel.TabIndex = 13;
            clinicaTelefoneLabel.Text = "Telefone";
            // 
            // clinicaTelefoneText
            // 
            clinicaTelefoneText.Location = new Point(5, 64);
            clinicaTelefoneText.Margin = new Padding(2);
            clinicaTelefoneText.Name = "clinicaTelefoneText";
            clinicaTelefoneText.Size = new Size(124, 23);
            clinicaTelefoneText.TabIndex = 12;
            // 
            // clinicaEmailLabel
            // 
            clinicaEmailLabel.AutoSize = true;
            clinicaEmailLabel.Location = new Point(131, 45);
            clinicaEmailLabel.Margin = new Padding(2, 0, 2, 0);
            clinicaEmailLabel.Name = "clinicaEmailLabel";
            clinicaEmailLabel.Size = new Size(36, 15);
            clinicaEmailLabel.TabIndex = 15;
            clinicaEmailLabel.Text = "Email";
            // 
            // clinicaEmailText
            // 
            clinicaEmailText.Location = new Point(131, 64);
            clinicaEmailText.Margin = new Padding(2);
            clinicaEmailText.Name = "clinicaEmailText";
            clinicaEmailText.Size = new Size(184, 23);
            clinicaEmailText.TabIndex = 14;
            // 
            // registarTabControl
            // 
            registarTabControl.Controls.Add(clinicaTabPage);
            registarTabControl.Controls.Add(medicoTabPage);
            registarTabControl.Controls.Add(donoTabPage);
            registarTabControl.Controls.Add(animalTabPage);
            registarTabControl.Controls.Add(medicamentoTabPage);
            registarTabControl.Controls.Add(consultaTabPage);
            registarTabControl.Controls.Add(pagamentoTabPage);
            registarTabControl.Controls.Add(prescricaoTabPage);
            registarTabControl.Controls.Add(especialidadeTabPage);
            registarTabControl.Controls.Add(especieTabPage);
            registarTabControl.Location = new Point(299, 25);
            registarTabControl.Multiline = true;
            registarTabControl.Name = "registarTabControl";
            registarTabControl.SelectedIndex = 0;
            registarTabControl.Size = new Size(326, 211);
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
            clinicaTabPage.Location = new Point(4, 64);
            clinicaTabPage.Name = "clinicaTabPage";
            clinicaTabPage.Padding = new Padding(3);
            clinicaTabPage.Size = new Size(318, 143);
            clinicaTabPage.TabIndex = 0;
            clinicaTabPage.Text = "Clinica";
            clinicaTabPage.UseVisualStyleBackColor = true;
            clinicaTabPage.Click += clinicaVeterinariaToolStripMenuItem_Click;
            // 
            // clinicaEnderecoLabel
            // 
            clinicaEnderecoLabel.AutoSize = true;
            clinicaEnderecoLabel.Location = new Point(5, 91);
            clinicaEnderecoLabel.Margin = new Padding(2, 0, 2, 0);
            clinicaEnderecoLabel.Name = "clinicaEnderecoLabel";
            clinicaEnderecoLabel.Size = new Size(56, 15);
            clinicaEnderecoLabel.TabIndex = 19;
            clinicaEnderecoLabel.Text = "Endereço";
            // 
            // clinicaEnderecoText
            // 
            clinicaEnderecoText.Location = new Point(5, 110);
            clinicaEnderecoText.Margin = new Padding(2);
            clinicaEnderecoText.Name = "clinicaEnderecoText";
            clinicaEnderecoText.Size = new Size(310, 23);
            clinicaEnderecoText.TabIndex = 18;
            // 
            // clinicaNifLabel
            // 
            clinicaNifLabel.AutoSize = true;
            clinicaNifLabel.Location = new Point(5, 3);
            clinicaNifLabel.Margin = new Padding(2, 0, 2, 0);
            clinicaNifLabel.Name = "clinicaNifLabel";
            clinicaNifLabel.Size = new Size(25, 15);
            clinicaNifLabel.TabIndex = 11;
            clinicaNifLabel.Text = "NIF";
            // 
            // clinicaNifText
            // 
            clinicaNifText.Location = new Point(5, 22);
            clinicaNifText.Margin = new Padding(2);
            clinicaNifText.Name = "clinicaNifText";
            clinicaNifText.Size = new Size(124, 23);
            clinicaNifText.TabIndex = 10;
            // 
            // medicoTabPage
            // 
            medicoTabPage.Controls.Add(medicoClinicaText);
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
            medicoTabPage.Location = new Point(4, 64);
            medicoTabPage.Name = "medicoTabPage";
            medicoTabPage.Padding = new Padding(3);
            medicoTabPage.Size = new Size(318, 143);
            medicoTabPage.TabIndex = 1;
            medicoTabPage.Text = "Medico";
            medicoTabPage.UseVisualStyleBackColor = true;
            // 
            // medicoClinicaText
            // 
            medicoClinicaText.Location = new Point(133, 110);
            medicoClinicaText.Margin = new Padding(2);
            medicoClinicaText.Name = "medicoClinicaText";
            medicoClinicaText.Size = new Size(180, 23);
            medicoClinicaText.TabIndex = 33;
            // 
            // medicoEspecialidadeLabel
            // 
            medicoEspecialidadeLabel.AutoSize = true;
            medicoEspecialidadeLabel.Location = new Point(5, 91);
            medicoEspecialidadeLabel.Margin = new Padding(2, 0, 2, 0);
            medicoEspecialidadeLabel.Name = "medicoEspecialidadeLabel";
            medicoEspecialidadeLabel.Size = new Size(78, 15);
            medicoEspecialidadeLabel.TabIndex = 32;
            medicoEspecialidadeLabel.Text = "Especialidade";
            // 
            // medicoEspecialidadeText
            // 
            medicoEspecialidadeText.Location = new Point(5, 110);
            medicoEspecialidadeText.Margin = new Padding(2);
            medicoEspecialidadeText.Name = "medicoEspecialidadeText";
            medicoEspecialidadeText.Size = new Size(124, 23);
            medicoEspecialidadeText.TabIndex = 31;
            // 
            // medicoOMVLabel
            // 
            medicoOMVLabel.AutoSize = true;
            medicoOMVLabel.Location = new Point(5, 3);
            medicoOMVLabel.Margin = new Padding(2, 0, 2, 0);
            medicoOMVLabel.Name = "medicoOMVLabel";
            medicoOMVLabel.Size = new Size(81, 15);
            medicoOMVLabel.TabIndex = 25;
            medicoOMVLabel.Text = "Numero OMV";
            // 
            // medicoOMVText
            // 
            medicoOMVText.Location = new Point(5, 22);
            medicoOMVText.Margin = new Padding(2);
            medicoOMVText.Name = "medicoOMVText";
            medicoOMVText.Size = new Size(124, 23);
            medicoOMVText.TabIndex = 23;
            // 
            // medicoNomeLabel
            // 
            medicoNomeLabel.AutoSize = true;
            medicoNomeLabel.Location = new Point(131, 3);
            medicoNomeLabel.Margin = new Padding(2, 0, 2, 0);
            medicoNomeLabel.Name = "medicoNomeLabel";
            medicoNomeLabel.Size = new Size(40, 15);
            medicoNomeLabel.TabIndex = 26;
            medicoNomeLabel.Text = "Nome";
            // 
            // medicoNomeText
            // 
            medicoNomeText.Location = new Point(131, 22);
            medicoNomeText.Margin = new Padding(2);
            medicoNomeText.Name = "medicoNomeText";
            medicoNomeText.Size = new Size(185, 23);
            medicoNomeText.TabIndex = 24;
            // 
            // medicoTelefoneLabel
            // 
            medicoTelefoneLabel.AutoSize = true;
            medicoTelefoneLabel.Location = new Point(5, 45);
            medicoTelefoneLabel.Margin = new Padding(2, 0, 2, 0);
            medicoTelefoneLabel.Name = "medicoTelefoneLabel";
            medicoTelefoneLabel.Size = new Size(52, 15);
            medicoTelefoneLabel.TabIndex = 28;
            medicoTelefoneLabel.Text = "Telefone";
            // 
            // medicoEmailLabel
            // 
            medicoEmailLabel.AutoSize = true;
            medicoEmailLabel.Location = new Point(131, 45);
            medicoEmailLabel.Margin = new Padding(2, 0, 2, 0);
            medicoEmailLabel.Name = "medicoEmailLabel";
            medicoEmailLabel.Size = new Size(36, 15);
            medicoEmailLabel.TabIndex = 30;
            medicoEmailLabel.Text = "Email";
            // 
            // medicoEmailText
            // 
            medicoEmailText.Location = new Point(131, 64);
            medicoEmailText.Margin = new Padding(2);
            medicoEmailText.Name = "medicoEmailText";
            medicoEmailText.Size = new Size(184, 23);
            medicoEmailText.TabIndex = 29;
            // 
            // medicoTelefoneText
            // 
            medicoTelefoneText.Location = new Point(5, 64);
            medicoTelefoneText.Margin = new Padding(2);
            medicoTelefoneText.Name = "medicoTelefoneText";
            medicoTelefoneText.Size = new Size(124, 23);
            medicoTelefoneText.TabIndex = 27;
            // 
            // medicoClinicaLabel
            // 
            medicoClinicaLabel.AutoSize = true;
            medicoClinicaLabel.Location = new Point(131, 91);
            medicoClinicaLabel.Margin = new Padding(2, 0, 2, 0);
            medicoClinicaLabel.Name = "medicoClinicaLabel";
            medicoClinicaLabel.Size = new Size(43, 15);
            medicoClinicaLabel.TabIndex = 22;
            medicoClinicaLabel.Text = "Clínica";
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
            donoTabPage.Location = new Point(4, 64);
            donoTabPage.Margin = new Padding(2);
            donoTabPage.Name = "donoTabPage";
            donoTabPage.Padding = new Padding(2);
            donoTabPage.Size = new Size(318, 143);
            donoTabPage.TabIndex = 2;
            donoTabPage.Text = "Dono";
            donoTabPage.UseVisualStyleBackColor = true;
            // 
            // donoEnderecoLabel
            // 
            donoEnderecoLabel.AutoSize = true;
            donoEnderecoLabel.Location = new Point(4, 90);
            donoEnderecoLabel.Margin = new Padding(2, 0, 2, 0);
            donoEnderecoLabel.Name = "donoEnderecoLabel";
            donoEnderecoLabel.Size = new Size(56, 15);
            donoEnderecoLabel.TabIndex = 29;
            donoEnderecoLabel.Text = "Endereço";
            // 
            // donoEnderecoText
            // 
            donoEnderecoText.Location = new Point(4, 109);
            donoEnderecoText.Margin = new Padding(2);
            donoEnderecoText.Name = "donoEnderecoText";
            donoEnderecoText.Size = new Size(310, 23);
            donoEnderecoText.TabIndex = 28;
            // 
            // donoNifLabel
            // 
            donoNifLabel.AutoSize = true;
            donoNifLabel.Location = new Point(4, 2);
            donoNifLabel.Margin = new Padding(2, 0, 2, 0);
            donoNifLabel.Name = "donoNifLabel";
            donoNifLabel.Size = new Size(25, 15);
            donoNifLabel.TabIndex = 22;
            donoNifLabel.Text = "NIF";
            // 
            // donoNifText
            // 
            donoNifText.Location = new Point(4, 21);
            donoNifText.Margin = new Padding(2);
            donoNifText.Name = "donoNifText";
            donoNifText.Size = new Size(124, 23);
            donoNifText.TabIndex = 20;
            // 
            // donoNomeLabel
            // 
            donoNomeLabel.AutoSize = true;
            donoNomeLabel.Location = new Point(130, 2);
            donoNomeLabel.Margin = new Padding(2, 0, 2, 0);
            donoNomeLabel.Name = "donoNomeLabel";
            donoNomeLabel.Size = new Size(40, 15);
            donoNomeLabel.TabIndex = 23;
            donoNomeLabel.Text = "Nome";
            // 
            // donoNomeText
            // 
            donoNomeText.Location = new Point(130, 21);
            donoNomeText.Margin = new Padding(2);
            donoNomeText.Name = "donoNomeText";
            donoNomeText.Size = new Size(185, 23);
            donoNomeText.TabIndex = 21;
            // 
            // donoTelefoneLabel
            // 
            donoTelefoneLabel.AutoSize = true;
            donoTelefoneLabel.Location = new Point(4, 44);
            donoTelefoneLabel.Margin = new Padding(2, 0, 2, 0);
            donoTelefoneLabel.Name = "donoTelefoneLabel";
            donoTelefoneLabel.Size = new Size(52, 15);
            donoTelefoneLabel.TabIndex = 25;
            donoTelefoneLabel.Text = "Telefone";
            // 
            // donoEmailLabel
            // 
            donoEmailLabel.AutoSize = true;
            donoEmailLabel.Location = new Point(130, 44);
            donoEmailLabel.Margin = new Padding(2, 0, 2, 0);
            donoEmailLabel.Name = "donoEmailLabel";
            donoEmailLabel.Size = new Size(36, 15);
            donoEmailLabel.TabIndex = 27;
            donoEmailLabel.Text = "Email";
            // 
            // donoEmailText
            // 
            donoEmailText.Location = new Point(130, 63);
            donoEmailText.Margin = new Padding(2);
            donoEmailText.Name = "donoEmailText";
            donoEmailText.Size = new Size(184, 23);
            donoEmailText.TabIndex = 26;
            // 
            // donoTelefoneText
            // 
            donoTelefoneText.Location = new Point(4, 63);
            donoTelefoneText.Margin = new Padding(2);
            donoTelefoneText.Name = "donoTelefoneText";
            donoTelefoneText.Size = new Size(124, 23);
            donoTelefoneText.TabIndex = 24;
            // 
            // animalTabPage
            // 
            animalTabPage.Controls.Add(animalDonoLabel);
            animalTabPage.Controls.Add(animalEspecieLabel);
            animalTabPage.Controls.Add(animalPesoLabel);
            animalTabPage.Controls.Add(animalDataNascimentoLabel);
            animalTabPage.Controls.Add(animalSexoLabel);
            animalTabPage.Controls.Add(animalNomeLabel);
            animalTabPage.Controls.Add(animalNumeroLabel);
            animalTabPage.Controls.Add(animalDonoText);
            animalTabPage.Controls.Add(animalNomeText);
            animalTabPage.Controls.Add(animalDataNascimentoText);
            animalTabPage.Controls.Add(animalEspecieText);
            animalTabPage.Controls.Add(animalPesoText);
            animalTabPage.Controls.Add(animalSexoText);
            animalTabPage.Controls.Add(animalNumeroText);
            animalTabPage.Location = new Point(4, 64);
            animalTabPage.Margin = new Padding(2);
            animalTabPage.Name = "animalTabPage";
            animalTabPage.Padding = new Padding(2);
            animalTabPage.Size = new Size(318, 143);
            animalTabPage.TabIndex = 3;
            animalTabPage.Text = "Animal";
            animalTabPage.UseVisualStyleBackColor = true;
            animalTabPage.Click += animalTabPage_Click;
            // 
            // animalDonoLabel
            // 
            animalDonoLabel.AutoSize = true;
            animalDonoLabel.Location = new Point(154, 96);
            animalDonoLabel.Name = "animalDonoLabel";
            animalDonoLabel.Size = new Size(36, 15);
            animalDonoLabel.TabIndex = 20;
            animalDonoLabel.Text = "Dono";
            // 
            // animalEspecieLabel
            // 
            animalEspecieLabel.AutoSize = true;
            animalEspecieLabel.Location = new Point(5, 96);
            animalEspecieLabel.Name = "animalEspecieLabel";
            animalEspecieLabel.Size = new Size(46, 15);
            animalEspecieLabel.TabIndex = 19;
            animalEspecieLabel.Text = "Especie";
            // 
            // animalPesoLabel
            // 
            animalPesoLabel.AutoSize = true;
            animalPesoLabel.Location = new Point(76, 46);
            animalPesoLabel.Name = "animalPesoLabel";
            animalPesoLabel.Size = new Size(32, 15);
            animalPesoLabel.TabIndex = 18;
            animalPesoLabel.Text = "Peso";
            // 
            // animalDataNascimentoLabel
            // 
            animalDataNascimentoLabel.AutoSize = true;
            animalDataNascimentoLabel.Location = new Point(154, 46);
            animalDataNascimentoLabel.Name = "animalDataNascimentoLabel";
            animalDataNascimentoLabel.Size = new Size(114, 15);
            animalDataNascimentoLabel.TabIndex = 17;
            animalDataNascimentoLabel.Text = "Data de Nascimento";
            // 
            // animalSexoLabel
            // 
            animalSexoLabel.AutoSize = true;
            animalSexoLabel.Location = new Point(5, 45);
            animalSexoLabel.Name = "animalSexoLabel";
            animalSexoLabel.Size = new Size(31, 15);
            animalSexoLabel.TabIndex = 16;
            animalSexoLabel.Text = "Sexo";
            // 
            // animalNomeLabel
            // 
            animalNomeLabel.AutoSize = true;
            animalNomeLabel.Location = new Point(154, 2);
            animalNomeLabel.Name = "animalNomeLabel";
            animalNomeLabel.Size = new Size(40, 15);
            animalNomeLabel.TabIndex = 15;
            animalNomeLabel.Text = "Nome";
            // 
            // animalNumeroLabel
            // 
            animalNumeroLabel.AutoSize = true;
            animalNumeroLabel.Location = new Point(3, 2);
            animalNumeroLabel.Name = "animalNumeroLabel";
            animalNumeroLabel.Size = new Size(51, 15);
            animalNumeroLabel.TabIndex = 14;
            animalNumeroLabel.Text = "Numero";
            // 
            // animalDonoText
            // 
            animalDonoText.Location = new Point(154, 114);
            animalDonoText.Name = "animalDonoText";
            animalDonoText.Size = new Size(159, 23);
            animalDonoText.TabIndex = 13;
            // 
            // animalNomeText
            // 
            animalNomeText.Location = new Point(154, 20);
            animalNomeText.Name = "animalNomeText";
            animalNomeText.Size = new Size(159, 23);
            animalNomeText.TabIndex = 11;
            // 
            // animalDataNascimentoText
            // 
            animalDataNascimentoText.Location = new Point(154, 64);
            animalDataNascimentoText.Name = "animalDataNascimentoText";
            animalDataNascimentoText.Size = new Size(159, 23);
            animalDataNascimentoText.TabIndex = 9;
            // 
            // animalEspecieText
            // 
            animalEspecieText.Location = new Point(5, 115);
            animalEspecieText.Name = "animalEspecieText";
            animalEspecieText.Size = new Size(136, 23);
            animalEspecieText.TabIndex = 7;
            // 
            // animalPesoText
            // 
            animalPesoText.Location = new Point(76, 64);
            animalPesoText.Name = "animalPesoText";
            animalPesoText.Size = new Size(66, 23);
            animalPesoText.TabIndex = 5;
            // 
            // animalSexoText
            // 
            animalSexoText.Location = new Point(5, 64);
            animalSexoText.Name = "animalSexoText";
            animalSexoText.Size = new Size(65, 23);
            animalSexoText.TabIndex = 3;
            // 
            // animalNumeroText
            // 
            animalNumeroText.Location = new Point(5, 19);
            animalNumeroText.Name = "animalNumeroText";
            animalNumeroText.Size = new Size(136, 23);
            animalNumeroText.TabIndex = 1;
            // 
            // medicamentoTabPage
            // 
            medicamentoTabPage.Location = new Point(4, 64);
            medicamentoTabPage.Margin = new Padding(2);
            medicamentoTabPage.Name = "medicamentoTabPage";
            medicamentoTabPage.Padding = new Padding(2);
            medicamentoTabPage.Size = new Size(318, 143);
            medicamentoTabPage.TabIndex = 4;
            medicamentoTabPage.Text = "Medicamento";
            medicamentoTabPage.UseVisualStyleBackColor = true;
            // 
            // consultaTabPage
            // 
            consultaTabPage.Location = new Point(4, 64);
            consultaTabPage.Margin = new Padding(2);
            consultaTabPage.Name = "consultaTabPage";
            consultaTabPage.Padding = new Padding(2);
            consultaTabPage.Size = new Size(318, 143);
            consultaTabPage.TabIndex = 5;
            consultaTabPage.Text = "Consulta";
            consultaTabPage.UseVisualStyleBackColor = true;
            // 
            // pagamentoTabPage
            // 
            pagamentoTabPage.Location = new Point(4, 64);
            pagamentoTabPage.Margin = new Padding(2);
            pagamentoTabPage.Name = "pagamentoTabPage";
            pagamentoTabPage.Padding = new Padding(2);
            pagamentoTabPage.Size = new Size(318, 143);
            pagamentoTabPage.TabIndex = 6;
            pagamentoTabPage.Text = "Pagamento";
            pagamentoTabPage.UseVisualStyleBackColor = true;
            // 
            // prescricaoTabPage
            // 
            prescricaoTabPage.Location = new Point(4, 64);
            prescricaoTabPage.Margin = new Padding(2);
            prescricaoTabPage.Name = "prescricaoTabPage";
            prescricaoTabPage.Padding = new Padding(2);
            prescricaoTabPage.Size = new Size(318, 143);
            prescricaoTabPage.TabIndex = 7;
            prescricaoTabPage.Text = "Prescrição";
            prescricaoTabPage.UseVisualStyleBackColor = true;
            // 
            // especialidadeTabPage
            // 
            especialidadeTabPage.Location = new Point(4, 64);
            especialidadeTabPage.Margin = new Padding(2);
            especialidadeTabPage.Name = "especialidadeTabPage";
            especialidadeTabPage.Padding = new Padding(2);
            especialidadeTabPage.Size = new Size(318, 143);
            especialidadeTabPage.TabIndex = 8;
            especialidadeTabPage.Text = "Especialidade";
            especialidadeTabPage.UseVisualStyleBackColor = true;
            // 
            // especieTabPage
            // 
            especieTabPage.Location = new Point(4, 64);
            especieTabPage.Margin = new Padding(2);
            especieTabPage.Name = "especieTabPage";
            especieTabPage.Padding = new Padding(2);
            especieTabPage.Size = new Size(318, 143);
            especieTabPage.TabIndex = 9;
            especieTabPage.Text = "Espécie";
            especieTabPage.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(628, 325);
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
            animalTabPage.ResumeLayout(false);
            animalTabPage.PerformLayout();
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
        private TabPage animalTabPage;
        private TabPage medicamentoTabPage;
        private TabPage consultaTabPage;
        private TabPage pagamentoTabPage;
        private TabPage prescricaoTabPage;
        private TabPage especialidadeTabPage;
        private TabPage especieTabPage;
        private TextBox medicoClinicaText;
        private TextBox animalSexoText;
        private TextBox animalNumeroText;
        private TextBox animalEspecieText;
        private TextBox animalPesoText;
        private TextBox animalNomeText;
        private TextBox animalDataNascimentoText;
        private Label animalSexoLabel;
        private Label animalNomeLabel;
        private Label animalNumeroLabel;
        private TextBox animalDonoText;
        private Label animalPesoLabel;
        private Label animalDataNascimentoLabel;
        private Label animalEspecieLabel;
        private Label animalDonoLabel;
    }
}
