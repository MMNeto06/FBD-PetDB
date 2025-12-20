using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Xml.Serialization;
namespace PetDB
{
    public partial class AdminForm : Form, IAppointmentForm, IMedForm
    {
        private SqlConnection cn;
        private int currentListIndex;
        protected Login loginPage;
        private String option = "";
        private String entity = "";
        private String tab = "";

        public AdminForm()
        {
            InitializeComponent();
        }

        public AdminForm(Login loginPage) : this()
        {
            this.loginPage = loginPage;
            registarTabControl.Visible = true;
            consultarTabControl.Visible = false;
            clinicaBaseControls();
            registarToolStripMenuItem_Click(null, null);
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

        protected virtual void SelecionarRegistarAbaInicial(object sender, EventArgs e)
        {
            clinicaVeterinariaTab_Click(sender, e);
        }

        protected void registarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tab = "Registar";
            consultarTabControl.Visible = false;
            registarTabControl.Visible = true;
            generalBaseControls();
            registarTabControl.SelectedIndex = 0;
            SelecionarRegistarAbaInicial(sender, e);
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tab = "Consultar";
            option = "";
            consultarTabControl.Visible = true;
            registarTabControl.Visible = false;
            addBtn.Visible = false;
            editBtn.Visible = false;
            remBtn.Visible = false;
            okBtn.Visible = false;
            cancelBtn.Visible = false;
            btnRestaurar.Visible = false;
            consultarVetCliTabPage_Click(sender, e);
        }

        protected void RestaurarControls()
        {
            addBtn.Visible = false;
            editBtn.Visible = false;
            remBtn.Visible = false;
            okBtn.Visible = false;
            cancelBtn.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tab = "Restaurar";
            option = "";
            addBtn.Visible = false;
            editBtn.Visible = false;
            remBtn.Visible = false;
            okBtn.Visible = false;
            cancelBtn.Visible = false;
            btnRestaurar.Visible = true;
            consultarTabControl.Visible = false;
            registarTabControl.Visible = true;
            registarTabControl.SelectedIndex = 0;
            clinicaVeterinariaTab_Click(sender, e);
        }

        protected void generalBaseControls()
        {
            addBtn.Visible = true;
            editBtn.Visible = true;
            remBtn.Visible = true;
            okBtn.Visible = false;
            cancelBtn.Visible = false;
            btnRestaurar.Visible = false;
            searchTextBox.Enabled = true;
        }

        protected void generalEditControls()
        {
            addBtn.Visible = false;
            editBtn.Visible = false;
            remBtn.Visible = false;
            okBtn.Visible = true;
            cancelBtn.Visible = true;
            searchTextBox.Enabled = false;
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
            clinicaNomeText.Enabled = true;
            clinicaTelefoneText.Enabled = true;
            clinicaEmailText.Enabled = true;
            clinicaEnderecoText.Enabled = true;
            generalEditControls();
        }

        private void clinicaAddControls()
        {
            clinicaEditControls();
            clinicaNifText.Enabled = true;
            clinicaNifText.Text = "";
            clinicaNomeText.Text = "";
            clinicaTelefoneText.Text = "";
            clinicaEmailText.Text = "";
            clinicaEnderecoText.Text = "";
        }

        protected void medicoBaseControls()
        {
            medicoOMVText.Enabled = false;
            medicoNomeText.Enabled = false;
            medicoTelefoneText.Enabled = false;
            medicoEmailText.Enabled = false;
            medicoEspecialidadeText.Enabled = false;
            medicoClinicaText.Enabled = false;
            medicoClinicaText.Visible = true;
            medicoEspecialidadeComboBox.Visible = false;
            medicoClinicaComboBox.Visible = false;
            generalBaseControls();
        }

        protected void medicoEditControls()
        {
            medicoNomeText.Enabled = true;
            medicoTelefoneText.Enabled = true;
            medicoEmailText.Enabled = true;
            medicoEspecialidadeText.Enabled = true;
            medicoClinicaText.Enabled = true;
            medicoEspecialidadeComboBox.Visible = true;
            medicoClinicaComboBox.Visible = true;
            generalEditControls();
        }

        protected void medicoAddControls()
        {
            medicoEditControls();
            medicoOMVText.Enabled = true;
            medicoOMVText.Text = "";
            medicoNomeText.Text = "";
            medicoTelefoneText.Text = "";
            medicoEmailText.Text = "";
            medicoEspecialidadeText.Text = "";
            medicoClinicaText.Text = "";
            medicoEspecialidadeComboBox.SelectedIndex = -1;
            medicoClinicaComboBox.SelectedIndex = -1;
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
            animalSexoComboBox.Visible = false;
            animalDateTimePicker.Visible = false;
            animalEspecieComboBox.Visible = false;
            animalDonoComboBox.Visible = false;
            generalBaseControls();
        }

        private void animalEditControls()
        {
            animalNomeText.Enabled = true;
            animalSexoText.Enabled = true;
            animalPesoText.Enabled = true;
            animalSexoComboBox.Visible = true;
            animalDateTimePicker.Visible = true;
            animalEspecieComboBox.Visible = true;
            animalDonoComboBox.Visible = true;
            generalEditControls();
        }

        private void animalAddControls()
        {
            animalEditControls();
            animalNumeroText.Text = "Automático";
            animalNomeText.Text = "";
            animalPesoText.Text = "";
            animalEspecieComboBox.SelectedIndex = -1;
            animalSexoComboBox.SelectedIndex = -1;
            animalDonoComboBox.SelectedIndex = -1;
        }

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
            generalEditControls();
        }

        private void medicamentoAddControls()
        {
            medicamentoEditControls();
            medicamentoCodigoText.Enabled = true;
            medicamentoCodigoText.Text = "";
            medicamentoDoseText.Text = "";
            medicamentoNomeText.Text = "";
        }

        private void consultaBaseControls()
        {
            consultaDataText.Visible = true;
            consultaAnimalText.Visible = true;
            consultaMedicoText.Visible = true;
            btnVerTratamentos.Visible = true;
            btnConsultarRelatorio.Visible = true;
            btnVerTratamentos.Enabled = true;
            btnConsultarRelatorio.Enabled = true;
            consultaIdText.Enabled = false;
            consultaDataText.Enabled = false;
            consultaAnimalText.Enabled = false;
            consultaMedicoText.Enabled = false;
            consultaDateTimePicker.Visible = false;
            consultaAnimaisComboBox.Visible = false;
            consultaMedicoComboBox.Visible = false;
            consultaBtnEditarRelatorio.Visible = false;
            consultaBtnEditarTratamentos.Visible = false;
            generalBaseControls();
        }

        private void consultaEditControls()
        {
            consultaDataText.Visible = false;
            consultaAnimalText.Visible = false;
            consultaMedicoText.Visible = false;
            btnVerTratamentos.Visible = false;
            btnConsultarRelatorio.Visible = false;
            consultaDateTimePicker.Visible = true;
            consultaDateTimePicker.Format = DateTimePickerFormat.Custom;
            consultaDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            consultaDateTimePicker.ShowUpDown = true;
            consultaAnimaisComboBox.Visible = true;
            consultaMedicoComboBox.Visible = true;
            consultaBtnEditarRelatorio.Visible = true;
            consultaBtnEditarTratamentos.Visible = true;
            consultaBtnEditarRelatorio.Enabled = true;
            consultaBtnEditarTratamentos.Enabled = true;
            generalEditControls();
        }

        private void consultaAddControls()
        {
            consultaEditControls();
            consultaIdText.Text = "Automático";
            consultaBtnEditarRelatorio.Enabled = false;
            consultaBtnEditarTratamentos.Enabled = false;
        }

        private void pagamentoBaseControls()
        {
            pagamentoAnimalLabel.Visible = true;
            pagamentoMedicoLabel.Visible = true;
            pagamentoAnimalText.Visible = true;
            pagamentoMedicoText.Visible = true;
            pagamentoIdText.Enabled = false;
            pagamentoValorText.Enabled = false;
            pagamentoDataText.Enabled = false;
            pagamentoEstadoText.Enabled = false;
            pagamentoMetodoText.Enabled = false;
            pagamentoAnimalText.Enabled = false;
            pagamentoMedicoText.Enabled = false;
            pagamentoDateTimePicker.Visible = false;
            pagamentoEstadoComboBox.Visible = false;
            pagamentoMetodoComboBox.Visible = false;
            pagamentoConsultaLabel.Visible = false;
            pagamentoConsultaComboBox.Visible = false;
            generalBaseControls();
        }


        private void pagamentoEditControls()
        {
            pagamentoAnimalLabel.Visible = false;
            pagamentoMedicoLabel.Visible = false;
            pagamentoAnimalText.Visible = false;
            pagamentoMedicoText.Visible = false;
            pagamentoValorText.Enabled = true;
            pagamentoDataText.Enabled = true;
            pagamentoDateTimePicker.Visible = true;
            pagamentoDateTimePicker.Format = DateTimePickerFormat.Custom;
            pagamentoDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            pagamentoDateTimePicker.ShowUpDown = true;
            pagamentoEstadoComboBox.Visible = true;
            pagamentoMetodoComboBox.Visible = true;
            pagamentoConsultaLabel.Visible = true;
            pagamentoConsultaComboBox.Visible = true;
            generalEditControls();
        }


        private void pagamentoAddControls()
        {
            pagamentoEditControls();
            pagamentoIdText.Text = "Auto";
            pagamentoValorText.Text = "";
            pagamentoDataText.Text = "";
            pagamentoEstadoComboBox.SelectedIndex = -1;
            pagamentoMetodoComboBox.SelectedIndex = -1;
            pagamentoConsultaComboBox.SelectedIndex = -1;
        }

        private void prescricaoBaseControls()
        {
            prescricaoAnimalComboBox.Visible = false;
            prescricaoMedicoComboBox.Visible = false;
            prescricaoNumeroText.Enabled = false;
            prescricaoDataText.Enabled = false;
            prescricaoDateTimePicker.Visible = false;
            prescricaoAnimalText.Enabled = false;
            prescricaoMedicoText.Enabled = false;
            prescricaoBtnVerMedicamentos.Visible = true;
            prescricaoBtnVerMedicamentos.Enabled = true;
            prescricaoBtnEditarMedicamentos.Visible = false;
            generalBaseControls();
        }

        private void prescricaoEditControls()
        {
            prescricaoNumeroText.Enabled = true;
            prescricaoDateTimePicker.Visible = true;
            prescricaoAnimalComboBox.Visible = true;
            prescricaoMedicoComboBox.Visible = true;
            prescricaoBtnEditarMedicamentos.Visible = true;
            prescricaoBtnVerMedicamentos.Visible = false;
            generalEditControls();
        }


        private void prescricaoAddControls()
        {
            prescricaoEditControls();
            prescricaoNumeroText.Text = "";
            prescricaoBtnEditarMedicamentos.Enabled = false;
            prescricaoAnimalComboBox.SelectedIndex = -1;
            prescricaoMedicoComboBox.SelectedIndex = -1;
        }

        private void especialidadeBaseControls()
        {
            btnConsultarMedicos.Enabled = true;
            especialidadeCodigoText.Enabled = false;
            especialidadeDescricaoText.Enabled = false;
            generalBaseControls();
            editBtn.Visible = false;
        }


        private void especialidadeAddControls()
        {
            especialidadeCodigoText.Text = "Automático";
            especialidadeDescricaoText.Text = "";
            especialidadeDescricaoText.Enabled = true;
            generalEditControls();
        }

        private void especieBaseControls()
        {
            btnConsultaAnimais.Enabled = true;
            especieCodigoText.Enabled = false;
            especieDescricaoText.Enabled = false;
            generalBaseControls();
            editBtn.Visible = false;
        }

        private void especieAddControls()
        {
            especieCodigoText.Text = "Automático";
            especieDescricaoText.Enabled = true;
            especieDescricaoText.Text = "";
            generalEditControls();
            editBtn.Visible = false;
        }

        private void metodoPagamentoBaseControls()
        {
            metodoPagamentoBtnPagamentos.Enabled = true;
            metodoPagamentoCodigoText.Enabled = false;
            metodoPagamentoDescricaoText.Enabled = false;
            generalBaseControls();
            editBtn.Visible = false;
        }

        private void metodoPagamentoAddControls()
        {
            metodoPagamentoCodigoText.Text = "Automático";
            metodoPagamentoDescricaoText.Enabled = true;
            metodoPagamentoDescricaoText.Text = "";
            generalEditControls();
            editBtn.Visible = false;
        }

        private void tratamentoBaseControls()
        {
            tratamentoBtnConsultas.Enabled = true;
            tratamentoCodigoText.Enabled = false;
            tratamentoDescricaoText.Enabled = false;
            generalBaseControls();
            editBtn.Visible = false;
        }

        private void tratamentoAddControls()
        {
            tratamentoCodigoText.Text = "Automático";
            tratamentoDescricaoText.Enabled = true;
            tratamentoDescricaoText.Text = "";
            generalEditControls();
            editBtn.Visible = false;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            loginPage.Show();
            this.Close();
        }

        private List<Med> getPrescriptionMedsById(int prescriptionId)
        {
            if (!verifySGBDConnection())
                return null;

            List<Med> meds = new List<Med>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetPrescriptionMedsById(@prescriptionID) ORDER BY Descricao", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@prescriptionID", prescriptionId);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Med m = new Med();
                m.Codigo = reader["Codigo"].ToString();
                m.Nome = reader["Descricao"].ToString();
                m.Dose = reader["Dose"].ToString();
                meds.Add(m);
            }

            reader.Close();
            cn.Close();

            return meds;
        }

        private List<String> getVetsBySpeciality(int especialidade)
        {
            if (!verifySGBDConnection())
                return null;

            List<String> vets = new List<String>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetVetsBySpeciality(@specialityID) ORDER BY Nome", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@specialityID", especialidade);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                vets.Add(reader["Nome"].ToString());
            }

            reader.Close();

            cn.Close();

            return vets;
        }

        private List<String> getAnimalsBySpecie(int especie)
        {
            if (!verifySGBDConnection())
                return null;

            List<String> animals = new List<String>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetAnimalsBySpecie(@specieID) ORDER BY Nome", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@specieID", especie);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                animals.Add(reader["Nome"].ToString());
            }

            reader.Close();
            cn.Close();

            return animals;
        }

        private List<CliVet> GetClinicasVeterinarias(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<CliVet> clinicas = new List<CliVet>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetClinicTable(@IsActive, @Search) ORDER BY Nome", cn);
            cmd.CommandType = CommandType.Text;
            if (tab == "Restaurar")
            {
                cmd.Parameters.AddWithValue("@IsActive", 0);
            }
            else cmd.Parameters.AddWithValue("@IsActive", 1);

            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CliVet CV = new CliVet();
                CV.NIF = reader["NIF"].ToString();
                CV.Nome = reader["Nome"].ToString();
                CV.Telefone = reader["Telefone"].ToString();
                CV.Email = reader["Email"].ToString();
                CV.Endereco = reader["Endereco"].ToString();
                clinicas.Add(CV);
            }
            reader.Close();
            cn.Close();

            return clinicas;
        }

        private void clinicaVeterinariaTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }

            entity = "Clinica";
            clinicaBaseControls();
            if (tab == "Restaurar")
                RestaurarControls();

            listBox1.Items.Clear();

            List<CliVet> clinicas = GetClinicasVeterinarias(searchContent);

            foreach (var CV in clinicas)
            {
                listBox1.Items.Add(CV);
            }

            cn.Close();

            if (listBox1.Items.Count <= 0)
            {
                listBox1.Items.Add("Não existem clínicas inativas!");
                clinicaNifText.Text = "";
                clinicaNomeText.Text = "";
                clinicaTelefoneText.Text = "";
                clinicaEmailText.Text = "";
                clinicaEnderecoText.Text = "";
                return;
            }

            currentListIndex = 0;
            ShowClinicaVeterinaria();
        }

        protected virtual List<Vet> GetMedicos(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Vet> vets = new List<Vet>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetVetInfo(@ClinicNIF, @VetOMV, @IsActive, @Search) ORDER BY Nome", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ClinicNIF", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@VetOMV", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value =(tab == "Restaurar") ? 0 : 1;
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Vet vet = new Vet();
                vet.NumOMV = reader["NumOMV"].ToString();
                vet.Nome = reader["Nome"].ToString();
                vet.Telefone = reader["Telefone"].ToString();
                vet.Email = reader["Email"].ToString();
                vet.Especialidade = reader["Especialidade"].ToString();
                vet.Clinica = reader["Clinica"].ToString();
                vets.Add(vet);
            }
            reader.Close();
            cn.Close();

            return vets;
        }

        protected void medicoVeterinarioTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }

            entity = "Medico";
            medicoBaseControls();
            if (tab == "Restaurar")
                RestaurarControls();

            listBox1.Items.Clear();

            List<Vet> vets = GetMedicos(searchContent);

            foreach (var v in vets)
                listBox1.Items.Add(v);

            cn.Close();

            if (listBox1.Items.Count <= 0)
            {
                listBox1.Items.Add("Não existem médicos inativos!");
                medicoOMVText.Text = "";
                medicoNomeText.Text = "";
                medicoTelefoneText.Text = "";
                medicoEmailText.Text = "";
                medicoEspecialidadeText.Text = "";
                medicoClinicaText.Text = "";
                return;
            }

            currentListIndex = 0;
            ShowVet();
        }

        private List<Owner> GetDonos(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Owner> owners = new List<Owner>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetOwnerTable(NULL, @IsActive, @Search) ORDER BY Nome", cn);
            if (tab == "Restaurar")
            {
                cmd.Parameters.AddWithValue("@IsActive", 0);
            }
            else cmd.Parameters.AddWithValue("@IsActive", 1);
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Owner owner = new Owner();
                owner.NIF = reader["NIF"].ToString();
                owner.Nome = reader["Nome"].ToString();
                owner.Telefone = reader["Telefone"].ToString();
                owner.Email = reader["Email"].ToString();
                owner.Endereco = reader["Endereco"].ToString();
                owners.Add(owner);
            }
            reader.Close();
            return owners;
        }

        private void donoTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }
            entity = "Dono";
            donoBaseControls();
            if (tab == "Restaurar")
                RestaurarControls();

            List<Owner> owners = GetDonos(searchContent);
            listBox1.Items.Clear();

            foreach (var owner in owners)
                listBox1.Items.Add(owner);

            cn.Close();


            if (listBox1.Items.Count <= 0)
            {
                listBox1.Items.Add("Não existem donos inativos!");
                donoNifText.Text = "";
                donoNomeText.Text = "";
                donoTelefoneText.Text = "";
                donoEmailText.Text = "";
                donoEnderecoText.Text = "";
                return;
            }

            currentListIndex = 0;
            ShowOwner();
        }

        private List<Pet> GetAnimais(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Pet> pets = new List<Pet>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetPetInfo(NULL, @IsActive, @Search) ORDER BY Nome", cn);
            cmd.CommandType = CommandType.Text;
            if (tab == "Restaurar")
                cmd.Parameters.AddWithValue("@IsActive", 0);
            else cmd.Parameters.AddWithValue("IsActive", 1);
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }
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
                pets.Add(pet);
            }
            reader.Close();
            cn.Close();

            return pets;
        }

        private void animalTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }

            entity = "Animal";
            animalBaseControls();
            if (tab == "Restaurar")
                RestaurarControls();

            listBox1.Items.Clear();

            List<Pet> pets = GetAnimais(searchContent);

            foreach (var p in pets)
                listBox1.Items.Add(p);

            cn.Close();

            if (listBox1.Items.Count <= 0)
            {
                listBox1.Items.Add("Não existem animais inativos!");
                animalNumeroText.Text = "";
                animalNomeText.Text = "";
                animalSexoText.Text = "";
                animalPesoText.Text = "";
                animalDataNascimentoText.Text = "";
                animalEspecieText.Text = "";
                animalDonoText.Text = "";
                return;
            }

            currentListIndex = 0;
            ShowPet();
        }

        public List<Med> GetMeds(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Med> meds = new List<Med>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetMedInfo(@IsActive, @Search) ORDER BY Nome", cn);
            if (tab == "Restaurar")
                cmd.Parameters.AddWithValue("@IsActive", 0);
            else cmd.Parameters.AddWithValue("@IsActive", 1);
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Med med = new Med();
                med.Codigo = reader["Codigo"].ToString();
                med.Nome = reader["Nome"].ToString();
                med.Dose = reader["Dose"].ToString();
                meds.Add(med);
            }
            reader.Close();
            return meds;
        }

        private void medTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }
            entity = "Medicamento";
            medicamentoBaseControls();
            if (tab == "Restaurar")
                RestaurarControls();

            listBox1.Items.Clear();

            List<Med> meds = GetMeds(searchContent);

            foreach (var m in meds)
                listBox1.Items.Add(m);

            cn.Close();

            if (listBox1.Items.Count <= 0)
            {
                listBox1.Items.Add("Não existem medicamentos inativos!");
                medicamentoCodigoText.Text = "";
                medicamentoNomeText.Text = "";
                medicamentoDoseText.Text = "";
                return;
            }

            currentListIndex = 0;
            ShowMed();
        }

        private List<Appointment> GetConsultas(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Appointment> consultas = new List<Appointment>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetAppointmentInfo(NULL, NULL, @IsActive, @Search) ORDER BY [Data] DESC", cn);
            cmd.CommandType = CommandType.Text;
            if (tab == "Restaurar")
                cmd.Parameters.AddWithValue("@IsActive", 0);
            else cmd.Parameters.AddWithValue("@IsActive", 1);
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Appointment ap = new Appointment();
                ap.Id = reader["Id"].ToString();
                ap.Data = reader["Data"].ToString();
                ap.Animal = reader["Animal"].ToString();
                ap.Medico = reader["Medico"].ToString();
                consultas.Add(ap);
            }
            reader.Close();
            cn.Close();

            return consultas;
        }

        private void consultaTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }

            entity = "Consulta";
            consultaBaseControls();
            if (tab == "Restaurar")
                RestaurarControls();
            listBox1.Items.Clear();

            List<Appointment> consultas = GetConsultas(searchContent);

            foreach (var c in consultas)
                listBox1.Items.Add(c);

            cn.Close();

            if (listBox1.Items.Count <= 0)
            {
                listBox1.Items.Add("Não existem consultas inativas!");
                consultaIdText.Text = "";
                consultaDataText.Text = "";
                consultaAnimalText.Text = "";
                consultaMedicoText.Text = "";
                btnVerTratamentos.Enabled = false;
                btnConsultarRelatorio.Enabled = false;
                return;
            }

            currentListIndex = 0;
            ShowConsulta();
        }

        private void pagamentoTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }
            entity = "Pagamento";
            pagamentoBaseControls();

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetPaymentInfo(NULL, @IsActive, @Search) ORDER BY [Data] DESC", cn);
            cmd.CommandType = CommandType.Text;
            if (tab == "Restaurar")
            {
                RestaurarControls();
                cmd.Parameters.AddWithValue("@IsActive", 0);
            }
            else cmd.Parameters.AddWithValue("@IsActive", 1);
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }

            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                Payment payment = new Payment();
                payment.Id = reader["Id"].ToString();
                payment.Valor = reader["Custo"].ToString();
                payment.Data = reader["Data"].ToString();
                payment.Estado = reader["Estado"].ToString();
                payment.Metodo = reader["Metodo"].ToString();
                payment.Animal = reader["Animal"].ToString();
                payment.Medico = reader["Medico"].ToString();
                listBox1.Items.Add(payment);
            }
            reader.Close();
            cn.Close();

            if (listBox1.Items.Count <= 0)
            {
                listBox1.Items.Add("Não existem pagamentos inativos!");
                pagamentoIdText.Text = "";
                pagamentoValorText.Text = "";
                pagamentoDataText.Text = "";
                pagamentoEstadoText.Text = "";
                pagamentoMetodoText.Text = "";
                pagamentoAnimalText.Text = "";
                pagamentoMedicoText.Text = "";
                return;
            }


            currentListIndex = 0;
            ShowPayment();
        }

        private void prescricaoTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }
            entity = "Prescricao";
            prescricaoBaseControls();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetPrescriptionInfo(NULL, NULL, @IsActive, @Search) ORDER BY [Data] DESC", cn);
            cmd.CommandType = CommandType.Text;
            if (tab == "Restaurar")
            {
                RestaurarControls();
                cmd.Parameters.AddWithValue("@IsActive", 0);
            }
            else cmd.Parameters.AddWithValue("@IsActive", 1);
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                Prescription prescription = new Prescription();
                prescription.Numero = reader["Numero"].ToString();
                prescription.Data = ((DateTime)reader["Data"]).ToString("dd/MM/yyyy");
                prescription.Animal = reader["Animal"].ToString();
                prescription.Medico = reader["Medico"].ToString();
                listBox1.Items.Add(prescription);
            }
            reader.Close();
            cn.Close();

            if (listBox1.Items.Count <= 0)
            {
                listBox1.Items.Add("Não existem prescrições inativas!");
                prescricaoBtnVerMedicamentos.Enabled = false;
                prescricaoNumeroText.Text = "";
                prescricaoDataText.Text = "";
                prescricaoAnimalText.Text = "";
                prescricaoMedicoText.Text = "";
                return;
            }

            currentListIndex = 0;
            ShowPrescription();
        }

        private List<Especialidade> GetEspecialidades(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Especialidade> especialidades = new List<Especialidade>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetSpecialityInfo(@IsActive, @Search) ORDER BY Descricao", cn);
            cmd.CommandType = CommandType.Text;
            if (tab == "Restaurar")
                cmd.Parameters.AddWithValue("@IsActive", 0);
            else cmd.Parameters.AddWithValue("@IsActive", 1);
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Especialidade especialidade = new Especialidade();
                especialidade.Codigo = reader["Codigo"].ToString();
                especialidade.Descricao = reader["Descricao"].ToString();
                especialidades.Add(especialidade);
            }
            reader.Close();
            cn.Close();

            return especialidades;
        }

        private void especialidadeTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }
            entity = "Especialidade";
            especialidadeBaseControls();
            if (tab == "Restaurar")
                RestaurarControls();
            List<Especialidade> especialidades = GetEspecialidades(searchContent);

            listBox1.Items.Clear();

            foreach (var especialidade in especialidades)
                listBox1.Items.Add(especialidade);

            cn.Close();

            if (listBox1.Items.Count <= 0)
            {
                listBox1.Items.Add("Não existem especialidades inativas!");
                btnConsultarMedicos.Enabled = false;
                especialidadeCodigoText.Text = "";
                especialidadeDescricaoText.Text = "";
                return;
            }

            currentListIndex = 0;
            ShowEspecialidade();
        }

        private List<Especie> GetEspecies(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Especie> especies = new List<Especie>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetSpecieInfo(@IsActive, @Search) ORDER BY Descricao", cn);
            cmd.CommandType = CommandType.Text;
            if (tab == "Restaurar")
                cmd.Parameters.AddWithValue("@IsActive", 0);
            else cmd.Parameters.AddWithValue("@IsActive", 1);
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Especie especie = new Especie();
                especie.Codigo = reader["Codigo"].ToString();
                especie.Descricao = reader["Descricao"].ToString();
                especies.Add(especie);
            }
            reader.Close();
            return especies;
        }

        private void especieTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }
            entity = "Especie";
            especieBaseControls();
            if (tab == "Restaurar")
                RestaurarControls();
            List<Especie> especies = GetEspecies(searchContent);

            listBox1.Items.Clear();

            foreach (var especie in especies)
                listBox1.Items.Add(especie);

            cn.Close();

            if (listBox1.Items.Count <= 0)
            {
                listBox1.Items.Add("Não existem espécies inativas!");
                btnConsultaAnimais.Enabled = false;
                especieCodigoText.Text = "";
                especieDescricaoText.Text = "";
                return;
            }

            currentListIndex = 0;
            ShowEspecie();
        }

        private List<PaymentMethod> GetMetodosPagamento(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<PaymentMethod> methods = new List<PaymentMethod>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetPaymentMethods(@IsActive, @Search)", cn);
            if (tab == "Restaurar")
            {
                cmd.Parameters.AddWithValue("@IsActive", 0);
            }
            else cmd.Parameters.AddWithValue("@IsActive", 1);
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PaymentMethod pm = new PaymentMethod();
                pm.Codigo = reader["Codigo"].ToString();
                pm.Descricao = reader["Descricao"].ToString();
                methods.Add(pm);
            }
            reader.Close();
            cn.Close();

            return methods;

        }

        private void metodoPagamentoTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }
            entity = "MetodoPagamento";
            metodoPagamentoBaseControls();
            if (tab == "Restaurar")
                RestaurarControls();
            List<PaymentMethod> methods = GetMetodosPagamento(searchContent);

            listBox1.Items.Clear();

            foreach (var method in methods)
                listBox1.Items.Add(method);

            cn.Close();

            if (listBox1.Items.Count <= 0)
            {
                listBox1.Items.Add("Não existem métodos de pagamento inativos!");
                metodoPagamentoBtnPagamentos.Enabled = false;
                metodoPagamentoCodigoText.Text = "";
                metodoPagamentoDescricaoText.Text = "";
                return;
            }

            currentListIndex = 0;
            ShowMetodoPagamento();
        }

        public List<Treatment> GetTreatments(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Treatment> treatments = new List<Treatment>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetTreatments(@IsActive, @Search)", cn);
            if (tab == "Restaurar")
                cmd.Parameters.AddWithValue("@IsActive", 0);
            else cmd.Parameters.AddWithValue("@IsActive", 1);
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Treatment t = new Treatment();
                t.Codigo = reader["Codigo"].ToString();
                t.Descricao = reader["Descricao"].ToString();
                treatments.Add(t);
            }
            reader.Close();
            cn.Close();

            return treatments;
        }

        private void tratamentoTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }
            entity = "Tratamento";
            tratamentoBaseControls();
            if (tab == "Restaurar")
                RestaurarControls();

            List<Treatment> treatments = GetTreatments(searchContent);

            listBox1.Items.Clear();

            foreach (var t in treatments)
                listBox1.Items.Add(t);

            cn.Close();

            if (listBox1.Items.Count <= 0)
            {
                listBox1.Items.Add("Não existem tratamentos inativos!");
                tratamentoBtnConsultas.Enabled = false;
                tratamentoCodigoText.Text = "";
                tratamentoDescricaoText.Text = "";
                return;
            }

            currentListIndex = 0;
            ShowTratamento();
        }


        private void ShowClinicaVeterinaria()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;
            CliVet cv = new CliVet();
            cv = (CliVet)listBox1.Items[currentListIndex];
            clinicaNifText.Text = cv.NIF;
            clinicaNomeText.Text = cv.Nome;
            clinicaTelefoneText.Text = cv.Telefone;
            clinicaEmailText.Text = cv.Email;
            clinicaEnderecoText.Text = cv.Endereco;

        }

        private void ShowVet()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
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

        private void ShowOwner()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;
            Owner owner = new Owner();
            owner = (Owner)listBox1.Items[currentListIndex];
            donoNifText.Text = owner.NIF;
            donoNomeText.Text = owner.Nome;
            donoTelefoneText.Text = owner.Telefone;
            donoEmailText.Text = owner.Email;
            donoEnderecoText.Text = owner.Endereco;
        }

        private void ShowPet()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
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

        private void ShowMed()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;
            Med med = new Med();
            med = (Med)listBox1.Items[currentListIndex];
            medicamentoCodigoText.Text = med.Codigo;
            medicamentoNomeText.Text = med.Nome;
            medicamentoDoseText.Text = med.Dose;
        }

        private void ShowConsulta()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;
            Appointment ap = new Appointment();
            ap = (Appointment)listBox1.Items[currentListIndex];
            consultaIdText.Text = ap.Id;
            consultaDataText.Text = ap.Data;
            consultaAnimalText.Text = ap.Animal;
            consultaMedicoText.Text = ap.Medico;
        }

        private void ShowPayment()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;
            Payment payment = new Payment();
            payment = (Payment)listBox1.Items[currentListIndex];
            pagamentoIdText.Text = payment.Id;
            pagamentoValorText.Text = payment.Valor;
            pagamentoDataText.Text = payment.Data;
            pagamentoEstadoText.Text = payment.Estado;
            pagamentoMetodoText.Text = payment.Metodo;
            pagamentoAnimalText.Text = payment.Animal;
            pagamentoMedicoText.Text = payment.Medico;
        }

        private void ShowPrescription()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;

            Prescription prescription = new Prescription();
            prescription = (Prescription)listBox1.Items[currentListIndex];
            prescricaoNumeroText.Text = prescription.Numero;
            prescricaoDataText.Text = prescription.Data;
            prescricaoAnimalText.Text = prescription.Animal;
            prescricaoMedicoText.Text = prescription.Medico;
        }

        private void ShowEspecialidade()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;

            Especialidade especialidade = new Especialidade();
            especialidade = (Especialidade)listBox1.Items[currentListIndex];
            especialidadeCodigoText.Text = especialidade.Codigo;
            especialidadeDescricaoText.Text = especialidade.Descricao;
        }

        private void ShowEspecie()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;

            Especie especie = new Especie();
            especie = (Especie)listBox1.Items[currentListIndex];
            especieCodigoText.Text = especie.Codigo;
            especieDescricaoText.Text = especie.Descricao;
        }

        private void ShowMetodoPagamento()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;

            PaymentMethod pm = new PaymentMethod();
            pm = (PaymentMethod)listBox1.Items[currentListIndex];
            metodoPagamentoCodigoText.Text = pm.Codigo;
            metodoPagamentoDescricaoText.Text = pm.Descricao;
        }

        private void ShowTratamento()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;

            Treatment t = new Treatment();
            t = (Treatment)listBox1.Items[currentListIndex];
            tratamentoCodigoText.Text = t.Codigo;
            tratamentoDescricaoText.Text = t.Descricao;
        }

        private void ShowClinicVet()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;
            Vet vet = new Vet();
            vet = (Vet)listBox1.Items[currentListIndex];
            consultarMedicosClinicaOMVText.Text = vet.NumOMV;
            consultarMedicosClinicaTelefoneText.Text = vet.Telefone;
            consultarMedicosClinicaEmailText.Text = vet.Email;
            consultarMedicosClinicaEspecialidadeText.Text = vet.Especialidade;
        }

        private void ShowOwnerPets()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;
            Pet pet = new Pet();
            pet = (Pet)listBox1.Items[currentListIndex];
            consultarAnimaisDonoNumero.Text = pet.Numero;
            consultarAnimaisDonoSexoText.Text = pet.Sexo;
            consultarAnimaisDonoPesoText.Text = pet.Peso;
            consultarAnimaisDonoDataNascimentoText.Text = pet.DataNascimento;
            consultarAnimaisDonoEspecieText.Text = pet.Especie;
        }

        private void ShowClinicPets()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;
            Pet pet = new Pet();
            pet = (Pet)listBox1.Items[currentListIndex];
            consultarAnimaisClinicaNumeroText.Text = pet.Numero;
            consultarAnimaisClinicaSexoText.Text = pet.Sexo;
            consultarAnimaisClinicaPesoText.Text = pet.Peso;
            consultarAnimaisClinicaDataNascimentoText.Text = pet.DataNascimento;
            consultarAnimaisClinicaEspecieText.Text = pet.Especie;
            consultarAnimaisClinicaDonoText.Text = pet.Dono;
        }

        private void ShowPetAppointments()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;
            Appointment ap = new Appointment();
            ap = (Appointment)listBox1.Items[currentListIndex];
            consultarConsultasAnimalIdText.Text = ap.Id;
            consultarConsultasAnimalMedicoText.Text = ap.Medico;
        }

        private void ShowVetAppointments()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;
            Appointment ap = new Appointment();
            ap = (Appointment)listBox1.Items[currentListIndex];
            consultarConsultasMedicoIdText.Text = ap.Id;
            consultarConsultasMedicoAnimalText.Text = ap.Animal;
        }

        private void ShowPetPrescriptions()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;

            Prescription prescription = new Prescription();
            prescription = (Prescription)listBox1.Items[currentListIndex];
            consultarPrescricaoAnimalNumeroText.Text = prescription.Numero;
            consultarPrescricaoAnimalMedicoText.Text = prescription.Medico;
        }

        private void ShowOwnerPayments()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;
            Payment payment = new Payment();
            payment = (Payment)listBox1.Items[currentListIndex];
            consultarPagamentosDonoNumeroText.Text = payment.Id;
            consultarPagamentosDonoValorText.Text = payment.Valor;
            consultarPagamentosDonoEstadoText.Text = payment.Estado;
            consultarPagamentosDonoMetodoText.Text = payment.Metodo;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                currentListIndex = listBox1.SelectedIndex;
                switch ((entity, tab))
                {
                    case ("Clinica", "Registar"):
                        ShowClinicaVeterinaria();
                        break;
                    case ("Medico", "Registar"):
                        ShowVet();
                        break;
                    case ("Dono", "Registar"):
                        ShowOwner();
                        break;
                    case ("Animal", "Registar"):
                        ShowPet();
                        break;
                    case ("Medicamento", "Registar"):
                        ShowMed();
                        break;
                    case ("Consulta", "Registar"):
                        ShowConsulta();
                        break;
                    case ("Pagamento", "Registar"):
                        ShowPayment();
                        break;
                    case ("Prescricao", "Registar"):
                        ShowPrescription();
                        break;
                    case ("Especialidade", "Registar"):
                        ShowEspecialidade();
                        break;
                    case ("Especie", "Registar"):
                        ShowEspecie();
                        break;
                    case ("MetodoPagamento", "Registar"):
                        ShowMetodoPagamento();
                        break;
                    case ("Tratamento", "Registar"):
                        ShowTratamento();
                        break;
                    case ("Medico", "Consultar"):
                        ShowClinicVet();
                        break;
                    case ("AnimalDono", "Consultar"):
                        ShowOwnerPets();
                        break;
                    case ("AnimalClinica", "Consultar"):
                        ShowClinicPets();
                        break;
                    case ("ConsultaAnimal", "Consultar"):
                        ShowPetAppointments();
                        break;
                    case ("ConsultaMedico", "Consultar"):
                        ShowVetAppointments();
                        break;
                    case ("PrescricaoAnimal", "Consultar"):
                        ShowPetPrescriptions();
                        break;
                    case ("PagamentoDono", "Consultar"):
                        ShowOwnerPayments();
                        break;
                    default:
                        break;
                }
            }
        }

        private void LoadEspecialidadesComboBox()
        {
            if (!verifySGBDConnection())
                return;

            medicoEspecialidadeComboBox.Items.Clear();

            List<Especialidade> especialidades = GetEspecialidades(null);

            foreach (var e in especialidades)
            {
                medicoEspecialidadeComboBox.Items.Add(e);
            }

            if (option == "Edit")
            {
                for (int i = 0; i < medicoEspecialidadeComboBox.Items.Count; i++)
                {
                    Especialidade e = (Especialidade)medicoEspecialidadeComboBox.Items[i];
                    if (e.Descricao == medicoEspecialidadeText.Text)
                    {
                        medicoEspecialidadeComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            cn.Close();
        }

        private void LoadClinicasComboBox(ComboBox cb, TextBox clinicName)
        {
            if (!verifySGBDConnection())
                return;

            cb.Items.Clear();

            List<CliVet> clinicas = GetClinicasVeterinarias(null);

            foreach (var CV in clinicas)
            {
                cb.Items.Add(CV);
            }

            if (option == "Edit")
            {
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    CliVet c = (CliVet)cb.Items[i];
                    if (c.Nome == clinicName.Text)
                    {
                        cb.SelectedIndex = i;
                        break;
                    }
                }
            }

            cn.Close();
        }

        private void LoadSexoComboBox()
        {
            if (!verifySGBDConnection())
                return;

            animalSexoComboBox.Items.Clear();
            animalSexoComboBox.Items.Add('M');
            animalSexoComboBox.Items.Add('F');

            if (option == "Edit")
            {
                for (int i = 0; i < animalSexoComboBox.Items.Count; i++)
                {
                    if (animalSexoComboBox.Items[i].ToString() == animalSexoText.Text)
                    {
                        animalSexoComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            cn.Close();
        }

        private void LoadEspeciesComboBox()
        {
            if (!verifySGBDConnection())
                return;

            animalEspecieComboBox.Items.Clear();

            List<Especie> especies = GetEspecies(null);

            foreach (var e in especies)
            {
                animalEspecieComboBox.Items.Add(e);
            }

            if (option == "Edit")
            {
                for (int i = 0; i < animalEspecieComboBox.Items.Count; i++)
                {
                    Especie e = (Especie)animalEspecieComboBox.Items[i];
                    if (e.Descricao == animalEspecieText.Text)
                    {
                        animalEspecieComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            cn.Close();
        }

        private void LoadDonosComboBox(ComboBox cb, TextBox ownerName)
        {
            if (!verifySGBDConnection())
                return;

            cb.Items.Clear();

            List<Owner> owners = GetDonos(null);

            foreach (var o in owners)
            {
                cb.Items.Add(o);
            }

            if (option == "Edit")
            {
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    Owner o = (Owner)cb.Items[i];
                    if (o.Nome == ownerName.Text)
                    {
                        cb.SelectedIndex = i;
                        break;
                    }
                }
            }

            cn.Close();
        }

        private void LoadAnimaisComboBox(ComboBox cb, TextBox animalName)
        {
            if (!verifySGBDConnection())
                return;

            cb.Items.Clear();

            List<Pet> pets = GetAnimais(null);

            foreach (var p in pets)
            {
                cb.Items.Add(p);
            }

            if (option == "Edit")
            {
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    Pet p = (Pet)cb.Items[i];
                    if (p.Nome == animalName.Text)
                    {
                        cb.SelectedIndex = i;
                        break;
                    }
                }
            }

            cn.Close();
        }

        private void LoadMedicosComboBox(ComboBox cb, TextBox medicoName)
        {
            if (!verifySGBDConnection())
                return;

            cb.Items.Clear();

            List<Vet> vets = GetMedicos(null);

            foreach (var v in vets)
            {
                cb.Items.Add(v);
            }

            if (option == "Edit")
            {
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    Vet v = (Vet)cb.Items[i];
                    if (v.Nome == medicoName.Text)
                    {
                        cb.SelectedIndex = i;
                        break;
                    }
                }
            }

            cn.Close();
        }

        private int GetPaymentAppointmentId(int paymentId)
        {
            int appointmentId = -1;

            if (!verifySGBDConnection())
                return appointmentId;

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetPaymentAppointment(@PaymentId)", cn);
            cmd.Parameters.AddWithValue("@PaymentId", paymentId);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                appointmentId = int.Parse(reader["Consulta"].ToString());
            }

            reader.Close();
            cn.Close();

            return appointmentId;
        }

        private void LoadConsultasComboBox()
        {
            if (!verifySGBDConnection())
                return;

            pagamentoConsultaComboBox.Items.Clear();

            List<Appointment> consultas = GetConsultas(null);

            foreach (var c in consultas)
            {
                pagamentoConsultaComboBox.Items.Add(c);
            }

            if (option == "Edit")
            {
                int appointmentId = GetPaymentAppointmentId(int.Parse(pagamentoIdText.Text));
                for (int i = 0; i < pagamentoConsultaComboBox.Items.Count; i++)
                {
                    Appointment ap = (Appointment)pagamentoConsultaComboBox.Items[i];
                    if (int.Parse(ap.Id) == appointmentId)
                    {
                        pagamentoConsultaComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            cn.Close();
        }

        private void LoadEstadoComboBox()
        {
            if (!verifySGBDConnection())
                return;
            pagamentoEstadoComboBox.Items.Clear();
            pagamentoEstadoComboBox.Items.Add("Pendente");
            pagamentoEstadoComboBox.Items.Add("Pago");

            if (option == "Edit")
            {
                for (int i = 0; i < pagamentoEstadoComboBox.Items.Count; i++)
                {
                    if (pagamentoEstadoComboBox.Items[i].ToString() == pagamentoEstadoText.Text)
                    {
                        pagamentoEstadoComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            cn.Close();
        }

        private void LoadMetodoComboBox()
        {
            if (!verifySGBDConnection())
                return;

            pagamentoMetodoComboBox.Items.Clear();

            List<PaymentMethod> methods = GetMetodosPagamento(null);

            foreach (var m in methods)
            {
                pagamentoMetodoComboBox.Items.Add(m);
            }

            if (option == "Edit")
            {
                for (int i = 0; i < pagamentoMetodoComboBox.Items.Count; i++)
                {
                    PaymentMethod pm = (PaymentMethod)pagamentoMetodoComboBox.Items[i];
                    if (pm.Descricao == pagamentoMetodoText.Text)
                    {
                        pagamentoMetodoComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            cn.Close();
        }

        private DateTime GetDateTimeById(String sp, String arg, int searchId)
        {
            DateTime date = DateTime.UtcNow;

            if (!verifySGBDConnection())
                return date;

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue(arg, searchId);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if ((DateTime)reader["Data"] != null)
                    date = (DateTime)reader["Data"];
            }

            reader.Close();
            cn.Close();

            return date;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            option = "Edit";
            switch (entity)
            {
                case "Clinica":
                    clinicaEditControls();
                    break;
                case "Medico":
                    medicoEditControls();
                    LoadEspecialidadesComboBox();
                    LoadClinicasComboBox(medicoClinicaComboBox, medicoClinicaText);
                    break;
                case "Dono":
                    donoEditControls();
                    break;
                case "Animal":
                    animalEditControls();
                    LoadSexoComboBox();
                    LoadEspeciesComboBox();
                    LoadDonosComboBox(animalDonoComboBox, animalDonoText);
                    break;
                case "Medicamento":
                    medicamentoEditControls();
                    break;
                case "Consulta":
                    consultaEditControls();
                    consultaDateTimePicker.Value = GetDateTimeById("SELECT * FROM dbo.fn_GetAppointmentDateById(@appointmentID)", "@appointmentID", int.Parse(consultaIdText.Text));
                    LoadAnimaisComboBox(consultaAnimaisComboBox, consultaAnimalText);
                    LoadMedicosComboBox(consultaMedicoComboBox, consultaMedicoText);
                    break;
                case "Pagamento":
                    pagamentoEditControls();
                    pagamentoDateTimePicker.Value = GetDateTimeById("SELECT * FROM dbo.fn_GetPaymentDate(@PaymentId)", "@PaymentId", int.Parse(pagamentoIdText.Text));
                    LoadEstadoComboBox();
                    LoadMetodoComboBox();
                    LoadConsultasComboBox();
                    break;
                case "Prescricao":
                    prescricaoEditControls();
                    prescricaoDateTimePicker.Value = GetDateTimeById("SELECT * FROM dbo.fn_GetPrescriptionDate(@PrescriptionID)", "@PrescriptionId", int.Parse(prescricaoNumeroText.Text));
                    LoadAnimaisComboBox(prescricaoAnimalComboBox, prescricaoAnimalText);
                    LoadMedicosComboBox(prescricaoMedicoComboBox, prescricaoMedicoText);
                    break;
                default: break;
            }
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

        private void OnInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageBox.Show(e.Message, "Info do SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteTuples(String sp, int pk, String param)
        {
            if (!verifySGBDConnection())
                return;

            cn.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(param, pk);
            cmd.Parameters.AddWithValue("@DeletedBy", "admin");
            ExecuteInsertSP(cmd);

            cn.InfoMessage -= new SqlInfoMessageEventHandler(OnInfoMessage);

            cn.Close();
        }

        private void remBtn_Click(object sender, EventArgs e)
        {
            switch (entity)
            {
                case "Clinica":
                    DeleteTuples("PR_SoftDeleteClinica", int.Parse(clinicaNifText.Text), "@ClinicNIF");
                    clinicaVeterinariaTab_Click(sender, e);
                    break;
                case "Medico":
                    DeleteTuples("PR_SoftDeleteMedicoVeterinario", int.Parse(medicoOMVText.Text), "@NumOMV");
                    medicoVeterinarioTab_Click(sender, e);
                    break;
                case "Dono":
                    DeleteTuples("PR_SoftDeleteDono", int.Parse(donoNifText.Text), "@NIF");
                    donoTab_Click(sender, e);
                    break;
                case "Animal":
                    DeleteTuples("PR_SoftDeleteAnimal", int.Parse(animalNumeroText.Text), "@Numero");
                    animalTab_Click(sender, e);
                    break;
                case "Medicamento":
                    DeleteTuples("PR_SoftDeleteMedicamento", int.Parse(medicamentoCodigoText.Text), "@Codigo");
                    medTab_Click(sender, e);
                    break;
                case "Consulta":
                    DeleteTuples("PR_SoftDeleteConsulta", int.Parse(consultaIdText.Text), "@ConsultaId");
                    consultaTab_Click(sender, e);
                    break;
                case "Pagamento":
                    DeleteTuples("PR_SoftDeletePagamento", int.Parse(pagamentoIdText.Text), "@PagamentoId");
                    consultaTab_Click(sender, e);
                    break;
                case "Prescricao":
                    DeleteTuples("PR_SoftDeletePrescricao", int.Parse(prescricaoNumeroText.Text), "@PrescricaoNumero");
                    prescricaoTab_Click(sender, e);
                    break;
                case "Especialidade":
                    DeleteTuples("PR_SoftDeleteEspecialidade", int.Parse(especialidadeCodigoText.Text), "@EspecialidadeCodigo");
                    especialidadeTab_Click(sender, e);
                    break;
                case "Especie":
                    DeleteTuples("PR_SoftDeleteEspecie", int.Parse(especieCodigoText.Text), "@EspecieCodigo");
                    especieTab_Click(sender, e);
                    break;
                case "MetodoPagamento":
                    DeleteTuples("PR_SoftDeleteMetodoPagamento", int.Parse(metodoPagamentoCodigoText.Text), "@MetodoCodigo");
                    metodoPagamentoTab_Click(sender, e);
                    break;
                case "Tratamento":
                    DeleteTuples("PR_SoftDeleteTratamento", int.Parse(tratamentoCodigoText.Text), "@TratamentoCodigo");
                    tratamentoTab_Click(sender, e);
                    break;
            }
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
                case "Consulta":
                    consultaBaseControls();
                    ShowConsulta();
                    break;
                case "Pagamento":
                    pagamentoBaseControls();
                    ShowPayment();
                    break;
                case "Prescricao":
                    prescricaoBaseControls();
                    ShowPrescription();
                    break;
                case "Especialidade":
                    especialidadeBaseControls();
                    ShowEspecialidade();
                    break;
                case "Especie":
                    especieBaseControls();
                    ShowEspecie();
                    break;
                case "MetodoPagamento":
                    metodoPagamentoBaseControls();
                    ShowMetodoPagamento();
                    break;
                case "Tratamento":
                    tratamentoBaseControls();
                    ShowTratamento();
                    break;

                default: break;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            option = "Add";
            switch (entity)
            {
                case "Clinica":
                    clinicaAddControls();
                    break;
                case "Medico":
                    medicoAddControls();
                    LoadEspecialidadesComboBox();
                    LoadClinicasComboBox(medicoClinicaComboBox, medicoClinicaText);
                    break;
                case "Dono":
                    donoAddControls();
                    break;
                case "Animal":
                    animalAddControls();
                    LoadSexoComboBox();
                    LoadEspeciesComboBox();
                    LoadDonosComboBox(animalDonoComboBox, animalDonoText);
                    break;
                case "Medicamento":
                    medicamentoAddControls();
                    break;
                case "Consulta":
                    consultaAddControls();
                    consultaDateTimePicker.Value = DateTime.UtcNow;
                    LoadAnimaisComboBox(consultaAnimaisComboBox, consultaAnimalText);
                    LoadMedicosComboBox(consultaMedicoComboBox, consultaMedicoText);
                    break;
                case "Pagamento":
                    pagamentoAddControls();
                    pagamentoDateTimePicker.Value = DateTime.UtcNow;
                    LoadEstadoComboBox();
                    LoadMetodoComboBox();
                    LoadConsultasComboBox();
                    break;
                case "Prescricao":
                    prescricaoAddControls();
                    prescricaoDateTimePicker.Value = DateTime.UtcNow.Date;
                    LoadAnimaisComboBox(prescricaoAnimalComboBox, consultaAnimalText);
                    LoadMedicosComboBox(prescricaoMedicoComboBox, consultaMedicoText);
                    break;
                case "Especialidade":
                    especialidadeAddControls();
                    break;
                case "Especie":
                    especieAddControls();
                    break;
                case "MetodoPagamento":
                    metodoPagamentoAddControls();
                    break;
                case "Tratamento":
                    tratamentoAddControls();
                    break;
                default: break;
            }
        }



        private void ClinicaTuples(String sp, String msgShow)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClinicNIF", int.Parse(clinicaNifText.Text));
            cmd.Parameters.AddWithValue("@ClinicName", clinicaNomeText.Text);
            cmd.Parameters.AddWithValue("@ClinicPhone", clinicaTelefoneText.Text);
            cmd.Parameters.AddWithValue("@ClinicEmail", clinicaEmailText.Text);
            cmd.Parameters.AddWithValue("@ClinicAddress", clinicaEnderecoText.Text);

            if (ExecuteInsertSP(cmd))
            {
                MessageBox.Show(msgShow);
            }

            cn.Close();
        }
        private void MedicoTuples(String sp, String msgShow)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VetOMV", int.Parse(medicoOMVText.Text));
            cmd.Parameters.AddWithValue("@VetName", medicoNomeText.Text);
            cmd.Parameters.AddWithValue("@VetPhone", medicoTelefoneText.Text);
            cmd.Parameters.AddWithValue("@VetEmail", medicoEmailText.Text);
            Especialidade e = (Especialidade)medicoEspecialidadeComboBox.SelectedItem;
            cmd.Parameters.AddWithValue("@VetSpecialty", e.Codigo);
            CliVet c = (CliVet)medicoClinicaComboBox.SelectedItem;
            cmd.Parameters.AddWithValue("@VetClinic", c.NIF);

            if (ExecuteInsertSP(cmd))
            {
                MessageBox.Show(msgShow);
            }

            cn.Close();
        }

        private void DonoTuples(String sp, String msgShow)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OwnerNIF", int.Parse(donoNifText.Text));
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

        private void AnimalTuples(String sp, String msgShow)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (sp.Equals("SP_UpdatePet"))
            {
                cmd.Parameters.AddWithValue("@PetID", animalNumeroText.Text);
            }
            cmd.Parameters.AddWithValue("@PetName", animalNomeText.Text);
            cmd.Parameters.AddWithValue("@PetBirthDate", animalDateTimePicker.Value.Date);
            double peso;
            bool ok = double.TryParse(
                animalPesoText.Text.Replace('.', ','),
                NumberStyles.Any,
                CultureInfo.CurrentCulture,
                out peso
            );
            cmd.Parameters.AddWithValue("@PetWeight", peso);
            cmd.Parameters.AddWithValue("@PetSex", animalSexoComboBox.SelectedItem.ToString());
            Especie e = (Especie)animalEspecieComboBox.SelectedItem;
            cmd.Parameters.AddWithValue("@PetSpecie", e.Codigo);
            Owner o = (Owner)animalDonoComboBox.SelectedItem;
            cmd.Parameters.AddWithValue("@PetOwner", o.NIF);

            if (ExecuteInsertSP(cmd))
            {
                MessageBox.Show(msgShow);
            }

            cn.Close();
        }

        private void MedicamentoTuples(String sp, String msgShow)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MedicineCode", Int32.Parse(medicamentoCodigoText.Text));
            cmd.Parameters.AddWithValue("@MedicineDescription", medicamentoNomeText.Text);
            String dose = medicamentoDoseText.Text;
            if (!(dose.Contains("mg") || dose.Contains("g") || dose.Contains("kg")))
            {
                MessageBox.Show(
                    "Dose inválida.\nUse unidades válidas: mg, g ou kg.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            cmd.Parameters.AddWithValue("@MedicineDose", dose);

            if (ExecuteInsertSP(cmd))
            {
                MessageBox.Show(msgShow);
            }

            cn.Close();
        }



        private void ConsultaTuples(String sp, String msgShow)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (sp == "SP_UpdateAppointment")
            {
                cmd.Parameters.AddWithValue("@AppointmentID", int.Parse(consultaIdText.Text));
            }
            cmd.Parameters.AddWithValue("@AppointmentDate", consultaDateTimePicker.Value);
            Pet p = (Pet)consultaAnimaisComboBox.SelectedItem;
            cmd.Parameters.AddWithValue("@AppointmentPet", p.Numero);
            Vet v = (Vet)consultaMedicoComboBox.SelectedItem;
            cmd.Parameters.AddWithValue("@AppointmentVet", v.NumOMV);

            if (ExecuteInsertSP(cmd))
            {
                MessageBox.Show(msgShow);
            }

            cn.Close();
        }

        private void PagamentoTuples(String sp, String msgShow)
        {
            if (!verifySGBDConnection())
                return;


            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (sp.Equals("SP_UpdatePet"))
            {
                cmd.Parameters.AddWithValue("@PaymentID", pagamentoIdText.Text);
            }
            cmd.Parameters.AddWithValue("@PaymentDate", pagamentoDateTimePicker.Value);
            double valor;
            bool ok = double.TryParse(
                pagamentoValorText.Text.Replace('.', ','),
                NumberStyles.Any,
                CultureInfo.CurrentCulture,
                out valor
            );
            cmd.Parameters.AddWithValue("@PaymentValue", valor);
            cmd.Parameters.AddWithValue("@PaymentStatus", pagamentoEstadoComboBox.SelectedItem.ToString());
            PaymentMethod pm = (PaymentMethod)pagamentoMetodoComboBox.SelectedItem;
            cmd.Parameters.AddWithValue("@PaymentMethod", pm.Codigo);
            Appointment ap = (Appointment)pagamentoConsultaComboBox.SelectedItem;
            cmd.Parameters.AddWithValue("@PaymentAppointment", ap.Id);

            if (ExecuteInsertSP(cmd))
            {
                MessageBox.Show(msgShow);
            }

            cn.Close();
        }

        private void PrescricaoTuples(String sp, String msgShow)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PrescriptionNumber", int.Parse(prescricaoNumeroText.Text));
            cmd.Parameters.AddWithValue("@PrescriptionDate", prescricaoDateTimePicker.Value.Date);
            Pet p = (Pet)prescricaoAnimalComboBox.SelectedItem;
            if (p != null)
                cmd.Parameters.AddWithValue("@PrescriptionPet", p.Numero);
            Vet v = (Vet)prescricaoMedicoComboBox.SelectedItem;
            if (v != null)
                cmd.Parameters.AddWithValue("@PrescriptionVet", v.NumOMV);

            if (ExecuteInsertSP(cmd))
            {
                MessageBox.Show(msgShow);
            }

            cn.Close();
        }

        private void SimpleAddTuples(String sp, String msgShow, String param, TextBox content)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(param, content.Text);

            if (ExecuteInsertSP(cmd))
            {
                MessageBox.Show(msgShow);
            }

            cn.Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            switch ((option, entity))
            {
                case ("Add", "Clinica"):
                    ClinicaTuples("SP_AddClinic", "Clinica adicionada com sucesso!");
                    clinicaVeterinariaTab_Click(sender, e);
                    break;
                case ("Edit", "Clinica"):
                    ClinicaTuples("SP_UpdateClinic", "Informações atualizadas com sucesso!");
                    clinicaVeterinariaTab_Click(sender, e);
                    break;
                case ("Add", "Medico"):
                    MedicoTuples("SP_AddVet", "Médico adicionado com sucesso!");
                    medicoVeterinarioTab_Click(sender, e);
                    break;
                case ("Edit", "Medico"):
                    MedicoTuples("SP_UpdateVet", "Informações atualizadas com sucesso!");
                    medicoVeterinarioTab_Click(sender, e);
                    break;
                case ("Add", "Dono"):
                    DonoTuples("SP_AddOwner", "Dono adicionado com sucesso!");
                    donoTab_Click(sender, e);
                    break;
                case ("Edit", "Dono"):
                    DonoTuples("SP_UpdateOwner", "Informações atualizadas com sucesso!");
                    donoTab_Click(sender, e);
                    break;
                case ("Add", "Animal"):
                    AnimalTuples("SP_AddPet", "Animal adicionado com sucesso!");
                    animalTab_Click(sender, e);
                    break;
                case ("Edit", "Animal"):
                    AnimalTuples("SP_UpdatePet", "Informações atualizadas com sucesso");
                    animalTab_Click(sender, e);
                    break;
                case ("Add", "Medicamento"):
                    MedicamentoTuples("SP_AddMedicine", "Medicamento adicionado com sucesso!");
                    medTab_Click(sender, e);
                    break;
                case ("Edit", "Medicamento"):
                    MedicamentoTuples("SP_UpdateMedicine", "Informações atualizadas com sucesso!");
                    medTab_Click(sender, e);
                    break;
                case ("Add", "Consulta"):
                    ConsultaTuples("SP_AddAppointment", "Consulta adicionada com sucesso!");
                    consultaTab_Click(sender, e);
                    break;
                case ("Edit", "Consulta"):
                    ConsultaTuples("SP_UpdateAppointment", "Informações atualizadas com sucesso!");
                    consultaTab_Click(sender, e);
                    break;
                case ("Add", "Pagamento"):
                    PagamentoTuples("SP_AddPayment", "Pagamento adicionado com sucesso!");
                    pagamentoTab_Click(sender, e);
                    break;
                case ("Edit", "Pagamento"):
                    PagamentoTuples("SP_UpdatePayment", "Informações atualizadas com sucesso!");
                    pagamentoTab_Click(sender, e);
                    break;
                case ("Add", "Prescricao"):
                    PrescricaoTuples("SP_AddPrescription", "Prescrição adicionada com sucesso!");
                    prescricaoTab_Click(sender, e);
                    break;
                case ("Edit", "Prescricao"):
                    PrescricaoTuples("SP_UpdatePrescription", "Informações atualizadas com sucesso!");
                    prescricaoTab_Click(sender, e);
                    break;
                case ("Add", "Especialidade"):
                    SimpleAddTuples("SP_AddSpecialty", "Especialidade adicionada com sucesso!", "@SpecialtyDescription", especialidadeDescricaoText);
                    especialidadeTab_Click(sender, e);
                    break;
                case ("Add", "Especie"):
                    SimpleAddTuples("SP_AddSpecie", "Especie adicionada com sucesso!", "@SpecieDescription", especieDescricaoText);
                    especieTab_Click(sender, e);
                    break;
                case ("Add", "MetodoPagamento"):
                    SimpleAddTuples("SP_AddPaymentMethod", "Método de Pagamento adicionado com sucesso!", "@MethodDescription", metodoPagamentoDescricaoText);
                    metodoPagamentoTab_Click(sender, e);
                    break;
                case ("Add", "Tratamento"):
                    SimpleAddTuples("SP_AddTreatment", "Tratamento adicionado com sucesso!", "@TreatmentDescription", tratamentoDescricaoText);
                    tratamentoTab_Click(sender, e);
                    break;
                default:
                    break;

            }
        }

        protected virtual void registarTabControl_onSelectedIndexChange(object sender, EventArgs e)
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
                case 5: // Consulta
                    consultaTab_Click(sender, e);
                    break;
                case 6: // Pagamento
                    pagamentoTab_Click(sender, e);
                    break;
                case 7: // Prescricao
                    prescricaoTab_Click(sender, e);
                    break;
                case 8: // Especialidade
                    especialidadeTab_Click(sender, e);
                    break;
                case 9: // Especie
                    especieTab_Click(sender, e);
                    break;
                case 10: // Metodo Pagamento
                    metodoPagamentoTab_Click(sender, e);
                    break;
                case 11: // Tratamento
                    tratamentoTab_Click(sender, e);
                    break;
                default: break;
            }
        }

        private List<Treatment> getAppointmentTreatmentsById(int appointmentId)
        {
            if (!verifySGBDConnection())
                return null;

            List<Treatment> treatments = new List<Treatment>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetAppointmentTreatmentsById(@appointmentID) ORDER BY Descricao", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@appointmentID", appointmentId);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Treatment t = new Treatment();
                t.Codigo = reader["Codigo"].ToString();
                t.Descricao = reader["Descricao"].ToString();
                treatments.Add(t);
            }

            reader.Close();

            cn.Close();

            return treatments;

        }

        private String getAppointmentReportById(int appointmentId)
        {
            if (!verifySGBDConnection())
                return null;

            String reportContent = "";
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetAppointmentReportById(@appointmentID)", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@appointmentID", appointmentId);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                reportContent = reader["Conteudo"].ToString();
            }

            reader.Close();

            cn.Close();

            return reportContent;
        }

        private void btnVerTratamentos_Click(object sender, EventArgs e)
        {
            int idConsulta = Int32.Parse(consultaIdText.Text);

            List<Treatment> treatments = getAppointmentTreatmentsById(idConsulta);

            UC_ListTreatments uc = new UC_ListTreatments();
            uc.SetMode("View");
            uc.SetTreatments(treatments);

            PopUpForm popup = new PopUpForm(uc, "Tratamentos da Consulta");
            popup.ShowDialog();

        }

        public void AddTreatmentToAppointment(Treatment treatment, UC_ListTreatments uc)
        {
            if (!verifySGBDConnection())
                return;

            int appointmentId = int.Parse(consultaIdText.Text);

            SqlCommand cmd = new SqlCommand("SP_AddTreatmentToAppointment", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
            cmd.Parameters.AddWithValue("@TreatmentID", int.Parse(treatment.Codigo));
            ExecuteInsertSP(cmd);

            uc.SetTreatments(getAppointmentTreatmentsById(appointmentId));

            cn.Close();
        }


        private void btnEditarTratamentos_Click(object sender, EventArgs e)
        {
            int idConsulta = Int32.Parse(consultaIdText.Text);

            List<Treatment> treatments = getAppointmentTreatmentsById(idConsulta);

            UC_ListTreatments uc = new UC_ListTreatments();
            uc.SetMode("Edit");
            uc.SetForm(this);
            uc.SetTreatments(treatments);

            PopUpForm popup = new PopUpForm(uc, "Tratamentos da Consulta");
            popup.ShowDialog();
        }

        private void btnConsultarRelatorio_Click(object sender, EventArgs e)
        {
            int idConsulta = Int32.Parse(consultaIdText.Text);

            String reportContent = getAppointmentReportById(idConsulta);

            UC_ShowReport uc = new UC_ShowReport();
            uc.setReportText(reportContent);
            uc.SetMethod("View");

            PopUpForm popup = new PopUpForm(uc, "Relatório da Consulta");
            popup.ShowDialog();
        }

        public void UpdateReport(String reportContent)
        {
            if (!verifySGBDConnection())
                return;

            int appointmentId = int.Parse(consultaIdText.Text);

            SqlCommand cmd = new SqlCommand("SP_UpdateReport", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
            cmd.Parameters.AddWithValue("@reportContent", reportContent);
            ExecuteInsertSP(cmd);

            cn.Close();
        }

        private void consultaBtnEditarRelatorio_Click(object sender, EventArgs e)
        {
            int idConsulta = Int32.Parse(consultaIdText.Text);
            UC_ShowReport uc = new UC_ShowReport();

            uc.SetMainForm(this);
            uc.setReportText(getAppointmentReportById(idConsulta));
            uc.SetMethod("Edit");

            PopUpForm popup = new PopUpForm(uc, "Editar Relatório");
            popup.ShowDialog();
        }

        private void btnVerMedicamentos_Click(object sender, EventArgs e)
        {
            int idPrescricao = Int32.Parse(prescricaoNumeroText.Text);

            List<Med> meds = getPrescriptionMedsById(idPrescricao);

            UC_ListMeds uc = new UC_ListMeds();
            uc.SetMainForm(this);
            uc.SetMeds(meds);
            uc.SetMethod("View");

            PopUpForm popup = new PopUpForm(uc, "Medicamentos da Prescrição");
            popup.ShowDialog();
        }

        public void AddMedToPrescription(Med newMed, UC_ListMeds uc)
        {
            if (!verifySGBDConnection())
                return;

            int prescriptionId = int.Parse(prescricaoNumeroText.Text);

            SqlCommand cmd = new SqlCommand("SP_AddMedToPrescription", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PrescriptionID", prescriptionId);
            cmd.Parameters.AddWithValue("@MedID", int.Parse(newMed.Codigo));
            ExecuteInsertSP(cmd);

            uc.SetMeds(getPrescriptionMedsById(prescriptionId));

            cn.Close();
        }

        private void prescricaoBtnEditarMedicamentos_Click(object sender, EventArgs e)
        {
            int idPrescricao = Int32.Parse(prescricaoNumeroText.Text);

            List<Med> meds = getPrescriptionMedsById(idPrescricao);

            UC_ListMeds uc = new UC_ListMeds();
            uc.SetMainForm(this);
            uc.SetMeds(meds);
            uc.SetMethod("Edit");

            PopUpForm popup = new PopUpForm(uc, "Medicamentos da Prescrição");
            popup.ShowDialog();
        }

        private void btnConsultarMedicos_Click(object sender, EventArgs e)
        {
            int especialidade = Int32.Parse(especialidadeCodigoText.Text);

            List<String> vets = getVetsBySpeciality(especialidade);

            UC_ListStrings uc = new UC_ListStrings();
            uc.SetStrings(vets);

            PopUpForm popup = new PopUpForm(uc, "Médicos");
            popup.ShowDialog();

        }

        private void btnConsultaAnimais_Click(object sender, EventArgs e)
        {
            int especie = Int32.Parse(especieCodigoText.Text);

            List<String> animais = getAnimalsBySpecie(especie);

            UC_ListStrings uc = new UC_ListStrings();
            uc.SetStrings(animais);

            PopUpForm popup = new PopUpForm(uc, "Animais");
            popup.ShowDialog();

        }

        private List<String> GetPaymentsByMethod(int paymentMethodId)
        {
            if (!verifySGBDConnection())
                return null;

            List<String> payments = new List<String>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetPaymentsByMethod(@MethodID) ORDER BY [Data] DESC", cn);
            cmd.Parameters.AddWithValue("@MethodId", paymentMethodId);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Payment payment = new Payment();
                payment.Id = reader["Id"].ToString();
                payment.Valor = reader["Custo"].ToString();
                payment.Data = reader["Data"].ToString();
                payment.Estado = reader["Estado"].ToString();
                payment.Metodo = reader["Metodo"].ToString();
                payment.Animal = reader["Animal"].ToString();
                payment.Medico = reader["Medico"].ToString();
                payments.Add(payment.ToString());
            }
            reader.Close();
            cn.Close();

            return payments;
        }

        private void metodoPagamentoBtnPagamentos_Click(object sender, EventArgs e)
        {
            int paymentMethodId = int.Parse(metodoPagamentoCodigoText.Text);

            List<String> payments = GetPaymentsByMethod(paymentMethodId);


            UC_ListStrings uc = new UC_ListStrings();
            uc.SetStrings(payments);

            PopUpForm popup = new PopUpForm(uc, "Pagamentos");
            popup.ShowDialog();
        }

        private List<String> GetAppointmentsByTreatment(int treatmentId)
        {
            if (!verifySGBDConnection())
                return null;

            List<String> appointments = new List<String>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetAppointmentsByTreatment(@TreatmentId)", cn);
            cmd.Parameters.AddWithValue("@TreatmentId", treatmentId);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Appointment ap = new Appointment();
                ap.Id = reader["Id"].ToString();
                ap.Data = reader["Data"].ToString();
                ap.Animal = reader["Animal"].ToString();
                ap.Medico = reader["Medico"].ToString();
                appointments.Add(ap.ToString());
            }
            reader.Close();
            cn.Close();

            return appointments;
        }

        private void tratamentoBtnConsultas_Click(object sender, EventArgs e)
        {
            int treatmentId = int.Parse(tratamentoCodigoText.Text);

            List<String> appointments = GetAppointmentsByTreatment(treatmentId);


            UC_ListStrings uc = new UC_ListStrings();
            uc.SetStrings(appointments);

            PopUpForm popup = new PopUpForm(uc, "Consultas");
            popup.ShowDialog();
        }



        private void consultarVetCliTabPage_Click(object sender, EventArgs e)
        {
            entity = "Medico";
            listBox1.Items.Clear();
            LoadClinicasComboBox(consultarMedicosClinicaComboBox, null);
        }

        private void consultarMedicosClinicaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }

            listBox1.Items.Clear();

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetVetInfo(@ClinicNIF, NULL, DEFAULT, @Search) ORDER BY Nome", cn);
            cmd.CommandType = CommandType.Text;
            CliVet cv = (CliVet)consultarMedicosClinicaComboBox.SelectedItem;
            cmd.Parameters.AddWithValue("@ClinicNIF", cv.NIF);
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }

            SqlDataReader reader = cmd.ExecuteReader();
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }
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

            reader.Close();
            cn.Close();
        }

        private void consultarAnimaisDonoTabPage_Click(object sender, EventArgs e)
        {
            entity = "AnimalDono";
            listBox1.Items.Clear();
            LoadDonosComboBox(consultarAnimaisDonoComboBox, null);
        }

        private void consultarAnimaisDonoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }
            listBox1.Items.Clear();

            Owner o = (Owner)consultarAnimaisDonoComboBox.SelectedItem;

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetPetInfo(@OwnerNIF, DEFAULT, @Search) ORDER BY Nome", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@OwnerNIF", int.Parse(o.NIF));
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }
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
                listBox1.Items.Add(pet);
            }
            reader.Close();
            cn.Close();
        }

        private void consultarAnimaisClinicaTabPage_Click(object sender, EventArgs e)
        {
            entity = "AnimalClinica";
            listBox1.Items.Clear();
            LoadClinicasComboBox(consultarAnimaisClinicaComboBox, null);
        }


        private void consultarAnimaisClinicaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }
            listBox1.Items.Clear();

            CliVet cv = (CliVet)consultarAnimaisClinicaComboBox.SelectedItem;

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetPetsByClinic(@ClinicNIF, @Search) ORDER BY Dono", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ClinicNIF", int.Parse(cv.NIF));
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }

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
                listBox1.Items.Add(pet);
            }
            reader.Close();
            cn.Close();
        }

        private void consultarConsultasAnimalTabPage_Click(object sender, EventArgs e)
        {
            entity = "ConsultaAnimal";
            listBox1.Items.Clear();
            LoadAnimaisComboBox(consultarConsultasAnimalComboBox, null);
        }

        private void consultarConsultasAnimalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }
            listBox1.Items.Clear();

            Pet p = (Pet)consultarConsultasAnimalComboBox.SelectedItem;

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetAppointmentInfo(@PetId, NULL, DEFAULT, @Search) ORDER BY [Data] DESC", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@PetId", int.Parse(p.Numero));
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Appointment ap = new Appointment();
                ap.Id = reader["Id"].ToString();
                ap.Data = reader["Data"].ToString();
                ap.Animal = reader["Animal"].ToString();
                ap.Medico = reader["Medico"].ToString();
                listBox1.Items.Add(ap);
            }
            reader.Close();
            cn.Close();
        }

        private void consultarConsultasAnimalBtnVerRelatório_Click(object sender, EventArgs e)
        {
            int idConsulta = Int32.Parse(consultarConsultasAnimalIdText.Text);

            String reportContent = getAppointmentReportById(idConsulta);

            UC_ShowReport uc = new UC_ShowReport();
            uc.setReportText(reportContent);
            uc.SetMethod("View");

            PopUpForm popup = new PopUpForm(uc, "Relatório da Consulta");
            popup.ShowDialog();
        }

        private void consultarConsultasAnimalBtnVerTratamentos_Click(object sender, EventArgs e)
        {
            int idConsulta = Int32.Parse(consultarConsultasAnimalIdText.Text);

            List<Treatment> treatments = getAppointmentTreatmentsById(idConsulta);

            UC_ListTreatments uc = new UC_ListTreatments();
            uc.SetMode("View");
            uc.SetTreatments(treatments);

            PopUpForm popup = new PopUpForm(uc, "Tratamentos da Consulta");
            popup.ShowDialog();

        }

        private void consultarConsultasVetTabPage_Click(object sender, EventArgs e)
        {
            entity = "ConsultaMedico";
            listBox1.Items.Clear();
            LoadMedicosComboBox(consultarConsultasMedicoComboBox, null);
        }

        private void consultarConsultasMedicoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }

            listBox1.Items.Clear();

            Vet v = (Vet)consultarConsultasMedicoComboBox.SelectedItem;

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetAppointmentInfo(NULL, @VetOMV, DEFAULT, @Search) ORDER BY [Data] DESC", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@VetOMV", int.Parse(v.NumOMV));
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Appointment ap = new Appointment();
                ap.Id = reader["Id"].ToString();
                ap.Data = reader["Data"].ToString();
                ap.Animal = reader["Animal"].ToString();
                ap.Medico = reader["Medico"].ToString();
                listBox1.Items.Add(ap);
            }
            reader.Close();
            cn.Close();
        }


        private void consultarConsultasMedicoBtnVerRelatorio_Click(object sender, EventArgs e)
        {
            int idConsulta = Int32.Parse(consultarConsultasMedicoIdText.Text);

            String reportContent = getAppointmentReportById(idConsulta);

            UC_ShowReport uc = new UC_ShowReport();
            uc.setReportText(reportContent);
            uc.SetMethod("View");

            PopUpForm popup = new PopUpForm(uc, "Relatório da Consulta");
            popup.ShowDialog();
        }

        private void consultarConsultasMedicoBtnVerTratamentos_Click(object sender, EventArgs e)
        {
            int idConsulta = Int32.Parse(consultarConsultasMedicoIdText.Text);

            List<Treatment> treatments = getAppointmentTreatmentsById(idConsulta);

            UC_ListTreatments uc = new UC_ListTreatments();
            uc.SetMode("View");
            uc.SetTreatments(treatments);

            PopUpForm popup = new PopUpForm(uc, "Tratamentos da Consulta");
            popup.ShowDialog();
        }

        private void consultarPrescricoesAnimalTabPage_Click(object sender, EventArgs e)
        {
            entity = "PrescricaoAnimal";
            listBox1.Items.Clear();
            LoadAnimaisComboBox(consultarPrescricaoAnimalComboBox, null);
        }

        private void consultarPrescricaoAnimalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }
            listBox1.Items.Clear();

            Pet p = (Pet)consultarPrescricaoAnimalComboBox.SelectedItem;

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetPrescriptionInfo(@PetId, NULL, DEFAULT, @Search) ORDER BY [Data] DESC", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@PetId", int.Parse(p.Numero));
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Prescription prescription = new Prescription();
                prescription.Numero = reader["Numero"].ToString();
                prescription.Data = ((DateTime)reader["Data"]).ToString("dd/MM/yyyy");
                prescription.Animal = reader["Animal"].ToString();
                prescription.Medico = reader["Medico"].ToString();
                listBox1.Items.Add(prescription);
            }
            reader.Close();
            cn.Close();
        }

        private void consultarPrescricaoAnimalBtnVerMedicamentos_Click(object sender, EventArgs e)
        {
            int idPrescricao = Int32.Parse(consultarPrescricaoAnimalNumeroText.Text);

            List<Med> meds = getPrescriptionMedsById(idPrescricao);

            UC_ListMeds uc = new UC_ListMeds();
            uc.SetMainForm(this);
            uc.SetMeds(meds);
            uc.SetMethod("View");

            PopUpForm popup = new PopUpForm(uc, "Medicamentos da Prescrição");
            popup.ShowDialog();
        }

        private void consultarPagamentosDonoTabPage_Click(object sender, EventArgs e)
        {
            entity = "PagamentoDono";
            listBox1.Items.Clear();
            LoadDonosComboBox(consultarPagamentosDonoComboBox, null);
        }

        private void consultarPagamentosDonoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            String searchContent = null;
            if (searchTextBox.Text.Length >= 3)
            {
                searchContent = searchTextBox.Text;
            }
            listBox1.Items.Clear();
            Owner o = (Owner)consultarPagamentosDonoComboBox.SelectedItem;

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetPaymentInfo(@OwnerNIF, DEFAULT, @Search) ORDER BY [Data] DESC", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@OwnerNIF", o.NIF);
            if (!string.IsNullOrWhiteSpace(searchContent))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = searchContent;
            }
            else
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 64).Value = DBNull.Value;
            }

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Payment payment = new Payment();
                payment.Id = reader["Id"].ToString();
                payment.Valor = reader["Custo"].ToString();
                payment.Data = reader["Data"].ToString();
                payment.Estado = reader["Estado"].ToString();
                payment.Metodo = reader["Metodo"].ToString();
                payment.Animal = reader["Animal"].ToString();
                payment.Medico = reader["Medico"].ToString();
                listBox1.Items.Add(payment);
            }

            reader.Close();
            cn.Close();
        }

        private void consultarTabControl_onSelectedIndexChange(object sender, EventArgs e)
        {
            int selectedTabIndex = consultarTabControl.SelectedIndex;
            switch (selectedTabIndex)
            {
                case 0: // Medidos por Clinica
                    consultarVetCliTabPage_Click(sender, e);
                    break;
                case 1: // Animais por Dono
                    consultarAnimaisDonoTabPage_Click(sender, e);
                    break;
                case 2: // Animais por Clinica
                    consultarAnimaisClinicaTabPage_Click(sender, e);
                    break;
                case 3: // Consultas por Animal
                    consultarConsultasAnimalTabPage_Click(sender, e);
                    break;
                case 4: // Consultas por Medico
                    consultarConsultasVetTabPage_Click(sender, e);
                    break;
                case 5: // Prescricao por Animal
                    consultarPrescricoesAnimalTabPage_Click(sender, e);
                    break;
                case 6: // Pagamentos por Dono
                    consultarPagamentosDonoTabPage_Click(sender, e);
                    break;
                default: break;
            }
        }

        private void RestaurarTuplos(String sp, int pk, String param)
        {
            if (!verifySGBDConnection())
                return;

            cn.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(param, pk);
            cmd.Parameters.AddWithValue("@RestoredBy", "admin");
            ExecuteInsertSP(cmd);

            cn.InfoMessage -= new SqlInfoMessageEventHandler(OnInfoMessage);

            cn.Close();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            switch (entity)
            {
                case "Clinica":
                    RestaurarTuplos("PR_RestoreClinica", int.Parse(clinicaNifText.Text), "@ClinicNIF");
                    clinicaVeterinariaTab_Click(sender, e);
                    break;
                case "Medico":
                    RestaurarTuplos("PR_RestoreMedicoVeterinario", int.Parse(medicoOMVText.Text), "@NumOMV");
                    medicoVeterinarioTab_Click(sender, e);
                    break;
                case "Dono":
                    RestaurarTuplos("PR_RestoreDono", int.Parse(donoNifText.Text), "@DonoNIF");
                    donoTab_Click(sender, e);
                    break;
                case "Animal":
                    RestaurarTuplos("PR_RestoreAnimal", int.Parse(animalNumeroText.Text), "@AnimalNumero");
                    animalTab_Click(sender, e);
                    break;
                case "Medicamento":
                    RestaurarTuplos("PR_RestoreMedicamento", int.Parse(medicamentoCodigoText.Text), "@MedicamentoCodigo");
                    medTab_Click(sender, e);
                    break;
                case "Consulta":
                    RestaurarTuplos("PR_RestoreConsulta", int.Parse(consultaIdText.Text), "@ConsultaId");
                    consultaTab_Click(sender, e);
                    break;
                case "Pagamento":
                    RestaurarTuplos("PR_RestorePagamento", int.Parse(pagamentoIdText.Text), "@PagamentoId");
                    pagamentoTab_Click(sender, e);
                    break;
                case "Prescricao":
                    RestaurarTuplos("PR_RestorePrescricao", int.Parse(prescricaoNumeroText.Text), "@PrescricaoNumero");
                    prescricaoTab_Click(sender, e);
                    break;
                case "Especialidade":
                    RestaurarTuplos("PR_RestoreEspecialidade", int.Parse(especialidadeCodigoText.Text), "@EspecialidadeCodigo");
                    especialidadeTab_Click(sender, e);
                    break;
                case "Especie":
                    RestaurarTuplos("PR_RestoreEspecie", int.Parse(especieCodigoText.Text), "@EspecieCodigo");
                    especieTab_Click(sender, e);
                    break;
                case "MetodoPagamento":
                    RestaurarTuplos("PR_RestoreMetodoPagamento", int.Parse(metodoPagamentoCodigoText.Text), "@MetodoPagamentoCodigo");
                    metodoPagamentoTab_Click(sender, e);
                    break;
                case "Tratamento":
                    RestaurarTuplos("PR_RestoreTratamento", int.Parse(tratamentoCodigoText.Text), "@TratamentoCodigo");
                    tratamentoTab_Click(sender, e);
                    break;

            }

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if(tab != "Consultar")
            {
                switch (entity)
                {
                    case "Clinica":
                        clinicaVeterinariaTab_Click(sender, e);
                        break;
                    case "Medico":
                        medicoVeterinarioTab_Click(sender, e);
                        break;
                    case "Dono":
                        donoTab_Click(sender, e);
                        break;
                    case "Animal":
                        animalTab_Click(sender, e);
                        break;
                    case "Medicamento":
                        medTab_Click(sender, e);
                        break;
                    case "Consulta":
                        consultaTab_Click(sender, e);
                        break;
                    case "Pagamento":
                        pagamentoTab_Click(sender, e);
                        break;
                    case "Prescricao":
                        prescricaoTab_Click(sender, e);
                        break;
                    case "Especialidade":
                        especialidadeTab_Click(sender, e);
                        break;
                    case "Especie":
                        especieTab_Click(sender, e);
                        break;
                    case "MetodoPagamento":
                        metodoPagamentoTab_Click(sender, e);
                        break;
                    case "Tratamento":
                        tratamentoTab_Click(sender, e);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (entity)
                {
                    case "Medico":
                        consultarMedicosClinicaComboBox_SelectedIndexChanged(sender, e);
                        break;
                    case "AnimalDono":
                        consultarAnimaisDonoComboBox_SelectedIndexChanged(sender, e);
                        break;
                    case "AnimalClinica":
                        consultarAnimaisClinicaComboBox_SelectedIndexChanged(sender, e);
                        break;
                    case "PrescricaoAnimal":
                        consultarPrescricaoAnimalComboBox_SelectedIndexChanged(sender, e);
                        break;
                    case "PagamentoDono":
                        consultarPagamentosDonoComboBox_SelectedIndexChanged(sender, e);
                        break;
                    case "ConsultaAnimal":
                        consultarConsultasAnimalComboBox_SelectedIndexChanged(sender, e);
                        break;
                    case "ConsultaMedico":
                        consultarConsultasMedicoComboBox_SelectedIndexChanged(sender, e);
                        break;
                    default: break;
                }
            }
            
        }
    }
}


