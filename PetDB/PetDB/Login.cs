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
            if(idType != "Administrador")
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
                    registerClinicaLabel.Visible = true;
                    registerClinicaTextBox.Visible = true;
                    registerClinicaTextBox.Text = "";
                    registerEspecialidadeLabel.Visible = true;
                    registerEspecialidadeComboBox.Visible = true;
                    //combo box por popular
                }
                else
                {
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

        public Login()
        {
            InitializeComponent();
            showInitialPage();
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            idType = "Administrador";
            showLoginPage();
            registerBtn.Enabled = false;
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
                        cmd = new SqlCommand("SELECT * FROM PETDB_ClinicaVeterinaria WHERE NIF=" + id, cn);
                    }
                    else if (idType == "Medico")
                    {
                        cmd = new SqlCommand("SELECT * FROM PETDB_MedicoVeterinario WHERE NumOMV=" + id, cn);
                    }
                    else
                    {
                        cmd = new SqlCommand("SELECT * FROM PETDB_Dono WHERE NIF=" + id, cn);
                    }

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) // Don't assume we have any rows.
                    {
                        //System.Windows.Forms.MessageBox.Show("Login com sucesso de " + idType + " " + reader["Nome"].ToString());

                        if (idType == "Clinica")
                        {
                            ClinicaForm clinicaPage = new ClinicaForm(this, Int32.Parse(reader["NIF"].ToString()), reader["Nome"].ToString());
                            clinicaPage.Show();
                            this.showInitialPage();
                            this.Hide();
                        }
                        else if (idType == "Medico")
                        {
                            MedicoForm medicoPage = new MedicoForm(this, Int32.Parse(reader["NumOmv"].ToString()), reader["Nome"].ToString());
                            medicoPage.Show();
                            this.showInitialPage();
                            this.Hide();
                        }
                        else
                        {
                            DonoForm donoPage = new DonoForm(this, Int32.Parse(reader["NIF"].ToString()), reader["Nome"].ToString());
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

        
    }
}
