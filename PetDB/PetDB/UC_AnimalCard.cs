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

            SqlCommand cmd = new SqlCommand("EXEC SP_GetSpecieName " + this._animal.Especie, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.especieLabel.Text = reader["Descricao"].ToString();
            }
            cn.Close();
            this.Click += Card_Click;
            foreach (Control c in Controls)
            {
                c.Click += Card_Click; // propagate clicks
            }
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source= localhost\\SQLEXPRESS ;integrated security=true;initial catalog=PETDB;TrustServerCertificate=true");
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
