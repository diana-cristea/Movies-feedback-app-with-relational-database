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
        // when loading the page dedicated to updating data, the data is displayed in initial format
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
        // data display function from the Movies table
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
        // delete text function from boxes
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
        // when the used clicks on a row, the text boxes take over the data of the selected movie so that it can be modified
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
        // function that is activated when the movie data update button is pressed
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            // sql command for updating data in the Movies table
            string query = "Update Filme set Titlu=@titlu, An_aparitie=@an, Durata=@durata, Tara_film=@tara, Limba=@limba, Descriere=@descriere, Regizor_principal=@regizor Where FilmID=@id";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            // Take the modified parameters from the text boxes
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
            DisplayData(); // the updated data is displayed
            ClearData(); // delete the data in the text boxes
        }
    }
}
