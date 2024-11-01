using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HospitalGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string connectionString = "Data Source=(local);Initial Catalog=HospitalSystem;Integrated Security=True";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (radioButton1.Checked)
                    {
                        string name = "'" + textBox1.Text + "'";

                        using (var command = new SqlCommand($"SELECT * FROM Doctor where Name={name} and DoctorId={textBox2.Text}", connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                textBox5.Text = ("\nAll Doctors:");
                                while (reader.Read())
                                {
                                    textBox5.Text += ($"DoctorId: {reader["DoctorId"]}, Name: {reader["Name"]}, Specialty: {reader["Specialty"]}");
                                }
                            }
                        }
                       }

                    else if (radioButton2.Checked)
                    {
                        string name = "'" + textBox1.Text + "'";

                        using (var command = new SqlCommand($"SELECT * FROM Patient where Name={name} and PatientId={textBox2.Text}", connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                textBox5.Text=("\nAll Patient:");
                                while (reader.Read())
                                {
                                    textBox5.Text += ($"PatientId: {reader["PatientId"]}, Name: {reader["Name"]}, PhoneNumber: {reader["PhoneNumber"]}");
                                }
                            }
                        }
                    }
                }
            }
            else if (textBox1.Text != "" && textBox2.Text == "")
            {
                string connectionString = "Data Source=(local);Initial Catalog=HospitalSystem;Integrated Security=True";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (radioButton1.Checked)
                    {
                        string name = "'" + textBox1.Text + "'";

                        using (var command = new SqlCommand($"SELECT * FROM Doctor where Name={name}", connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                textBox5.Text=("\nAll Doctors:");
                                while (reader.Read())
                                {
                                    textBox5.Text += ($"DoctorId: {reader["DoctorId"]}, Name: {reader["Name"]}, Specialty: {reader["Specialty"]}");
                                }
                            }
                        }
                    }

                    else if (radioButton2.Checked)
                    {

                        string name = "'" + textBox1.Text + "'";

                        using (var command = new SqlCommand($"SELECT * FROM Patient where Name={name}", connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                textBox5.Text = ("\nAll Patient:");
                                while (reader.Read())
                                {
                                    textBox5.Text += ($"PatientId: {reader["PatientId"]}, Name: {reader["Name"]}, PhoneNumber: {reader["PhoneNumber"]}");
                                }
                            }
                        }
                    }
                }
            }
            else if (textBox1.Text == "" && textBox2.Text != "")
            {
                string connectionString = "Data Source=(local);Initial Catalog=HospitalSystem;Integrated Security=True";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (radioButton1.Checked)
                    {


                        using (var command = new SqlCommand($"SELECT * FROM Doctor where DoctorId={textBox2.Text}", connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                textBox5.Text = ("\nAll Doctors:");
                                while (reader.Read())
                                {
                                    textBox5.Text += ($"DoctorId: {reader["DoctorId"]}, Name: {reader["Name"]}, Specialty: {reader["Specialty"]}");
                                }
                            }
                        }
                    }

                    else if (radioButton2.Checked)
                    {


                        using (var command = new SqlCommand($"SELECT * FROM Patient where PatientId={textBox2.Text}", connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                textBox5.Text = ("\nAll Patient:");
                                while (reader.Read())
                                {
                                    textBox5.Text += ($"PatientId: {reader["PatientId"]}, Name: {reader["Name"]}, PhoneNumber: {reader["PhoneNumber"]}");
                                }
                            }
                        }
                    }
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = "Data Source=(local);Initial Catalog=HospitalSystem;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (radioButton2.Checked)
                {
                    string name = "'" + textBox1.Text + "'";

                    using (var command = new SqlCommand($"INSERT INTO Patient (PatientID, Name, PhoneNumber) VALUES ({textBox2.Text}, {name}, '01127710427')", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                else if (radioButton1.Checked)
                {
                    string name = "'" + textBox1.Text + "'";
                    using (var command = new SqlCommand($"INSERT INTO Doctor (DoctorID, Name) VALUES ({textBox2.Text}, {name})", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(local);Initial Catalog=HospitalSystem;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (radioButton2.Checked)
                {
                    string name = "'" + textBox1.Text + "'";

                    using (var command = new SqlCommand($"UPDATE Patient SET name = {name} WHERE PatientID = {textBox2.Text}", connection))
                {
                    command.ExecuteNonQuery();
                }
}
                else if (radioButton1.Checked) {
                    string name = "'" + textBox1.Text + "'";
                    using (var command = new SqlCommand($"UPDATE Doctor SET name = {name} WHERE DoctorId = {textBox2.Text}", connection))
                {
                    command.ExecuteNonQuery();
                } 
                }

            }
        }
    }
}
