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
    public DateTime TrainingDate;
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

    public void SetTrainingDate(DateTime TrainingDate){
        this.TrainingDate = TrainingDate;
    }

    public DateTime GetTrainingDate(){
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

    
     public Session(int Id, string customerName, string customerEmail, DateTime trainingDate, int trainerId, string trainerName, SessionStatus status)
     {
        this.Id = Id;
        this.CustomerName = customerName;
        this.CustomerEmail = customerEmail;
        this.TrainingDate = trainingDate;
        this.TrainerId = trainerId;
        this.TrainerName = trainerName;
        this.Status = status;
    }
    public override string ToString(){
    return $"{Id}#{CustomerName}#{CustomerEmail}#{TrainingDate}#{TrainerId}#{TrainerName}#{Status}";
    }
    }
}

