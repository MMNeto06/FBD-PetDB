namespace PetDB
{
    partial class UC_ListStrings
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
            listBoxStrings = new ListBox();
            SuspendLayout();
            // 
            // listBoxStrings
            // 
            listBoxStrings.FormattingEnabled = true;
            listBoxStrings.Location = new Point(0, 0);
            listBoxStrings.Name = "listBoxStrings";
            listBoxStrings.Size = new Size(402, 229);
            listBoxStrings.TabIndex = 0;
            // 
            // UC_ListStrings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listBoxStrings);
            Location = new Point(182, 101);
            Name = "UC_ListStrings";
            Size = new Size(402, 229);
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxStrings;
    }
}
