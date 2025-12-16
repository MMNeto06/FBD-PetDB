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

        public void SetStrings(List<String> strings)
        {
            if (strings != null)
            {
                listBox1.Items.Clear();

                foreach (var s in strings)
                    listBox1.Items.Add(s);
            }
        }
    }
}
