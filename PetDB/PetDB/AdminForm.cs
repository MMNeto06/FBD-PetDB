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

        private void generalBaseControls()
        {
            addBtn.Visible = true;
            editBtn.Visible = true;
            remBtn.Visible = true;
            okBtn.Visible = false;
            cancelBtn.Visible = false;
        }

        private void generalEditControls()
        {
            addBtn.Visible = false;
            editBtn.Visible = false;
            remBtn.Visible = false;
            okBtn.Visible = true;
            cancelBtn.Visible = true;
        }

        private void clinicaBaseControls()
        {
            clinicaNifText.Enabled = false;
            clinicaNomeText.Enabled = false;
            clinicaTelefoneText.Enabled = false;
            clinicaEmailText.Enabled = false;
            clinicaEnderecoText.Enabled = false;
            generalBaseControls();
        }

        private void clinicaEditControls()
        {
            clinicaNifText.Enabled = true;
            clinicaNomeText.Enabled = true;
            clinicaTelefoneText.Enabled = true;
            clinicaEmailText.Enabled = true;
            clinicaEnderecoText.Enabled = true;
            generalEditControls();
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
            medicoClinicaText.Enabled = false;
            medicoClinicaText.Visible = true;
            generalBaseControls();
        }

        private void medicoEditControls()
        {
            medicoOMVText.Enabled = true;
            medicoNomeText.Enabled = true;
            medicoTelefoneText.Enabled = true;
            medicoEmailText.Enabled = true;
            medicoEspecialidadeText.Enabled = true;
            medicoClinicaText.Enabled = true;
            generalEditControls();
        }

        private void medicoAddControls()
        {
            medicoEditControls();
            medicoOMVText.Text = "";
            medicoNomeText.Text = "";
            medicoTelefoneText.Text = "";
            medicoEmailText.Text = "";
            medicoEspecialidadeText.Text = "";
            medicoClinicaText.Text = "";
        }

        private void donoBaseControls()
        {
            donoNifText.Enabled = false;
            donoNomeText.Enabled = false;
            donoTelefoneText.Enabled = false;
            donoEmailText.Enabled = false;
            donoEnderecoText.Enabled = false;
            generalBaseControls();
        }

        private void donoEditControls()
        {
            donoNifText.Enabled = true;
            donoNomeText.Enabled = true;
            donoTelefoneText.Enabled = true;
            donoEmailText.Enabled = true;
            donoEnderecoText.Enabled = true;
            generalEditControls();
        }

        private void donoAddControls()
        {
            donoEditControls();
            donoNifText.Text = "";
            donoNomeText.Text = "";
            donoTelefoneText.Text = "";
            donoEmailText.Text = "";
            donoEnderecoText.Text = "";
        }

        private void animalBaseControls()
        {
            animalNumeroText.Enabled = false;
            animalNomeText.Enabled = false;
            animalSexoText.Enabled = false;
            animalPesoText.Enabled = false;
            animalDataNascimentoText.Enabled = false;
            animalEspecieText.Enabled = false;
            animalDonoText.Enabled = false;
            generalBaseControls();
        }

        private void animalEditControls()
        {
            animalNomeText.Enabled = true;
            animalSexoText.Enabled = true;
            animalPesoText.Enabled = true;
            animalDataNascimentoText.Enabled = true;
            animalEspecieText.Enabled = true;
            animalDonoText.Enabled = true;
            generalEditControls();
        }

        // TODO
        /*private void animalAddControls()
        {
            animalNumeroText.Text = "Automático";
            ideias: 
                mudar coisas para dropdowns; 
                calendário para data de nascimento;
        }*/

        private void medicamentoBaseControls()
        {
            medicamentoCodigoText.Enabled = false;
            medicamentoDoseText.Enabled = false;
            medicamentoNomeText.Enabled = false;
            generalBaseControls();
        }

        private void medicamentoEditControls()
        {
            medicamentoNomeText.Enabled = true;
            medicamentoDoseText.Enabled = true;
            medicamentoNomeText.Enabled = true;
            generalEditControls();
        }

        private void medicamentoAddControls()
        {
            medicamentoCodigoText.Text = "";
            medicamentoDoseText.Text = "";
            medicamentoNomeText.Text = "";
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            loginPage.Show();
            this.Close();
        }

        private void clinicaVeterinariaTab_Click(object sender, EventArgs e)
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
        private void medicoVeterinarioTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            entity = "Medico";
            medicoBaseControls();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetVetInfo", cn);
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

        private void donoTab_Click(object sender, EventArgs e)
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

        private void animalTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            entity = "Animal";
            animalBaseControls();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetPetInfo", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                Pet pet = new Pet();
                pet.Numero = reader["Numero"].ToString();
                pet.Nome = reader["Nome"].ToString();
                pet.DataNascimento = reader["DataNascimento"].ToString();
                pet.Sexo = reader["Sexo"].ToString();
                pet.Peso = reader["Peso"].ToString();
                pet.Especie = reader["Especie"].ToString();
                pet.Dono = reader["Dono"].ToString();
                listBox1.Items.Add(pet);
            }

            cn.Close();


            currentListIndex = 0;
            ShowPet();
        }

        private void medTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            entity = "Medicamento";
            medicamentoBaseControls();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetMedInfo", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                Med med = new Med();
                med.Codigo = reader["Codigo"].ToString();
                med.Nome = reader["Nome"].ToString();
                med.Dose = reader["Dose"].ToString();
                listBox1.Items.Add(med);
            }

            cn.Close();


            currentListIndex = 0;
            ShowMed();
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
            medicoEspecialidadeText.Text = vet.Especialidade;
            medicoClinicaText.Text = vet.Clinica;
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

        public void ShowPet()
        {
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;
            Pet pet = new Pet();
            pet = (Pet)listBox1.Items[currentListIndex];
            animalNumeroText.Text = pet.Numero;
            animalNomeText.Text = pet.Nome;
            animalSexoText.Text = pet.Sexo;
            animalPesoText.Text = pet.Peso;
            animalDataNascimentoText.Text = pet.DataNascimento;
            animalEspecieText.Text = pet.Especie;
            animalDonoText.Text = pet.Dono;
        }

        public void ShowMed()
        {
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;
            Med med = new Med();
            med = (Med)listBox1.Items[currentListIndex];
            medicamentoCodigoText.Text = med.Codigo;
            medicamentoNomeText.Text = med.Nome;
            medicamentoDoseText.Text = med.Dose;
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
                    case "Animal":
                        ShowPet();
                        break;
                    case "Medicamento":
                        ShowMed();
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
                case "Animal":
                    animalEditControls();
                    break;
                case "Medicamento":
                    medicamentoEditControls();
                    break;
                default: break;
            }
        }

        private void remBtn_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("DELETE FROM PetDB_ClinicaVeterinaria WHERE NIF=" + clinicaNifText.Text, cn); // MUDAR PARA SP; ADICIONAR SWITCH CASE
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
            clinicaVeterinariaTab_Click(sender, e);
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
                case "Animal":
                    animalBaseControls();
                    ShowPet();
                    break;
                case "Medicamento":
                    medicamentoBaseControls();
                    ShowMed();
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
                case "Animal":
                    //animalAddControls();
                    break;
                case "Medicamento":
                    medicamentoAddControls();
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
                    clinicaVeterinariaTab_Click(sender, e);
                    break;
                case 1: //Medico
                    medicoVeterinarioTab_Click(sender, e);
                    break;
                case 2: //Dono
                    donoTab_Click(sender, e);
                    break;
                case 3: // Animal
                    animalTab_Click(sender, e);
                    break;
                case 4: // Medicamento
                    medTab_Click(sender, e);
                    break;
                default: break;
            }
        }

    }
}
