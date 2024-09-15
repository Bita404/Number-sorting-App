using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting_App
{
    public partial class FormMain : Form
    {
        string fileName = null;
        Boolean isChanged;

        public FormMain()
        {
            InitializeComponent();
        }

        private void labelName1_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonDescending_CheckedChanged(object sender, EventArgs e)
        {
            long[] linesAsNumbers = new long[textBox1.Lines.Length];

            long i = 0;
            foreach (string line in textBox1.Lines)
            {
                linesAsNumbers[i++] = Convert.ToInt64(line);
            }
            Array.Sort(linesAsNumbers);
            Array.Reverse(linesAsNumbers);

            textBox2.Text = String.Join<long>("-", linesAsNumbers);
        }

        private void labelName2_Click(object sender, EventArgs e)
        {

        }

        private void labelSortedData_Click(object sender, EventArgs e)
        {

        }

        private void studentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("- Done by Bita Saeed s9919314 -" + "\n" + " Thanks for choosing this app :D"+"\n"+"             Hope you enjoy!");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == null)
            {
                saveFileDialogmain.DefaultExt = "txt";
                saveFileDialogmain.ShowDialog();
                if (saveFileDialogmain.ShowDialog() == DialogResult.Cancel)
                    return;

                fileName = saveFileDialogmain.FileName;
                this.Text = fileName;
            }
            System.IO.File.WriteAllText(fileName, textBox2.Text);
            isChanged = false;
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChanged == true)
            {
                DialogResult dr;
                dr = MessageBox.Show("Do you want to Save this file ?", "save...", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    saveToolStripMenuItem_Click(null, null);
            }
            textBox2.Text = "";
            this.Text = "sorting app num";
            fileName = null;
            isChanged = false;
        }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)&& (e.KeyChar != '-'))
    

            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            isChanged = true;
        }

        private void radioButtonAscending_CheckedChanged(object sender, EventArgs e)
        {
            long[] linesAsNumbers = new long[textBox1.Lines.Length];

            long i = 0;
            foreach (string line in textBox1.Lines)
            {
                linesAsNumbers[i++] = Convert.ToInt64(line);
            }
            Array.Sort(linesAsNumbers);

            textBox2.Text = String.Join<long>( "-" ,linesAsNumbers);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(null, null);
            openFileDialog1.Filter = "text File|*.txt|C# source File|*.cs|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            fileName = openFileDialog1.FileName;
            textBox2.Text = System.IO.File.ReadAllText(fileName);
            isChanged = false;
            this.Text = fileName;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.IO.File.WriteAllText("layout.txt", textBox2.Name);
            newToolStripMenuItem_Click(null, null);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileName = null;
            saveToolStripMenuItem_Click(null, null);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("even though I used \\n for my array result" + "\n" + "It didnt changes anything at all :(");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
