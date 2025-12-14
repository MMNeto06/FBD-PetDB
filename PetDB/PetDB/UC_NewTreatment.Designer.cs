namespace PetDB
{
    partial class UC_NewTreatment
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            treatmentsComboBox = new ComboBox();
            okBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(182, 15);
            label1.TabIndex = 0;
            label1.Text = "Selecione o tratamento desejado:";
            // 
            // treatmentsComboBox
            // 
            treatmentsComboBox.FormattingEnabled = true;
            treatmentsComboBox.Location = new Point(12, 34);
            treatmentsComboBox.Name = "treatmentsComboBox";
            treatmentsComboBox.Size = new Size(182, 23);
            treatmentsComboBox.TabIndex = 1;
            // 
            // okBtn
            // 
            okBtn.Location = new Point(209, 34);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(46, 23);
            okBtn.TabIndex = 2;
            okBtn.Text = "OK";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += okBtn_Click;
            // 
            // UC_NewTreatment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(okBtn);
            Controls.Add(treatmentsComboBox);
            Controls.Add(label1);
            Name = "UC_NewTreatment";
            Size = new Size(267, 84);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox treatmentsComboBox;
        private Button okBtn;
    }
}
