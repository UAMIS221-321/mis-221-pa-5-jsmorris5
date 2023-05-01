namespace mis_221_pa_5_jsmorris5
{
    public class ReportsUtility
    {
        public static void RunReports(){
            List<CustomerSession> sessions = new List<CustomerSession>();
            List<Revenue> revenues = new List<Revenue>();
            string filePath = "transactions.txt";

        using (StreamReader reader = new StreamReader(filePath)) {
            string line;
        while ((line = reader.ReadLine()) != null) {
            string[] fields = line.Split('#');
        if (fields.Length == 8) {
            int sessionId = int.Parse(fields[0]);
            string customerName = fields[1];
            string customerEmail = fields[2];
            DateTime trainingDate = DateTime.Parse(fields[3]);
            int trainerId = int.Parse(fields[4]);
            string trainerName = fields[5];
            // SessionStatus status = SessionStatus.Parse(fields[6]);
            SessionStatus status = Enum.Parse<SessionStatus>(fields[6]);
            decimal amount = decimal.Parse(fields[7]);
            

            sessions.Add(new CustomerSession() { SessionId = sessionId, CustomerName = customerName, CustomerEmail = customerEmail, Date = trainingDate, TrainerId = trainerId, TrainerName = trainerName, Status = status });
            revenues.Add(new Revenue() { Date = trainingDate, Amount = amount });
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
            System.Console.WriteLine("Revenue Report:");
            System.Console.WriteLine("Month: $50,000 Year: $100,000");
            reportGenerator.GenerateHistoricalRevenueReport();
        } else if (choice == "4") {
            Console.WriteLine("Exiting program...");
            break;
        } else {
            Console.WriteLine("Invalid choice. Please try again.");
        }
        }
        }
    }
}