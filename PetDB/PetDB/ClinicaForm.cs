using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PetDB
{
    public partial class ClinicaForm : Form
    {
        private Login loginPage;
        private int nif;
        public ClinicaForm(Login loginPage, int nif)
        {
            InitializeComponent();
            this.loginPage = loginPage;
            this.nif = nif;
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
    }
}
