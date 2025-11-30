using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Xml.Serialization;
namespace PetDB
{
    public partial class AdminForm : Form
    {
        private SqlConnection cn;
        private int currentListIndex;
        private Login loginPage;
        private String option = "Add";
        public AdminForm(Login loginPage)
        {
            InitializeComponent();
            this.loginPage = loginPage;
            clinicaBaseControls();
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

        private void clinicaBaseControls()
        {
            nifText.Enabled = false;
            nomeText.Enabled = false;
            telefoneText.Enabled = false;
            emailText.Enabled = false;
            enderecoText.Enabled = false;
            addBtn.Visible = true;
            editBtn.Visible = true;
            remBtn.Visible = true;
            okBtn.Visible = false;
            cancelBtn.Visible = false;
        }

        private void clinicaEditControls()
        {
            nifText.Enabled = true;
            nomeText.Enabled = true;
            telefoneText.Enabled = true;
            emailText.Enabled = true;
            enderecoText.Enabled = true;
            addBtn.Visible = false;
            editBtn.Visible = false;
            remBtn.Visible = false;
            okBtn.Visible = true;
            cancelBtn.Visible = true;
        }

        private void clinicaAddControls()
        {
            clinicaEditControls();
            nifText.Text = "";
            nomeText.Text = "";
            telefoneText.Text = "";
            emailText.Text = "";
            enderecoText.Text = "";
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            loginPage.Show();
            this.Close();
        }

        private void clinicaVeterinariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM PETDB_ClinicaVeterinaria", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                CliVet CV = new CliVet();
                CV.NIF = reader["NIF"].ToString();
                CV.Nome = reader["Nome"].ToString();
                CV.Telefone = reader["Telefone"].ToString();
                CV.Email = reader["Email"].ToString();
                CV.Endereco = reader["Endereco"].ToString();
                listBox1.Items.Add(CV);
            }

            cn.Close();


            currentListIndex = 0; //nã o sei para que isto serve
            ShowClinicaVeterinaria();
        }

        public void ShowClinicaVeterinaria()
        {
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;
            CliVet cv = new CliVet();
            cv = (CliVet)listBox1.Items[currentListIndex];
            nifText.Text = cv.NIF;
            nomeText.Text = cv.Nome;
            telefoneText.Text = cv.Telefone;
            emailText.Text = cv.Email;
            enderecoText.Text = cv.Endereco;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                currentListIndex = listBox1.SelectedIndex;
                ShowClinicaVeterinaria();
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            clinicaEditControls();
        }

        private void remBtn_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("DELETE FROM PetDB_ClinicaVeterinaria WHERE NIF=" + nifText.Text, cn);
            try
            {
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Clinica apagada da base de dados");
            }
            catch(Exception exception)
            {
                System.Windows.Forms.MessageBox.Show("Ocorreu um erro: \n" + exception);
            }
            cn.Close();
            clinicaVeterinariaToolStripMenuItem_Click(sender, e);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            clinicaBaseControls();
            ShowClinicaVeterinaria();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            clinicaAddControls();
        }
    }
}
