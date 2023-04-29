namespace mis_221_pa_5_jsmorris5
{
    public class TrainerUtility
    {
        public static void ManageTrainerData(){
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
    }
}