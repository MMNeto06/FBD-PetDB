using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PetDB
{
    public partial class UC_ListStrings : UserControl
    {
        public UC_ListStrings()
        {
            InitializeComponent();
        }

        public void setStrings(List<String> strings)
        {
            listBoxStrings.Items.Clear();

            foreach (var s in strings)
            {
                listBoxStrings.Items.Add(s);
            }
        }
    }
}
