namespace mis_221_pa_5_jsmorris5
{
    public class Listing
    {
    public int Id;
    public string TrainerName;
    public DateTime SessionDate;
    public TimeSpan SessionTime;
    public decimal SessionCost;
    public string IsTaken;

    public void SetId(int Id){
        this.Id = Id;
    }
    
    public int GetId(){
        return Id;
    }

    public void SetTrainerName(string TrainerName){
        this.TrainerName = TrainerName;
    }

    public string GetTrainerName(){
        return TrainerName;
    }

    public void SetSessionDate(DateTime SessionDate){
        this.SessionDate = SessionDate;
    }

    public DateTime GetSessionDate(){
        return SessionDate;
    }

    public void SetSessionTime(TimeSpan SessionTime){
        this.SessionTime = SessionTime;
    }

    public TimeSpan GetSessionTime(){
        return SessionTime;
    }

    public void SetSessionCost(decimal SessionCost){
        this.SessionCost = SessionCost;
    }

    public decimal GetSessionCost(){
        return SessionCost;
    }

    public void SetIsTaken(string IsTaken){
        this.IsTaken = IsTaken;
    }

    public string GetIsTaken(){
        return IsTaken;
    }

        public Listing (int id, string name, DateTime date, TimeSpan time, decimal cost, string IsTaken){
        Id = id;
        TrainerName = name;
        SessionDate = date;
        SessionTime = time;
        SessionCost = cost;
        IsTaken = IsTaken;
        }

        public override string ToString(){
        return $"{Id}#{TrainerName}#{SessionDate}#{SessionTime}#{SessionCost}#{IsTaken}";
        }
    }
}
