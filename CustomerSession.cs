namespace mis_221_pa_5_jsmorris5
{
    public class CustomerSession
    {
    public int SessionId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail;
    public DateTime Date;
    public int Duration;
    public int TrainerId { get; set; }
    public string TrainerName { get; set; }
    public SessionStatus Status { get; set; }

    public void SetCustomerEmail(string CustomerEmail){
        this.CustomerEmail = CustomerEmail;
    }

    public string GetCustomerEmail(){
        return CustomerEmail;
    }

    public void SetDate(DateTime Date){
        this.Date = Date;
    }

    public DateTime GetDate(){
        return Date;
    }

    public void SetDuration(int Duration){
        this.Duration = Duration;
    }

    public int GetDuration(){
        return Duration;
    }
    }
}