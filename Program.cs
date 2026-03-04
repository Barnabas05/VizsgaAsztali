using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizsgaAsztali
{
    public class Program
    {
        [STAThread]

        public static void Main(string[] args)
        {
            if(args.Length > 0 && args[0] == "--stat")
            {
                Statistics.Run();
			}
            else
            {
                var app = new App();
                app.InitializeComponent();
                app.Run();
			}
		}

	}
}
