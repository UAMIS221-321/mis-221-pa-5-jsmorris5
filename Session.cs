namespace mis_221_pa_5_jsmorris5{
    public enum SessionStatus
    {
    Booked,
    Completed,
    Cancelled
    }
    public class Session
    {
    public int Id;
    public string CustomerName;
    public string CustomerEmail;
    public string TrainingDate;
    public int TrainerId;
    public string TrainerName;
    public SessionStatus Status;

    public void SetId(int Id){
        this.Id = Id;
    }
    
    public int GetId(){
        return Id;
    }

    public void SetCustomerName(string CustomerName){
        this.CustomerName = CustomerName;
    }

    public string GetCustomerName(){
        return CustomerName;
    }

    public void SetCustomerEmail(string CustomerEmail){
        this.CustomerEmail = CustomerEmail;
    }

    public string GetCustomerEmail(){
        return CustomerEmail;
    }

    public void SetTrainingDate(string TrainingDate){
        this.TrainingDate = TrainingDate;
    }

    public string GetTrainingDate(){
        return TrainingDate;
    }

    public void SetTrainerId(int TrainerId){
        this.TrainerId = TrainerId;
    }

    public int GetTrainerId(){
        return TrainerId;
    }

    public void SetTrainerName(string TrainerName){
        this.TrainerName = TrainerName;
    }

    public string GetTrainerName(){
        return TrainerName;
    }
    public void SetStatus(SessionStatus Status){
        this.Status = Status;
    }

    public SessionStatus GetStatus(){
        return Status;
    }

    
     public Session(int id, string customerName, string customerEmail, string trainingDate, int trainerId, string trainerName, SessionStatus status)
     {
        Id = id;
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        TrainingDate = trainingDate;
        TrainerId = trainerId;
        TrainerName = trainerName;
        Status = status;
    }
    public override string ToString(){
    return $"{Id}#{CustomerName}#{CustomerEmail}#{TrainingDate}#{TrainerId}#{TrainerName}#{Status}";
    }
    }
}

