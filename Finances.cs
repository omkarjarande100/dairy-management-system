using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DairyFarmSystem
{
    public partial class Finances : Form
    {
        public Finances()
        {
            InitializeComponent();
            populateExp();
            populateInc();
            FillEmpId();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
            Ob.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MilkProduction Ob = new MilkProduction();
            Ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            CowHealth Ob = new CowHealth();
            Ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Breeding Ob = new Breeding();
            Ob.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            MilkSales Ob = new MilkSales();
            Ob.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jaran\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void populateExp()
        {
            Con.Open();
            string query = "select * from ExpenditureTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void populateInc()
        {
            Con.Open();
            string query = "select * from IncomeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FilterIncome()
        {
            Con.Open();
            string query = "select * from IncomeTbl where IncDate='"+IncomeDateFilter.Value.Date+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FilterExp()
        {
            Con.Open();
            string query = "select * from ExpenditureTbl where ExpDate='" + ExpDateFilter.Value.Date + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void ClearExp()
        {
            AmountTb.Text = "";
        }
        private void label15_Click(object sender, EventArgs e)
        {
            DashBoard Ob = new DashBoard();
            Ob.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (PurpCb.SelectedIndex == -1 || AmountTb.Text == "" || EmpIdCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into ExpenditureTbl values('" + ExpDate.Value.Date + "','" + PurpCb.SelectedItem.ToString() + "'," + AmountTb.Text + "," + EmpIdCb.SelectedValue.ToString() + ")";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expenditure Saved Successfully");

                    Con.Close();
                    populateExp();
                    ClearExp();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void FillEmpId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select EmpId from EmployeeTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId", typeof(int));
            dt.Load(Rdr);
            EmpIdCb.ValueMember = "EmpId";
            EmpIdCb.DataSource = dt;
            Con.Close();
        }
        private void ClearInc()
        {
            IncPurCb.SelectedIndex = -1;
            IncAmount.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (IncPurCb.SelectedIndex == -1 || IncAmount.Text == "" || EmpIdCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into IncomeTbl values('" + IncDate.Value.Date + "','" + IncPurCb.SelectedItem.ToString() + "'," + IncAmount.Text + "," + EmpIdCb.SelectedValue.ToString() + ")";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income Saved Successfully");

                    Con.Close();
                    populateInc();
                    ClearInc();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            FilterIncome();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            populateInc();
        }

        private void ExpDateFilter_ValueChanged(object sender, EventArgs e)
        {
            FilterExp();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            populateExp();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void Finances_Load(object sender, EventArgs e)
        {

        }
    }
}
