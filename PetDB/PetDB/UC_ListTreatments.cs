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
        private IAppointmentForm mainForm;
        private List<Treatment> treatments;
        private List<Treatment> allTreatments;
        private Treatment newTreatment;

        public UC_ListTreatments()
        {
            InitializeComponent();
            treatments = new List<Treatment>();
            allTreatments = new List<Treatment>(); 
        }

        public void SetMode(String mode)
        {
            switch (mode)
            {
                case "View":
                    btnAddTreatment.Enabled = false;
                    btnAddTreatment.Enabled = false;
                    btnRemoveTreatment.Enabled = false;
                    break;
                case "Edit":
                    btnAddTreatment.Enabled = true;
                    btnRemoveTreatment.Enabled = true;
                    break;
            }
        }

        public void SetForm(IAppointmentForm form)
        {
            if (form != null)
                mainForm = form;
                
        }

        public void SetTreatments(List<Treatment> treatments)
        {
            this.treatments = treatments;
            treatmentsListBox.Items.Clear();

            foreach (var t in treatments)
                treatmentsListBox.Items.Add(t);
        }

        public void SetNewTreatment(Treatment newTreatment)
        {
            if (newTreatment != null)
                this.newTreatment = newTreatment;

            mainForm.AddTreatmentToAppointment(this.newTreatment, this);
        }

        private void btnAddTreatment_Click(object sender, EventArgs e)
        {
            UC_NewTreatment uc = new UC_NewTreatment();
            uc.SetUCListTreatments(this);
            allTreatments = mainForm.GetTreatments();
            uc.LoadTreatmentsComboBox(allTreatments);

            PopUpForm popup = new PopUpForm(uc, "Editar Tratamento");
            popup.ShowDialog();
        }

        private void btnRemoveTreatment_Click(object sender, EventArgs e)
        {

        }
    }
}
