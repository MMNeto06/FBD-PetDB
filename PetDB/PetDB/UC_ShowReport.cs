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
        public UC_ShowReport()
        {
            InitializeComponent();
        }

        public void setReportText(String report)
        {
            reportText.Clear();
            reportText.Enabled = false;
            reportText.Text = report; 
            
        }
    }
}
