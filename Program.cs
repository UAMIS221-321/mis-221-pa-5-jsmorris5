using mis_221_pa_5_jsmorris5;
using System.Globalization;
using static mis_221_pa_5_jsmorris5.TrainerUtility;
using static mis_221_pa_5_jsmorris5.ListingUtility;
using static mis_221_pa_5_jsmorris5.BookingUtility;

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

static void RunReports(){
    List<CustomerSession> sessions = new List<CustomerSession>();
    List<Revenue> revenues = new List<Revenue>();
    string filePath = "transactions.txt";
    
    // Read the transactions from the file and populate the sessions and revenues lists
    using (StreamReader reader = new StreamReader(filePath)) {
        string line;
        while ((line = reader.ReadLine()) != null) {
            string[] parts = line.Split(',');
            if (parts.Length == 4) {
                string customerEmail = parts[0];
                DateTime date = DateTime.Parse(parts[1]);
                // int duration = int.Parse(parts[2]);
                int duration = Convert.ToInt32(parts[2]);
                decimal amount = decimal.Parse(parts[3]);

                sessions.Add(new CustomerSession() { CustomerEmail = customerEmail, Date = date, Duration = duration });
                revenues.Add(new Revenue() { Date = date, Amount = amount });
            }
        }
    }

    ReportGenerator reportGenerator = new ReportGenerator(sessions, revenues);

    while (true) {
        Console.WriteLine("Please select a report to view:");
        Console.WriteLine("1. Individual Customer Sessions");
        Console.WriteLine("2. Historical Customer Sessions");
        Console.WriteLine("3. Historical Revenue Report");
        Console.WriteLine("4. Exit");

        string choice = Console.ReadLine();

        if (choice == "1") {
            Console.WriteLine("Please enter customer email:");
            string email = Console.ReadLine();
            reportGenerator.GenerateIndividualCustomerSessionsReport(email);
        } else if (choice == "2") {
            reportGenerator.GenerateHistoricalCustomerSessionsReport();
        } else if (choice == "3") {
            reportGenerator.GenerateHistoricalRevenueReport();
        } else if (choice == "4") {
            Console.WriteLine("Exiting program...");
            break;
        } else {
            Console.WriteLine("Invalid choice. Please try again.");
        }
    }
    }

//     List<CustomerSession> sessions = new List<CustomerSession>() {
//         new CustomerSession() { CustomerEmail = "john@example.com", Date = new DateTime(2023, 4, 01), Duration = 60 },
//         new CustomerSession() { CustomerEmail = "john@example.com", Date = new DateTime(2023, 4, 15), Duration = 45 },
//         new CustomerSession() { CustomerEmail = "jane@example.com", Date = new DateTime(2023, 4, 02), Duration = 30 },
//         new CustomerSession() { CustomerEmail = "jane@example.com", Date = new DateTime(2023, 4, 18), Duration = 90 },
//         new CustomerSession() { CustomerEmail = "joe@example.com", Date = new DateTime(2023, 4, 03), Duration = 120 },
//         new CustomerSession() { CustomerEmail = "joe@example.com", Date = new DateTime(2023, 4, 20), Duration = 60 },
// };

//     List<Revenue> revenues = new List<Revenue>() {
//         new Revenue() { Date = new DateTime(2023, 4, 1), Amount = 100 },
//         new Revenue() { Date = new DateTime(2023, 4, 15), Amount = 50 },
//         new Revenue() { Date = new DateTime(2023, 5, 1), Amount = 200 },
//         new Revenue() { Date = new DateTime(2023, 5, 15), Amount = 150 },
//         new Revenue() { Date = new DateTime(2022, 12, 31), Amount = 500 }
//     };
// string filePath = "transactions.txt";
// List<CustomerSession> sessions = new List<CustomerSession>();

// Read the file and parse its contents into a sessions list
// using (StreamReader sr = new StreamReader(filePath)) {
//     string line;
//     while ((line = sr.ReadLine()) != null) {
//         string[] transaction = line.Split('#');
//         if (transaction[0] == "session_id") {
//             continue; // Skip the header row
//         } else {
//             sessions.Add(new CustomerSession() {
//                 CustomerEmail = transaction[2],
//                 Date = DateTime.ParseExact(transaction[3], "yyyy-MM-dd", CultureInfo.InvariantCulture),
//                 Duration = 30 // Set a default duration value
//             });
//         }
//     }
// }

// ReportGenerator reportGenerator = new ReportGenerator(sessions, revenues);

//     while (true) {
//         Console.WriteLine("Please select a report to view:");
//         Console.WriteLine("1. Individual Customer Sessions");
//         Console.WriteLine("2. Historical Customer Sessions");
//         Console.WriteLine("3. Historical Revenue Report");
//         Console.WriteLine("4. Exit");

//         string choice = Console.ReadLine();

//         if (choice == "1") {
//             Console.WriteLine("Please enter customer email:");
//             string email = Console.ReadLine();
//             reportGenerator.GenerateIndividualCustomerSessionsReport(email);
//         } else if (choice == "2") {
//             reportGenerator.GenerateHistoricalCustomerSessionsReport();
//         } else if (choice == "3") {
//             reportGenerator.GenerateHistoricalRevenueReport();
//         } else if (choice == "4") {
//             Console.WriteLine("Exiting program...");
//             break;
//         } else {
//             Console.WriteLine("Invalid choice. Please try again.");
//         }
//     }
// }







