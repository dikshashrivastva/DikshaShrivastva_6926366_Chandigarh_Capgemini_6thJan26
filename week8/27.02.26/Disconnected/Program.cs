using System;
using System.Data;
using Microsoft.Data.SqlClient;
namespace Disconnected
{
	internal class Program
	{
		static string connectionString = "Data Source=AIKI\\SQLEXPRESS;" +
			"Initial Catalog=LibraryDB;" +
			"Integrated Security=True;" +
			"TrustServerCertificate=True;";
		static void Main(string[] args)
		{
			Console.WriteLine("Library Database - Disconnected Architecture");

			InsertBook();
			GetBooks();
			UpdateBook();
			DeleteBook();

			Console.ReadLine();
		}

		//insert book using data-adapter
		static void InsertBook()
		{
			SqlConnection con = new SqlConnection(connectionString);
			SqlDataAdapter adapter = new SqlDataAdapter("GetBooks", con);

			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

			DataTable table = new DataTable();

			adapter.Fill(table);

			DataRow row = table.NewRow();

			row["Title"] = "Animal Farm";
			row["AuthorId"] = 2;
			row["PublishedYear"] = 1945;

			table.Rows.Add(row);

			SqlCommand insertCommand = new SqlCommand("InsertBook", con);

			insertCommand.CommandType = CommandType.StoredProcedure;

			insertCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 200, "Title");
			insertCommand.Parameters.Add("@AuthorId", SqlDbType.Int, 0, "AuthorId");
			insertCommand.Parameters.Add("@PublishedYear", SqlDbType.Int, 0, "PublishedYear");

			adapter.InsertCommand = insertCommand;

			adapter.Update(table);

			Console.WriteLine("Book inserted");
		}

		//select books using dataset
		static void GetBooks()
		{
			SqlConnection con = new SqlConnection(connectionString);

			SqlDataAdapter adapter = new SqlDataAdapter("GetBooks", con);
			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

			DataSet ds = new DataSet();

			adapter.Fill(ds, "Books");
			Console.WriteLine("\nBooks List:");

			foreach (DataRow row in ds.Tables["Books"].Rows)
			{
				Console.WriteLine(
					row["BookId"] + " " +
					row["Title"] + " " +
					row["AuthorId"] + " " +
					row["PublishedYear"]);
			}
		}

		//update book using dataadapter
		static void UpdateBook()
		{
			SqlConnection con = new SqlConnection(connectionString);
			SqlDataAdapter adapter = new SqlDataAdapter("GetBooks", con);

			adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

			DataTable table = new DataTable();

			adapter.Fill(table);

			table.Rows[0]["Title"] = "Harry Potter Updated ";

			SqlCommand updateCommand = new SqlCommand("UpdateBook", con);
			updateCommand.CommandType = CommandType.StoredProcedure;

			updateCommand.Parameters.Add("@BookId", SqlDbType.Int, 0, "BookId");
			updateCommand.Parameters.Add("@Title", SqlDbType.VarChar, 200, "Title");
			updateCommand.Parameters.Add("@AuthorId", SqlDbType.Int, 0, "AuthorId");
			updateCommand.Parameters.Add("@PublishedYear", SqlDbType.Int, 0, "PublishedYear");

			adapter.UpdateCommand = updateCommand;
			adapter.Update(table);
			Console.WriteLine("\nBook Updated");


		}

		// DELETE BOOK USING DATAADAPTER
		static void DeleteBook()
		{
			SqlConnection con =
			new SqlConnection(connectionString);

			con.Open();

			// Step 1 Delete BorrowRecords
			SqlCommand cmd1 =
			new SqlCommand(
			"DELETE FROM BorrowRecords WHERE BookId=@BookId",
			con);

			cmd1.Parameters.AddWithValue("@BookId", 1);

			cmd1.ExecuteNonQuery();

			con.Close();


			// Step 2 Delete Book using DataAdapter
			SqlDataAdapter adapter =
			new SqlDataAdapter("GetBooks", con);

			adapter.SelectCommand.CommandType =
			CommandType.StoredProcedure;

			DataTable table = new DataTable();

			adapter.Fill(table);

			table.Rows[0].Delete();

			SqlCommand deleteCommand =
			new SqlCommand("DeleteBook", con);

			deleteCommand.CommandType =
			CommandType.StoredProcedure;

			deleteCommand.Parameters.Add(
			"@BookId", SqlDbType.Int, 0, "BookId");

			adapter.DeleteCommand = deleteCommand;

			adapter.Update(table);

			Console.WriteLine("Book Deleted");
		}
	}
}
