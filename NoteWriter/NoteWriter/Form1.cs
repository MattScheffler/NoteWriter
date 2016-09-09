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

namespace NoteWriter
{
    public partial class Form1 : Form
    {
        //Globals used in the window grag code
        private bool mouseDown;
        private Point location;

        public Form1()
        {
            InitializeComponent();
        }

        //Start font change button events
        private void buttonItalic_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionFont.Italic)
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, FontStyle.Regular);
            else
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, FontStyle.Italic);
            richTextBox.Focus();
        }

        private void buttonBold_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionFont.Bold)
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, FontStyle.Regular);
            else
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, FontStyle.Bold);
            richTextBox.Focus();
        }

        private void buttonBoldItalic_Click(object sender, EventArgs e)
        {
            if ((richTextBox.SelectionFont.Bold) && (richTextBox.SelectionFont.Italic))
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, FontStyle.Regular);
            else
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, FontStyle.Bold | FontStyle.Italic);
            richTextBox.Focus();
        }

        private void buttonUnderline_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionFont.Underline)
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, FontStyle.Regular);
            else
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, FontStyle.Underline);
            richTextBox.Focus();
        }

        private void buttonStrikeout_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionFont.Strikeout)
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, FontStyle.Regular);
            else
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, FontStyle.Strikeout);
            richTextBox.Focus();
        }
        //End font change button events

        //Start top right buttons
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //End top right buttons

        //Start of window drag code, moves the window if blank space in the top menu is clicked down
        private void menuStrip_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            location = e.Location;
        }

        private void menuStrip_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void menuStrip_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - location.X) + e.X, (this.Location.Y - location.Y) + e.Y);
                this.Update();
            }
        }
        //End of window drag code

        //Start file menu buttons
        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            labelFilename.Text = String.Empty;
            richTextBox.Text = String.Empty;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = String.Empty;
            openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(Application.StartupPath + '\\');
            try
            {
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                else
                {
                    richTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                    int filenameStart = openFileDialog.FileName.LastIndexOf('\\');
                    labelFilename.Text = openFileDialog.FileName.Substring(filenameStart + 1);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = labelFilename.Text;
            saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(Application.StartupPath + '\\');
            try
            {
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                else
                {
                    richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                    int filenameStart = saveFileDialog.FileName.LastIndexOf('\\');
                    labelFilename.Text = saveFileDialog.FileName.Substring(filenameStart + 1);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //End file menu buttons
    }
}
