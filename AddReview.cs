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
        //functie ce completeaza numele filmului la care se va introduce un review in caseta text destinata 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            film.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); //caseta text preia titlul complet al filmului selectat
            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = ("Data Source=DESKTOP-MFIROOJ\\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            sc.Open();
            com.Connection = sc;
            //comanda sql pentru selectarea utilizatorilor ce NU au introdus inca un review la filmul selectat
            com.CommandText = @"Select Username From Reviewer 
            where ReviewerID NOT IN( Select Distinct ReviewerID from Rating Where FilmID=(Select FilmID from Filme Where Titlu=@film))";
            com.Parameters.AddWithValue("@film", film.Text); //se preia numele filmului din caseta
            com.ExecuteNonQuery();
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            reviewer.DataSource = dt; //lista va contine doar username-ul utilizatorilor ce pot introduce un review la acel film
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
        //functie pentru afisarea filmelor ce contin o portiune din numele filmului introdusa de utilizator
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
        //functie ce se executa la apasarea butonului de adaugare review
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = ("Data Source=DESKTOP-MFIROOJ\\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            sc.Open();
            com.Connection = sc;
            //comanda sql pentru adaugarea unei inregistrari in tabela de review-uri
            com.CommandText = @"Insert into Rating(FilmID, ReviewerID, Nr_stele, Comentariu) Values ((Select FilmID From Filme Where Titlu=@film),(Select ReviewerID From Reviewer where Username=@reviewer),@nrstele,@comentariu)";
            //sunt preluate valorile din casetele text pentru a fi folosite in interogare
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
            //comanda sql pentru actualizarea rating-ului unui film dupa ce a fost adaugat un nou review
            com1.CommandText = @"Update Filme SET Rating_general=(Select Round(AVG(Cast(Rating.Nr_stele as float)),2)
				  From Rating 
				  WHERE Filme.FilmID=Rating.FilmID
				  Group by Rating.FilmID)
                   Where FilmID=(Select FilmID from Filme Where Titlu=@film1)";
            com1.Parameters.AddWithValue("@film1", film.Text);
            com1.ExecuteNonQuery();
            sc1.Close();
            DisplayData(); //Se afiseaza valorile actualizate pentru nota filmului
            //Se sterge textul din casetele text
            film.Text = null;
            reviewer.Text = null;
            Stele.Text = null;
            Comentariu.Text = null;
        }
    }
}
