using System;
using System.Collections.Generic;
using System.ComponentModel;
using SD = System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace Case_lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(var c in this.Controls)
            {
                if(c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int ROWS = dataGridView1.Rows.Count;
            for (int i = 0; i < ROWS; i++)
            {
                int max = dataGridView1.Rows.Count - 1;
                dataGridView1.Rows.Remove(dataGridView1.Rows[max]);
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
        }


       

        private void button4_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();

            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;
            int i, j;
            string rep;
            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    wsh.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText.ToString();
                    rep = dataGridView1[j, i].Value.ToString().Replace("|", "\\");
                    wsh.Cells[i + 2, j + 1] = rep;
                }
            }
            exApp.Visible = true;
        }
    }
}
