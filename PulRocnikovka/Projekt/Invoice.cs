using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    public partial class Invoice : Form
    {
        string constring = "Server=localhost;Database=mydb;Uid=root;Pwd=''";
        MySqlConnection con;
        MySqlCommand cmd3;
        public Invoice()
        {
            InitializeComponent();
            con = new MySqlConnection(constring);
            con.Open();
            //vypsat();
        }
       /* private void vypsat()
        {
            cmd3 = new MySqlCommand(@"SELECT name FROM component ", con);
            cmd3.ExecuteNonQuery();
            MySqlDataReader rdr = cmd3.ExecuteReader();
            string newLine = Environment.NewLine;
            while (rdr.Read())
            {
                textBox3.Text += rdr.GetString(0) + newLine;
            }
            rdr.Close();
            
        }
        */
       
        private void button1_Click(object sender, EventArgs e)
        {
            cmd3 = new MySqlCommand(@"SELECT name FROM component WHERE name = '" + textBox2.Text + "'", con);
            cmd3.ExecuteNonQuery();
            MySqlDataReader rdr = cmd3.ExecuteReader();
            string a = "";
            while (rdr.Read())
            {
                a = rdr.GetString(0);
            }
            rdr.Close();

            if (String.IsNullOrEmpty(a) == true)
            {
                
                MySqlCommand cmd = new MySqlCommand(@"INSERT INTO component (name) " + "VALUES (@name); ", con);
                cmd.Parameters.Add(new MySqlParameter("@name", textBox2.Text));
                cmd.ExecuteNonQuery();



                /* MySqlCommand cmd2 = new MySqlCommand(@"INSERT INTO invoice (id_Component,id_Customer) " + "VALUES (@com,@cus); ", con);
                 cmd2.Parameters.Add(new MySqlParameter("@com", cmd.LastInsertedId));
                 cmd2.Parameters.Add(new MySqlParameter("@cus", textBox1.Text));
                 cmd2.ExecuteNonQuery();
                 */
                string query = "SELECT id_Component FROM invoice WHERE id_Customer = '" + textBox1.Text + "'";
                MySqlCommand cmd1 = new MySqlCommand(query, con);
                cmd1.ExecuteNonQuery();
                MySqlDataReader rdr3 = cmd1.ExecuteReader();
                int id1 = 0;
                while (rdr3.Read())
                {
                    id1 = rdr3.GetInt32(0);
                }
                rdr3.Close();
                MySqlCommand cmd3 = new MySqlCommand(@"UPDATE Component SET name = '" + textBox2.Text + "' WHERE id = '" + id1 + "'; ", con);
                cmd3.ExecuteNonQuery();

            }
            else
            {
                
                MySqlCommand cmd = new MySqlCommand(@"SELECT id FROM component WHERE name = '" + textBox2.Text + "'", con);
                cmd.ExecuteNonQuery();
                MySqlDataReader rdr2 = cmd.ExecuteReader();
                int id = 0;
                while (rdr2.Read())
                {
                    id = rdr2.GetInt32(0);
                }
                rdr2.Close();
               /* MySqlCommand cmd2 = new MySqlCommand(@"INSERT INTO invoice (id_Component,id_Customer) " + "VALUES (@com,@cus); ", con);
                cmd2.Parameters.Add(new MySqlParameter("@com", id));
                cmd2.Parameters.Add(new MySqlParameter("@cus", textBox1.Text));
                cmd2.ExecuteNonQuery();
                */
                string query = "SELECT id_Component FROM invoice WHERE id_Customer = '" + textBox1.Text + "'";
                MySqlCommand cmd1 = new MySqlCommand(query, con);
                cmd1.ExecuteNonQuery();
                MySqlDataReader rdr3 = cmd1.ExecuteReader();
                int id1 = 0;
                while (rdr3.Read())
                {
                    id1 = rdr3.GetInt32(0);
                }
                rdr3.Close();

                MySqlCommand cmd3 = new MySqlCommand(@"UPDATE Component SET name = '"+ textBox2.Text +"' WHERE id = '"+ id1 +"'; ", con);
                cmd3.ExecuteNonQuery();



                Console.WriteLine("Invoice created");

            }

            
            this.Close();
            
        }
    }
}
