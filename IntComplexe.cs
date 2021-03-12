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
    public partial class IntComplexe : Form
    {
        public IntComplexe()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //	Actorii ce joaca in filmele care au nota mai mare decat media notelor celorlalte filme.
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select Distinct A.Prenume, A.Nume " +
                            "From Actori A inner join Distributie D on A.ActorID = D.ActorID " +
                            " inner join Filme F on F.FilmID = D.FilmID " +
                             "Where F.Rating_general > (Select Avg(Rating_general) " +
                                                         " From Filme " +
                                                        " Where FilmID<>F.FilmID)";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Filmele care au numarul de reviewuri mai mare decat media numarului de reviewuri ale tututor filmelor
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select F.Titlu, NrRev.Nr " +
                "From Filme F, (Select FilmID, Count(*) as Nr " +
                                "From Rating " +
                                 "Group by FilmID) as NrRev " +
                                 "Where F.FilmID = NrRev.FilmID AND NrRev.Nr > " +
                                                                    " (Select Avg(NrRev.Nr) " +
                                                                     " From(Select FilmID, Count(*) as Nr " +
                                                                       "From Rating " +
                                                                       "Group by FilmID) as NrRev )";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //	Numele si numarul de reviewuri ale utilizatorilor ce s-au inscris acum un anumit numar de ani
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select U.Nume, U.Prenume, " +
                "(Select Count(*) " +
                "From Rating " +
                "Where ReviewerID = U.ReviewerID) as NumarReviewuri " +
                "From Reviewer U " +
                "Where Year(Getdate()) - U.An_inscriere >"+Int32.Parse(textBox1.Text) +" " ;
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //	Genurile de filme in care joaca cei mai multi actori de gen(masculin sau feminin)
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MFIROOJ\SQLEXPRESS;Initial Catalog=MovieFeedbackandClassif;Integrated Security=True");
            string query = "Select G.Nume_gen, Count(*) as nrActori " +
                            "From Genuri G inner join Gen_film Gf on G.GenID = Gf.GenID " +
                                        "inner join Filme F on F.FilmID = Gf.FilmID " +
                                         "inner join Distributie D on F.FilmID = D.FilmID " +
                                         " inner join Actori A on A.ActorID = D.ActorID " +
                            "Where A.Sex ='" + comboBox1.Text + "' " +
                             "Group by G.Nume_gen " +
                            "Having Count(A.ActorID) = (Select TOP 1 Count(*) " +
                                                        " From Genuri G1 inner join Gen_film Gf1 on G1.GenID = Gf1.GenID " +
                                                                " inner join Filme F1 on F1.FilmID = Gf1.FilmID " +
                                                                " inner join Distributie D1 on F1.FilmID = D1.FilmID " +
                                                                "  inner join Actori A1 on A1.ActorID = D1.ActorID" +
                                                         " Where A1.Sex ='" + comboBox1.Text+"' "+
                                                         " Group by G1.Nume_gen" +
                                                         " Order by Count(*) DESC)";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter sdr = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //Atunci cand se incarca pagina, se adauga lista de valori posibile pentru genul unui actor(M sau F)
        private void IntComplexe_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("M");
            comboBox1.Items.Add("F");
        }
    }
}
