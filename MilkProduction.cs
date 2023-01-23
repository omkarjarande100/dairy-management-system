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
    public partial class MilkProduction : Form
    {
        public MilkProduction()
        {
            InitializeComponent();
            FillCowId();
            populate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
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

        private void label16_Click(object sender, EventArgs e)
        {
            Finances Ob = new Finances();
            Ob.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            DashBoard Ob = new DashBoard();
            Ob.Show();
            this.Hide();
        }

        private void MilkProduction_Load(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jaran\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillCowId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CowId from CowTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CowId", typeof(int));
            dt.Load(Rdr);
            CowIdCb.ValueMember = "CowId";
            CowIdCb.DataSource = dt;
            Con.Close();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from MilkTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MilkDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            Cownmametb.Text = "";
            Amtb.Text = "";
            noonTb.Text = "";
            PmTb.Text = "";
            TotalTb.Text = "";
            key = 0;
        }
        private void GetCowName()
        {
            Con.Open();
            string query = "Select * from CowTbl where CowId= " + CowIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Cownmametb.Text = dr["CowName"].ToString();

            }
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || Cownmametb.Text == "" || Amtb.Text == "" || PmTb.Text == "" || noonTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into MilkTbl values(" + CowIdCb.SelectedValue.ToString() + ",'" + Cownmametb.Text + "'," + Amtb.Text + "," + noonTb.Text + "," + PmTb.Text + "," + TotalTb.Text + ",'" + Date.Value.Date + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Milk Saved Successfully");

                    Con.Close();
                    populate();
                    //Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }
        private void PmTb_MouseUp(object sender, MouseEventArgs e)
        { }
        private void PmTb_OnValueChanged(object sender, EventArgs e)
        { }
        private void TotalTb_OnValueChanged(object sender, EventArgs e)
        { }
        private void TotalTb_MouseClick(object sender, MouseEventArgs e)
        { }
        private void TotalTb_Click(object sender, EventArgs e)
        { }
        private void TotalTb_MouseEnter(object sender, EventArgs e)
        { }
        private void TotalTb_MouseDown(object sender, MouseEventArgs e)
        { }
        private void PmTb_Leave(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(Amtb.Text) + Convert.ToInt32(PmTb.Text) + Convert.ToInt32(noonTb.Text);
            TotalTb.Text = "" + total;
        }
        int key = 0;

        private void MilkDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowIdCb.SelectedValue = MilkDGV.SelectedRows[0].Cells[1].Value.ToString();
            Cownmametb.Text = MilkDGV.SelectedRows[0].Cells[2].Value.ToString();
            Amtb.Text = MilkDGV.SelectedRows[0].Cells[3].Value.ToString();
            noonTb.Text = MilkDGV.SelectedRows[0].Cells[4].Value.ToString();
            PmTb.Text = MilkDGV.SelectedRows[0].Cells[5].Value.ToString();
            TotalTb.Text = MilkDGV.SelectedRows[0].Cells[6].Value.ToString();
            Date.Text = MilkDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (Cownmametb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(MilkDGV.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Milk Product To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "delete from MilkTbl where MId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Successfully");

                    Con.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || Cownmametb.Text == "" || Amtb.Text == "" || PmTb.Text == "" || noonTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "update MilkTbl set CowName='" + Cownmametb.Text + "',AmMilk=" + Amtb.Text + ",NoonMilk=" + noonTb.Text + ",PmMilk=" + PmTb.Text + ",TotalMilk=" + TotalTb.Text + ",DateProd='" + Date.Value.Date + "' where Mid=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Updated Successfully");
                    Con.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}