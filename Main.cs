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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //functie pentru afisarea filmelor al caror titlu contin o anumita secventa de caractere
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select * from Filme where Titlu like '%" + textBox2.Text.Trim() + "%' ";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }
        //Afisarea filmelor in care joaca un actor al carui nume contine o anumita secventa de caractere
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select F.Titlu, A.Prenume, A.Nume from Filme F inner join Distributie D on F.FilmID=D.FilmID inner join Actori A on A.ActorID=D.ActorID where A.Nume like '%" + textBox1.Text.Trim() + "%' or A.Prenume like '%" + textBox1.Text.Trim() + "%'";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //buton catre pagina de stergere review
        private void button3_Click(object sender, EventArgs e)
        {
            StergeReview ss = new StergeReview();
            ss.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //functie pentru afisarea filmelor dintr-un anumit gen selectat din lista
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select Titlu, An_aparitie from Filme F inner join Gen_film Gf on F.FilmID=Gf.FilmID inner join Genuri G on G.GenID=Gf.GenID where G.Nume_gen='" + comboBox1.Text+ "'";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //buton catre pagina de adaugare film
        private void button1_Click(object sender, EventArgs e)
        {
            FilmNou ss = new FilmNou();
            ss.Show();
        }
        //buton catre pagina de editare informatii film
        private void button5_Click(object sender, EventArgs e)
        {
            EditFilm ss = new EditFilm();
            ss.Show();
        }
        //buton catre pagina de stergere film
        private void button6_Click(object sender, EventArgs e)
        {
            StergeFilm ss = new StergeFilm();
            ss.Show();
        }
        //buton catre pagina de adaugare review
        private void button4_Click(object sender, EventArgs e)
        {
            AddReview ss = new AddReview();
            ss.Show();
        }
        //buton catre pagina de editare review
        private void button2_Click(object sender, EventArgs e)
        {
            EditReview ss = new EditReview();
            ss.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        //buton catre pagina cu interogari complexe
        private void button11_Click(object sender, EventArgs e)
        {
            IntComplexe ss = new IntComplexe();
            ss.Show();
        }
        //interogare simpla
        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select F.Titlu, Count(R.ReviewerID) as Numar_Reviewuri " +
                "from Filme F left join Rating R on F.FilmID=R.FilmID " +
                "Group by F.Titlu ";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //interogare simpla
        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select U.Nume, U.Prenume, Count(*) as NrReviewuri " +
                "from Reviewer U inner join Rating R on U.ReviewerID=R.ReviewerID " +
                " Group by U.Nume, U.Prenume " +
                "Order by Count(*) DESC";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //interogare simpla
        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select Distinct A.Prenume, A.Nume " +
                "from Actori A inner join Distributie D on A.ActorID=D.ActorID " +
                "inner join Filme F on F.FilmID=D.FilmID " +
                " Where F.Rating_general>9";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
        //interogare simpla
        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select U.Username, F.Titlu, R.Nr_stele, R.Comentariu " +
                "from Reviewer U inner join Rating R on U.ReviewerID=R.ReviewerID " +
                "inner join Filme F on F.FilmID=R.FilmID " +
                "Where U.An_inscriere>2000 ";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
    }
}
