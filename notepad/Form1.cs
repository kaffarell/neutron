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
        public Form1()
        {
            InitializeComponent();
            richTextBox1.ShortcutsEnabled = true;
            richTextBox1.Font = new Font("Product Sans", 10);
            richTextBox1.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            
        }

        
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveasFile();
        }  

       

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                directory = openFileDialog.InitialDirectory + openFileDialog.FileName;
                name_file = openFileDialog.FileName;
            }

            name_file = Path.GetFileName(name_file);
            Form1.ActiveForm.Text = name_file + " - notepad";

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); 
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Gabriel Goller\nv1.2.0 \"cosmic warrior\" \nhttps://github.com/kaffarell\nBeta-Tester: Siloswagster, Gavaii", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            saveasFile();
        }

        public void saveFile()
        {
            var path = directory;
            StreamWriter writer = new StreamWriter(path);
            string content = richTextBox1.Text;         

            writer.Write(content);
            writer.Close();
        }

        public void saveasFile()
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                directory = saveFileDialog.InitialDirectory + saveFileDialog.FileName;
                name_file = saveFileDialog.FileName;
            }

            name_file = Path.GetFileName(name_file);
            Form1.ActiveForm.Text = name_file + " - notepad";
        }

        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                saveFile();
                e.SuppressKeyPress = true;
            }
        }

        public string directory { get; set; }

        public string name_file { get; set; }

    }


   
}

