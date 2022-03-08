using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegalPlotter
{
    public partial class LegalForm : Form
    {

        public Legal legal;

        public LegalForm(Legal legalObject)
        {
            legal = legalObject;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void LegalForm_Load(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            legal.parcelName = ParcelName.Text;
            legal.legalDescription = LegalDescription.Text;
            legal.LegalPlotter();
        }
    }
}
