using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PetDB
{
    public partial class UC_AnimalCard : UserControl
    {
        public Pet _animal;
        private SqlConnection cn;

        public UC_AnimalCard(Pet animal)
        {
            InitializeComponent();
            this._animal = animal;
            this.nomeLabel.Text = animal.Nome;

            if (!verifySGBDConnection())
                return;

            this.Click += Card_Click;
            foreach (Control c in Controls)
            {
                c.Click += Card_Click; // propagate clicks
            }
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source=tcp:mednat.ieeta.pt\\SQLSERVER,8101;Persist Security Info=True;User ID=p2g2;Password=V@ndalism0;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=30");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            OnCardClicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler OnCardClicked;

    }
}
