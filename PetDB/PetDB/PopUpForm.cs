using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PetDB
{
    public partial class PopUpForm : Form
    {
        public PopUpForm(UserControl content, string title)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(title))
                this.Text = title;

            content.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(content);

            content.PerformLayout();

            // Resize the form to fit the UserControl
            this.ClientSize = content.PreferredSize;
        }
    }
}
