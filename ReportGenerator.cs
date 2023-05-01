namespace mis_221_pa_5_jsmorris5
{
    public class ReportGenerator
    {
    private List<CustomerSession> customerSessions;
    private List<Revenue> revenues;

    public ReportGenerator(List<CustomerSession> sessions, List<Revenue> revenues) {
        this.customerSessions = sessions;
        this.revenues = revenues;
    }

   public void GenerateIndividualCustomerSessionsReport(string email) {
    List<CustomerSession> sessionsForCustomer = customerSessions.Where(s => s.CustomerEmail == email).ToList();

    if (sessionsForCustomer.Count == 0) {
        Console.WriteLine("No training sessions found for customer with email: " + email);
    } else {
        Console.WriteLine("Training sessions for customer with email: " + email);
        foreach (CustomerSession session in sessionsForCustomer) {
            Console.WriteLine("Date: " + session.Date + ", Duration: " + session.Duration);
            Console.WriteLine("Session ID: " + session.SessionId + ", Date: " + session.Date + ", Duration: " + session.Duration + ", Trainer: " + session.TrainerName + ", Status: " + session.Status);
        }
    }
    }

    public void GenerateHistoricalCustomerSessionsReport() {
        Dictionary<string, List<CustomerSession>> sessionsByCustomer = new Dictionary<string, List<CustomerSession>>();
        Dictionary<string, int> sessionCountsByCustomer = new Dictionary<string, int>();

        foreach (CustomerSession session in customerSessions) {
            if (sessionsByCustomer.ContainsKey(session.CustomerEmail)) {
                sessionsByCustomer[session.CustomerEmail].Add(session);
            } else {
                sessionsByCustomer.Add(session.CustomerEmail, new List<CustomerSession>() { session });
            }
        }

        foreach (string customerEmail in sessionsByCustomer.Keys) {
            sessionCountsByCustomer.Add(customerEmail, sessionsByCustomer[customerEmail].Count);
        }

        Console.WriteLine("Historical Customer Sessions Report");
        foreach (string customerEmail in sessionsByCustomer.Keys) {
            Console.WriteLine("Customer Email: " + customerEmail + ", Total Sessions: " + sessionCountsByCustomer[customerEmail]);
            foreach (CustomerSession session in sessionsByCustomer[customerEmail]) {
                Console.WriteLine("Date: " + session.Date + ", Duration: " + session.Duration);
            }
        }
    }

    public void GenerateHistoricalRevenueReport() {
    var revenueByMonth = revenues.GroupBy(r => new { r.Year, r.Month })
                                 .Select(g => new { Month = g.Key.Month, Year = g.Key.Year, TotalRevenue = g.Sum(r => r.Amount) });

    foreach (var revenue in revenueByMonth) {
        Console.WriteLine($"Month: {revenue.Month}, Year: {revenue.Year}");
    }
}

    public void SaveReportToFile(string report, string fileName) {
        File.WriteAllText(fileName, report);
    }
}
}