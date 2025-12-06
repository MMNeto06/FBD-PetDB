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
        private String entity = "";
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
            clinicaNifText.Enabled = false;
            clinicaNomeText.Enabled = false;
            clinicaTelefoneText.Enabled = false;
            clinicaEmailText.Enabled = false;
            clinicaEnderecoText.Enabled = false;
            addBtn.Visible = true;
            editBtn.Visible = true;
            remBtn.Visible = true;
            okBtn.Visible = false;
            cancelBtn.Visible = false;
        }

        private void clinicaEditControls()
        {
            clinicaNifText.Enabled = true;
            clinicaNomeText.Enabled = true;
            clinicaTelefoneText.Enabled = true;
            clinicaEmailText.Enabled = true;
            clinicaEnderecoText.Enabled = true;
            addBtn.Visible = false;
            editBtn.Visible = false;
            remBtn.Visible = false;
            okBtn.Visible = true;
            cancelBtn.Visible = true;
        }

        private void clinicaAddControls()
        {
            clinicaEditControls();
            clinicaNifText.Text = "";
            clinicaNomeText.Text = "";
            clinicaTelefoneText.Text = "";
            clinicaEmailText.Text = "";
            clinicaEnderecoText.Text = "";
        }

        private void medicoBaseControls()
        {
            medicoOMVText.Enabled = false;
            medicoNomeText.Enabled = false;
            medicoTelefoneText.Enabled = false;
            medicoEmailText.Enabled = false;
            medicoEspecialidadeText.Enabled = false;
            medicoClinicaComboBox.Enabled = false;
            addBtn.Visible = true;
            editBtn.Visible = true;
            remBtn.Visible = true;
            okBtn.Visible = false;
            cancelBtn.Visible = false;
            medicoClinicaComboBox.Visible = true;
        }

        private void medicoEditControls()
        {
            medicoOMVText.Enabled = true;
            medicoNomeText.Enabled = true;
            medicoTelefoneText.Enabled = true;
            medicoEmailText.Enabled = true;
            medicoEspecialidadeText.Enabled = true;
            medicoClinicaComboBox.Enabled = true;
            addBtn.Visible = false;
            editBtn.Visible = false;
            remBtn.Visible = false;
            okBtn.Visible = true;
            cancelBtn.Visible = true;
        }

        private void medicoAddControls()
        {
            medicoEditControls();
            medicoOMVText.Text = "";
            medicoNomeText.Text = "";
            medicoTelefoneText.Text = "";
            medicoEmailText.Text = "";
            medicoEspecialidadeText.Text = "";
            medicoClinicaComboBox.Text = "";
        }

        private void donoBaseControls()
        {
            donoNifText.Enabled = false;
            donoNomeText.Enabled = false;
            donoTelefoneText.Enabled = false;
            donoEmailText.Enabled = false;
            donoEnderecoText.Enabled = false;
            addBtn.Visible = true;
            editBtn.Visible = true;
            remBtn.Visible = true;
            okBtn.Visible = false;
            cancelBtn.Visible = false;
        }

        private void donoEditControls()
        {
            donoNifText.Enabled = true;
            donoNomeText.Enabled = true;
            donoTelefoneText.Enabled = true;
            donoEmailText.Enabled = true;
            donoEnderecoText.Enabled = true;
            addBtn.Visible = false;
            editBtn.Visible = false;
            remBtn.Visible = false;
            okBtn.Visible = true;
            cancelBtn.Visible = true;
        }

        private void donoAddControls()
        {
            donoEditControls();
            clinicaNifText.Text = "";
            clinicaNomeText.Text = "";
            clinicaTelefoneText.Text = "";
            clinicaEmailText.Text = "";
            clinicaEnderecoText.Text = "";
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            loginPage.Show();
            this.Close();
        }

        private void populateClinicaComboBox()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("EXEC SP_GetClinicTable", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                medicoClinicaComboBox.Items.Add(new String(reader["Nome"].ToString()));
            }

            cn.Close();

        }

        private void clinicaVeterinariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            entity = "Clinica";
            clinicaBaseControls();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetClinicTable", cn);
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
        private void medicoVeterinarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            entity = "Medico";
            medicoBaseControls();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetVetTable", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                Vet vet = new Vet();
                vet.NumOMV = reader["NumOMV"].ToString();
                vet.Nome = reader["Nome"].ToString();
                vet.Telefone = reader["Telefone"].ToString();
                vet.Email = reader["Email"].ToString();
                vet.Especialidade = reader["Especialidade"].ToString();
                vet.Clinica = reader["Clinica"].ToString();
                listBox1.Items.Add(vet);
            }

            cn.Close();


            currentListIndex = 0;
            ShowVet();
        }

        private void donoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            entity = "Dono";
            donoBaseControls();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetOwnerTable", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                Owner Owner = new Owner();
                Owner.NIF = reader["NIF"].ToString();
                Owner.Nome = reader["Nome"].ToString();
                Owner.Telefone = reader["Telefone"].ToString();
                Owner.Email = reader["Email"].ToString();
                Owner.Endereco = reader["Endereco"].ToString();
                listBox1.Items.Add(Owner);
            }

            cn.Close();


            currentListIndex = 0;
            ShowOwner();
        }

        public void ShowClinicaVeterinaria()
        {
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;
            CliVet cv = new CliVet();
            cv = (CliVet)listBox1.Items[currentListIndex];
            clinicaNifText.Text = cv.NIF;
            clinicaNomeText.Text = cv.Nome;
            clinicaTelefoneText.Text = cv.Telefone;
            clinicaEmailText.Text = cv.Email;
            clinicaEnderecoText.Text = cv.Endereco;
           
        }

        public void ShowVet()
        {
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;
            Vet vet = new Vet();
            vet = (Vet)listBox1.Items[currentListIndex];
            medicoOMVText.Text = vet.NumOMV;
            medicoNomeText.Text = vet.Nome;
            medicoTelefoneText.Text = vet.Telefone;
            medicoEmailText.Text = vet.Email;
            medicoEspecialidadeText.Text = vet.Especialidade; // just for testing, this is not correct
            //clinicaComboBox.SelectedIndex = 0;
        }

        public void ShowOwner()
        {
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;
            Owner owner = new Owner();
            owner = (Owner)listBox1.Items[currentListIndex];
            donoNifText.Text = owner.NIF;
            donoNomeText.Text = owner.Nome;
            donoTelefoneText.Text = owner.Telefone;
            donoEmailText.Text = owner.Email;
            donoEnderecoText.Text = owner.Endereco;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                currentListIndex = listBox1.SelectedIndex;
                switch (entity)
                {
                    case "Clinica":
                        ShowClinicaVeterinaria();
                        break;

                    case "Medico":
                        ShowVet();
                        break;
                    case "Dono":
                        ShowOwner();
                        break;

                    default:
                        break;
                }
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            switch (entity)
            {
                case "Clinica":
                    clinicaEditControls();
                    break;
                case "Medico":
                    medicoEditControls();
                    break;
                case "Dono":
                    donoEditControls();
                    break;
                default : break;
            }
        }

        private void remBtn_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("DELETE FROM PetDB_ClinicaVeterinaria WHERE NIF=" + clinicaNifText.Text, cn);
            try
            {
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Clinica apagada da base de dados");
            }
            catch (Exception exception)
            {
                System.Windows.Forms.MessageBox.Show("Ocorreu um erro: \n" + exception);
            }
            cn.Close();
            clinicaVeterinariaToolStripMenuItem_Click(sender, e);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            switch (entity)
            {
                case "Clinica":
                    clinicaBaseControls();
                    ShowClinicaVeterinaria();
                    break;
                case "Medico":
                    medicoBaseControls();
                    ShowVet();
                    break;
                case "Dono":
                    donoBaseControls();
                    ShowOwner();
                    break;
                default: break;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            switch (entity)
            {
                case "Clinica":
                    clinicaAddControls();
                    break;
                case "Medico":
                    medicoAddControls();
                    break;
                case "Dono":
                    donoAddControls();
                    break;
                default: break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void registarTabControl_onSelectedIndexChange(object sender, EventArgs e)
        {
            int selectedTabIndex = registarTabControl.SelectedIndex;
            switch (selectedTabIndex)
            {
                case 0://clinica
                    clinicaVeterinariaToolStripMenuItem_Click(sender, e);
                    break;
                case 1: //Medico
                    medicoVeterinarioToolStripMenuItem_Click(sender, e);
                    break;
                case 2: //Dono
                    donoToolStripMenuItem_Click(sender, e);
                    break;
                default: break;
            }
        }
    }
}
