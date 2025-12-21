using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices.JavaScript;
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
            this.Text = "Bem Vindo " + getDonoName();
            animaisToolStripMenuItem_Click(null, null);
        }

        public String getDonoName()
        {
            if (!verifySGBDConnection())
                return "";

            String d = "";
            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetOwnerTable(@OwnerNIF, DEFAULT, NULL) ORDER BY Nome", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@OwnerNIF", this.nif);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                d = reader["Nome"].ToString();
            }
            reader.Close();
            cn.Close();
            return d;
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
            cardsFlowLayoutPanel.Controls.Clear();
            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetPetInfo(@OwnerNIF, DEFAULT, NULL) ORDER BY Nome", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@OwnerNIF", this.nif);
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

        public void loadPaymentTable()
        {
            if (!verifySGBDConnection())
                return;

            BindingList<Payment> payments = new BindingList<Payment>();
            dataGridView1.DataSource = payments;
            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetPaymentInfo(@OwnerNIF, DEFAULT, DEFAULT, NULL) ORDER BY [Data] DESC", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@OwnerNIF", this.nif);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Payment payment = new Payment();
                //payment.Id = reader[""].ToString();
                payment.Valor = reader["Custo"].ToString();
                payment.Data = reader["Data"].ToString();
                payment.Estado = reader["Estado"].ToString();
                payment.Metodo = reader["Metodo"].ToString();
                payment.Animal = reader["Animal"].ToString();
                payment.Medico = reader["Medico"].ToString();
                payments.Add(payment);
            }
            cn.Close();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Refresh();
        }

        private void donoBaseControls()
        {
            donoNomeText.Enabled = false;
            donoTelefoneText.Enabled = false;
            donoEmailText.Enabled = false;
            donoEnderecoText.Enabled = false;
            editBtn.Visible = true;
            okBtn.Visible = false;
            cancelBtn.Visible = false;
        }

        private void donoEditControls()
        {
            donoNomeText.Enabled = true;
            donoTelefoneText.Enabled = true;
            donoEmailText.Enabled = true;
            donoEnderecoText.Enabled = true;
            editBtn.Visible = false;
            okBtn.Visible = true;
            cancelBtn.Visible = true;
        }

        private void animaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Os seus Animais";
            cardsFlowLayoutPanel.Visible = true;
            dataGridView1.Visible = false;
            perfilPanel.Visible = false;
            loadFlowoutPanel();
        }

        private void pagamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Os seus Pagamentos";
            cardsFlowLayoutPanel.Visible = false;
            dataGridView1.Visible = true;
            perfilPanel.Visible = false;
            loadPaymentTable();
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Os seus Perfil";
            cardsFlowLayoutPanel.Visible = false;
            dataGridView1.Visible = false;
            perfilPanel.Visible = true;
            donoBaseControls();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetOwnerTable(@OwnerNIF, DEFAULT, NULL) ORDER BY Nome", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@OwnerNIF", this.nif);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) // Don't assume we have any rows.
            {
                donoNomeText.Text = reader["Nome"].ToString();
                donoEmailText.Text = reader["Email"].ToString();
                donoEnderecoText.Text = reader["Endereco"].ToString();
                donoTelefoneText.Text = reader["Telefone"].ToString();
            }
            reader.Close();
            cn.Close();
            this.Text = "Bem Vindo " + donoNomeText.Text;
        }
        private bool ExecuteInsertSP(SqlCommand cmd)
        {
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Erro na Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void DonoTuples(String sp, String msgShow)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OwnerNIF", this.nif);
            cmd.Parameters.AddWithValue("@OwnerName", donoNomeText.Text);
            cmd.Parameters.AddWithValue("@OwnerPhone", donoTelefoneText.Text);
            cmd.Parameters.AddWithValue("@OwnerEmail", donoEmailText.Text);
            cmd.Parameters.AddWithValue("@OwnerAddress", donoEnderecoText.Text);

            if (ExecuteInsertSP(cmd))
            {
                MessageBox.Show(msgShow);
            }

            cn.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DonoTuples("SP_UpdateOwner", "Informações atualizadas com sucesso!");
            perfilToolStripMenuItem_Click(sender, e);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            donoEditControls();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            donoBaseControls();
        }
    }
}
