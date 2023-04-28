namespace mis_221_pa_5_jsmorris5
{
    
    public class Transaction
    {
    public int SessionId;
    public string CustomerName;
    public string CustomerEmail;
    public DateTime TrainingDate;
    public int TrainerId;
    public string TrainerName;
    public SessionStatus Status;
    public DateTime TransactionDate;

    public void SetSessionId(int SessionId){
        this.SessionId = SessionId;
    }
    
    public int GetSessionId(){
        return SessionId;
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

    public void SetTransactionDate(DateTime TransactionDate){
        this.TransactionDate = TransactionDate;
    }

    public DateTime GetTransactionDate(){
        return TransactionDate;
    }

    public override string ToString(){
        return $"{SessionId}#{CustomerName}#{CustomerEmail}#{TrainingDate}#{TrainerId}#{TrainerName}#{Status}#{TransactionDate}";
    }
    }
}