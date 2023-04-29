using static mis_221_pa_5_jsmorris5.BookingUtility;
namespace mis_221_pa_5_jsmorris5

{
    public class BookingReport
    {
    static void ViewAvailableSessions(List<Session> sessions, string sessionFile)
    {
    Console.WriteLine("Available training sessions:");
    
    foreach (Session session in sessions)
    {
        if (session != null && session.Status == SessionStatus.Booked)
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
                    session.TrainingDate = trainingDate;
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
    }
}
