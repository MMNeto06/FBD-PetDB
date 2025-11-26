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
            idLabel.Size = new Size(318, 35);
            idLabel.TabIndex = 6;
            idLabel.Text = "Identificação (NIF ou OMV)";
            // 
            // idTextBox
            // 
            idTextBox.Font = new Font("Segoe UI", 15F);
            idTextBox.Location = new Point(171, 189);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(318, 41);
            idTextBox.TabIndex = 7;
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
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}