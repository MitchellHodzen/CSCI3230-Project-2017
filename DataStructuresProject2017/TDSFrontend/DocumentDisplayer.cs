using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TDSFrontend
{
    public partial class DocumentDisplayer : Form
    {
        public DocumentDisplayer()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void DocumentDisplayer_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(docList[0] != null)
                MessageBox.Show(File.ReadAllText(docList[0]));
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (docList[1] != null)
                MessageBox.Show(File.ReadAllText(docList[1]));
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (docList[2] != null)
                MessageBox.Show(File.ReadAllText(docList[2]));
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (docList[3] != null)
                MessageBox.Show(File.ReadAllText(docList[3]));
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (docList[4] != null)
                MessageBox.Show(File.ReadAllText(docList[4]));
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (docList[5] != null)
                MessageBox.Show(File.ReadAllText(docList[5]));
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (docList[6] != null)
                MessageBox.Show(File.ReadAllText(docList[6]));
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (docList[7] != null)
                MessageBox.Show(File.ReadAllText(docList[7]));
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (docList[8] != null)
                MessageBox.Show(File.ReadAllText(docList[8]));
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (docList[9] != null)
                MessageBox.Show(File.ReadAllText(docList[9]));
        }
    }
}
