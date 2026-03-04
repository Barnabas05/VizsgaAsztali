using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizsgaAsztali
{
	public class Statistics
	{
		private static List<[Class_name]> [list_name] = new List<[Class_name]>();

		public static void Run()
		{
			try
			{
				[list_name] = Database.GetItems();

			}
			catch (Exception ex)
			{
				Console.WriteLine("Adatbázis kapcsolat hiba!");
				Console.WriteLine(ex.Message);
				return;
			}

			/*functions goes here*/
		}
	}
}