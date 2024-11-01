using System;
using System.Data.SqlClient;


class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        int randomNumber = random.Next(10000);
        string connectionString = "Data Source=(local);Initial Catalog=HospitalSystem;Integrated Security=True";

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (var command = new SqlCommand($"INSERT INTO Patient (PatientID, Name, PhoneNumber) VALUES ({randomNumber}, 'abohadima', '01127710427')", connection))
            {
                command.ExecuteNonQuery();
            }
            randomNumber = random.Next(10000);
            using (var command = new SqlCommand($"INSERT INTO Doctor (DoctorId, Name, Specialty) VALUES ({randomNumber}, 'Hossam', 'Cardiology')", connection))
            {
                command.ExecuteNonQuery();
            }

            using (var command = new SqlCommand("DELETE FROM Patient WHERE Name = 'abohadima'", connection))
            {
                command.ExecuteNonQuery();
            }

            using (var command = new SqlCommand("DELETE FROM Doctor WHERE DoctorId = 20220108", connection))
            {
                command.ExecuteNonQuery();
            }

            using (var command = new SqlCommand("UPDATE Patient SET [Address] = 'giza' WHERE PatientID = 15", connection))
            {
                command.ExecuteNonQuery();
            }

            using (var command = new SqlCommand("UPDATE Doctor SET Specialty = 'Neurology' WHERE DoctorId = 20220108", connection))
            {
                command.ExecuteNonQuery();
            }

            using (var command = new SqlCommand("SELECT * FROM Patient", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("All Patients:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"PatientID: {reader["PatientID"]}, Name: {reader["Name"]}, PhoneNumber: {reader["PhoneNumber"]}");
                    }
                }
            }

            using (var command = new SqlCommand("SELECT * FROM Doctor", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("\nAll Doctors:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"DoctorId: {reader["DoctorId"]}, Name: {reader["Name"]}, Specialty: {reader["Specialty"]}");
                    }
                }
            }
            using (var command = new SqlCommand("SELECT Patient.Name AS PatientName, Doctor.Name AS DoctorName, Doctor.Specialty FROM Patient INNER JOIN Appointment ON Patient.PatientID = Appointment.PatientID INNER JOIN Doctor ON Appointment.DoctorID = Doctor.DoctorId;", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("\nPatients with Assigned Doctors:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Patient: {reader["PatientName"]}, Doctor: {reader["DoctorName"]}");
                    }
                }
            }

        }
    }
}

