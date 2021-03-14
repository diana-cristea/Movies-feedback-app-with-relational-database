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

namespace ProiectBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Login page
         // function for pressing the login button
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            // if the username and password are entered correctly, then the main page opens
            if (textBox1.Text == "Admin123" && textBox2.Text == "bazadedate")
            {
                this.Hide();
                Main ss = new Main();
                ss.Show();
            }
            // otherwise, an error message appears
            else MessageBox.Show("Username sau parola gresita");
            con.Close();
        }

      
    }
}
