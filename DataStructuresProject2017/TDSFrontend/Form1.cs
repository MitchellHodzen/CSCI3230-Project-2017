using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDSBackend;

namespace TDSFrontend
{
   
    public partial class Form1 : Form
    {
        Backend backend;
        public Form1()
        {
            InitializeComponent();
            backend = new Backend(null);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            String input = (this.inputText.Text);

            List<string> sortedList = backend.GetSortedSimilarityList(input);
            for (int i = 0; i < sortedList.Count; i++)
            {
                LinkLabel pcurrentDoc = new LinkLabel();
                pcurrentDoc.Text = sortedList[i];
                pcurrentDoc.Links[0].LinkData = sortedList[i];

                pcurrentDoc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkClicked);
                flowLayoutPanel1.Controls.Add(pcurrentDoc);
            }
        }

        private void linkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            //open file
            MessageBox.Show((string)e.Link.LinkData);

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
