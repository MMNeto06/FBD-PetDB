namespace PetDB
{
    partial class UC_ListMeds
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
            listBoxMeds = new ListBox();
            listMedsBtnRemove = new Button();
            listMedsAddBtn = new Button();
            SuspendLayout();
            // 
            // listBoxMeds
            // 
            listBoxMeds.FormattingEnabled = true;
            listBoxMeds.Location = new Point(0, 0);
            listBoxMeds.Name = "listBoxMeds";
            listBoxMeds.Size = new Size(402, 199);
            listBoxMeds.TabIndex = 0;
            // 
            // listMedsBtnRemove
            // 
            listMedsBtnRemove.Location = new Point(239, 203);
            listMedsBtnRemove.Name = "listMedsBtnRemove";
            listMedsBtnRemove.Size = new Size(85, 23);
            listMedsBtnRemove.TabIndex = 1;
            listMedsBtnRemove.Text = "Remover";
            listMedsBtnRemove.UseVisualStyleBackColor = true;
            listMedsBtnRemove.Click += listMedsBtnRemove_Click;
            // 
            // listMedsAddBtn
            // 
            listMedsAddBtn.Location = new Point(85, 203);
            listMedsAddBtn.Name = "listMedsAddBtn";
            listMedsAddBtn.Size = new Size(87, 23);
            listMedsAddBtn.TabIndex = 2;
            listMedsAddBtn.Text = "Adicionar";
            listMedsAddBtn.UseVisualStyleBackColor = true;
            listMedsAddBtn.Click += listMedsAddBtn_Click;
            // 
            // UC_ListMeds
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listMedsAddBtn);
            Controls.Add(listMedsBtnRemove);
            Controls.Add(listBoxMeds);
            Location = new Point(182, 101);
            Name = "UC_ListMeds";
            Size = new Size(402, 229);
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxMeds;
        private Button listMedsBtnRemove;
        private Button listMedsAddBtn;
    }
}
