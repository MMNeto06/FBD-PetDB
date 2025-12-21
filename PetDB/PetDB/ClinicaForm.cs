using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PetDB
{
    public partial class ClinicaForm : AdminForm
    {
        private int nif;
        private SqlConnection cn;

        public ClinicaForm(Login loginPage, int nif) : base()
        {
            InitializeComponent();
            base.loginPage = loginPage;
            this.nif = nif;
            base.nif = this.nif;
            this.Text = "Bem-Vindo " + GetThisClinicName();
            restaurarToolStripMenuItem.Text = "Histórico";
            auditLogToolStripMenuItem.Visible = false;
            auditLogToolStripMenuItem.Enabled = false;
            btnRestaurar.Visible = false;
            medicoClinicaComboBox.Visible = false;
            registarTabControl.TabPages.Remove(clinicaTabPage);
            consultarTabControl.TabPages.Remove(consultarVetCliTabPage);
            consultarTabControl.TabPages.Remove(consultarAnimaisClinicaTabPage);
            ToolStripMenuItem perfilItem = new ToolStripMenuItem("Perfil");
            perfilItem.Name = "perfilToolStripMenuItem";
            perfilItem.Alignment = ToolStripItemAlignment.Left;
            perfilItem.Click += new EventHandler(perfilToolStripMenuItem_Click);
            this.menuStrip1.Items.Add(perfilItem);
            perfilPanel.Visible = false;
            medicoBaseControls();
            registarToolStripMenuItem_Click(null, null);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source=tcp:mednat.ieeta.pt\\SQLSERVER,8101;Persist Security Info=True;User ID=p2g2;Password=V@ndalism0;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=30");
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

        protected override void AtualizarBotoesAcao()
        {
            string[] abasBloqueadas = { "Medicamento", "Especialidade", "Especie" };
            string[] restrictedAbas = { "Pagamento", "Prescricao", "MetodoPagamento", "Tratamento"};
            if (abasBloqueadas.Contains(base.entity))
            {
                addBtn.Visible = false;
                editBtn.Visible = false;
                remBtn.Visible = false;
            } else if (restrictedAbas.Contains(base.entity))
            {
                addBtn.Visible = true;
                editBtn.Visible = false;
                remBtn.Visible = false;
            } else
            {
                addBtn.Visible = true;
                editBtn.Visible = true;
                remBtn.Visible = true;
            }

            if (base.entity != "PerfilClinica")
            {
                perfilPanel.Visible = false;
            }
            else
                perfilPanel.Visible = true; 
        }

        private String GetThisClinicName()
        {
            List<CliVet> cvs = GetClinicasVeterinarias("");

            foreach (var cv in cvs)
            {
                if (int.Parse(cv.NIF) == this.nif)
                    return cv.Nome;
            }

            return "";
        }

        protected override void SelecionarRegistarAbaInicial(object sender, EventArgs e)
        {
            medicoVeterinarioTab_Click(sender, e);
        }

        protected override void MedicoClinicaComboBoxVisible()
        {
            medicoClinicaComboBox.Enabled = false;
        }

        protected override void MedicoClinicaNomeTextEnabled()
        {
            medicoClinicaText.Enabled = false;
        }

        protected override void MedicoClinicaText()
        {
            medicoClinicaText.Text = GetThisClinicName();
        }

        protected override List<Vet> GetMedicos(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Vet> vets = new List<Vet>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetVetInfo(@ClinicNIF, @VetOMV, @IsActive, @Search) ORDER BY Nome", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ClinicNIF", SqlDbType.Int).Value = this.nif;
            cmd.Parameters.Add("@VetOMV", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = (base.tab == "Restaurar") ? 0 : 1;
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


        protected override List<Appointment> GetConsultas(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Appointment> consultas = new List<Appointment>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetAppointmentInfo(NULL, NULL, @ClinicNIF, @IsActive, @Search) ORDER BY [Data] DESC", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ClinicNIF", SqlDbType.Int).Value = this.nif;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = (base.tab == "Restaurar") ? 0 : 1;
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

        protected override List<Payment> GetPayments(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Payment> payments = new List<Payment>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetPaymentInfo(NULL, @ClinicNIF, @IsActive, @Search) ORDER BY [Data] DESC", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ClinicNIF", SqlDbType.Int).Value = this.nif;
            if (base.tab == "Restaurar")
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
                payments.Add(payment);
            }
            reader.Close();
            cn.Close();

            return payments;
        }

        protected override List<Prescription> GetPrescriptions(String searchContent)
        {
            if (!verifySGBDConnection())
                return null;

            List<Prescription> prescriptions = new List<Prescription>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetPrescriptionInfo(NULL, NULL, @ClinicNIF, @IsActive, @Search) ORDER BY [Data] DESC", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ClinicNIF", SqlDbType.Int).Value = this.nif;
            if (base.tab == "Restaurar")
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
                prescriptions.Add(prescription);
            }
            reader.Close();
            cn.Close();

            return prescriptions;
        }

        protected override void registarTabControl_onSelectedIndexChange(object sender, EventArgs e)
        {
            int selectedTabIndex = registarTabControl.SelectedIndex;
            switch (selectedTabIndex)
            {
                case 0: //Medico
                    medicoVeterinarioTab_Click(sender, e);
                    break;
                case 1: //Dono
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
                    break;
                default: break;
            }
        }

        protected override void SetPrimeiraAbaConsultar(object sender, EventArgs e)
        {
            consultarAnimaisDonoTabPage_Click(sender, e);
        }


        protected override void consultarTabControl_onSelectedIndexChange(object sender, EventArgs e)
        {
            int selectedTabIndex = consultarTabControl.SelectedIndex;
            switch (selectedTabIndex)
            {
                case 0: // Animais por Dono
                    consultarAnimaisDonoTabPage_Click(sender, e);
                    break;
                case 1: // Consultas por Animal
                    consultarConsultasAnimalTabPage_Click(sender, e);
                    break;
                case 2: // Consultas por Medico
                    consultarConsultasVetTabPage_Click(sender, e);
                    break;
                case 3: // Prescricao por Animal
                    consultarPrescricoesAnimalTabPage_Click(sender, e);
                    break;
                case 4: // Pagamentos por Dono
                    consultarPagamentosDonoTabPage_Click(sender, e);
                    break;
                default: break;
            }
        }

        protected override void RestaurarBtnVisible()
        {
            btnRestaurar.Visible = false;
        }

        private void FillClinicInfo()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetClinicTable(@ClinicNIF, DEFAULT, DEFAULT) ORDER BY Nome", cn);
            cmd.Parameters.AddWithValue("@ClinicNIF", this.nif);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                clinicaPerfilNomeText.Text = reader["Nome"].ToString();
                clinicaPerfilTelefoneText.Text = reader["Telefone"].ToString();
                clinicaPerfilEmailText.Text = reader["Email"].ToString();
                clinicaPerfilEnderecoText.Text = reader["Endereco"].ToString();
            }

            reader.Close();
            cn.Close();
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.entity = "PerfilClinica"; 
            perfilPanel.Visible = true;
            clinicaPerfilBtnCancelar.Visible = false;
            clinicaPerfilBtnOK.Visible = false;
            clinicaPerfilNomeText.Enabled = false;
            clinicaPerfilTelefoneText.Enabled = false;
            clinicaPerfilEmailText.Enabled = false;
            clinicaPerfilEnderecoText.Enabled = false;
            FillClinicInfo();
        }

        private void clinicaPerfilBtnEditar_Click(object sender, EventArgs e)
        {
            clinicaPerfilBtnCancelar.Visible = true;
            clinicaPerfilBtnOK.Visible = true;
            clinicaPerfilNomeText.Enabled = true;
            clinicaPerfilTelefoneText.Enabled = true;
            clinicaPerfilEmailText.Enabled = true;
            clinicaPerfilEnderecoText.Enabled = true;
        }

        private void UpdateClinicInfo()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SP_UpdateClinic", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClinicNIF", this.nif);
            cmd.Parameters.AddWithValue("@ClinicName", clinicaPerfilNomeText.Text);
            cmd.Parameters.AddWithValue("@ClinicPhone", clinicaPerfilTelefoneText.Text);
            cmd.Parameters.AddWithValue("@ClinicEmail", clinicaPerfilEmailText.Text);
            cmd.Parameters.AddWithValue("@ClinicAddress", clinicaPerfilEnderecoText.Text);

            if (ExecuteInsertSP(cmd))
            {
                MessageBox.Show("Informações atualizadas com sucesso!");
            }

            cn.Close();
        }

        private void clinicaPerfilBtnCancelar_Click(object sender, EventArgs e)
        {
            perfilToolStripMenuItem_Click(sender, e);
        }

        private void clinicaPerfilBtnOK_Click(object sender, EventArgs e)
        {
            UpdateClinicInfo();
            perfilToolStripMenuItem_Click(sender, e); 
        }

        public override void DeleteTuples(String sp, int pk, String param)
        {
            if (!verifySGBDConnection())
                return;

            cn.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);

            SqlCommand cmd = new SqlCommand(sp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(param, pk);
            cmd.Parameters.AddWithValue("@DeletedBy", GetThisClinicName());
            ExecuteInsertSP(cmd);

            cn.InfoMessage -= new SqlInfoMessageEventHandler(OnInfoMessage);

            cn.Close();
        }
    }
}
