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
using TDSBackend.DocumentStorage;

namespace TDSFrontend
{
   
    public partial class Form1 : Form
    {
        Backend backend;
        public Form1()
        {
            InitializeComponent();
            string resourcePath = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\TDSBackend\\Resources";
            backend = new Backend(resourcePath);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            String input = (this.inputText.Text);

            List<KeyValuePair<DocumentVector, double>> sortedList = backend.GetSortedSimilarityList(input);
            for (int i = sortedList.Count - 1; i >= 0; i--)
            {
                LinkLabel pcurrentDoc = new LinkLabel();
                pcurrentDoc.Text = sortedList.ElementAt(i).Key.GetDocumentLocation();
                pcurrentDoc.Text = System.IO.Path.GetFileName(sortedList.ElementAt(i).Key.GetDocumentLocation());
                pcurrentDoc.Links[0].LinkData = sortedList.ElementAt(i).Key.GetDocumentLocation();

                pcurrentDoc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkClicked);
                flowLayoutPanel1.Controls.Add(pcurrentDoc);
            }
        }

        private void linkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            //open file
            System.Diagnostics.Process.Start((string)e.Link.LinkData);

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
