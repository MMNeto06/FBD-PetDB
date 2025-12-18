using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PetDB
{
    public partial class ClinicaForm : AdminForm
    {
        private int nif;
        private String option = "";
        private String entity = "";
        private String tab = "";
        private int currentListIndex;
        private SqlConnection cn;

        public ClinicaForm(Login loginPage, int nif) : base()
        {
            InitializeComponent();
            base.loginPage = loginPage;
            this.nif = nif;
            registarTabControl.TabPages.Remove(clinicaTabPage);
            medicoBaseControls();
            registarToolStripMenuItem_Click(null, null); 
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e); 
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


        private void backBtn_Click(object sender, EventArgs e)
        {
            loginPage.Show();
            this.Close();
        }

        protected override void SelecionarRegistarAbaInicial(object sender, EventArgs e)
        {
            medicoVeterinarioTab_Click(sender, e); 
        }

        protected override List<Vet> GetMedicos()
        {
            if (!verifySGBDConnection())
                return null;

            List<Vet> vets = new List<Vet>();

            SqlCommand cmd = new SqlCommand("SP_GetVetInfo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClinicNIF", this.nif); 
            if (tab == "Restaurar")
            {
                cmd.Parameters.AddWithValue("@IsActive", 0);
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

        protected override void registarTabControl_onSelectedIndexChange(object sender, EventArgs e)
        {
            int selectedTabIndex = registarTabControl.SelectedIndex;
            switch (selectedTabIndex)
            {
                case 0: //Medico
                    medicoVeterinarioTab_Click(sender, e);
                    break;
                /*case 1: //Dono
                    donoTab_Click(sender, e);
                    break;
                case 2: // Animal
                    animalTab_Click(sender, e);
                    break;
                case 3: // Medicamento
                    medTab_Click(sender, e);
                    break;
                case 4: // Consulta
                    consultaTab_Click(sender, e);
                    break;
                case 5: // Pagamento
                    pagamentoTab_Click(sender, e);
                    break;
                case 6: // Prescricao
                    prescricaoTab_Click(sender, e);
                    break;
                case 7: // Especialidade
                    especialidadeTab_Click(sender, e);
                    break;
                case 8: // Especie
                    especieTab_Click(sender, e);
                    break;
                case 9: // Metodo Pagamento
                    metodoPagamentoTab_Click(sender, e);
                    break;
                case 10: // Tratamento
                    tratamentoTab_Click(sender, e);
                    break;*/
                default: break;
            }
        }

    }
}
