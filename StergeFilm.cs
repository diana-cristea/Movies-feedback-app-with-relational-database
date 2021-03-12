using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProiectBD
{
    public partial class StergeFilm : Form
    {
        public StergeFilm()
        {
            InitializeComponent();
        }
        int ID = 0;
        //functie pentru incarcarea paginii, in care se afiseaza toate filmele din baza de date
        private void StergeFilm_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select * From Filme";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //functie de afisare a datelor sub forma de tabel
        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select * From Filme";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //cand este apasat butonul de stergere film
            private void button1_Click(object sender, EventArgs e)
        {
            //filmul este sters mai intai din tabelele de legatura
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            //se sterg inregistrarile review-urilor la filmul care urmeaza a fi sters
            string query1 = "Delete from Rating where FilmID=@id";
            con.Open();
            SqlCommand com1 = new SqlCommand(query1, con);
            com1.Parameters.AddWithValue("@id", ID);
            com1.ExecuteNonQuery();
            //Se sterg inregitrarile din tabela Distributie care contineau id-ul filmului ce urmeaza a fi sters
            string query2 = "Delete from Distributie where FilmID=@id";
            SqlCommand com2 = new SqlCommand(query2, con);
            com2.Parameters.AddWithValue("@id", ID);
            com2.ExecuteNonQuery();
            // Se sterge filmul
            string query = "Delete from Filme where FilmID=@id";

            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@id", ID);
            com.ExecuteNonQuery();
            //Se afiseaza un mesaj corespunzator
            MessageBox.Show("Filmul a fost sters");
            con.Close();
            DisplayData(); //Se afiseaza filmele, fara cel care a fost sters
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Se retine ID-ul filmului selectat, pentru a fi folosit la stergere
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); 
            
        }
    }
}
