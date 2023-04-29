namespace mis_221_pa_5_jsmorris5
{
    public class Revenue
    {
    public DateTime Date;
    public decimal Amount;


    public void SetDate(DateTime Date){
        this.Date = Date;
    }

    public DateTime GetDate(){
        return Date;
    }

      public void SetAmount(decimal Amount){
        this.Amount = Amount;
    }

    public decimal GetAmount(){
        return Amount;
    }
    
}
}