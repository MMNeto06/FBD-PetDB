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
    public partial class MedicoForm : Form
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
            this.Text = "Bem Vindo Médico";
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

            List<Appointment> consultas = GetConsultas();

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

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelTitleLabel.Text = "O seu perfil";
            consultasPanel.Visible = false;
            prescricoesPanel.Visible = false;
            perfilPanel.Visible = true;
            listBox1.Visible = false;
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
            prescricaoDateTimePicker.Visible = true;
            prescricaoAnimalComboBox.Visible = true;;
            prescricaoBtnEditarMedicamentos.Visible = true;
            prescricaoBtnVerMedicamentos.Visible = false;
            addBtn.Visible = false;
            editBtn.Visible = false;
            okBtn.Visible = true;
            cancelBtn.Visible = true;
        }

        private void prescricaoAddControls()
        {
            prescricaoEditControls();
            prescricaoBtnEditarMedicamentos.Enabled = false;
            prescricaoAnimalComboBox.SelectedIndex = -1;
        }

        private List<Appointment> GetConsultas()
        {
            if (!verifySGBDConnection())
                return null;

            List<Appointment> consultas = new List<Appointment>();

            SqlCommand cmd = new SqlCommand("EXEC SP_GetAppointmentsByVet " + omv, cn);
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
            prescricaoDataText.Text = prescription.Data;
            prescricaoAnimalText.Text = prescription.Animal;
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
                case "Consulta":
                    consultaEditControls();
                    consultaDateTimePicker.Value = GetDateTimeById("SP_GetAppointmentDateById", "@appointmentID", idConsulta);
                    LoadAnimaisComboBox(consultaAnimaisComboBox, consultaAnimalText);
                    break;
                case "Prescricao":
                    /*prescricaoEditControls();
                    prescricaoDateTimePicker.Value = GetDateTimeById("SP_GetPrescriptionDate", "@PrescriptionId", int.Parse(prescricaoNumeroText.Text));
                    LoadAnimaisComboBox(prescricaoAnimalComboBox, prescricaoAnimalText);*/
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
                case ("Add", "Consulta"):
                    //ConsultaTuples("SP_AddAppointment", "Consulta adicionada com sucesso!");
                    consultasToolStripMenuItem_Click(sender, e);
                    break;
                case ("Edit", "Consulta"):
                    //ConsultaTuples("SP_UpdateAppointment", "Informações atualizadas com sucesso!");
                    consultasToolStripMenuItem_Click(sender, e);
                    break;
                case ("Add", "Prescricao"):
                    //PrescricaoTuples("SP_AddPrescription", "Prescrição adicionada com sucesso!");
                    prescricoesToolStripMenuItem_Click(sender, e);
                    break;
                case ("Edit", "Prescricao"):
                    //PrescricaoTuples("SP_UpdatePrescription", "Informações atualizadas com sucesso!");
                    prescricoesToolStripMenuItem_Click(sender, e);
                    break;
                default:
                    break;

            }
        }

        private void consultaBtnEditarRelatorio_Click(object sender, EventArgs e)
        {

        }
    }
}
