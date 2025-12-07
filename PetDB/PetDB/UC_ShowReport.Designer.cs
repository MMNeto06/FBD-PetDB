namespace PetDB
{
    partial class UC_ShowReport
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
            reportText = new TextBox();
            SuspendLayout();
            // 
            // reportText
            // 
            reportText.Location = new Point(0, 0);
            reportText.Multiline = true;
            reportText.Name = "reportText";
            reportText.Size = new Size(434, 285);
            reportText.TabIndex = 0;
            // 
            // UC_ShowReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(reportText);
            Name = "UC_ShowReport";
            Size = new Size(434, 285);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox reportText;
    }
}
