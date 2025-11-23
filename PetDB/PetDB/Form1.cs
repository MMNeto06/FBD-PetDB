using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
namespace PetDB
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;
        private int currentListIndex;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            //loadCustomersToolStripMenuItem_Click(null, null);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }

        private void button1_Click_4(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

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

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void emailText_TextChanged(object sender, EventArgs e)
        {

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
    }
}
