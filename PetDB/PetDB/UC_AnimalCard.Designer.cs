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
            nomeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            nomeLabel.AutoSize = true;
            nomeLabel.Font = new Font("Segoe UI", 12F);
            nomeLabel.Location = new Point(42, 38);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new Size(66, 28);
            nomeLabel.TabIndex = 0;
            nomeLabel.Text = "Nome";
            nomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // especieLabel
            // 
            especieLabel.AutoSize = true;
            especieLabel.Location = new Point(42, 89);
            especieLabel.Name = "especieLabel";
            especieLabel.Size = new Size(59, 20);
            especieLabel.TabIndex = 1;
            especieLabel.Text = "Especie";
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
