using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PetDB
{
    public partial class Login : Form
    {
        private SqlConnection cn;
        private String idType = "Administrador";
        private int codigoEspecialidade = 1;
        // opções de idType: Administrador, Clinica, Medico, Veterinario
        private void showInitialPage()
        {
            idLabel.Visible = false;
            idTextBox.Visible = false;
            loginBtn.Visible = false;
            registerBtn.Visible = false;
            backBtn.Visible = false;
            loginText.Visible = true;
            adminBtn.Visible = true;
            clinicaBtn.Visible = true;
            medicoBtn.Visible = true;
            donoBtn.Visible = true;
            logoBox.Visible = true;

            adicionarBtn.Visible = false;
            registerBackBtn.Visible = false;
            registerClinicaLabel.Visible = false;
            registerClinicaTextBox.Visible = false;
            registerEmailLabel.Visible = false;
            registerEmailTextBox.Visible = false;
            registerEnderecoLabel.Visible = false;
            registerEnderecoTextBox.Visible = false;
            registerEspecialidadeLabel.Visible = false;
            registerEspecialidadeComboBox.Visible = false;
            registerIdLabel.Visible = false;
            registerIdText.Visible = false;
            registerNomeLabel.Visible = false;
            registerNomeTextBox.Visible = false;
            registerTelefoneLabel.Visible = false;
            registerTelefoneTextBox.Visible = false;
        }

        private void showLoginPage()
        {
            if (idType == "Administrador")
            {
                registerBtn.Enabled = false;
            }
            else if (idType == "Medico")
            {
                registerBtn.Enabled = true;
            }
            else
            {
                registerBtn.Enabled = true;
            }
            idLabel.Visible = true;
            idTextBox.Visible = true;
            loginBtn.Visible = true;
            registerBtn.Visible = true;
            backBtn.Visible = true;
            loginText.Visible = false;
            adminBtn.Visible = false;
            clinicaBtn.Visible = false;
            medicoBtn.Visible = false;
            donoBtn.Visible = false;
            logoBox.Visible = false;
            idTextBox.Text = "";

            adicionarBtn.Visible = false;
            registerBackBtn.Visible = false;
            registerClinicaLabel.Visible = false;
            registerClinicaTextBox.Visible = false;
            registerEmailLabel.Visible = false;
            registerEmailTextBox.Visible = false;
            registerEnderecoLabel.Visible = false;
            registerEnderecoTextBox.Visible = false;
            registerEspecialidadeLabel.Visible = false;
            registerEspecialidadeComboBox.Visible = false;
            registerIdLabel.Visible = false;
            registerIdText.Visible = false;
            registerNomeLabel.Visible = false;
            registerNomeTextBox.Visible = false;
            registerTelefoneLabel.Visible = false;
            registerTelefoneTextBox.Visible = false;
        }

        private void showRegisterPage()
        {
            if (idType != "Administrador")
            {
                idLabel.Visible = false;
                idTextBox.Visible = false;
                loginBtn.Visible = false;
                registerBtn.Visible = false;
                backBtn.Visible = false;
                loginText.Visible = false;
                adminBtn.Visible = false;
                clinicaBtn.Visible = false;
                medicoBtn.Visible = false;
                donoBtn.Visible = false;
                logoBox.Visible = false;

                adicionarBtn.Visible = true;
                registerBackBtn.Visible = true;
                registerEmailLabel.Visible = true;
                registerEmailTextBox.Visible = true;
                registerEmailTextBox.Text = "";
                registerIdLabel.Visible = true;
                registerIdText.Visible = true;
                registerIdText.Text = "";
                registerNomeLabel.Visible = true;
                registerNomeTextBox.Visible = true;
                registerNomeTextBox.Text = "";
                registerTelefoneLabel.Visible = true;
                registerTelefoneTextBox.Visible = true;
                registerTelefoneTextBox.Text = "";

                if (idType == "Medico")
                {
                    registerIdLabel.Text = "Número OMV";
                    registerClinicaLabel.Visible = true;
                    registerClinicaTextBox.Visible = true;
                    registerClinicaTextBox.Text = "";
                    registerEspecialidadeLabel.Visible = true;
                    registerEspecialidadeComboBox.Visible = true;
                    codigoEspecialidade = 1;
                    registerEspecialidadeComboBox.SelectedIndex = 0;
                }
                else
                {
                    registerIdLabel.Text = "NIF";
                    registerEnderecoLabel.Visible = true;
                    registerEnderecoTextBox.Visible = true;
                    registerEnderecoTextBox.Text = "";
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Opção indisponível para Administrador");
            }

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

        private void populateEspecialidadeComboBox()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("EXEC SP_GetSpecialtyTable", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                registerEspecialidadeComboBox.Items.Add(new String(reader["Descricao"].ToString()));
            }

            cn.Close();

        }

        public Login()
        {
            InitializeComponent();
            showInitialPage();
            populateEspecialidadeComboBox();
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            idType = "Administrador";
            showLoginPage();
        }

        private void clinicaBtn_Click(object sender, EventArgs e)
        {
            idType = "Clinica";
            showLoginPage();
        }

        private void medicoBtn_Click(object sender, EventArgs e)
        {
            idType = "Medico";
            showLoginPage();
        }

        private void donoBtn_Click(object sender, EventArgs e)
        {
            idType = "Dono";
            showLoginPage();
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            showInitialPage();
        }

        private void registerBtn_Click(Object sender, EventArgs e)
        {
            showRegisterPage();
        }

        private void registerBackBtn_Click(Object sender, EventArgs e)
        {
            showInitialPage();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            int id;
            if (Int32.TryParse(idTextBox.Text, out id) == false)
            {
                System.Windows.Forms.MessageBox.Show("Erro: A sua identificação só pode ser composta por números");
            }
            else
            {
                if (idType == "Administrador")
                {
                    if (id == -1) //Definir aqui palavra passe de administrador
                    {
                        //System.Windows.Forms.MessageBox.Show("Login com sucesso de Administrador");
                        AdminForm adminPage = new AdminForm(this);
                        adminPage.Show();
                        this.showInitialPage();
                        this.Hide();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Identificação errada para Administrador");
                    }
                }
                else
                {
                    if (!verifySGBDConnection())
                        return;

                    SqlCommand cmd;
                    if (idType == "Clinica")
                    {
                        cmd = new SqlCommand("EXEC SP_GetClinicByNIF " + id, cn);
                    }
                    else if (idType == "Medico")
                    {
                        cmd = new SqlCommand("EXEC SP_GetMedicByOMV " + id, cn);
                    }
                    else
                    {
                        cmd = new SqlCommand("SP_GetOwnerTable", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OwnerNIF", id);
                    }

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) // Don't assume we have any rows.
                    {
                        //System.Windows.Forms.MessageBox.Show("Login com sucesso de " + idType + " " + reader["Nome"].ToString());

                        if (idType == "Clinica")
                        {
                            ClinicaForm clinicaPage = new ClinicaForm(this, Int32.Parse(reader["NIF"].ToString()));
                            clinicaPage.Show();
                            this.showInitialPage();
                            this.Hide();
                        }
                        else if (idType == "Medico")
                        {
                            MedicoForm medicoPage = new MedicoForm(this, Int32.Parse(reader["NumOmv"].ToString()));
                            medicoPage.Show();
                            this.showInitialPage();
                            this.Hide();
                        }
                        else
                        {
                            DonoForm donoPage = new DonoForm(this, Int32.Parse(reader["NIF"].ToString()));
                            donoPage.Show();
                            this.showInitialPage();
                            this.Hide();
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(idType + " não encontrado.");
                    }
                    cn.Close();
                }
            }
        }

        private void adicionarBtn_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            int entityId;
            int telefone;
            int clinicaNif;
            String nome = registerNomeTextBox.Text;
            String email = registerEmailTextBox.Text;
            String endereco = registerEnderecoTextBox.Text;
            if (Int32.TryParse(registerIdText.Text, out entityId) == false)
            {
                System.Windows.Forms.MessageBox.Show("Erro: A sua identificação só pode ser composta por números");
            }
            if (Int32.TryParse(registerTelefoneTextBox.Text, out telefone) == false)
            {
                System.Windows.Forms.MessageBox.Show("Erro: O número de telefone deve ser um número");
            }
            if (Int32.TryParse(registerClinicaTextBox.Text, out clinicaNif) == false && idType == "Medico")
            {
                System.Windows.Forms.MessageBox.Show("Erro: O NIF da sua clinica deve ser um número");
            }


            SqlCommand cmd;
            if (idType == "Clinica")
            {
                cmd = new SqlCommand("EXEC SP_AddClinic " +
                    entityId + ",'" +
                    nome + "', '" +
                    telefone + "', '" +
                    email + "', '" +
                    endereco + "'", cn);
            }
            else if (idType == "Medico")
            {
                cmd = new SqlCommand("EXEC SP_AddVet " +
                    entityId + ",'" +
                    nome + "', '" +
                    telefone + "', '" +
                    email + "', " +
                    codigoEspecialidade + ", " +
                    clinicaNif, cn);
            }
            else
            {
                cmd = new SqlCommand("EXEC SP_AddOwner " +
                    entityId + ", '" +
                    nome + "', '" +
                    telefone + "', '" +
                    email + "', '" +
                    endereco + "'", cn);
            }

            try
            {
                if (cmd.ExecuteNonQuery() == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Ocorreu um erro: nenhuma linha foi atualizada");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Registo feito com sucesso!");
                    idTextBox.Text = entityId.ToString();
                    loginBtn_Click(sender, new EventArgs());
                }
            }
            catch (Exception exception)
            {
                System.Windows.Forms.MessageBox.Show("Ocorreu um erro: " + exception.ToString());
            }
        }

        private void registerEspecialidadeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            codigoEspecialidade = registerEspecialidadeComboBox.SelectedIndex + 1;
            //System.Diagnostics.Debug.WriteLine("Especialidade código: " + selectedEspecialidade);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                loginBtn_Click(sender, e);
            }

        }
    }
}
