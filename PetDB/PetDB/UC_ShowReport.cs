using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PetDB
{
    public partial class UC_ShowReport : UserControl
    {
        private IAppointmentForm mainForm;
        public UC_ShowReport()
        {
            InitializeComponent();
        }

        public void setReportText(String report)
        {
            reportText.Clear();
            reportText.Text = report;
        }

        public void SetMethod(String method)
        {
            switch (method)
            {
                case "Edit":
                    reportText.Enabled = true;
                    showReportBtnOK.Enabled = true;
                    break;
                case "View":
                    reportText.Enabled = false;
                    showReportBtnOK.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        public void SetMainForm(IAppointmentForm form)
        {
            if (form != null)
                this.mainForm = form;
        }

        private void showReportBtnOK_Click(object sender, EventArgs e)
        {
            String reportContent = reportText.Text;
            if (reportContent != null)
                mainForm.UpdateReport(reportContent);
            Form parentForm = this.FindForm();
            if (parentForm != null)
                parentForm.Close();
        }
    }
}
