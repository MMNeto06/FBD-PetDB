using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.WebSockets;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PetDB
{
    public partial class UC_NewTreatment : UserControl
    {
        private UC_ListTreatments ucList; 

        public UC_NewTreatment()
        {
            InitializeComponent();
        }

        public void LoadTreatmentsComboBox(List<Treatment> treatments)
        {
            treatmentsComboBox.Items.Clear();

            foreach (var t in treatments)
                treatmentsComboBox.Items.Add(t);
        }

        public void SetUCListTreatments(UC_ListTreatments uc)
        {
            if (uc != null) 
                ucList = uc;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Treatment t = (Treatment)treatmentsComboBox.SelectedItem;
            ucList.SetNewTreatment(t);
            Form parentForm = this.FindForm();
            if (parentForm != null)
                parentForm.Close();
        }
    }
}
