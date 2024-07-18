using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projekt
{
    public partial class Form1 : Form
    {
        String constring;
        MySqlConnection con;
        int id;
        string query;

        public Form1()
        {
            InitializeComponent();
            //Není připojená DB (MySQL)
            //Connectdb();
            //Count();
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
            label4.BackColor = System.Drawing.Color.Transparent;
            label5.BackColor = System.Drawing.Color.Transparent;
            label7.BackColor = System.Drawing.Color.Transparent;
            lblCount.BackColor = System.Drawing.Color.Transparent;

        }
        //Pripojeni na databazi (db)
        private void Connectdb()
        {
            constring = AppSettings.ConnectionString();

            con = new MySqlConnection(constring);
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                MessageBox.Show("Connection create");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        //Funcke na vypocitani poctu 
        private void Count()
        {
            query = "SELECT COUNT(id) FROM customer";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            int i = 0;
            while (rdr.Read())
            {
                i = rdr.GetInt32(0);
            }
            rdr.Close();
            lblCount.Text = i.ToString();

        }
        //Vytvoreni CRUD (Create, Read, Update, Delete) funkci po kliknuti na tlacitka
        private void createBtn_Click(object sender, EventArgs e)
        {

            if((textJmeno != null && !string.IsNullOrWhiteSpace(textJmeno.Text)) && (textPrijmeni != null && !string.IsNullOrWhiteSpace(textPrijmeni.Text)) && (textAdresa != null && !string.IsNullOrWhiteSpace(textAdresa.Text)) && (textCastka != null && !string.IsNullOrWhiteSpace(textCastka.Text)))
            {
                MySqlCommand cmd2;
                //Kontrola, jestli textPozn je prazny nebo ne
                if (textPozn != null && !string.IsNullOrWhiteSpace(textPozn.Text))
                {
                    cmd2 = new MySqlCommand(@"INSERT INTO note (description) " + "VALUES (@des); ", con);
                    cmd2.Parameters.Add(new MySqlParameter("@des", textPozn.Text));
                    cmd2.ExecuteNonQuery();
      
                }
                else
                {
                    cmd2 = new MySqlCommand(@"INSERT INTO note (description) " + "VALUES (@des); ", con);
                    cmd2.Parameters.Add(new MySqlParameter("@des", "Nic"));
                    cmd2.ExecuteNonQuery();

                }
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO customer (surName,lastName,address,cost,id_Note) " + "VALUES (@sur,@last,@add,@co,@id); ", con);
                cmd.Parameters.Add(new MySqlParameter("@sur", textJmeno.Text));
                cmd.Parameters.Add(new MySqlParameter("@last", textPrijmeni.Text));
                cmd.Parameters.Add(new MySqlParameter("@add", textAdresa.Text));
                cmd.Parameters.Add(new MySqlParameter("@co", textCastka.Text));
                cmd.Parameters.Add(new MySqlParameter("@id", cmd2.LastInsertedId));
                cmd.ExecuteNonQuery();


                MySqlCommand cmd4 = new MySqlCommand(@"INSERT INTO component (name) " + "VALUES (@name); ", con);
                cmd4.Parameters.Add(new MySqlParameter("@name", "Nic"));
                cmd4.ExecuteNonQuery();

                MySqlCommand cmd3 = new MySqlCommand(@"INSERT INTO Invoice (id_Customer, id_Component) " + "VALUES (@id,@idC); ", con);
                cmd3.Parameters.Add(new MySqlParameter("@id", cmd.LastInsertedId));
                cmd3.Parameters.Add(new MySqlParameter("@idC", cmd4.LastInsertedId));
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Note created");

                textJmeno.Clear();
                textPrijmeni.Clear();
                textAdresa.Clear();
                textCastka.Clear();
                textPozn.Clear();
                Count();
            }
            else
            {
                MessageBox.Show("Vyplň všechny pole!!");

            }
        }

        //
        private void showBtn_Click(object sender, EventArgs e)
        {
            textVypis.Clear();
            String query = "SELECT * FROM customer";
            MySqlDataAdapter SDA = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;

            String query2 = "SELECT * FROM Note";
            MySqlDataAdapter SDA2 = new MySqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            SDA2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //POUZE S FAKTUROU
            string sql = "SELECT Customer.surName, Customer.lastName, Customer.address, Customer.cost, Note.description, Component.name FROM Customer JOIN Note on customer.id_Note = Note.id JOIN Invoice on Invoice.id_Customer = customer.id JOIN Component on Invoice.id_Component = Component.id";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            string newLine = Environment.NewLine;

         
            while (rdr.Read())
            {


                textVypis.Text += "Jmeno: " + rdr.GetString(0) + " " + rdr.GetString(1) + newLine + "Adresa: " + rdr.GetString(2) + newLine + "Částka: " + rdr.GetInt32(3) + newLine + "Poznámka: " + rdr.GetString(4) + newLine + "Komponent: " + rdr.GetString(5) + newLine + newLine;

            }
            rdr.Close();
            
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            query = "UPDATE customer SET surName = '" + textJmeno.Text + "', lastName = '" + textPrijmeni.Text + "', address = '" + textAdresa.Text + "', cost = '" + textCastka.Text + "'WHERE id='" + id + "'";
            MySqlDataAdapter SDA = new MySqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();

            query = "SELECT id_Note FROM Customer WHERE id = '" + id + "'";
            MySqlCommand cmd2 = new MySqlCommand(query, con);
            cmd2.ExecuteNonQuery();
            MySqlDataReader rdr = cmd2.ExecuteReader();
            int id1 = 0;
            while (rdr.Read())
            {
                id1 = rdr.GetInt32(0);
            }
            rdr.Close();

            query = "UPDATE note SET description = '" + textPozn.Text + "' WHERE id='" + id1 + "'";
            MySqlDataAdapter SDA2 = new MySqlDataAdapter(query, con);
            SDA2.SelectCommand.ExecuteNonQuery();


            MessageBox.Show("Note Updated");

            textJmeno.Clear();
            textPrijmeni.Clear();
            textAdresa.Clear();
            textCastka.Clear();
            textPozn.Clear();

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            textJmeno.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textPrijmeni.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textAdresa.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textCastka.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textPozn.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();

        }
        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
            textPozn.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            
        }


        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (textJmeno != null && !string.IsNullOrWhiteSpace(textJmeno.Text))
            {

                query = "SELECT id_Note FROM Customer WHERE id = '" + id + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MySqlDataReader rdr = cmd.ExecuteReader();
                int id2 = 0;
                while (rdr.Read())
                {
                    id2 = rdr.GetInt32(0);
                }
                rdr.Close();

                query = "SELECT id FROM Invoice WHERE id_Customer = '" + id + "'";
                MySqlCommand cmd2 = new MySqlCommand(query, con);
                cmd2.ExecuteNonQuery();
                MySqlDataReader rdr2 = cmd2.ExecuteReader();
                int id3 = 0;
                while (rdr2.Read())
                {
                    id3 = rdr2.GetInt32(0);
                }
                rdr2.Close();

                query = "DELETE FROM invoice WHERE id = '" + id3 + "'";
                MySqlDataAdapter SDA2 = new MySqlDataAdapter(query, con);
                SDA2.SelectCommand.ExecuteNonQuery();

                

                query = "DELETE FROM customer WHERE id= '" + id + "'";
                MySqlDataAdapter SDA3 = new MySqlDataAdapter(query, con);
                SDA3.SelectCommand.ExecuteNonQuery();


                query = "DELETE FROM note WHERE id = '" + id2 + "'";
                MySqlDataAdapter SDA = new MySqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Note DELETED");

            }
            else
            {
                query = "UPDATE note SET description = 'Nic' WHERE id = '"+id+"'";
                MySqlDataAdapter SDA = new MySqlDataAdapter(query, con);
                SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Note DELETED");
            }
            textJmeno.Clear();
            textPrijmeni.Clear();
            textAdresa.Clear();
            textCastka.Clear();
            textPozn.Clear();
            Count();
        }

        //Vyhledani zakaznika
        private void search_Click(object sender, EventArgs e)
        {
            if(textBox1 != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textVypis.Clear();
                string value = textBox1.Text.ToString();
                query = "SELECT Customer.surName, Customer.lastName, Customer.address, Customer.cost, Note.description, Component.name FROM Customer LEFT JOIN Note on Customer.id_Note = Note.id LEFT JOIN Invoice on Invoice.id_Customer = customer.id JOIN Component on Invoice.id_Component = Component.id WHERE CONCAT(surName, lastName, address, cost) like '%" + textBox1.Text + "%'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;


                MySqlDataReader rdr = cmd.ExecuteReader();
                string newLine = Environment.NewLine;

                while (rdr.Read())
                {

                  textVypis.Text += "Jmeno: " + rdr.GetString(0) + " " + rdr.GetString(1) + newLine + "Adresa: " + rdr.GetString(2) + newLine + "Částka: " + rdr.GetInt32(3) + newLine + "Poznámka: " + rdr.GetString(4) + newLine + "Komponent: " + rdr.GetString(5) + newLine + newLine;

                }
                rdr.Close();
                fill_Number();
            }


        }
        public void fill_Number()
        {
            query = "SELECT COUNT(id) FROM Customer WHERE CONCAT(surName, lastName, address, cost) like '%" + textBox1.Text + "%'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            string newLine = Environment.NewLine;
            while (rdr.Read())
            {
                lblCount2.Text = rdr.GetInt32(0).ToString();
            }
            rdr.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Invoice a = new Invoice();
            a.ShowDialog();
            a.Close();
           
        }



    }
}
