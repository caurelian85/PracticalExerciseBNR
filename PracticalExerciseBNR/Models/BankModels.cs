namespace PracticalExerciseBNR.Models;

public class BankModels
{
    public int BankId { get; set; } 
    public string BankName { get; set;}
    public List<CustomerModels> CustomerEnt { get; set; }
}
public class CustomerModels
{
    public int Id { get; set; } 
    public string CustomerName { get; set; }
    public int? CreditAmount{ get; set; }
}

public class CustomerDebtorModels
{
    public string CustomerName { get; set; }
    //public List<string> BankName { get; set; }
}
