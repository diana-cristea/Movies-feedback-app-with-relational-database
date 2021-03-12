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
    public partial class EditFilm : Form
    {
        public EditFilm()
        {
            InitializeComponent();
        }
        int ID = 0;
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        //la incarcarea paginii dedicate actualizarii de date se afiseaza datele in format initial
        private void EditFilm_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select FilmID, Titlu, An_aparitie, Durata, Tara_film, Limba, Descriere, Regizor_principal from Filme";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //functie de afisare date din tabela Filme
        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select FilmID, Titlu, An_aparitie, Durata, Tara_film, Limba, Descriere, Regizor_principal from Filme";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //functie de stergere text din casete
        private void ClearData()
        {
            Titlu.Text = "";
            An.Text = "";
            Durata.Text = "";
            Tara.Text = "";
            Limba.Text = "";
            Descriere.Text = "";
            Regizor.Text = "";
        }
        private void Regizor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        //atunci cand se apasa in dreptul unui rand, casetele text preiau datele filmului selectat pentru a putea fi modificate
        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Titlu.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            An.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Durata.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Tara.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            Limba.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            Descriere.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            Regizor.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }
        //functie ce se activeaza la apasarea butonului de actualizare date film
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            //comanda sql pentru actualizarea datelor in tabela Filme
            string query = "Update Filme set Titlu=@titlu, An_aparitie=@an, Durata=@durata, Tara_film=@tara, Limba=@limba, Descriere=@descriere, Regizor_principal=@regizor Where FilmID=@id";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            //Se preiau parametrii modificati din casetele text
            com.Parameters.AddWithValue("@id", ID);
            com.Parameters.AddWithValue("@titlu",Titlu.Text);
            com.Parameters.AddWithValue("@an", An.Text);
            com.Parameters.AddWithValue("@durata", Durata.Text);
            com.Parameters.AddWithValue("@tara", Tara.Text);
            com.Parameters.AddWithValue("@limba", Limba.Text);
            com.Parameters.AddWithValue("@descriere", Descriere.Text);
            com.Parameters.AddWithValue("@regizor", Regizor.Text);
            com.ExecuteNonQuery();
            MessageBox.Show("Inregistrare actualizata cu succes!"); //se afiseaza un mesaj de informare 
            con.Close();
            DisplayData(); //se afiseaza datele actualizate
            ClearData(); //se sterg datele din casetele text
        }
    }
}
