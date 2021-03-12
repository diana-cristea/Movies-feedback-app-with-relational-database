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
    public partial class StergeReview : Form
    {
        public StergeReview()
        {
            InitializeComponent();
        }
        String film = null;
        String rev = null;
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //functie afisare date review-uri sub forma de tabel
        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select F.Titlu, R.Username, Ra.Nr_stele, Ra.Comentariu from Filme F inner join Rating Ra on" +
                " F.FilmID=Ra.FilmID inner join Reviewer R on R.ReviewerID=Ra.ReviewerID";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //Functie la incarcarea paginii, tot pentru afisarea reviewurilor
        private void StergeReview_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select F.Titlu, R.Username, Ra.Nr_stele, Ra.Comentariu from Filme F inner join Rating Ra on" +
                " F.FilmID=Ra.FilmID inner join Reviewer R on R.ReviewerID=Ra.ReviewerID";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //atunci cand este selectat un rand(o inregistrare)
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         //Se retine titlul filmului si username-ul reviewerului pentru a fi folosite la stergere
          film = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
          rev= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            //se sterge review-ul selectat
            string query = "Delete from Rating where FilmID=(Select FilmID from Filme where Titlu=@film) and ReviewerID=(Select ReviewerID from Reviewer Where Username=@reviewer)";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@film", film);
            com.Parameters.AddWithValue("@reviewer", rev);
            com.ExecuteNonQuery();
            con.Close();
            SqlConnection sc1 = new SqlConnection();
            SqlCommand com1 = new SqlCommand();
            sc1.ConnectionString = ("Data Source=DESKTOP-MFIROOJ\\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            sc1.Open();
            com1.Connection = sc1;
            //Se actualizeaza nota filmului fara acel review
            com1.CommandText = @"Update Filme SET Rating_general=(Select Round(AVG(Cast(Rating.Nr_stele as float)),2)
				  From Rating 
				  WHERE Filme.FilmID=Rating.FilmID
				  Group by Rating.FilmID)
                   Where FilmID=(Select FilmID from Filme Where Titlu=@film1)";
            com1.Parameters.AddWithValue("@film1", film);
            com1.ExecuteNonQuery();
            sc1.Close();
            DisplayData(); //Se afiseaza reviewurile fara cel sters
        }
    }
}
