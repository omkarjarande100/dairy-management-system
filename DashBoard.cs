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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            Finance();
            Logistic();
            GetMax();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            Finances Ob = new Finances();
            Ob.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            MilkSales Ob = new MilkSales();
            Ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Breeding Ob = new Breeding();
            Ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            CowHealth Ob = new CowHealth();
            Ob.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MilkProduction Ob = new MilkProduction();
            Ob.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
            Ob.Show();
            this.Hide();
        }

        private void bunifuMaterialTextbox6_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jaran\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Finance()
        {
            // we calculate the finance related analytics
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select sum(IncAmt) from IncomeTbl", Con);
            SqlDataAdapter sda1 = new SqlDataAdapter("Select sum(ExpAmount) from ExpenditureTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int inc, exp;
              double bal;
            inc = Convert.ToInt32(dt.Rows[0][0].ToString());
           
            IncLbl.Text = "Rs"+dt.Rows[0][0].ToString();
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            exp = Convert.ToInt32(dt1.Rows[0][0].ToString());
            bal = inc - exp;
            ExpLbl.Text = "Rs"+dt1.Rows[0][0].ToString();
            BalLbl.Text = "Rs" + bal;
            Con.Close();

        }
        private void Logistic()
        {
            // we calculate the Logistics related analytics
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from CowTbl", Con);
            SqlDataAdapter sda1 = new SqlDataAdapter("Select sum(TotalMilk) from MilkTbl", Con);
            SqlDataAdapter sda2 = new SqlDataAdapter("Select Count(*) from EmployeeTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Cownumlbl.Text = dt.Rows[0][0].ToString();
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            MilkLbl.Text = dt1.Rows[0][0].ToString() + "Liters";
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            Empnumlbl.Text = dt2.Rows[0][0].ToString();
            Con.Close();

        }
        private void GetMax()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select Max(IncAmt) from IncomeTbl", Con);
            SqlDataAdapter sda1 = new SqlDataAdapter("Select Max(ExpAmount) from ExpenditureTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            HighAmtlbl.Text = "Rs" + dt.Rows[0][0].ToString();
            //HighDateLbl.Text = dt.Rows[0][1].ToString();
            HighExplbl.Text = "Rs" + dt1.Rows[0][0].ToString();

        }
        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
