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
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;


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
            richTextBox1.AcceptsTab = true;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            string path3 = @AppDomain.CurrentDomain.BaseDirectory + "first_time_shortcut.txt";
            string text = File.ReadAllText(path3);
            if (File.Exists(path3) && (text != "0"))
            {
                string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); ;
                string linkName = "notepad";

                using (StreamWriter writer = new StreamWriter(deskDir + "\\" + linkName + ".url"))
                {
                    string app = System.Reflection.Assembly.GetExecutingAssembly().Location;
                     writer.WriteLine("[InternetShortcut]");
                     writer.WriteLine("URL=file:///" + app);
                     writer.WriteLine("IconIndex=0");
                     string icon = app.Replace('\\', '/');
                     writer.WriteLine("IconFile=" + icon);
                     writer.Flush();
                }
                text = "0";
                File.WriteAllText(path3, text);
            }
            

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.CheckKeyword("while", Color.OrangeRed, 0);
            this.CheckKeyword("for", Color.OrangeRed, 0);
            this.CheckKeyword("if", Color.Orange, 0);
            this.CheckKeyword("else", Color.Orange, 0);
            this.CheckKeyword("int", Color.Blue, 0);
            this.CheckKeyword("string", Color.Blue, 0);
            this.CheckKeyword("double", Color.Blue, 0);
            this.CheckKeyword("var", Color.Blue, 0);
            this.CheckKeyword("null", Color.DarkBlue, 0);

            string text = richTextBox1.Text;
            foreach (var line in richTextBox1.Lines)
            {
                if (line.Contains("#"))
                {
                    int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();

                    int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);

                    richTextBox1.Select(firstcharindex, 10);

                    richTextBox1.SelectionColor = Color.Red;

                    richTextBox1.DeselectAll();
                    richTextBox1.Select(richTextBox1.Text.Length, 0);
                }else if (line.Contains("//"))
                {
                    int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();

                    int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);

                    richTextBox1.Select(firstcharindex, 10);

                    richTextBox1.SelectionColor = Color.Green;

                    richTextBox1.DeselectAll();
                    richTextBox1.Select(richTextBox1.Text.Length, 0);
                }
                else
                {
                    int firstcharindex = richTextBox1.GetFirstCharIndexOfCurrentLine();

                    int currentline = richTextBox1.GetLineFromCharIndex(firstcharindex);

                    richTextBox1.Select(firstcharindex, 10);

                    richTextBox1.SelectionColor = Color.Black;

                    richTextBox1.DeselectAll();
                    richTextBox1.Select(richTextBox1.Text.Length, 0);
                }
            }
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTextBox1.SelectionStart;

                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index + startIndex), word.Length);
                    this.richTextBox1.SelectionColor = color;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
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
            Form1.ActiveForm.Text = name_file + " - " + "notepad";

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
                saveFile();
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

        private void fontToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fd.Font;
            }
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Gabriel Goller\nv1.3.0 \"cosmic warrior\" \nhttps://github.com/kaffarell\nBeta-Tester: Siloswagster, Gavaii", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void updateInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); ;



            var parameters = new FirefoxOptions();
            parameters.AddArgument("--headless");

            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.download.manager.showWhenStarting", false);
            options.SetPreference("browser.download.dir", downloadPath);
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "kaffarell/notepad/archive/master.zip");

            IWebDriver browser = new FirefoxDriver(options);

            browser.Navigate().GoToUrl("https://github.com/kaffarell/notepad/archive/master.zip");



        }

        private void updateWithGitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process proc = null;
            string batDir = string.Format(@AppDomain.CurrentDomain.BaseDirectory);
            proc = new Process();
            proc.StartInfo.WorkingDirectory = batDir;
            proc.StartInfo.FileName = "update.bat";
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            proc.WaitForExit();
            MessageBox.Show("Updater executed, restart notepad!!");
          
            
        }
    }
}

