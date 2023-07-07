namespace PracticalExerciseBNR_DAL;

public partial class Customer
{
    public int Idcustomer { get; set; }

    public string NameCustomer { get; set; } = null!;

    public int Idbank { get; set; }

    public int CurrentAmount { get; set; }

    public int? CreditAmount { get; set; }

    public int? DepositAmount { get; set; }

    public virtual Bank IdbankNavigation { get; set; } = null!;
}
