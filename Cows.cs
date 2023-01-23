using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DairyFarmSystem
{
    public partial class Cows : Form
    {
        public Cows()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jaran\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
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

        private void label15_Click(object sender, EventArgs e)
        {
            DashBoard Ob = new DashBoard();
            Ob.Show();
            this.Hide();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void label16_Click(object sender, EventArgs e)
        {
            Finances Ob = new Finances();
            Ob.Show();
            this.Hide();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from Cowtbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CowsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear ()
        {
            CowNameTb.Text = "";
            EarTagTb.Text = "";
            ColorTb.Text = "";
            BreedTb.Text = "";
            WeightTb.Text = "";
            AgeTb.Text = "";
            PastureTb.Text = "";
            key = 0;
        }
        int age = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if(CowNameTb.Text=="" || EarTagTb.Text == ""||ColorTb.Text == ""||BreedTb.Text == ""||WeightTb.Text =="" || AgeTb.Text == "" || PastureTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into CowTbl values('" + CowNameTb.Text + "','" + EarTagTb.Text + "','" + ColorTb.Text + "','" + BreedTb.Text + "'," + age + "," + WeightTb.Text + ",'" + PastureTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Saved Successfully");

                    Con.Close();
                    populate();
                    Clear();
                } catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Cows_Load(object sender, EventArgs e)
        {

        }

        private void DOBDate_ValueChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days)/365;
        }

        private void DOBDate_MouseLeave(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days) / 365;
            AgeTb.Text = "" + age;
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }
        int key = 0;
        private void CowsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowNameTb.Text = CowsDGV.SelectedRows[0].Cells[1].Value.ToString();
            EarTagTb.Text = CowsDGV.SelectedRows[0].Cells[2].Value.ToString();
            ColorTb.Text = CowsDGV.SelectedRows[0].Cells[3].Value.ToString();
            BreedTb.Text = CowsDGV.SelectedRows[0].Cells[4].Value.ToString();
            WeightTb.Text = CowsDGV.SelectedRows[0].Cells[6].Value.ToString();
            PastureTb.Text = CowsDGV.SelectedRows[0].Cells[7].Value.ToString();
            if(CowNameTb.Text == "")
            {
                key = 0;
                age = 0;
            }else
            {
                key = Convert.ToInt32(CowsDGV.SelectedRows[0].Cells[0].Value.ToString());
                age = Convert.ToInt32(CowsDGV.SelectedRows[0].Cells[5].Value.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (key ==0)
            {
                MessageBox.Show("Select The Cow To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "delete from CowTbl where CowId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Deleted Successfully");

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
            if (CowNameTb.Text == "" || EarTagTb.Text == "" || ColorTb.Text == "" || BreedTb.Text == "" || WeightTb.Text == "" || AgeTb.Text == "" || PastureTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "update CowTbl set CowName='" + CowNameTb.Text + "',EarTag='" + EarTagTb.Text + "',Color='" + ColorTb.Text + "',Breed='" + BreedTb.Text + "',Age=" + age + ",weightatbirth=" + WeightTb.Text + ",Pasture='" + PastureTb.Text + "' where Cowid=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Updated Successfully");

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
        private void SearchCow()
        {
            Con.Open();
            String query = "Select * from CowTbl where CowName like '%" + CowSearchTb.Text + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CowsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            SearchCow();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}