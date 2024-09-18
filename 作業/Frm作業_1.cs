using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();
            int startYear = 1996;
            int endYear = 1998;
            for(int i=startYear; i<endYear; i++)
            {
                comboBox1.Items.Add(i);
            }
        }

        

        int currentPage = 0;
        int pageSize = 10;

        private void button13_Click(object sender, EventArgs e)
        {

           var query = this.nwDataSet1.Orders.OrderBy(order=>order.OrderID)
                .Skip(currentPage * pageSize) 
                .Take(pageSize);
            dataGridView1.DataSource = query.ToList();
            currentPage++;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                    where f.Extension == ".log"
                    select f;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();
            var q = from f in files
                    where f.CreationTime.Year == 2022
                    select f;
            this.dataGridView2.DataSource = q.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();
            var q = from f in files
                    where f.Length > 5000000
                    select f;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);
            var order = from o in this.nwDataSet1.Orders
                        select o;
            this.dataGridView1.DataSource= order.ToList();
                       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);
            try
            {
                var order = from o in this.nwDataSet1.Orders
                            where o.OrderDate.Year == Convert.ToInt32(comboBox1.Text)                              
                            select o;
                this.dataGridView1.DataSource = order.ToList();
            }
            catch
            {
                MessageBox.Show("請輸入年份");
            }         


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.order_DetailsTableAdapter1.Fill(this.nwDataSet2.Order_Details);

            
            int a=dataGridView1.Rows[e.RowIndex].Index;
            var temp = from o in this.nwDataSet1.Orders
                       join od in this.nwDataSet2.Order_Details
                       on o.OrderID equals od.OrderID
                       where o.OrderID == Convert.ToInt32(dataGridView1.Rows[a].Cells[0].Value)
                       select od;

            this.dataGridView2.DataSource = temp.ToList();
                       
        }

        

        

        private void button12_Click(object sender, EventArgs e)
        {
            var a = from o in this.nwDataSet1.Orders.OrderBy(orders => orders.OrderID)
                   .Skip(currentPage * pageSize)
                   .Take(pageSize)
                    select o;
            this.dataGridView1.DataSource = a.ToList();
            currentPage--;
        }

        
    }
}
