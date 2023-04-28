using mis_221_pa_5_jsmorris5;
using System.Globalization;

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

static void ManageTrainerData(){
        string trainersFile = "trainers.txt";

        while (true)
        {
            Console.WriteLine("Enter '1' to add a new trainer");
            Console.WriteLine("Enter '2' to edit an existing trainer");
            Console.WriteLine("Enter '3' to delete an existing trainer");
            Console.WriteLine("Enter '4' to exit the program");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddTrainer(trainersFile);
                    break;
                case "2":
                    EditTrainer(trainersFile);
                    break;
                case "3":
                    DeleteTrainer(trainersFile);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
}

static void AddTrainer(string filename)
{
        Console.WriteLine("Enter the Trainer ID:");
        string id = Console.ReadLine();

        Console.WriteLine("Enter the Trainer Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the Mailing Address:");
        string address = Console.ReadLine();

        Console.WriteLine("Enter the Trainer Email Address:");
        string email = Console.ReadLine();

        Trainer trainer = new Trainer(id, name, address, email);

        using (StreamWriter writer = File.AppendText(filename))
        {
            writer.WriteLine(trainer);
        }

        Console.WriteLine("Trainer added successfully.");
        Console.ReadKey();
}

static void EditTrainer(string filename)
{
        Console.WriteLine("Enter the Trainer ID of the trainer you want to edit:");
        string idToEdit = Console.ReadLine();

        string[] trainers = File.ReadAllLines(filename);

        bool foundTrainer = false;

        for (int i = 0; i < trainers.Length; i++)
        {
            string[] trainerInfo = trainers[i].Split('#');

            if (trainerInfo[0] == idToEdit)
            {
                foundTrainer = true;

                Console.WriteLine($"Enter the new Trainer Name (current value: {trainerInfo[1]}):");
                string newName = Console.ReadLine();

                Console.WriteLine($"Enter the new Mailing Address (current value: {trainerInfo[2]}):");
                string newAddress = Console.ReadLine();

                Console.WriteLine($"Enter the new Trainer Email Address (current value: {trainerInfo[3]}):");
                string newEmail = Console.ReadLine();

                Trainer editedTrainer = new Trainer(idToEdit, newName, newAddress, newEmail);

                trainers[i] = editedTrainer.ToString();

                File.WriteAllLines(filename, trainers);

                Console.WriteLine("Trainer edited successfully.");
                break;
            }
        }

        if (!foundTrainer)
        {
            Console.WriteLine("Trainer not found.");
        }
}

static void DeleteTrainer(string filename){
        Console.WriteLine("Enter the Trainer ID of the trainer you want to delete:");
        string idToDelete = Console.ReadLine();

        string[] trainers = File.ReadAllLines(filename);

        bool foundTrainer = false;

        for (int i = 0; i < trainers.Length; i++){
            string[] trainerInfo = trainers[i].Split('#');

            if (trainerInfo[0] == idToDelete)
            {
                foundTrainer = true;

                Console.WriteLine($"Are you sure you want to delete trainer '{trainerInfo[1]}'? (y/n)");
                string confirm = Console.ReadLine();

                if (confirm.ToLower() == "y")
                {
                    trainers = trainers.Where((val, idx) => idx != i).ToArray();

                    File.WriteAllLines(filename, trainers);

                    Console.WriteLine("Trainer deleted successfully.");
                    break;
                }
                else
                {
                    Console.WriteLine("Deletion canceled.");
                    break;
                }
            }
        }

        if (!foundTrainer)
        {
        Console.WriteLine("Trainer not found.");
        }
}

static void ManageListingData(){
        string listingsFile = "listings.txt";

        while (true)
        {
            Console.WriteLine("Enter '1' to add a new listing");
            Console.WriteLine("Enter '2' to edit an existing listing");
            Console.WriteLine("Enter '3' to delete an existing listing");
            Console.WriteLine("Enter '4' to exit the program");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddListing(listingsFile);
                    break;
                case "2":
                    EditListing(listingsFile);
                    break;
                case "3":
                    DeleteListing(listingsFile);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
}
static void AddListing(string filename)
{
        Console.WriteLine("Enter the Listing ID:");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the Trainer Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the Date of the Session: MM/dd/yyyy ");
        DateTime date;
        while (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {
        Console.WriteLine("Invalid date format. Please enter a date in the format MM/dd/yyyy.");
        }

        Console.WriteLine("Enter the Time of the Session:");
        TimeSpan time = TimeSpan.Parse(Console.ReadLine());

        Console.WriteLine("Enter the Cost of the Session: Please enter a decimal number.");
        decimal cost;
        while (!decimal.TryParse(Console.ReadLine(), out cost))
        {
        Console.WriteLine("Invalid input. Please enter a decimal number.");
        }

        Console.WriteLine("Has the listing been taken? Y or N");
        string input = Console.ReadLine();
        Console.ReadLine();
        // bool availability = input.ToLower() == "y" ? true : false;

        Listing listing = new Listing(id, name, date, time, cost, input);

        using (StreamWriter writer = File.AppendText(filename))
        {
            writer.WriteLine(listing);
        }

        Console.WriteLine("Listing added successfully.");
        Console.ReadKey();
}

static void EditListing(string filename){
    Console.WriteLine("Enter the Listing ID of the listing you want to edit:");
    int Id = int.Parse(Console.ReadLine());

    // List<string> lines = File.ReadAllLines(filename).ToList();
    string[] listings = File.ReadAllLines(filename);
    bool found = false;

    for (int i = 0; i < listings.Length; i++){
        string[] listingsInfo = listings[i].Split('#');
        if (int.Parse(listingsInfo[0]) == Id)
        {
            Console.WriteLine($"Enter the new Trainer Name (current value is {listingsInfo[1]}):");
            string newName = Console.ReadLine();
            Console.WriteLine($"Enter the new Date of the Session (current value is {listingsInfo[2]}):");
            DateTime newDate;
            while (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out newDate))
            {
            Console.WriteLine("Invalid date format. Please enter a date in the format MM/dd/yyyy.");
            }
            Console.WriteLine($"Enter the new Time of the Session (current value is {listingsInfo[3]}):");
            TimeSpan newTime = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine($"Enter the new Cost of the Session (current value is {listingsInfo[4]}):");
            decimal newCost;
            while (!decimal.TryParse(Console.ReadLine(), out newCost))
            {
            Console.WriteLine("Invalid input. Please enter a decimal number.");
            }
            Console.WriteLine($"Is this session taken? (current value is {listingsInfo[5]}):");
            string newAvailability = Console.ReadLine();

            Listing editedListing = new Listing(Id, newName, newDate, newTime, newCost, newAvailability);
            listings[i] = editedListing.ToString();
            File.WriteAllLines(filename, listings);
            Console.WriteLine("Listing edited successfully.");
            break;
        }
    }

    if (!found)
    {
        Console.WriteLine("Listing not found.");
    }
}

static void DeleteListing(string filename){
    Console.WriteLine("Enter the Listing ID of the listing you want to delete:");
    string listingId = Console.ReadLine();

    // List<string> lines = File.ReadAllLines(filename).ToList();
    string [] listings = File.ReadAllLines(filename);
    bool found = false;

    for (int i = 0; i < listings.Length; i++){
        string[] listingsInfo = listings[i].Split('#');

        if (listingsInfo[0] == listingId)
        {
            found = true;
            System.Console.WriteLine($"Are you sure you want to delete trainer '{listingsInfo[1]}'? (y/n)");
            string confirm = Console.ReadLine();

            if (confirm.ToLower() == "y")
            {
                listings = listings.Where((val, idx) => idx != i).ToArray();

                    File.WriteAllLines(filename, listings);

                    Console.WriteLine("Listing deleted successfully.");
                    break;
                }
                else
                {
                    Console.WriteLine("Deletion canceled.");
                    break;
                }
            }
        }

        if (!found)
        {
        Console.WriteLine("Listing not found.");
        }
}

static void ManageBookingData(){
        List<Session> sessions = new List<Session>();
        List<Transaction> transactions = new List<Transaction>();
        string transactionsFile = "transactions.txt";

        // Load existing transactions from file, if any
        if (File.Exists(transactionsFile))
        {
            string[] transactionLines = File.ReadAllLines(transactionsFile);
            foreach (string transactionLine in transactionLines)
            {
                string[] fields = transactionLine.Split('#');
                if (fields.Length == 8)
                {
                    Transaction transaction = new Transaction();
                    transaction.SessionId = int.Parse(fields[0]);
                    transaction.CustomerName = fields[1];
                    transaction.CustomerEmail = fields[2];
                    transaction.TrainingDate = DateTime.Parse(fields[3]);
                    transaction.TrainerId = int.Parse(fields[4]);
                    transaction.TrainerName = fields[5];
                    transaction.Status = (SessionStatus)Enum.Parse(typeof(SessionStatus), fields[6]);
                    transaction.TransactionDate = DateTime.Parse(fields[7]);
                    transactions.Add(transaction);
                }
            }
        }

        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. View available training sessions");
            Console.WriteLine("2. Book a training session");
            Console.WriteLine("3. Exit");

            string input = Console.ReadLine();
            int option;
            if (int.TryParse(input, out option))
            {
                switch (option)
                {
                    case 1:
                        ViewAvailableSessions(sessions);
                        break;
                    case 2:
                        BookSession(sessions, transactions, transactionsFile);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
}

static void ViewAvailableSessions(List<Session> sessions)
{
    Console.WriteLine("Available training sessions:");
    foreach (Session session in sessions)
    {
        System.Console.WriteLine("Here");
        if (session.Status == SessionStatus.Booked)
        {
            Console.WriteLine($"{session.Id}: {session.TrainingDate} - {session.TrainerName}");
        }
    }
}

static void BookSession(List<Session> sessions, List<Transaction> transactions, string transactionsFile)
{
    Console.WriteLine("Enter session ID to book:");
    string input = Console.ReadLine();
    int sessionId;
    if (int.TryParse(input, out sessionId))
    {
        Session session = sessions.Find(s => s.Id == sessionId);
        if (session != null && session.Status == SessionStatus.Booked)
        {
            Console.WriteLine("Enter customer name:");
            string customerName = Console.ReadLine();
            Console.WriteLine("Enter customer email:");
            string customerEmail = Console.ReadLine();
            Console.WriteLine("Enter training date (YYYY-MM-DD HH:MM):");
            string trainingDateInput = Console.ReadLine();
            DateTime trainingDate;
            if (DateTime.TryParse(trainingDateInput, out trainingDate))
            {
                Console.WriteLine("Enter trainer ID:");
                string trainerIdInput = Console.ReadLine();
                int trainerId;
                if (int.TryParse(trainerIdInput, out trainerId))
                {
                    Console.WriteLine("Enter trainer name:");
                    string trainerName = Console.ReadLine();
                    session.CustomerName = customerName;
                    session.CustomerEmail = customerEmail;
                    session.TrainingDate = trainingDate.ToString("yyyy-MM-dd HH:mm");
                    session.TrainerId = trainerId;
                    session.TrainerName = trainerName;
                    session.Status = SessionStatus.Booked;
                    Console.WriteLine("Session booked successfully.");
                    Transaction transaction = new Transaction();
                    transaction.SessionId = session.Id;
                    transaction.CustomerName = customerName;
                    transaction.CustomerEmail = customerEmail;
                    transaction.TrainingDate = trainingDate;
                    transaction.TrainerId = trainerId;
                    transaction.TrainerName = trainerName;
                    transaction.Status = session.Status;
                    transaction.TransactionDate = DateTime.Now;
                    transactions.Add(transaction);
                    string transactionLine = $"{transaction.SessionId}#{transaction.CustomerName}#{transaction.CustomerEmail}#{transaction.TrainingDate.ToString("yyyy-MM-dd HH:mm")}#{transaction.TrainerId}#{transaction.TrainerName}#{transaction.Status}#{transaction.TransactionDate.ToString("yyyy-MM-dd HH:mm:ss")}";
                    File.AppendAllLines(transactionsFile, new string[] { transactionLine });
                }
                else
                {
                    Console.WriteLine("Invalid trainer ID. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid training date. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid session ID or session is not available for booking. Please try again.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
}

static void RunReports(){
    List<CustomerSession> sessions = new List<CustomerSession>() {
        new CustomerSession() { CustomerEmail = "john@example.com", Date = new DateTime(2023, 4, 01), Duration = 60 },
        new CustomerSession() { CustomerEmail = "john@example.com", Date = new DateTime(2023, 4, 15), Duration = 45 },
        new CustomerSession() { CustomerEmail = "jane@example.com", Date = new DateTime(2023, 4, 02), Duration = 30 },
        new CustomerSession() { CustomerEmail = "jane@example.com", Date = new DateTime(2023, 4, 18), Duration = 90 },
        new CustomerSession() { CustomerEmail = "joe@example.com", Date = new DateTime(2023, 4, 03), Duration = 120 },
        new CustomerSession() { CustomerEmail = "joe@example.com", Date = new DateTime(2023, 4, 20), Duration = 60 },
};

    List<Revenue> revenues = new List<Revenue>() {
        new Revenue() { Date = new DateTime(2023, 4, 1), Amount = 100 },
        new Revenue() { Date = new DateTime(2023, 4, 15), Amount = 50 },
        new Revenue() { Date = new DateTime(2023, 5, 1), Amount = 200 },
        new Revenue() { Date = new DateTime(2023, 5, 15), Amount = 150 },
        new Revenue() { Date = new DateTime(2022, 12, 31), Amount = 500 }
    };
string filePath = "transactions.txt";
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







