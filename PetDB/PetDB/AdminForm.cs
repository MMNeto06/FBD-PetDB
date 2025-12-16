using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Serialization;
namespace PetDB
{
    public partial class AdminForm : Form, IAppointmentForm, IMedForm
    {
        private SqlConnection cn;
        private int currentListIndex;
        private Login loginPage;
        private String option = "";
        private String entity = "";
        public AdminForm(Login loginPage)
        {
            InitializeComponent();
            this.loginPage = loginPage;
            clinicaBaseControls();
            registarTabControl.Visible = true;
            consultarTabControl.Visible = false;
            clinicaVeterinariaTab_Click(null, null);
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

        private void registarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consultarTabControl.Visible = false;
            registarTabControl.Visible = true;
            generalBaseControls();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consultarTabControl.Visible = true;
            registarTabControl.Visible = false;
            addBtn.Visible = false;
            editBtn.Visible = false;
            remBtn.Visible = false;
            okBtn.Visible = false;
            cancelBtn.Visible = false;
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

        private void medicoBaseControls()
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

        private void medicoEditControls()
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

        private void medicoAddControls()
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
            SqlCommand cmd = new SqlCommand("SP_GetPrescriptionMedsById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
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
            SqlCommand cmd = new SqlCommand("SP_GetVetsBySpeciality", cn);
            cmd.CommandType = CommandType.StoredProcedure;
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
            SqlCommand cmd = new SqlCommand("SP_GetAnimalsBySpecie", cn);
            cmd.CommandType = CommandType.StoredProcedure;
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

        private List<CliVet> GetClinicasVeterinarias()
        {
            if (!verifySGBDConnection())
                return null;

            List<CliVet> clinicas = new List<CliVet>();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetClinicTable", cn);
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

            entity = "Clinica";
            clinicaBaseControls();

            listBox1.Items.Clear();

            List<CliVet> clinicas = GetClinicasVeterinarias();

            foreach (var CV in clinicas)
            {
                listBox1.Items.Add(CV);
            }

            cn.Close();

            currentListIndex = 0;
            ShowClinicaVeterinaria();
        }

        private List<Vet> GetMedicos()
        {
            if (!verifySGBDConnection())
                return null;

            List<Vet> vets = new List<Vet>();

            SqlCommand cmd = new SqlCommand("EXEC SP_GetVetInfo", cn);
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

        private void medicoVeterinarioTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            entity = "Medico";
            medicoBaseControls();
            listBox1.Items.Clear();

            List<Vet> vets = GetMedicos();

            foreach (var v in vets)
                listBox1.Items.Add(v);

            cn.Close();

            currentListIndex = 0;
            ShowVet();
        }

        private List<Owner> GetDonos()
        {
            if (!verifySGBDConnection())
                return null;

            List<Owner> owners = new List<Owner>();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetOwnerTable", cn);
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

            entity = "Dono";
            donoBaseControls();
            List<Owner> owners = GetDonos();
            listBox1.Items.Clear();

            foreach (var owner in owners)
                listBox1.Items.Add(owner);

            cn.Close();

            currentListIndex = 0;
            ShowOwner();
        }

        private List<Pet> GetAnimais()
        {
            if (!verifySGBDConnection())
                return null;

            List<Pet> pets = new List<Pet>();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetPetInfo", cn);
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

            entity = "Animal";
            animalBaseControls();
            listBox1.Items.Clear();

            List<Pet> pets = GetAnimais();

            foreach (var p in pets)
                listBox1.Items.Add(p);

            cn.Close();


            currentListIndex = 0;
            ShowPet();
        }

        public List<Med> GetMeds()
        {
            if (!verifySGBDConnection())
                return null;

            List<Med> meds = new List<Med>();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetMedInfo", cn);
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

            entity = "Medicamento";
            medicamentoBaseControls();
            listBox1.Items.Clear();

            List<Med> meds = GetMeds();

            foreach (var m in meds)
                listBox1.Items.Add(m);

            cn.Close();

            currentListIndex = 0;
            ShowMed();
        }

        private List<Appointment> GetConsultas()
        {
            if (!verifySGBDConnection())
                return null;

            List<Appointment> consultas = new List<Appointment>();

            SqlCommand cmd = new SqlCommand("EXEC SP_GetAppointmentInfo", cn);
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

            entity = "Consulta";
            consultaBaseControls();
            listBox1.Items.Clear();

            List<Appointment> consultas = GetConsultas();

            foreach (var c in consultas)
                listBox1.Items.Add(c);

            cn.Close();

            currentListIndex = 0;
            ShowConsulta();
        }

        private void pagamentoTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            entity = "Pagamento";
            pagamentoBaseControls();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetPaymentInfo", cn);
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


            currentListIndex = 0;
            ShowPayment();
        }

        private void prescricaoTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            entity = "Prescricao";
            prescricaoBaseControls();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetPrescriptionInfo", cn);
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

            currentListIndex = 0;
            ShowPrescription();
        }

        private List<Especialidade> GetEspecialidades()
        {
            if (!verifySGBDConnection())
                return null;

            List<Especialidade> especialidades = new List<Especialidade>();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetSpecialityInfo", cn);
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

            entity = "Especialidade";
            especialidadeBaseControls();
            List<Especialidade> especialidades = GetEspecialidades();

            listBox1.Items.Clear();

            foreach (var especialidade in especialidades)
                listBox1.Items.Add(especialidade);

            cn.Close();

            currentListIndex = 0;
            ShowEspecialidade();
        }

        private List<Especie> GetEspecies()
        {
            if (!verifySGBDConnection())
                return null;

            List<Especie> especies = new List<Especie>();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetSpecieInfo", cn);
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

            entity = "Especie";
            especieBaseControls();
            List<Especie> especies = GetEspecies();

            listBox1.Items.Clear();

            foreach (var especie in especies)
                listBox1.Items.Add(especie);

            cn.Close();

            currentListIndex = 0;
            ShowEspecie();
        }

        private List<PaymentMethod> GetMetodosPagamento()
        {
            if (!verifySGBDConnection())
                return null;

            List<PaymentMethod> methods = new List<PaymentMethod>();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetPaymentMethods", cn);
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

            entity = "MetodoPagamento";
            metodoPagamentoBaseControls();
            List<PaymentMethod> methods = GetMetodosPagamento();

            listBox1.Items.Clear();

            foreach (var method in methods)
                listBox1.Items.Add(method);

            cn.Close();

            currentListIndex = 0;
            ShowMetodoPagamento();
        }

        public List<Treatment> GetTreatments()
        {
            if (!verifySGBDConnection())
                return null;

            List<Treatment> treatments = new List<Treatment>();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetTreatments", cn);
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

            entity = "Tratamento";
            tratamentoBaseControls();
            List<Treatment> treatments = GetTreatments();

            listBox1.Items.Clear();

            foreach (var t in treatments)
                listBox1.Items.Add(t);

            cn.Close();

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
                    case "Consulta":
                        ShowConsulta();
                        break;
                    case "Pagamento":
                        ShowPayment();
                        break;
                    case "Prescricao":
                        ShowPrescription();
                        break;
                    case "Especialidade":
                        ShowEspecialidade();
                        break;
                    case "Especie":
                        ShowEspecie();
                        break;
                    case "MetodoPagamento":
                        ShowMetodoPagamento();
                        break;
                    case "Tratamento":
                        ShowTratamento();
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

            List<Especialidade> especialidades = GetEspecialidades();

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

        private void LoadClinicasComboBox()
        {
            if (!verifySGBDConnection())
                return;

            medicoClinicaComboBox.Items.Clear();

            List<CliVet> clinicas = GetClinicasVeterinarias();

            foreach (var CV in clinicas)
            {
                medicoClinicaComboBox.Items.Add(CV);
            }

            if (option == "Edit")
            {
                for (int i = 0; i < medicoClinicaComboBox.Items.Count; i++)
                {
                    CliVet c = (CliVet)medicoClinicaComboBox.Items[i];
                    if (c.Nome == medicoClinicaText.Text)
                    {
                        medicoClinicaComboBox.SelectedIndex = i;
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

            List<Especie> especies = GetEspecies();

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

        private void LoadDonosComboBox()
        {
            if (!verifySGBDConnection())
                return;

            animalDonoComboBox.Items.Clear();

            List<Owner> owners = GetDonos();

            foreach (var o in owners)
            {
                animalDonoComboBox.Items.Add(o);
            }

            if (option == "Edit")
            {
                for (int i = 0; i < animalDonoComboBox.Items.Count; i++)
                {
                    Owner o = (Owner)animalDonoComboBox.Items[i];
                    if (o.Nome == animalDonoText.Text)
                    {
                        animalDonoComboBox.SelectedIndex = i;
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

            List<Pet> pets = GetAnimais();

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

            List<Vet> vets = GetMedicos();

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

            SqlCommand cmd = new SqlCommand("SP_GetPaymentAppointment", cn);
            cmd.CommandType = CommandType.StoredProcedure;
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

            List<Appointment> consultas = GetConsultas();

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

            List<PaymentMethod> methods = GetMetodosPagamento();

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
            cmd.CommandType = CommandType.StoredProcedure;
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
                    LoadClinicasComboBox();
                    break;
                case "Dono":
                    donoEditControls();
                    break;
                case "Animal":
                    animalEditControls();
                    LoadSexoComboBox();
                    LoadEspeciesComboBox();
                    LoadDonosComboBox();
                    break;
                case "Medicamento":
                    medicamentoEditControls();
                    break;
                case "Consulta":
                    consultaEditControls();
                    consultaDateTimePicker.Value = GetDateTimeById("SP_GetAppointmentDateById", "@appointmentID", int.Parse(consultaIdText.Text));
                    LoadAnimaisComboBox(consultaAnimaisComboBox, consultaAnimalText);
                    LoadMedicosComboBox(consultaMedicoComboBox, consultaMedicoText);
                    break;
                case "Pagamento":
                    pagamentoEditControls();
                    pagamentoDateTimePicker.Value = GetDateTimeById("SP_GetPaymentDate", "@PaymentId", int.Parse(pagamentoIdText.Text));
                    LoadEstadoComboBox();
                    LoadMetodoComboBox();
                    LoadConsultasComboBox();
                    break;
                case "Prescricao":
                    prescricaoEditControls();
                    prescricaoDateTimePicker.Value = GetDateTimeById("SP_GetPrescriptionDate", "@PrescriptionId", int.Parse(prescricaoNumeroText.Text));
                    LoadAnimaisComboBox(prescricaoAnimalComboBox, prescricaoAnimalText);
                    LoadMedicosComboBox(prescricaoMedicoComboBox, prescricaoMedicoText);
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
                    LoadClinicasComboBox();
                    break;
                case "Dono":
                    donoAddControls();
                    break;
                case "Animal":
                    animalAddControls();
                    LoadSexoComboBox();
                    LoadEspeciesComboBox();
                    LoadDonosComboBox();
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
                    break;
                case ("Add", "Tratamento"):
                    SimpleAddTuples("SP_AddTreatment", "Tratamento adicionado com sucesso!", "@TreatmentDescription", tratamentoDescricaoText);
                    break;
                default:
                    break;

            }
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
            SqlCommand cmd = new SqlCommand("SP_GetAppointmentTreatmentsById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
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
            SqlCommand cmd = new SqlCommand("SP_GetAppointmentReportById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
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
            SqlCommand cmd = new SqlCommand("SP_GetPaymentsByMethod", cn);
            cmd.CommandType = CommandType.StoredProcedure;
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
            SqlCommand cmd = new SqlCommand("SP_GetAppointmentsByTreatment", cn);
            cmd.CommandType = CommandType.StoredProcedure;
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
    }
}
