using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.WebSockets;
using System.Text;
using System.Windows.Forms;

namespace PetDB
{
    public partial class UC_NewTreatment : UserControl
    {
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

        private void okBtn_Click(object sender, EventArgs e)
        {
            Treatment t = (Treatment)treatmentsComboBox.SelectedItem;


        }
    }
}
