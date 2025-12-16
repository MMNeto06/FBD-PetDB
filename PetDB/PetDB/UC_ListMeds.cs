using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PetDB
{
    public partial class UC_ListMeds : UserControl
    {
        private IMedForm mainForm; 
        private List<Med> allMeds; 
        public UC_ListMeds()
        {
            InitializeComponent();
            allMeds = new List<Med>();
        }

        public void SetMeds(List<Med> meds)
        {
            listBoxMeds.Items.Clear();

            foreach (var m in meds)
            {
                listBoxMeds.Items.Add(m);
            }
        }

        public void SetMethod(String method)
        {
            switch (method)
            {
                case "View":
                    listMedsAddBtn.Enabled = false; 
                    listMedsBtnRemove.Enabled = false;
                    break;
                case "Edit":
                    listMedsAddBtn.Enabled = true;
                    listMedsBtnRemove.Enabled = true;
                    break; 
            }
        }

        public void SetMainForm (IMedForm form)
        {
            if (form != null)
                this.mainForm = form;
        }

        public void SetNewMed(Med newMed)
        {
            if (newMed != null)
                mainForm.AddMedToPrescription(newMed, this);
        }


        private void listMedsAddBtn_Click(object sender, EventArgs e)
        {
            UC_NewMed uc = new UC_NewMed();
            uc.SetUCListMeds(this);
            allMeds = mainForm.GetMeds();
            uc.LoadMedsComboBox(allMeds);

            PopUpForm popup = new PopUpForm(uc, "Editar Tratamento");
            popup.ShowDialog();
        }

        private void listMedsBtnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}
