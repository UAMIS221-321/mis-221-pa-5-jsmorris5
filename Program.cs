using mis_221_pa_5_jsmorris5;
using System.Globalization;
using static mis_221_pa_5_jsmorris5.TrainerUtility;
using static mis_221_pa_5_jsmorris5.ListingUtility;
using static mis_221_pa_5_jsmorris5.BookingUtility;
using static mis_221_pa_5_jsmorris5.ReportsUtility;

Console.WriteLine("Welcome to Train Like A Champion - Personal Fitness Website! Choose 1 to sign up as a trainer and 2 to search and sign up for a session... ");
DisplayMenu();

Console.WriteLine("Press any key to exit...");
Console.ReadKey();

static void DisplayMenu()
{
    string choice = "";

    while (choice != "1" && choice != "2")
    {
        Console.WriteLine("Enter choice (1 or 2):");
        choice = Console.ReadLine();
    }

    switch (choice)
    {
        case "1":
            while (true)
            {
                Console.WriteLine("Please choose an option...");
                Console.WriteLine("1. Manage trainer data");
                Console.WriteLine("2. Manage listing data");
                Console.WriteLine("3. Run reports");
                Console.WriteLine("4. Exit the application");

                Console.WriteLine("Enter choice (1-4):");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageTrainerData();
                        break;
                    case "2":
                        ManageListingData();
                        break;
                    case "3":
                        RunReports();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.WriteLine();
            }
        case "2":
            while (true)
            {
                Console.WriteLine("Please choose an option...");
                Console.WriteLine("1. Manage customer booking data");
                Console.WriteLine("2. Exit the application");
                Console.WriteLine("Enter choice (1 or 2):");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageBookingData();
                        break;
                    case "2":
                        Console.WriteLine("Goodbye.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.WriteLine();
            }
        default:
            Console.WriteLine("Invalid choice, please try again.");
            break;
    }
}







