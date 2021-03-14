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
    public partial class FilmNou : Form
    {
        public FilmNou()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-MFIROOJ\\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            String[] valuesList = new string[30];
            connection.Open();
            // All movie titles are selected
            SqlCommand command = new SqlCommand("Select Titlu From Filme", connection);
            SqlDataReader dataReader = command.ExecuteReader();
            int i = 0;
            // Create a vector with these values
            while (dataReader.Read())
            {
                valuesList[i]=dataReader[0].ToString();
                i++;
            }
            connection.Close();
            int ok = 0;
            // Check if there is already a movie with the title introduced in the database
            for (int j = 0; j < 30; j++)
                if (Titlu.Text == valuesList[j]) ok = 1;
            if (ok == 1) MessageBox.Show("Filmul exista deja in baza de date"); // if the database already has a movie with that name, a warning message is displayed
            // Thus, the movie is entered in the database
            else
            {
                SqlConnection sc = new SqlConnection();
                SqlCommand com = new SqlCommand();
                sc.ConnectionString = ("Data Source=DESKTOP-MFIROOJ\\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
                sc.Open();
                com.Connection = sc;
                com.CommandText = @"Insert into Filme (Titlu, An_aparitie, Durata, Tara_film, Limba, Descriere, Regizor_principal) Values (@titlu, @an, @durata, @tara, @limba, @descriere, @regizor)";
                com.Parameters.AddWithValue("@titlu", Titlu.Text);
                com.Parameters.AddWithValue("@an", An.Text);
                com.Parameters.AddWithValue("@durata", Durata.Text);
                com.Parameters.AddWithValue("@tara", Tara.Text);
                com.Parameters.AddWithValue("@limba", Limba.Text);
                com.Parameters.AddWithValue("@descriere", Descriere.Text);
                com.Parameters.AddWithValue("@regizor", Regizor.Text);
                com.ExecuteNonQuery();
                sc.Close(); // the connection closes
               // Delete data from text boxes
                Titlu.Text = null;
                An.Text = null;
                Durata.Text = null;
                Tara.Text = null;
                Limba.Text = null;
                Descriere.Text = null;
                Regizor.Text = null;
            }
        }

    }
}
