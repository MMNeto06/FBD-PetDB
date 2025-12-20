using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PetDB
{
    public partial class MedicoForm : Form, IAppointmentForm, IMedForm
    {
        private Login loginPage;
        private int omv, currentListIndex, idConsulta;
        private SqlConnection cn;
        private String entity = "Consulta";
        private String option = "Add";
        public MedicoForm(Login loginPage, int omv)
        {
            InitializeComponent();
            this.loginPage = loginPage;
            this.omv = omv;
            //this.Text = "Bem Vindo Médico";
            consultasToolStripMenuItem_Click(this, new EventArgs());
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            loginPage.Show();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            loginPage.Show();
            this.Close();
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

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelTitleLabel.Text = "Consultas";
            consultasPanel.Visible = true;
            prescricoesPanel.Visible = false;
            perfilPanel.Visible = false;
            listBox1.Visible = true;
            if (!verifySGBDConnection())
                return;

            entity = "Consulta";
            consultaBaseControls();
            listBox1.Items.Clear();

            List<Appointment> consultas = GetConsultas(null);

            foreach (var c in consultas)
                listBox1.Items.Add(c);

            cn.Close();

            currentListIndex = 0;
            ShowConsulta();
        }

        private void prescricoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelTitleLabel.Text = "Prescrições";
            consultasPanel.Visible = false;
            prescricoesPanel.Visible = true;
            perfilPanel.Visible = false;
            listBox1.Visible = true;

            if (!verifySGBDConnection())
                return;

            entity = "Prescricao";
            prescricaoBaseControls();
            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetPrescriptionInfo(NULL, @VetOMV, DEFAULT, NULL) ORDER BY [Data] DESC", cn);
            cmd.Parameters.AddWithValue("@VetOMV", omv);
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

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelTitleLabel.Text = "O seu perfil";
            consultasPanel.Visible = false;
            prescricoesPanel.Visible = false;
            perfilPanel.Visible = true;
            listBox1.Visible = false;
            medicoBaseControls();

            entity = "Medico";
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetVetInfo(NULL, @VetOMV, DEFAULT, NULL) ORDER BY NOME", cn);
            cmd.Parameters.AddWithValue("@VetOMV", omv);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                medicoNomeText.Text = reader["Nome"].ToString();
                medicoTelefoneText.Text = reader["Telefone"].ToString();
                medicoEmailText.Text = reader["Email"].ToString();
                medicoEspecialidadeText.Text = reader["Especialidade"].ToString();
                medicoClinicaText.Text = reader["Clinica"].ToString();
            }
            reader.Close();
            cn.Close();

        }

        private void consultaBaseControls()
        {
            consultaDataText.Visible = true;
            consultaAnimalText.Visible = true;
            btnVerTratamentos.Visible = true;
            btnConsultarRelatorio.Visible = true;
            consultaDataText.Enabled = false;
            consultaAnimalText.Enabled = false;
            consultaDateTimePicker.Visible = false;
            consultaAnimaisComboBox.Visible = false;
            consultaBtnEditarRelatorio.Visible = false;
            consultaBtnEditarTratamentos.Visible = false;
            addBtn.Visible = true;
            editBtn.Visible = true;
            okBtn.Visible = false;
            cancelBtn.Visible = false;
        }

        private void consultaEditControls()
        {
            consultaDataText.Visible = false;
            consultaAnimalText.Visible = false;
            btnVerTratamentos.Visible = false;
            btnConsultarRelatorio.Visible = false;
            consultaDateTimePicker.Visible = true;
            consultaDateTimePicker.Format = DateTimePickerFormat.Custom;
            consultaDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            consultaDateTimePicker.ShowUpDown = true;
            consultaAnimaisComboBox.Visible = true;
            consultaBtnEditarRelatorio.Visible = true;
            consultaBtnEditarTratamentos.Visible = true;
            consultaBtnEditarRelatorio.Enabled = true;
            consultaBtnEditarTratamentos.Enabled = true;
            addBtn.Visible = false;
            editBtn.Visible = false;
            okBtn.Visible = true;
            cancelBtn.Visible = true;
        }

        private void consultaAddControls()
        {
            consultaEditControls();
            consultaBtnEditarRelatorio.Enabled = false;
            consultaBtnEditarTratamentos.Enabled = false;
        }

        private void prescricaoBaseControls()
        {
            prescricaoAnimalComboBox.Visible = false;
            prescricaoNumeroText.Enabled = false;
            prescricaoDataText.Enabled = false;
            prescricaoDateTimePicker.Visible = false;
            prescricaoAnimalText.Enabled = false;
            prescricaoBtnVerMedicamentos.Visible = true;
            prescricaoBtnEditarMedicamentos.Visible = false;
            addBtn.Visible = true;
            editBtn.Visible = true;
            okBtn.Visible = false;
            cancelBtn.Visible = false;
        }

        private void prescricaoEditControls()
        {
            prescricaoNumeroText.Enabled = true;
            prescricaoDateTimePicker.Visible = true;
            prescricaoAnimalComboBox.Visible = true;
            prescricaoBtnEditarMedicamentos.Visible = true;
            prescricaoBtnEditarMedicamentos.Enabled = true;
            prescricaoBtnVerMedicamentos.Visible = false;
            addBtn.Visible = false;
            editBtn.Visible = false;
            okBtn.Visible = true;
            cancelBtn.Visible = true;
        }

        private void prescricaoAddControls()
        {
            prescricaoEditControls();
            prescricaoNumeroText.Text = "";
            prescricaoBtnEditarMedicamentos.Enabled = false;
            prescricaoAnimalComboBox.SelectedIndex = -1;
        }

        private void medicoBaseControls()
        {
            medicoNomeText.Enabled = false;
            medicoTelefoneText.Enabled = false;
            medicoEmailText.Enabled = false;
            medicoEspecialidadeText.Enabled = false;
            medicoClinicaText.Enabled = false;
            medicoClinicaText.Visible = true;
            medicoEspecialidadeComboBox.Visible = false;
            medicoClinicaComboBox.Visible = false;
            addBtn.Visible = false;
            editBtn.Visible = true;
            okBtn.Visible = false;
            cancelBtn.Visible = false;
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
            addBtn.Visible = false;
            editBtn.Visible = false;
            okBtn.Visible = true;
            cancelBtn.Visible = true;
        }

        private List<Appointment> GetConsultas(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Appointment> consultas = new List<Appointment>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetAppointmentInfo(DEFAULT, @VetOMV, DEFAULT, DEFAULT, DEFAULT) ORDER BY [Data] DESC", cn);
            cmd.Parameters.AddWithValue("@VetOMV", omv);
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

        private void ShowConsulta()
        {
            if (listBox1.Items.Count == 0 || currentListIndex < 0)
                return;
            Appointment ap = new Appointment();
            ap = (Appointment)listBox1.Items[currentListIndex];
            idConsulta = Int32.Parse(ap.Id);
            consultaDataText.Text = ap.Data;
            consultaAnimalText.Text = ap.Animal;
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
        }

        private String getAppointmentReportById(int appointmentId)
        {
            if (!verifySGBDConnection())
                return null;

            String reportContent = "";
            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetAppointmentReportById(@appointmentID)", cn);
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

        private List<Treatment> getAppointmentTreatmentsById(int appointmentId)
        {
            if (!verifySGBDConnection())
                return null;

            List<Treatment> treatments = new List<Treatment>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetAppointmentTreatmentsById(@appointmentID) ORDER BY Descricao", cn);
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

        private List<Med> getPrescriptionMedsById(int prescriptionId)
        {
            if (!verifySGBDConnection())
                return null;

            List<Med> meds = new List<Med>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetPrescriptionMedsById(@prescriptionID) ORDER BY Descricao", cn);
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
        public List<Med> GetMeds(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Med> meds = new List<Med>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetMedInfo() ORDER BY Nome", cn);
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

        private void btnVerMedicamentos_Click(object sender, EventArgs e)
        {
            int idPrescricao;
            try
            {
                idPrescricao = Int32.Parse(prescricaoNumeroText.Text);

            }
            catch
            {
                return;
            }

            List<Med> meds = getPrescriptionMedsById(idPrescricao);

            UC_ListMeds uc = new UC_ListMeds();
            uc.SetMainForm(this);
            uc.SetMeds(meds);
            uc.SetMethod("View");

            PopUpForm popup = new PopUpForm(uc, "Medicamentos da Prescrição");
            popup.ShowDialog();
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

                cmd.Parameters.AddWithValue("@PrescriptionVet", omv);

            if (ExecuteInsertSP(cmd))
            {
                MessageBox.Show(msgShow);
            }

            cn.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                currentListIndex = listBox1.SelectedIndex;
                switch (entity)
                {
                    case "Consulta":
                        ShowConsulta();
                        break;
                    case "Prescricao":
                        ShowPrescription();
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnConsultarRelatorio_Click(object sender, EventArgs e)
        {
            String reportContent = getAppointmentReportById(idConsulta);

            UC_ShowReport uc = new UC_ShowReport();
            uc.setReportText(reportContent);
            uc.SetMethod("View");

            PopUpForm popup = new PopUpForm(uc, "Relatório da Consulta");
            popup.ShowDialog();
        }

        private void btnVerTratamentos_Click(object sender, EventArgs e)
        {
            List<Treatment> treatments = getAppointmentTreatmentsById(idConsulta);

            UC_ListTreatments uc = new UC_ListTreatments();
            uc.SetMode("View");
            uc.SetTreatments(treatments);

            PopUpForm popup = new PopUpForm(uc, "Tratamentos da Consulta");
            popup.ShowDialog();

        }

        private List<Pet> GetAnimais()
        {
            if (!verifySGBDConnection())
                return null;

            List<Pet> pets = new List<Pet>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetPetInfo() ORDER BY Nome", cn);
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
                case "Medico":
                    medicoEditControls();
                    LoadEspecialidadesComboBox();
                    LoadClinicasComboBox(medicoClinicaComboBox, medicoClinicaText);
                    break;
                case "Consulta":
                    consultaEditControls();
                    consultaDateTimePicker.Value = GetDateTimeById("SELECT * FROM fn_GetAppointmentDateById(@appointmentID)", "@appointmentID", idConsulta);
                    LoadAnimaisComboBox(consultaAnimaisComboBox, consultaAnimalText);
                    break;
                case "Prescricao":
                    prescricaoEditControls();
                    prescricaoDateTimePicker.Value = GetDateTimeById("SELECT * FRPM fn_GetPrescriptionDate(@appointmentID)", "@PrescriptionId", int.Parse(prescricaoNumeroText.Text));
                    LoadAnimaisComboBox(prescricaoAnimalComboBox, prescricaoAnimalText);
                    break;
                default: break;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            switch (entity)
            {
                case "Consulta":
                    consultaBaseControls();
                    ShowConsulta();
                    break;
                case "Prescricao":
                    prescricaoBaseControls();
                    ShowPrescription();
                    break;
                case "Medico":
                    perfilToolStripMenuItem_Click(sender, e);
                    break;
                default: break;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            option = "Add";
            switch (entity)
            {
                case "Consulta":
                    consultaAddControls();
                    consultaDateTimePicker.Value = DateTime.UtcNow;
                    LoadAnimaisComboBox(consultaAnimaisComboBox, consultaAnimalText);
                    break;
                case "Prescricao":
                    prescricaoAddControls();
                    prescricaoDateTimePicker.Value = DateTime.UtcNow.Date;
                    LoadAnimaisComboBox(prescricaoAnimalComboBox, consultaAnimalText);
                    break;
                default: break;
            }
        }

        private void OkBtn_Click(object sender, EventArgs e) //POR DESCOMENTAR
        {
            switch ((option, entity))
            {
                case ("Edit", "Medico"):
                    MedicoTuples("SP_UpdateVet", "Informações atualizadas com sucesso!");
                    perfilToolStripMenuItem_Click(sender, e);
                    break;
                case ("Add", "Consulta"):
                    ConsultaTuples("SP_AddAppointment", "Consulta adicionada com sucesso!");
                    consultasToolStripMenuItem_Click(sender, e);
                    break;
                case ("Edit", "Consulta"):
                    ConsultaTuples("SP_UpdateAppointment", "Informações atualizadas com sucesso!");
                    consultasToolStripMenuItem_Click(sender, e);
                    break;
                case ("Add", "Prescricao"):
                    PrescricaoTuples("SP_AddPrescription", "Prescrição adicionada com sucesso!");
                    prescricoesToolStripMenuItem_Click(sender, e);
                    break;
                case ("Edit", "Prescricao"):
                    PrescricaoTuples("SP_UpdatePrescription", "Informações atualizadas com sucesso!");
                    prescricoesToolStripMenuItem_Click(sender, e);
                    break;
                default:
                    break;

            }
        }

        private void ConsultaTuples(String sp, String msgShow)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (sp == "SP_UpdateAppointment")
            {
                cmd.Parameters.AddWithValue("@AppointmentID", idConsulta);
            }
            cmd.Parameters.AddWithValue("@AppointmentDate", consultaDateTimePicker.Value);
            Pet p = (Pet)consultaAnimaisComboBox.SelectedItem;
            cmd.Parameters.AddWithValue("@AppointmentPet", p.Numero);
            cmd.Parameters.AddWithValue("@AppointmentVet", omv);

            if (ExecuteInsertSP(cmd))
            {
                MessageBox.Show(msgShow);
            }

            cn.Close();
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

        private void consultaBtnEditarRelatorio_Click(object sender, EventArgs e)
        {
            UC_ShowReport uc = new UC_ShowReport();

            uc.SetMainForm(this);
            uc.setReportText(getAppointmentReportById(idConsulta));
            uc.SetMethod("Edit");

            PopUpForm popup = new PopUpForm(uc, "Editar Relatório");
            popup.ShowDialog();
        }

        private void btnEditarTratamentos_Click(object sender, EventArgs e)
        {
            List<Treatment> treatments = getAppointmentTreatmentsById(idConsulta);

            UC_ListTreatments uc = new UC_ListTreatments();
            uc.SetMode("Edit");
            uc.SetForm(this);
            uc.SetTreatments(treatments);

            PopUpForm popup = new PopUpForm(uc, "Tratamentos da Consulta");
            popup.ShowDialog();
        }

        public List<Treatment> GetTreatments(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Treatment> treatments = new List<Treatment>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetTreatments()", cn);
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

        public void AddTreatmentToAppointment(Treatment treatment, UC_ListTreatments uc)
        {
            if (!verifySGBDConnection())
                return;

            int appointmentId = idConsulta;

            SqlCommand cmd = new SqlCommand("SP_AddTreatmentToAppointment", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
            cmd.Parameters.AddWithValue("@TreatmentID", int.Parse(treatment.Codigo));
            ExecuteInsertSP(cmd);

            uc.SetTreatments(getAppointmentTreatmentsById(appointmentId));

            cn.Close();
        }

        public void UpdateReport(String reportContent)
        {
            if (!verifySGBDConnection())
                return;

            int appointmentId = idConsulta;

            SqlCommand cmd = new SqlCommand("SP_UpdateReport", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
            cmd.Parameters.AddWithValue("@reportContent", reportContent);
            ExecuteInsertSP(cmd);

            cn.Close();
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

        private void LoadClinicasComboBox(ComboBox cb, TextBox clinicName)
        {
            if (!verifySGBDConnection())
                return;

            cb.Items.Clear();

            List<CliVet> clinicas = GetClinicasVeterinarias();

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

        private List<CliVet> GetClinicasVeterinarias()
        {
            if (!verifySGBDConnection())
                return null;

            List<CliVet> clinicas = new List<CliVet>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetClinicTable(DEFAULT, DEFAULT) ORDER BY Nome", cn);
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

        private List<Especialidade> GetEspecialidades()
        {
            if (!verifySGBDConnection())
                return null;

            List<Especialidade> especialidades = new List<Especialidade>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetSpecialityInfo(DEFAULT, DEFAULT) ORDER BY Descricao", cn);
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

        private void MedicoTuples(String sp, String msgShow)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VetOMV", omv);
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
    }
}
