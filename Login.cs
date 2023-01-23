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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            PasswordTb.Text = "";
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jaran\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter the UserName And Password");
            }
            else
            {
                if (RoleCb.SelectedIndex > -1)
                {
                    if (RoleCb.SelectedIndex.ToString() == "Admin")
                    {
                        if (UnameTb.Text == "Admin" && PasswordTb.Text == "Admin")
                        {
                            Employees prod = new Employees();
                            prod.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("If you are the Admin, Enter the Correct Ip and Passsword");
                        }
                    }
                    else
                    {
                        Con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from EmployeeTbl where EmpName='" + UnameTb.Text + "' and EmpPass='" + PasswordTb.Text + "'", Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            Cows Cow = new Cows();
                            Cow.Show();
                            this.Hide();
                            Con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong UserName or Password");
                        }
                        Con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Select A Role");
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RoleCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

