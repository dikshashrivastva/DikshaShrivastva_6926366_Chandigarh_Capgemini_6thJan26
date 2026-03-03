using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBankProject
{
	class TransactionLog<T>
	{
		private List<T> logs = new List<T>();

		public void AddLog(T item)
		{
			logs.Add(item);
		}

		public void ShowLogs()
		{
			Console.WriteLine("\nTransaction Logs:");
			foreach (T log in logs)
			{
				Console.WriteLine(log);
			}
		}
	}
}
