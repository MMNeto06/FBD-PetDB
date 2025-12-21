namespace PetDB
{
    partial class DonoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonoForm));
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            animaisToolStripMenuItem = new ToolStripMenuItem();
            pagamentosToolStripMenuItem = new ToolStripMenuItem();
            perfilToolStripMenuItem = new ToolStripMenuItem();
            titleLabel = new Label();
            cardsFlowLayoutPanel = new FlowLayoutPanel();
            dataGridView1 = new DataGridView();
            perfilPanel = new Panel();
            cancelBtn = new Button();
            okBtn = new Button();
            editBtn = new Button();
            donoEnderecoLabel = new Label();
            donoEnderecoText = new TextBox();
            donoNomeLabel = new Label();
            donoNomeText = new TextBox();
            donoTelefoneLabel = new Label();
            donoEmailLabel = new Label();
            donoEmailText = new TextBox();
            donoTelefoneText = new TextBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            perfilPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, animaisToolStripMenuItem, pagamentosToolStripMenuItem, perfilToolStripMenuItem });
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
            // animaisToolStripMenuItem
            // 
            animaisToolStripMenuItem.Name = "animaisToolStripMenuItem";
            animaisToolStripMenuItem.Size = new Size(62, 20);
            animaisToolStripMenuItem.Text = "Animais";
            animaisToolStripMenuItem.Click += animaisToolStripMenuItem_Click;
            // 
            // pagamentosToolStripMenuItem
            // 
            pagamentosToolStripMenuItem.Name = "pagamentosToolStripMenuItem";
            pagamentosToolStripMenuItem.Size = new Size(85, 20);
            pagamentosToolStripMenuItem.Text = "Pagamentos";
            pagamentosToolStripMenuItem.Click += pagamentosToolStripMenuItem_Click;
            // 
            // perfilToolStripMenuItem
            // 
            perfilToolStripMenuItem.Name = "perfilToolStripMenuItem";
            perfilToolStripMenuItem.Size = new Size(46, 20);
            perfilToolStripMenuItem.Text = "Perfil";
            perfilToolStripMenuItem.Click += perfilToolStripMenuItem_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 20F);
            titleLabel.Location = new Point(46, 28);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(204, 37);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "Os seus animais";
            // 
            // cardsFlowLayoutPanel
            // 
            cardsFlowLayoutPanel.Location = new Point(46, 64);
            cardsFlowLayoutPanel.Margin = new Padding(3, 2, 3, 2);
            cardsFlowLayoutPanel.Name = "cardsFlowLayoutPanel";
            cardsFlowLayoutPanel.Size = new Size(629, 243);
            cardsFlowLayoutPanel.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new Point(35, 77);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(629, 242);
            dataGridView1.TabIndex = 8;
            // 
            // perfilPanel
            // 
            perfilPanel.Controls.Add(cancelBtn);
            perfilPanel.Controls.Add(okBtn);
            perfilPanel.Controls.Add(editBtn);
            perfilPanel.Controls.Add(donoEnderecoLabel);
            perfilPanel.Controls.Add(donoEnderecoText);
            perfilPanel.Controls.Add(donoNomeLabel);
            perfilPanel.Controls.Add(donoNomeText);
            perfilPanel.Controls.Add(donoTelefoneLabel);
            perfilPanel.Controls.Add(donoEmailLabel);
            perfilPanel.Controls.Add(donoEmailText);
            perfilPanel.Controls.Add(donoTelefoneText);
            perfilPanel.Location = new Point(19, 67);
            perfilPanel.Margin = new Padding(3, 2, 3, 2);
            perfilPanel.Name = "perfilPanel";
            perfilPanel.Size = new Size(670, 241);
            perfilPanel.TabIndex = 9;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(198, 187);
            cancelBtn.Margin = new Padding(2);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(82, 22);
            cancelBtn.TabIndex = 42;
            cancelBtn.Text = "Cancelar";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // okBtn
            // 
            okBtn.Location = new Point(112, 187);
            okBtn.Margin = new Padding(2);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(82, 22);
            okBtn.TabIndex = 41;
            okBtn.Text = "OK";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += okBtn_Click;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(26, 187);
            editBtn.Margin = new Padding(2);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(82, 22);
            editBtn.TabIndex = 40;
            editBtn.Text = "Editar";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // donoEnderecoLabel
            // 
            donoEnderecoLabel.AutoSize = true;
            donoEnderecoLabel.Location = new Point(26, 136);
            donoEnderecoLabel.Margin = new Padding(2, 0, 2, 0);
            donoEnderecoLabel.Name = "donoEnderecoLabel";
            donoEnderecoLabel.Size = new Size(56, 15);
            donoEnderecoLabel.TabIndex = 39;
            donoEnderecoLabel.Text = "Endereço";
            // 
            // donoEnderecoText
            // 
            donoEnderecoText.Location = new Point(26, 153);
            donoEnderecoText.Margin = new Padding(2);
            donoEnderecoText.Name = "donoEnderecoText";
            donoEnderecoText.Size = new Size(338, 23);
            donoEnderecoText.TabIndex = 38;
            // 
            // donoNomeLabel
            // 
            donoNomeLabel.AutoSize = true;
            donoNomeLabel.Location = new Point(26, 19);
            donoNomeLabel.Margin = new Padding(2, 0, 2, 0);
            donoNomeLabel.Name = "donoNomeLabel";
            donoNomeLabel.Size = new Size(40, 15);
            donoNomeLabel.TabIndex = 33;
            donoNomeLabel.Text = "Nome";
            // 
            // donoNomeText
            // 
            donoNomeText.Location = new Point(26, 35);
            donoNomeText.Margin = new Padding(2);
            donoNomeText.Name = "donoNomeText";
            donoNomeText.Size = new Size(338, 23);
            donoNomeText.TabIndex = 31;
            // 
            // donoTelefoneLabel
            // 
            donoTelefoneLabel.AutoSize = true;
            donoTelefoneLabel.Location = new Point(26, 57);
            donoTelefoneLabel.Margin = new Padding(2, 0, 2, 0);
            donoTelefoneLabel.Name = "donoTelefoneLabel";
            donoTelefoneLabel.Size = new Size(52, 15);
            donoTelefoneLabel.TabIndex = 35;
            donoTelefoneLabel.Text = "Telefone";
            // 
            // donoEmailLabel
            // 
            donoEmailLabel.AutoSize = true;
            donoEmailLabel.Location = new Point(26, 97);
            donoEmailLabel.Margin = new Padding(2, 0, 2, 0);
            donoEmailLabel.Name = "donoEmailLabel";
            donoEmailLabel.Size = new Size(36, 15);
            donoEmailLabel.TabIndex = 37;
            donoEmailLabel.Text = "Email";
            // 
            // donoEmailText
            // 
            donoEmailText.Location = new Point(26, 115);
            donoEmailText.Margin = new Padding(2);
            donoEmailText.Name = "donoEmailText";
            donoEmailText.Size = new Size(338, 23);
            donoEmailText.TabIndex = 36;
            // 
            // donoTelefoneText
            // 
            donoTelefoneText.Location = new Point(26, 75);
            donoTelefoneText.Margin = new Padding(2);
            donoTelefoneText.Name = "donoTelefoneText";
            donoTelefoneText.Size = new Size(338, 23);
            donoTelefoneText.TabIndex = 34;
            // 
            // DonoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(dataGridView1);
            Controls.Add(titleLabel);
            Controls.Add(menuStrip1);
            Controls.Add(cardsFlowLayoutPanel);
            Controls.Add(perfilPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "DonoForm";
            Text = "Bem Vindo Dono";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            perfilPanel.ResumeLayout(false);
            perfilPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem animaisToolStripMenuItem;
        private Label titleLabel;
        private FlowLayoutPanel cardsFlowLayoutPanel;
        private ToolStripMenuItem perfilToolStripMenuItem;
        private ToolStripMenuItem pagamentosToolStripMenuItem;
        private DataGridView dataGridView1;
        private Panel perfilPanel;
        private Label donoEnderecoLabel;
        private TextBox donoEnderecoText;
        private Label donoNomeLabel;
        private TextBox donoNomeText;
        private Label donoTelefoneLabel;
        private Label donoEmailLabel;
        private TextBox donoEmailText;
        private TextBox donoTelefoneText;
        private Button cancelBtn;
        private Button okBtn;
        private Button editBtn;
    }
}