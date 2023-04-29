using System.Globalization;
namespace mis_221_pa_5_jsmorris5
{
    public class ListingUtility
    {
        public static void ManageListingData(){
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
    }
}