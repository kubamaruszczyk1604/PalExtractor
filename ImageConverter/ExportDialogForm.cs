using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImageConverter
{
    public partial class ExportDialogForm : Form
    {
        string m_OldName;
        string m_SaveDir;
        public DialogResult Result { get; private set; }
        public ExportDialogForm()
        {
            InitializeComponent();
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            textBoxDirectory.Text = path + @"\"+textBoxName.Text;
            m_SaveDir = path;
            m_OldName = textBoxName.Text;
            Result = DialogResult.Cancel;
        }



        public void SetChromaImage(Image img)
        {
            pictureBox1.Image = img;
        }

        public void SetLumaImage(Image img)
        {
            pictureBox2.Image = img;
        }

        public void SetPaletteImage(Image img)
        {
            pictureBoxPalette.Image = img;
        }

        public string OutputDir { get { return textBoxDirectory.Text; } }

        public bool ChromaChecked{ get { return checkBoxChroma.Checked; } }
        public bool LumaChecked { get { return checkBoxLuma.Checked; } }
        public bool PaletteChecked { get { return checkBoxPalette.Checked; } }



        private void textBoxDirectory_DoubleClick(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBoxDirectory.Text = fbd.SelectedPath + @"\" + textBoxName.Text;
                    m_SaveDir = fbd.SelectedPath;
                }
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            string invalidChars = new string (System.IO.Path.GetInvalidFileNameChars()) + ",";

            foreach (char c in invalidChars)
            {
                if(textBoxName.Text.Contains(c))
                {
                    textBoxName.Text = m_OldName;
                    return;
                }
            }
            m_OldName = textBoxName.Text;
           
            textBoxDirectory.Text = m_SaveDir + @"\" + textBoxName.Text; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text.Trim().Length < 1)
            {
                MessageBox.Show("You must enter package name!", "Error");
            }
            else
            {
                if (!System.IO.Directory.Exists(textBoxDirectory.Text))
                {
                    Result = DialogResult.OK;
                    Close();
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Overwrite?", "Directory with package name already exists!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Result = DialogResult.OK;
                        Close();
                    }

                }


            }
        }
    }
}
