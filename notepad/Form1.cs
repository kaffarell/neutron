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
using System.Text.RegularExpressions;


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

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);

                var path = directory;            //Text wird in Textdokument unter dem Pfad gespeichert    
                StreamWriter writer = new StreamWriter(path);

            }

           
        }  

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Gabriel Goller\nv1.1.1 \"shadowy notepad\" \nhttps://github.com/kaffarell\nBeta-Tester: Silas Demez", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                directory = openFileDialog.InitialDirectory + openFileDialog.FileName;
            }
 
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); 
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public string directory { get; set; }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = directory;            //Text wird in Textdokument unter dem Pfad gespeichert    
            StreamWriter writer = new StreamWriter(path);
            string content = richTextBox1.Text;         // Text wird hinengeschrieben

            writer.Write(content);
            writer.Close();
        }
    }


   
}

