using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PetDB
{
    public partial class UC_ListTreatments : UserControl
    {
        public UC_ListTreatments()
        {
            InitializeComponent();
            if (treatmentsListBox.Items.Count == 0)
            {
                btnEditTreatment.Enabled = false;
            }
        }

        public void SetTreatments(List<Treatment> treatments)
        {
            treatmentsListBox.Items.Clear();

            foreach (var t in treatments)
                treatmentsListBox.Items.Add(t);
        }

        private void btnEditTreatment_Click(object sender, EventArgs e)
        {

        }

        private void btnAddTreatment_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveTreatment_Click(object sender, EventArgs e)
        {

        }
    }
}
