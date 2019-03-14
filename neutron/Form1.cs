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
using System.Net;
using System.Diagnostics;
using IWshRuntimeLibrary;
using ScintillaNET;

namespace notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fastColoredTextBox1.Font = new Font("Product Sans", 10);
            fastColoredTextBox1.Dock = DockStyle.Fill;
            fastColoredTextBox1.AcceptsTab = true;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            string path3 = @AppDomain.CurrentDomain.BaseDirectory + "first_time_shortcut.txt";
            string text = System.IO.File.ReadAllText(path3);
            if (System.IO.File.Exists(path3) && (text != "0"))
            {
                string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string linkName = "neutron";
                string batDir = string.Format(@AppDomain.CurrentDomain.BaseDirectory);

                //make link at Desktop
                WshShell shell = new WshShell();
                IWshShortcut link = (IWshShortcut)shell.CreateShortcut(deskDir + "\\" + linkName + ".lnk");
                link.TargetPath = batDir + "\\neutron.exe";
                link.Save();

                text = "0";     //set link to 0
                System.IO.File.WriteAllText(path3, text);

            }


        }

        private void fastColoredTextBox1_TextChanged(object sender, EventArgs e)
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
                fastColoredTextBox1.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
                directory = openFileDialog.InitialDirectory + openFileDialog.FileName;
                name_file = openFileDialog.FileName;
            }

            name_file = Path.GetFileName(name_file);
            Form1.ActiveForm.Text = name_file + " - " + "neutron";

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = directory;
            if (path == null)
            {
                Environment.Exit(0);
            }
            else
            {
                saveFile();         //when exit save 
                Environment.Exit(-1);            
            }
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (directory == null)
            {
                saveasFile();
            }
            else
            {
                saveFile();
            }
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = "";
            saveasFile();
        }

        public void saveFile()
        {
            var path = directory;
            StreamWriter writer = new StreamWriter(path);
            string content = fastColoredTextBox1.Text;         

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
                System.IO.File.WriteAllText(saveFileDialog.FileName, fastColoredTextBox1.Text);
                directory = saveFileDialog.InitialDirectory + saveFileDialog.FileName;
                name_file = saveFileDialog.FileName;
            }

            name_file = Path.GetFileName(name_file);
            Form1.ActiveForm.Text = name_file + " - neutron";
        }

        private void fontToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                fastColoredTextBox1.Font = fd.Font;
            }
        }


        private void documentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text1;
            string file_extension;

            if (name_file != null)
            {
                file_extension = name_file.Substring(name_file.IndexOf("."));               
            }else
            {
                file_extension = "";
            }
            text1 = "Name of Document: " + name_file + "\n" + "Full path: " + directory + "\n" + "File extension: " + file_extension;
            MessageBox.Show(text1, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string directory { get; set; }

        public string name_file { get; set; }


        private void updateWithGitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process proc = null;
            string batDir = string.Format(@AppDomain.CurrentDomain.BaseDirectory);
            
            //set link to 1 before update to make new link
            string path = batDir + "\\first_time_shortcut.txt";
            StreamWriter writer = new StreamWriter(path);
            string content = "1";
            writer.Write(content);
            writer.Close();

            //start batch to make update
            proc = new Process();
            proc.StartInfo.WorkingDirectory = batDir;
            proc.StartInfo.FileName = "update.bat";
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            proc.WaitForExit();
            MessageBox.Show("Updater executed, restart neutron!!");
          
            
        }

        private void neutronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Gabriel Goller\nv1.4.0 \"cosmic warrior\" \nhttps://github.com/kaffarell\nBeta-Tester: Siloswagster, Gavaii", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

