using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace UniversityData
{
	internal class Program
	{
		static string connectionString =
		"Data Source=AIKI\\SQLEXPRESS;Initial Catalog=UniversityDB;Integrated Security=True;TrustServerCertificate=True";

		static void Main(string[] args)
		{
			Console.WriteLine("University Database CRUD Operations");

			InsertStudent();

			GetStudents();

			UpdateStudent();

			DeleteStudent();

			GetStudentsUsingAdapter();

			Console.ReadLine();
		}

		// INSERT STUDENT
		static void InsertStudent()
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("InsertStudent", con);

				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@FirstName", "John");
				cmd.Parameters.AddWithValue("@LastName", "Doe");
				cmd.Parameters.AddWithValue("@Email", "john@uni.com");
				cmd.Parameters.AddWithValue("@DeptId", 1);

				con.Open();

				cmd.ExecuteNonQuery();

				Console.WriteLine("Student Inserted Successfully");

				con.Close();
			}
		}

		// SELECT STUDENTS USING DATAREADER
		static void GetStudents()
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("GetStudents", con);

				cmd.CommandType = CommandType.StoredProcedure;

				con.Open();

				SqlDataReader reader = cmd.ExecuteReader();

				Console.WriteLine("\nStudents List:");

				while (reader.Read())
				{
					Console.WriteLine(
						reader["StudentId"] + " " +
						reader["FirstName"] + " " +
						reader["LastName"] + " " +
						reader["Email"] + " Dept:" +
						reader["DeptId"]);
				}

				reader.Close();
			}
		}

		// UPDATE STUDENT
		static void UpdateStudent()
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("UpdateStudent", con);

				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@StudentId", 1);
				cmd.Parameters.AddWithValue("@FirstName", "Alice");
				cmd.Parameters.AddWithValue("@LastName", "Williams");
				cmd.Parameters.AddWithValue("@Email", "alicew@uni.com");
				cmd.Parameters.AddWithValue("@DeptId", 2);

				con.Open();

				cmd.ExecuteNonQuery();

				Console.WriteLine("\nStudent Updated Successfully");
			}
		}

		// DELETE STUDENT
		static void DeleteStudent()
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				// Delete Enrollments first
				SqlCommand cmd1 = new SqlCommand(
				"DELETE FROM Enrollments WHERE StudentId=@StudentId", con);

				cmd1.Parameters.AddWithValue("@StudentId", 1);
				cmd1.ExecuteNonQuery();

				// Then delete Student
				SqlCommand cmd2 = new SqlCommand("DeleteStudent", con);

				cmd2.CommandType = CommandType.StoredProcedure;
				cmd2.Parameters.AddWithValue("@StudentId", 1);

				cmd2.ExecuteNonQuery();

				Console.WriteLine("Student Deleted Successfully");
			}
		}

		// SELECT USING DATAADAPTER
		static void GetStudentsUsingAdapter()
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("GetStudents", con);

				cmd.CommandType = CommandType.StoredProcedure;

				SqlDataAdapter adapter = new SqlDataAdapter(cmd);

				DataTable table = new DataTable();

				adapter.Fill(table);

				Console.WriteLine("\nStudents Using DataAdapter:");

				foreach (DataRow row in table.Rows)
				{
					Console.WriteLine(
						row["StudentId"] + " " +
						row["FirstName"] + " " +
						row["LastName"] + " " +
						row["Email"]);
				}
			}
		}

	}
}
