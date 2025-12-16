using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PetDB
{
    public partial class UC_AnimalInfo : UserControl
    {
        private Pet _animal;
        private SqlConnection cn;
        private int currentListIndex;
        private int idConsulta, idPrescricao;
        String entity = "Consulta";
        public UC_AnimalInfo(Pet pet)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this._animal = pet;
            loadEverything();
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

        public void loadEverything()
        {
            animalNumeroText.Text = _animal.Numero;
            animalNomeText.Text = _animal.Nome;
            animalSexoText.Text = _animal.Sexo;
            animalPesoText.Text = _animal.Peso;
            animalDataNascimentoText.Text = _animal.DataNascimento;
            animalEspecieText.Text = _animal.Especie;
            consultaTab_Click(null, null);
        }

        private void tabControl_onSelectedIndexChange(object sender, EventArgs e)
        {
            int selectedTabIndex = tabControl.SelectedIndex;
            switch (selectedTabIndex)
            {
                case 0: // Consulta
                    consultaTab_Click(sender, e);
                    break;
                case 1: // Prescricao
                    prescricaoTab_Click(sender, e);
                    break;
                default: break;
            }
        }

        private void consultaTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            entity = "Consulta";
            SqlCommand cmd = new SqlCommand("EXEC SP_GetAppointmentInfoByAnimal " + _animal.Numero, cn);
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

        private void ShowConsulta()
        {
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;
            Appointment ap = new Appointment();
            ap = (Appointment)listBox1.Items[currentListIndex];
            idConsulta = Int32.Parse(ap.Id);
            consultaDataText.Text = ap.Data;
            consultaMedicoText.Text = ap.Medico;
        }

        private void prescricaoTab_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            entity = "Prescricao";
            SqlCommand cmd = new SqlCommand("EXEC SP_GetPrescriptionsByPet " + _animal.Numero, cn);
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

        private void ShowPrescription()
        {
            if (listBox1.Items.Count == 0 | currentListIndex < 0)
                return;

            Prescription prescription = new Prescription();
            prescription = (Prescription)listBox1.Items[currentListIndex];
            idPrescricao = Int32.Parse(prescription.Numero);
            prescricaoDataText.Text = prescription.Data;
        }

        private void btnVerMedicamentos_Click(object sender, EventArgs e)
        {

            List<String> meds = getPrescriptionMedsById(idPrescricao);

            UC_ListStrings uc = new UC_ListStrings();
            uc.SetStrings(meds);

            PopUpForm popup = new PopUpForm(uc, "Medicamentos da Prescrição");
            popup.ShowDialog();
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

        private void btnVerTratamentos_Click(object sender, EventArgs e)
        {
            List<String> treatments = getAppointmentTreatmentsById(idConsulta);

            UC_ListStrings uc = new UC_ListStrings();
            uc.SetStrings(treatments);

            PopUpForm popup = new PopUpForm(uc, "Tratamentos da Consulta");
            popup.ShowDialog();

        }

        private void btnConsultarRelatorio_Click(object sender, EventArgs e)
        {
            String reportContent = getAppointmentReportById(idConsulta);

            UC_ShowReport uc = new UC_ShowReport();
            uc.setReportText(reportContent);

            PopUpForm popup = new PopUpForm(uc, "Relatório da Consulta");
            popup.ShowDialog();
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
                        //ShowPrescription();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
