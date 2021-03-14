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
    public partial class AddReview : Form
    {
        public AddReview()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //function that completes the name of the movie for which a review will be entered in the intended text box 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            film.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); // the text box takes over the full title of the selected movie
            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = ("Data Source=DESKTOP-MFIROOJ\\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            sc.Open();
            com.Connection = sc;
            // sql command to select users who have NOT yet entered a review for the selected movie
            com.CommandText = @"Select Username From Reviewer 
            where ReviewerID NOT IN( Select Distinct ReviewerID from Rating Where FilmID=(Select FilmID from Filme Where Titlu=@film))";
            com.Parameters.AddWithValue("@film", film.Text); // take the name of the movie from the text box 
            com.ExecuteNonQuery();
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            reviewer.DataSource = dt; // the list will only contain the username of the users who can enter a review for that movie
            reviewer.DisplayMember = "ID";
            reviewer.ValueMember = "Username";
            sc.Close();
        }
        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select Titlu,Rating_general,Regizor_principal from Filme where Titlu like '%" + film.Text.Trim() + "%' ";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        // function for displaying movies that contain a portion of the movie name entered by the user
        private void film_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select Titlu,Rating_general,Regizor_principal from Filme where Titlu like '%" + film.Text.Trim() + "%' ";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
       // function that is executed when pressing the add review button
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = ("Data Source=DESKTOP-MFIROOJ\\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            sc.Open();
            com.Connection = sc;
            // sql command to add a record to the review table
            com.CommandText = @"Insert into Rating(FilmID, ReviewerID, Nr_stele, Comentariu) Values ((Select FilmID From Filme Where Titlu=@film),(Select ReviewerID From Reviewer where Username=@reviewer),@nrstele,@comentariu)";
            // values are taken from the text boxes to be used in the query
            com.Parameters.AddWithValue("@film", film.Text); 
            com.Parameters.AddWithValue("@reviewer", reviewer.Text);
            com.Parameters.AddWithValue("@nrstele", Stele.Text);
            com.Parameters.AddWithValue("@comentariu", Comentariu.Text);
            com.ExecuteNonQuery();
            sc.Close();
            SqlConnection sc1 = new SqlConnection();
            SqlCommand com1 = new SqlCommand();
            sc1.ConnectionString = ("Data Source=DESKTOP-MFIROOJ\\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            sc1.Open();
            com1.Connection = sc1;
            // command sql to update a movie's rating after a new review has been added
            com1.CommandText = @"Update Filme SET Rating_general=(Select Round(AVG(Cast(Rating.Nr_stele as float)),2)
				  From Rating 
				  WHERE Filme.FilmID=Rating.FilmID
				  Group by Rating.FilmID)
                   Where FilmID=(Select FilmID from Filme Where Titlu=@film1)";
            com1.Parameters.AddWithValue("@film1", film.Text);
            com1.ExecuteNonQuery();
            sc1.Close();
            DisplayData(); // The updated values for the movie note are displayed
            // Delete the text from the text boxes
            film.Text = null;
            reviewer.Text = null;
            Stele.Text = null;
            Comentariu.Text = null;
        }
    }
}
