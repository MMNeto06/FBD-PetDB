namespace PetDB
{
    partial class UC_ListTreatments
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
            treatmentsListBox = new ListBox();
            btnAddTreatment = new Button();
            btnRemoveTreatment = new Button();
            SuspendLayout();
            // 
            // treatmentsListBox
            // 
            treatmentsListBox.FormattingEnabled = true;
            treatmentsListBox.Location = new Point(0, 0);
            treatmentsListBox.Name = "treatmentsListBox";
            treatmentsListBox.Size = new Size(402, 199);
            treatmentsListBox.TabIndex = 0;
            // 
            // btnAddTreatment
            // 
            btnAddTreatment.Location = new Point(75, 203);
            btnAddTreatment.Name = "btnAddTreatment";
            btnAddTreatment.Size = new Size(92, 23);
            btnAddTreatment.TabIndex = 1;
            btnAddTreatment.Text = "Adicionar";
            btnAddTreatment.UseVisualStyleBackColor = true;
            btnAddTreatment.Click += btnAddTreatment_Click;
            // 
            // btnRemoveTreatment
            // 
            btnRemoveTreatment.Location = new Point(223, 203);
            btnRemoveTreatment.Name = "btnRemoveTreatment";
            btnRemoveTreatment.Size = new Size(83, 23);
            btnRemoveTreatment.TabIndex = 3;
            btnRemoveTreatment.Text = "Remover";
            btnRemoveTreatment.UseVisualStyleBackColor = true;
            btnRemoveTreatment.Click += btnRemoveTreatment_Click;
            // 
            // UC_ListTreatments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRemoveTreatment);
            Controls.Add(btnAddTreatment);
            Controls.Add(treatmentsListBox);
            Name = "UC_ListTreatments";
            Size = new Size(402, 229);
            ResumeLayout(false);
        }

        #endregion

        private ListBox treatmentsListBox;
        private Button btnAddTreatment;
        private Button btnRemoveTreatment;
    }
}
