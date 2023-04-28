namespace mis_221_pa_5_jsmorris5
{
    public class Revenue
    {
    public DateTime Date;
    public int Amount;


    public void SetDate(DateTime Date){
        this.Date = Date;
    }

    public DateTime GetDate(){
        return Date;
    }

      public void SetAmount(int Amount){
        this.Amount = Amount;
    }

    public int GetAmount(){
        return Amount;
    }

    }
}