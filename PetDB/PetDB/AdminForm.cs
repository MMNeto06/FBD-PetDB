using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
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

        private void consultaBaseControls()
        {
            consultaIdText.Enabled = false;
            consultaDataText.Enabled = false;
            consultaAnimalText.Enabled = false;
            consultaMedicoText.Enabled = false;
            generalBaseControls();
        }

        private void pagamentoBaseControls()
        {
            pagamentoIdText.Enabled = false;
            pagamentoValorText.Enabled = false;
            pagamentoDataText.Enabled = false;
            pagamentoEstadoText.Enabled = false;
            pagamentoMetodoText.Enabled = false;
            pagamentoAnimalText.Enabled = false;
            pagamentoMedicoText.Enabled = false;
            generalBaseControls();
        }

        // falta corrigir, por dropdowns
        private void pagamentoEditControls()
        {
            pagamentoValorText.Enabled = true;
            pagamentoDataText.Enabled = true;
            pagamentoEstadoText.Enabled = true;
            pagamentoMetodoText.Enabled = true;
            pagamentoAnimalText.Enabled = true;
            pagamentoMedicoText.Enabled = true;
            generalEditControls();
        }

        // TODO 
        /*private void pagamentoAddControls()
        {

        }*/

        private void prescricaoBaseControls()
        {
            prescricaoNumeroText.Enabled = false;
            prescricaoDataText.Enabled = false;
            prescricaoAnimalText.Enabled = false;
            generalBaseControls();
        }

        /*TODO
        private void prescricaoEditControls()
        {

        }*/

        /* TODO
        private void prescricaoAddControls()
        {

        }*/

        private void especialidadeBaseControls()
        {
            especialidadeCodigoText.Enabled = false;
            especialidadeDescricaoText.Enabled = false;
            generalBaseControls();
        }

        /*TODO
        private void especialidadeEditControls()
        {

        }*/

        /* TODO
        private void especialidadeAddControls()
        {

        }*/

        private void especieBaseControls()
        {
            especieCodigoText.Enabled = false;
            especieDescricaoText.Enabled = false;
            generalBaseControls();
        }

        /*TODO
        private void especieEditControls()
        {

        }*/

        /* TODO
        private void especieAddControls()
        {

        }*/

        private void backBtn_Click(object sender, EventArgs e)
        {
            loginPage.Show();
            this.Close();
        }

        private List<String> getAppointmentTreatmentsById(int appointmentId)
        {
            if (!verifySGBDConnection())
                return null;

            List<String> treatments = new List<String>();
            SqlCommand cmd = new SqlCommand("SP_GetAppointmentTreatmentsById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@appointmentID", appointmentId);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                treatments.Add(reader["Descricao"].ToString());
            }

            cn.Close();

            return treatments;

        }

        private String getAppointmentReportById(int appointmentId)
        {
            if (!verifySGBDConnection())
                return null;

            String reportContent = "Inválido!";
            SqlCommand cmd = new SqlCommand("SP_GetAppointmentReportById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@appointmentID", appointmentId);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                reportContent = reader["Conteudo"].ToString();
            }

            cn.Close();

            return reportContent;
        }

        private List<String> getPrescriptionMedsById(int appointmentId)
        {
            if (!verifySGBDConnection())
                return null;

            List<String> meds = new List<String>();
            SqlCommand cmd = new SqlCommand("SP_GetPrescriptionMedsById", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@prescriptionID", appointmentId);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                meds.Add(reader["Descricao"].ToString());
            }

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
                pet.DataNascimento = ((DateTime)reader["DataNascimento"]).ToString("dd/MM/yyyy");
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

        private void consultaTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            entity = "Consulta";
            consultaBaseControls();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetAppointmentInfo", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                Appointment ap = new Appointment();
                ap.Id = reader["Id"].ToString();
                ap.Data = reader["Data"].ToString();
                ap.Animal = reader["Animal"].ToString();
                ap.Medico = reader["Medico"].ToString();
                listBox1.Items.Add(ap);
            }

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
                listBox1.Items.Add(prescription);
            }

            cn.Close();

            currentListIndex = 0;
            ShowPrescription();
        }

        private List<Especialidade> getEspecialidades()
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

            cn.Close();

            return especialidades;
        }

        private void especialidadeTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            entity = "Especialidade";
            especialidadeBaseControls();
            List<Especialidade> especialidades = getEspecialidades();

            listBox1.Items.Clear();

            foreach (var especialidade in especialidades)
                listBox1.Items.Add(especialidade);

            cn.Close();

            currentListIndex = 0;
            ShowEspecialidade();
        }

        private void especieTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            entity = "Especie";
            especieBaseControls();
            SqlCommand cmd = new SqlCommand("EXEC SP_GetSpecieInfo", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                Especie especie = new Especie();
                especie.Codigo = reader["Codigo"].ToString();
                especie.Descricao = reader["Descricao"].ToString();
                listBox1.Items.Add(especie);
            }

            cn.Close();

            currentListIndex = 0;
            ShowEspecie();
        }

        private void ShowClinicaVeterinaria()
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

        private void ShowVet()
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

        private void ShowOwner()
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

        private void ShowPet()
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

        private void ShowMed()
        {
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;
            Med med = new Med();
            med = (Med)listBox1.Items[currentListIndex];
            medicamentoCodigoText.Text = med.Codigo;
            medicamentoNomeText.Text = med.Nome;
            medicamentoDoseText.Text = med.Dose;
        }

        private void ShowConsulta()
        {
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
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
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
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
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;

            Prescription prescription = new Prescription();
            prescription = (Prescription)listBox1.Items[currentListIndex];
            prescricaoNumeroText.Text = prescription.Numero;
            prescricaoDataText.Text = prescription.Data;
            prescricaoAnimalText.Text = prescription.Animal;
        }

        private void ShowEspecialidade()
        {
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;

            Especialidade especialidade = new Especialidade();
            especialidade = (Especialidade)listBox1.Items[currentListIndex];
            especialidadeCodigoText.Text = especialidade.Codigo;
            especialidadeDescricaoText.Text = especialidade.Descricao;
        }

        private void ShowEspecie()
        {
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;

            Especie especie = new Especie();
            especie = (Especie)listBox1.Items[currentListIndex];
            especieCodigoText.Text = especie.Codigo;
            especieDescricaoText.Text = especie.Descricao;
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

                    default:
                        break;
                }
            }
        }

        private void LoadEspecialidadesComboBox()
        {
            if (!verifySGBDConnection())
                return;

            List<Especialidade> especialidades = getEspecialidades();

            foreach (var e in especialidades)
            {
                medicoEspecialidadeComboBox.Items.Add(e);
            }

            for (int i = 0; i < medicoEspecialidadeComboBox.Items.Count; i++)
            {
                Especialidade e = (Especialidade)medicoEspecialidadeComboBox.Items[i];
                if (e.Descricao == medicoEspecialidadeText.Text)
                {
                    medicoEspecialidadeComboBox.SelectedIndex = i;
                    break;
                }
            }

            cn.Close();
        }

        private void LoadClinicasComboBox()
        {
            if (!verifySGBDConnection())
                return;

            List<CliVet> clinicas = GetClinicasVeterinarias();

            foreach (var CV in clinicas)
            {
                medicoClinicaComboBox.Items.Add(CV);
            }

            for (int i = 0; i < medicoClinicaComboBox.Items.Count; i++)
            {
                CliVet c = (CliVet)medicoClinicaComboBox.Items[i];
                if (c.Nome == medicoClinicaText.Text)
                {
                    medicoClinicaComboBox.SelectedIndex = i;
                    break;
                }
            }

            cn.Close();
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
                    break;
                case "Medicamento":
                    medicamentoEditControls();
                    break;
                case "Consulta":
                    //consultaEditControls();
                    break;
                case "Pagamento":
                    pagamentoEditControls();
                    break;
                case "Prescricao":
                    //prescricaoEditControls();
                    break;
                case "Especialidade":
                    //especialidadeEditControls();
                    break;
                case "Especie":
                    //especieEditControls();
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

                default: break;
            }
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
                    LoadEspecialidadesComboBox();
                    LoadClinicasComboBox();
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
                case "Consulta":
                    //consultaAddControls();
                    break;
                case "Pagamento":
                    //pagamentoAddControls();
                    break;
                case "Prescricao":
                    //prescricaoAddControls();
                    break;
                case "Especialidade":
                    //especialidadeAddControls(); 
                    break;
                case "Especie":
                    //especieAddControls(); 
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
                cmd.Parameters.AddWithValue("@PetNumero", animalNumeroText.Text);
            }
            cmd.Parameters.AddWithValue("@PetName", animalNomeText.Text);
            cmd.Parameters.AddWithValue("@OwnerPhone", donoTelefoneText.Text);
            cmd.Parameters.AddWithValue("@OwnerEmail", donoEmailText.Text);
            cmd.Parameters.AddWithValue("@OwnerAddress", donoEnderecoText.Text);

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
                default: break;
            }
        }

        private void btnVerTratamentos_Click(object sender, EventArgs e)
        {
            int idConsulta = Int32.Parse(consultaIdText.Text);

            List<String> treatments = getAppointmentTreatmentsById(idConsulta);

            UC_ListStrings uc = new UC_ListStrings();
            uc.setStrings(treatments);

            PopUpForm popup = new PopUpForm(uc, "Tratamentos da Consulta");
            popup.ShowDialog();

        }

        private void btnConsultarRelatorio_Click(object sender, EventArgs e)
        {
            int idConsulta = Int32.Parse(consultaIdText.Text);

            String reportContent = getAppointmentReportById(idConsulta);

            UC_ShowReport uc = new UC_ShowReport();
            uc.setReportText(reportContent);

            PopUpForm popup = new PopUpForm(uc, "Relatório da Consulta");
            popup.ShowDialog();
        }

        private void btnVerMedicamentos_Click(object sender, EventArgs e)
        {
            int idPrescricao = Int32.Parse(prescricaoNumeroText.Text);

            List<String> meds = getPrescriptionMedsById(idPrescricao);

            UC_ListStrings uc = new UC_ListStrings();
            uc.setStrings(meds);

            PopUpForm popup = new PopUpForm(uc, "Medicamentos da Prescrição");
            popup.ShowDialog();
        }

        private void btnConsultarMedicos_Click(object sender, EventArgs e)
        {
            int especialidade = Int32.Parse(especialidadeCodigoText.Text);

            List<String> vets = getVetsBySpeciality(especialidade);

            UC_ListStrings uc = new UC_ListStrings();
            uc.setStrings(vets);

            PopUpForm popup = new PopUpForm(uc, "Médicos");
            popup.ShowDialog();

        }

        private void btnConsultaAnimais_Click(object sender, EventArgs e)
        {
            int especie = Int32.Parse(especieCodigoText.Text);

            List<String> animais = getAnimalsBySpecie(especie);

            UC_ListStrings uc = new UC_ListStrings();
            uc.setStrings(animais);

            PopUpForm popup = new PopUpForm(uc, "Animais");
            popup.ShowDialog();

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
    }
}
