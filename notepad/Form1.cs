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

namespace notepad
{
    public partial class Form1 : Form
    {

        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "text.txt");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextWriter tw = new StreamWriter(path, true);
            tw.WriteLine(richTextBox1.Text);
            tw.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete(path);
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Gabriel Goller\nhttps://github.com/kaffarell\nBeta-Tester: Silas Demez");
        }
    }
}
