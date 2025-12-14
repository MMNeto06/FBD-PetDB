namespace PetDB
{
    partial class UC_AnimalCard
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
            nomeLabel = new Label();
            especieLabel = new Label();
            SuspendLayout();
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Font = new Font("Segoe UI", 12F);
            nomeLabel.Location = new Point(3, 33);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new Size(119, 28);
            nomeLabel.TabIndex = 0;
            nomeLabel.Text = "Nome super";
            nomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // especieLabel
            // 
            especieLabel.AutoSize = true;
            especieLabel.Location = new Point(3, 95);
            especieLabel.Name = "especieLabel";
            especieLabel.Size = new Size(134, 20);
            especieLabel.TabIndex = 1;
            especieLabel.Text = "Porquinho da india";
            especieLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_AnimalCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(especieLabel);
            Controls.Add(nomeLabel);
            Name = "UC_AnimalCard";
            Size = new Size(146, 146);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nomeLabel;
        private Label especieLabel;
    }
}
