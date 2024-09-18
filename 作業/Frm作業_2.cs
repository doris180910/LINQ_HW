using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MyHomeWork
{
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
            int strYear = 1990;
            int endYear = DateTime.Now.Year;
            for (int i = strYear; i < endYear; i++)
            { 
               comboBox3.Items.Add(i);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.productPhotoTableAdapter1.Fill(this.awDataSet1.ProductPhoto);
            var a = from b in this.awDataSet1.ProductPhoto
                    select b;
            this.dataGridView1.DataSource = a.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.productPhotoTableAdapter1.Fill(this.awDataSet1.ProductPhoto);
            var a = from b in this.awDataSet1.ProductPhoto
                    where b.ModifiedDate >= dateTimePicker1.Value && b.ModifiedDate <= dateTimePicker2.Value
                    select b;
            this.dataGridView1.DataSource = a.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource=null;
            this.productPhotoTableAdapter1.Fill(this.awDataSet1.ProductPhoto);
            var a =from b in this.awDataSet1.ProductPhoto
                   where b.ModifiedDate.Year ==Convert.ToInt32(comboBox3.Text)
                   select b;
            this.dataGridView1.DataSource = a.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridView1.Rows[e.RowIndex].Index;
            var temp = from o in this.awDataSet1.ProductPhoto
                       where o.ProductPhotoID == (int)dataGridView1.Rows[a].Cells[0].Value
                       select o.ThumbNailPhoto;

            byte[] b = temp.FirstOrDefault();
            MemoryStream ms = new MemoryStream(b);
            
            pictureBox1.Image = Image.FromStream(ms);
            


            
                     
        }
    }
}
