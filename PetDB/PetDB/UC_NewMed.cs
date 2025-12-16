using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PetDB
{
    public partial class UC_NewMed : UserControl
    {
        private UC_ListMeds ucList;

        public UC_NewMed()
        {
            InitializeComponent();
        }

        public void LoadMedsComboBox(List<Med> meds)
        {
            medsComboBox.Items.Clear();

            foreach (var m in meds)
                medsComboBox.Items.Add(m);
        }

        public void SetUCListMeds(UC_ListMeds uc)
        {
            if (uc != null)
                ucList = uc;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Med m = (Med)medsComboBox.SelectedItem;
            ucList.SetNewMed(m);
            Form parentForm = this.FindForm();
            if (parentForm != null)
                parentForm.Close();
        }
    }
}
