namespace PracticalExerciseBNR.Repositories;

public class BankqueriesRepository
{
    private TestscursnetcoreContext context;
    public BankqueriesRepository()
    {
        context = new TestscursnetcoreContext();
    }

    public IEnumerable<BankModels> GetAllCustomers()
    {
        if (context == null)
        {
            ArgumentNullException.ThrowIfNull(context);
        }
        List<BankModels> result = new List<BankModels>();
        var bankCustomers = (IEnumerable<Bank>)context.Banks
            .Include(c => c.Customers);
        foreach (var b in bankCustomers)
        {
            List<CustomerModels> debtorCustomers = new List<CustomerModels>();
            if (b.Customers.Count > 0)
            {
                debtorCustomers.AddRange(from c in b.Customers
                                         where c.CreditAmount > 0
                                         select new CustomerModels
                                         {
                                             Id = c.Idcustomer,
                                             CustomerName = c.NameCustomer,
                                             CreditAmount = c.CreditAmount,
                                         });
                result.Add(new BankModels
                {
                    BankId = b.Idbank,
                    BankName = b.NameBank,
                    CustomerEnt = debtorCustomers
                });
            }
        }

        return result;
    }
}
