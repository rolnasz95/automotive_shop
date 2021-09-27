using System;
using System.IO;

namespace Automotive_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal oilLubeCost = OilLubeCharge();
            decimal flushCost = FlushCharge();
            decimal miscCost = MiscCharge();

            Console.Write("Amount of labor hours: ");
            decimal labor = LaborCharge( int.Parse( Console.ReadLine() ) );

            decimal tax = TaxCharges(oilLubeCost, flushCost);   // Calculate tax amount based on services provided only

            PrintCharges(ref oilLubeCost, ref flushCost, ref miscCost, ref labor, ref tax);
            TotalCharges(ref oilLubeCost, ref flushCost, ref miscCost, ref labor, ref tax);     // Calculate and display total charges

        }

        static decimal OilLubeCharge()
        {
            const decimal oilCharge = 26.00M;   // Cost of oil change
            const decimal lubeCharge = 18.00M;  // Cost of lube work
            decimal total = 0M;     // Hold total cost
            string input;   // Store user input

            Console.Write("Do you need oil change? (y/n): ");
            input = Console.ReadLine();

            if (input == "Y" || input == "y")   // If true add oilCharge to total
            {
                total += oilCharge;
            }

            Console.Write("Do you need lube change? (y/n): ");
            input = Console.ReadLine();

            if (input == "Y" || input == "y")   // If true add lubeCharge to total
            {
                total += lubeCharge;
            }

            return total;   // Return value of total
        }

        static decimal FlushCharge()
        {
            const decimal radiatorCharge = 30.00M;      // Cost of radiator replacement
            const decimal transmissionCharge = 80.00M;  // Cost of transmission replacement
            decimal total = 0M;     // Hold total cost
            string input;   // Store user input

            Console.Write("Do you need the radiator to be flushed? (y/n): ");
            input = Console.ReadLine();

            if (input == "Y" || input == "y")   // If true add radiatorCharge to total
            {
                total += radiatorCharge;
            }

            Console.Write("Do you need the transmission to be flushed? (y/n): ");
            input = Console.ReadLine();

            if (input == "Y" || input == "y")   // If true add transmissionCharge to total
            {
                total += transmissionCharge;
            }

            return total;   // Return value of total
        }

        static decimal MiscCharge()
        {
            const decimal inspection = 15.00M;      // Cost of inspection
            const decimal muffle = 100.00M;         // Cost of muffle repair
            const decimal tireRotation = 20.00M;    // Cost of tire rotation
            decimal total = 0M;
            string input;

            Console.Write("Do you need inspection? (y/n): ");
            input = Console.ReadLine();

            if (input == "Y" || input == "y")   // If true add inspection to total
            {
                total += inspection;
            }

            Console.Write("Do you need muffle repair? (y/n): ");
            input = Console.ReadLine();

            if (input == "Y" || input == "y")   // If true add muffle to total
            {
                total += muffle;
            }

            Console.Write("Do you need tire rotation? (y/n): ");
            input = Console.ReadLine();

            if (input == "Y" || input == "y")   // If true add tireRotation to total
            {
                total += tireRotation;
            }

            return total;
        }

        static decimal LaborCharge(int hours)
        {
            const decimal labor = 40.00M;   // Labor charge is $40.00 per hour

            return labor * hours;   // Return labor times hours
        }

        static decimal TaxCharges(decimal oilLube, decimal flush)
        {
            const decimal taxRate = 0.06M;  // Tax rate is 6%
            decimal total = (oilLube * taxRate) + (flush * taxRate);    // Calculate total tax on oil and flush services

            return total;
        }

        static void TotalCharges(ref decimal oilLube, ref decimal flush, ref decimal misc, ref decimal labor, ref decimal tax)
        {
            decimal total = oilLube + flush + misc + labor + tax;   // Calculate total costs

            // Print final bill to console
            Console.WriteLine("Here is your total bill:");
            Console.WriteLine("Oil & Lube costs: " + oilLube.ToString("C"));
            Console.WriteLine("Radiator & Transmission flush costs: " + flush.ToString("C"));
            Console.WriteLine("Misc. costs: " + misc.ToString("C"));
            Console.WriteLine("Labor costs: " + labor.ToString("C"));
            Console.WriteLine("Tax for services: " + tax.ToString("C"));
            Console.WriteLine("\nTotal amount: " + total.ToString("C"));
        }

        static void PrintCharges(ref decimal oilLube, ref decimal flush, ref decimal misc, ref decimal labor, ref decimal tax)
        {
            decimal total = oilLube + flush + misc + labor + tax;
            string choice;

            Console.Write("Do you want to create a .txt receipt for your invoice? (y/n): ");
            choice = Console.ReadLine();

            if (choice == "Y" || choice == "y")
            {
                StreamWriter receipt = new("C:\\Users\\Public\\Documents\\Receipt.txt");

                receipt.WriteLine("INVOICE FOR SERVICE:");
                receipt.WriteLine("OIL CHANGE: " + oilLube.ToString("C"));
                receipt.WriteLine("RADIATOR FLUSH: " + flush.ToString("C"));
                receipt.WriteLine("MISC. COST: " + misc.ToString("C"));
                receipt.WriteLine("LABOR CHARGES: " + labor.ToString("C"));
                receipt.WriteLine("TAX: " + tax.ToString("C"));
                receipt.WriteLine("TOTAL COST: " + total.ToString("C"));

                Console.WriteLine("Receipt successfully saved in C:\\Users\\Public\\Documents path.");

                receipt.Close();
            }
            else
            {
                Console.WriteLine("Okay. Displaying final bill to console only.");
            }
        }
    }
}
