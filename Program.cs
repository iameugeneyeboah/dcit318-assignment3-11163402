using System;

namespace Assignment3
{
    public class Program
    {
        public static void Main()
        {
            var gh = new System.Globalization.CultureInfo("en-GH");
	    System.Globalization.CultureInfo.DefaultThreadCurrentCulture = gh;
	    System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = gh;

            new Assignment3.Q1.FinanceApp().Run();
            new Assignment3.Q2.HealthSystemApp().Run();
            new Assignment3.Q3.WareHouseManager().Run();
            new Assignment3.Q4.GradingDemo().Run();
            new Assignment3.Q5.InventoryApp().Run();

            Console.WriteLine("All demos complete. Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}
