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
    public partial class EditReview : Form
    {
        public EditReview()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //functie pentru afisarea review-urilor din baza de date
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
        //functie pentru stergerea datelor din casetele text
        private void ClearData()
        {
            film.Text = "";
            reviewer.Text = "";
            Stele.Text = "";
            Comentariu.Text = "";
        }
        //functie ce se executa la incarcarea paginii si afiseaza toate review-urile in forma nemodificata
        private void EditReview_Load(object sender, EventArgs e)
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
        //functie in care se extrag datele existente pentru review-ul selectat
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            film.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            reviewer.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Stele.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Comentariu.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        //functie ce se executa la apasarea butonului de update
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            //Se actualizeaza datele pentru review atunci cand este apasat butonul de update
            string query = "Update Rating set Nr_stele=@nrstele, Comentariu=@comentariu Where FilmID=(Select FilmID From Filme Where Titlu=@film) AND ReviewerID=(Select ReviewerID From Reviewer Where Username=@reviewer)";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@film", film.Text);
            com.Parameters.AddWithValue("@reviewer", reviewer.Text);
            com.Parameters.AddWithValue("@nrstele", Stele.Text);
            com.Parameters.AddWithValue("@comentariu", Comentariu.Text);
            com.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();
            SqlConnection sc1 = new SqlConnection();
            SqlCommand com1 = new SqlCommand();
            sc1.ConnectionString = ("Data Source=DESKTOP-MFIROOJ\\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            sc1.Open();
            com1.Connection = sc1;
            //Se actualizeaza nota filmului dupa ce a fost modificat review-ul
            com1.CommandText = @"Update Filme SET Rating_general=(Select Round(AVG(Cast(Rating.Nr_stele as float)),2)
				  From Rating 
				  WHERE Filme.FilmID=Rating.FilmID
				  Group by Rating.FilmID)
                   Where FilmID=(Select FilmID from Filme Where Titlu=@film1)";
            com1.Parameters.AddWithValue("@film1", film.Text);
            com1.ExecuteNonQuery();
            sc1.Close();
            DisplayData(); //Se fiseaza datele actualizate
            ClearData(); //Se sterg datele din casutele text
        }
    }
}
