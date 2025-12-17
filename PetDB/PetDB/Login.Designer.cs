namespace PetDB
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            loginText = new Label();
            adminBtn = new Button();
            clinicaBtn = new Button();
            medicoBtn = new Button();
            donoBtn = new Button();
            logoBox = new PictureBox();
            idLabel = new Label();
            idTextBox = new TextBox();
            loginBtn = new Button();
            registerBtn = new Button();
            backBtn = new Button();
            registerIdText = new TextBox();
            registerIdLabel = new Label();
            registerNomeLabel = new Label();
            registerNomeTextBox = new TextBox();
            registerTelefoneLabel = new Label();
            registerTelefoneTextBox = new TextBox();
            registerEmailLabel = new Label();
            registerEmailTextBox = new TextBox();
            registerEnderecoLabel = new Label();
            registerEnderecoTextBox = new TextBox();
            registerClinicaLabel = new Label();
            registerClinicaTextBox = new TextBox();
            registerEspecialidadeLabel = new Label();
            registerBackBtn = new Button();
            adicionarBtn = new Button();
            registerEspecialidadeComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // loginText
            // 
            loginText.AutoSize = true;
            loginText.Font = new Font("Segoe UI", 20F);
            loginText.Location = new Point(115, 87);
            loginText.Name = "loginText";
            loginText.Size = new Size(344, 92);
            loginText.TabIndex = 0;
            loginText.Text = "Bem Vindo\r\nPor favor efetue login";
            loginText.TextAlign = ContentAlignment.TopCenter;
            // 
            // adminBtn
            // 
            adminBtn.Font = new Font("Segoe UI", 20F);
            adminBtn.Location = new Point(98, 236);
            adminBtn.Name = "adminBtn";
            adminBtn.Size = new Size(272, 56);
            adminBtn.TabIndex = 1;
            adminBtn.Text = "Administrador";
            adminBtn.UseVisualStyleBackColor = true;
            adminBtn.Click += adminBtn_Click;
            // 
            // clinicaBtn
            // 
            clinicaBtn.Font = new Font("Segoe UI", 20F);
            clinicaBtn.Location = new Point(399, 236);
            clinicaBtn.Name = "clinicaBtn";
            clinicaBtn.Size = new Size(272, 56);
            clinicaBtn.TabIndex = 2;
            clinicaBtn.Text = "Clinica";
            clinicaBtn.UseVisualStyleBackColor = true;
            clinicaBtn.Click += clinicaBtn_Click;
            // 
            // medicoBtn
            // 
            medicoBtn.Font = new Font("Segoe UI", 20F);
            medicoBtn.Location = new Point(98, 318);
            medicoBtn.Name = "medicoBtn";
            medicoBtn.Size = new Size(272, 56);
            medicoBtn.TabIndex = 3;
            medicoBtn.Text = "Médico";
            medicoBtn.UseVisualStyleBackColor = true;
            medicoBtn.Click += medicoBtn_Click;
            // 
            // donoBtn
            // 
            donoBtn.Font = new Font("Segoe UI", 20F);
            donoBtn.Location = new Point(399, 318);
            donoBtn.Name = "donoBtn";
            donoBtn.Size = new Size(272, 56);
            donoBtn.TabIndex = 4;
            donoBtn.Text = "Dono de Animal";
            donoBtn.UseVisualStyleBackColor = true;
            donoBtn.Click += donoBtn_Click;
            // 
            // logoBox
            // 
            logoBox.ImageLocation = "C:\\Users\\netom\\Desktop\\UNIVERSIDADE\\2_ANO\\FBD\\PetDB\\FBD-PetDB\\PetDB\\PetDB\\logo.jpg";
            logoBox.InitialImage = (Image)resources.GetObject("logoBox.InitialImage");
            logoBox.Location = new Point(495, 30);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(200, 200);
            logoBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoBox.TabIndex = 5;
            logoBox.TabStop = false;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Font = new Font("Segoe UI", 15F);
            idLabel.Location = new Point(171, 144);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(157, 35);
            idLabel.TabIndex = 6;
            idLabel.Text = "Identificação";
            // 
            // idTextBox
            // 
            idTextBox.Font = new Font("Segoe UI", 15F);
            idTextBox.Location = new Point(171, 189);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(318, 41);
            idTextBox.TabIndex = 7;
            idTextBox.KeyDown += OnKeyDownHandler;
            // 
            // loginBtn
            // 
            loginBtn.Font = new Font("Segoe UI", 12F);
            loginBtn.Location = new Point(270, 392);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(85, 46);
            loginBtn.TabIndex = 8;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // registerBtn
            // 
            registerBtn.Font = new Font("Segoe UI", 12F);
            registerBtn.Location = new Point(374, 392);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(93, 46);
            registerBtn.TabIndex = 9;
            registerBtn.Text = "Registar";
            registerBtn.UseVisualStyleBackColor = true;
            registerBtn.Click += registerBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(81, 72);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(94, 29);
            backBtn.TabIndex = 10;
            backBtn.Text = "<-";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // registerIdText
            // 
            registerIdText.Location = new Point(125, 39);
            registerIdText.Name = "registerIdText";
            registerIdText.Size = new Size(306, 27);
            registerIdText.TabIndex = 11;
            // 
            // registerIdLabel
            // 
            registerIdLabel.AutoSize = true;
            registerIdLabel.Location = new Point(127, 19);
            registerIdLabel.Name = "registerIdLabel";
            registerIdLabel.Size = new Size(70, 20);
            registerIdLabel.TabIndex = 12;
            registerIdLabel.Text = "NIF/OMV";
            // 
            // registerNomeLabel
            // 
            registerNomeLabel.AutoSize = true;
            registerNomeLabel.Location = new Point(127, 76);
            registerNomeLabel.Name = "registerNomeLabel";
            registerNomeLabel.Size = new Size(50, 20);
            registerNomeLabel.TabIndex = 14;
            registerNomeLabel.Text = "Nome";
            // 
            // registerNomeTextBox
            // 
            registerNomeTextBox.Location = new Point(125, 96);
            registerNomeTextBox.Name = "registerNomeTextBox";
            registerNomeTextBox.Size = new Size(306, 27);
            registerNomeTextBox.TabIndex = 13;
            // 
            // registerTelefoneLabel
            // 
            registerTelefoneLabel.AutoSize = true;
            registerTelefoneLabel.Location = new Point(127, 144);
            registerTelefoneLabel.Name = "registerTelefoneLabel";
            registerTelefoneLabel.Size = new Size(66, 20);
            registerTelefoneLabel.TabIndex = 16;
            registerTelefoneLabel.Text = "Telefone";
            // 
            // registerTelefoneTextBox
            // 
            registerTelefoneTextBox.Location = new Point(125, 164);
            registerTelefoneTextBox.Name = "registerTelefoneTextBox";
            registerTelefoneTextBox.Size = new Size(306, 27);
            registerTelefoneTextBox.TabIndex = 15;
            // 
            // registerEmailLabel
            // 
            registerEmailLabel.AutoSize = true;
            registerEmailLabel.Location = new Point(127, 213);
            registerEmailLabel.Name = "registerEmailLabel";
            registerEmailLabel.Size = new Size(46, 20);
            registerEmailLabel.TabIndex = 18;
            registerEmailLabel.Text = "Email";
            // 
            // registerEmailTextBox
            // 
            registerEmailTextBox.Location = new Point(125, 233);
            registerEmailTextBox.Name = "registerEmailTextBox";
            registerEmailTextBox.Size = new Size(306, 27);
            registerEmailTextBox.TabIndex = 17;
            // 
            // registerEnderecoLabel
            // 
            registerEnderecoLabel.AutoSize = true;
            registerEnderecoLabel.Location = new Point(125, 283);
            registerEnderecoLabel.Name = "registerEnderecoLabel";
            registerEnderecoLabel.Size = new Size(71, 20);
            registerEnderecoLabel.TabIndex = 20;
            registerEnderecoLabel.Text = "Endereco";
            // 
            // registerEnderecoTextBox
            // 
            registerEnderecoTextBox.Location = new Point(123, 303);
            registerEnderecoTextBox.Name = "registerEnderecoTextBox";
            registerEnderecoTextBox.Size = new Size(306, 27);
            registerEnderecoTextBox.TabIndex = 19;
            // 
            // registerClinicaLabel
            // 
            registerClinicaLabel.AutoSize = true;
            registerClinicaLabel.Location = new Point(360, 344);
            registerClinicaLabel.Name = "registerClinicaLabel";
            registerClinicaLabel.Size = new Size(79, 20);
            registerClinicaLabel.TabIndex = 22;
            registerClinicaLabel.Text = "NIF Clinica";
            // 
            // registerClinicaTextBox
            // 
            registerClinicaTextBox.Location = new Point(358, 364);
            registerClinicaTextBox.Name = "registerClinicaTextBox";
            registerClinicaTextBox.Size = new Size(306, 27);
            registerClinicaTextBox.TabIndex = 21;
            // 
            // registerEspecialidadeLabel
            // 
            registerEspecialidadeLabel.AutoSize = true;
            registerEspecialidadeLabel.Location = new Point(115, 344);
            registerEspecialidadeLabel.Name = "registerEspecialidadeLabel";
            registerEspecialidadeLabel.Size = new Size(101, 20);
            registerEspecialidadeLabel.TabIndex = 24;
            registerEspecialidadeLabel.Text = "Especialidade";
            // 
            // registerBackBtn
            // 
            registerBackBtn.Location = new Point(12, 30);
            registerBackBtn.Name = "registerBackBtn";
            registerBackBtn.Size = new Size(94, 29);
            registerBackBtn.TabIndex = 25;
            registerBackBtn.Text = "<-";
            registerBackBtn.UseVisualStyleBackColor = true;
            registerBackBtn.Click += registerBackBtn_Click;
            // 
            // adicionarBtn
            // 
            adicionarBtn.Font = new Font("Segoe UI", 12F);
            adicionarBtn.Location = new Point(473, 397);
            adicionarBtn.Name = "adicionarBtn";
            adicionarBtn.Size = new Size(115, 46);
            adicionarBtn.TabIndex = 26;
            adicionarBtn.Text = "Adicionar";
            adicionarBtn.UseVisualStyleBackColor = true;
            adicionarBtn.Click += adicionarBtn_Click;
            // 
            // registerEspecialidadeComboBox
            // 
            registerEspecialidadeComboBox.FormattingEnabled = true;
            registerEspecialidadeComboBox.Location = new Point(113, 367);
            registerEspecialidadeComboBox.Name = "registerEspecialidadeComboBox";
            registerEspecialidadeComboBox.Size = new Size(239, 28);
            registerEspecialidadeComboBox.TabIndex = 27;
            registerEspecialidadeComboBox.SelectedIndexChanged += registerEspecialidadeComboBox_SelectedIndexChanged;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(registerEspecialidadeComboBox);
            Controls.Add(adicionarBtn);
            Controls.Add(registerBackBtn);
            Controls.Add(registerEspecialidadeLabel);
            Controls.Add(registerClinicaLabel);
            Controls.Add(registerClinicaTextBox);
            Controls.Add(registerEnderecoLabel);
            Controls.Add(registerEnderecoTextBox);
            Controls.Add(registerEmailLabel);
            Controls.Add(registerEmailTextBox);
            Controls.Add(registerTelefoneLabel);
            Controls.Add(registerTelefoneTextBox);
            Controls.Add(registerNomeLabel);
            Controls.Add(registerNomeTextBox);
            Controls.Add(registerIdLabel);
            Controls.Add(registerIdText);
            Controls.Add(backBtn);
            Controls.Add(registerBtn);
            Controls.Add(loginBtn);
            Controls.Add(idTextBox);
            Controls.Add(idLabel);
            Controls.Add(logoBox);
            Controls.Add(donoBtn);
            Controls.Add(medicoBtn);
            Controls.Add(clinicaBtn);
            Controls.Add(adminBtn);
            Controls.Add(loginText);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label loginText;
        private Button adminBtn;
        private Button clinicaBtn;
        private Button medicoBtn;
        private Button donoBtn;
        private PictureBox logoBox;
        private Label idLabel;
        private TextBox idTextBox;
        private Button loginBtn;
        private Button registerBtn;
        private Button backBtn;
        private TextBox registerIdText;
        private Label registerIdLabel;
        private Label registerNomeLabel;
        private TextBox registerNomeTextBox;
        private Label registerTelefoneLabel;
        private TextBox registerTelefoneTextBox;
        private Label registerEmailLabel;
        private TextBox registerEmailTextBox;
        private Label registerEnderecoLabel;
        private TextBox registerEnderecoTextBox;
        private Label registerClinicaLabel;
        private TextBox registerClinicaTextBox;
        private Label registerEspecialidadeLabel;
        private Button registerBackBtn;
        private Button adicionarBtn;
        private ComboBox registerEspecialidadeComboBox;
    }
}