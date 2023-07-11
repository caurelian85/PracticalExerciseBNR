namespace PracticalExerciseBNR_DAL;

public partial class Customer //:IValidatableObject
{
    public int Idcustomer { get; set; }

    public string NameCustomer { get; set; } = null!;

    public int Idbank { get; set; }

    public int CurrentAmount { get; set; }

    public int? CreditAmount { get; set; }

    public int? DepositAmount { get; set; }

    public virtual Bank IdbankNavigation { get; set; } = null!;

    /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        //422 Unprocessable Entity
        if (this.CreditAmount > 5000)
        { 
            yield return new ValidationResult("422 Unprocessable Entity! MaxDebt exceeded!");
        }
    }*/
}
