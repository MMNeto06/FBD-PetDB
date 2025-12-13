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
    public partial class DonoForm : Form
    {
        private Login loginPage;
        private int nif;
        private SqlConnection cn;
        public DonoForm(Login loginPage, int nif)
        {
            InitializeComponent();
            this.loginPage = loginPage;
            this.nif = nif;
            //this.nome = nome;
            loadFlowoutPanel();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            loginPage.Show();
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

        private void backBtn_Click(object sender, EventArgs e)
        {
            loginPage.Show();
            this.Close();
        }

        public void loadFlowoutPanel()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("EXEC SP_GetPetsByOwner " + this.nif, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Pet pet = new Pet();
                pet.Numero = reader["Numero"].ToString();
                pet.Nome = reader["Nome"].ToString();
                pet.DataNascimento = ((DateTime)reader["DataNascimento"]).ToString("dd/MM/yyyy");
                pet.Sexo = reader["Sexo"].ToString();
                pet.Peso = reader["Peso"].ToString();
                pet.Especie = reader["Especie"].ToString();
                pet.Dono = reader["Dono"].ToString();

                var card = new UC_AnimalCard(pet);
                card.OnCardClicked += (s, e) =>
                {
                    showAnimalPopup(card);
                };
                cardsFlowLayoutPanel.Controls.Add(card);
            }

            cn.Close();
        }

        public void showAnimalPopup(UC_AnimalCard card)
        {
            UC_AnimalInfo uc = new UC_AnimalInfo(card._animal);
            
            PopUpForm popup = new PopUpForm(uc, "Detalhes sobre o animal");
            //popup.ClientSize = new Size(1000, 1000);
            popup.ShowDialog();        
        }

    }
}
