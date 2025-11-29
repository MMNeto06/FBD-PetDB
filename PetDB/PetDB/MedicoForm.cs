using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PetDB
{
    public partial class MedicoForm : Form
    {
        private Login loginPage;
        public MedicoForm(Login loginPage, int nif, string nome)
        {
            InitializeComponent();
            showNifLabel.Text = nif.ToString();
            showNameLabel.Text = nome.ToString();
            this.loginPage = loginPage;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            loginPage.Show();
            this.Close();
        }
    }
}
