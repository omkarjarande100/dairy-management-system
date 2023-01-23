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
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            populate();
        }

        private void Employees_Load(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jaran\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            PhoneTb.Text = "";
            EmpNameTb.Text = "";
            AddressTb.Text = "";
            GenCb.SelectedIndex = -1;
            key = 0;
            EmpPassTb.Text = "";        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || PhoneTb.Text == "" || AddressTb.Text == "" || EmpPassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String Query = "insert into EmployeeTbl values('" + EmpNameTb.Text + "','" + DOB.Value.Date + "','" + GenCb.SelectedItem.ToString() + "','" + PhoneTb.Text + "','" + AddressTb.Text + "','"+EmpPassTb.Text+"')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Saved Successfully");

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
        int key = 0;
        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            DOB.Text = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenCb.SelectedItem = EmployeeDGV.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = EmployeeDGV.SelectedRows[0].Cells[4].Value.ToString();
            AddressTb.Text = EmployeeDGV.SelectedRows[0].Cells[5].Value.ToString();
            EmpPassTb.Text = EmployeeDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (EmpNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EmployeeDGV.SelectedRows[0].Cells[0].Value.ToString());
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Employee To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "delete from EmployeeTbl where EmpId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Successfully");

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
            if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || PhoneTb.Text == "" || AddressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "update EmployeeTbl set EmpName='" + EmpNameTb.Text + "',EmpDOB='" + DOB.Value.Date + "',Gender='" + GenCb.SelectedItem.ToString() + "',Phone='" + PhoneTb.Text + "',Address='" + AddressTb.Text + "',EmpPass='"+EmpPassTb.Text+"' where Empid=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated Successfully");

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
    }
}
