namespace PracticalExerciseBNR.Repositories;

public class BankqueriesRepository
{
    private TestscursnetcoreContext context;
    public BankqueriesRepository()
    {
        context = new TestscursnetcoreContext();
    }

    public IEnumerable<BankModels> GetDebtorCustomers()
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

    public IEnumerable<CustomerDebtorModels> GetCustomersWithMoreCredits()
    {
        if (context == null)
        {
            ArgumentNullException.ThrowIfNull(context);
        }

        IQueryable<CustomerDebtorModels>? query = from c in context.Customers
                                                  join b in context.Banks on c.Idbank equals b.Idbank
                                                  group c by new { c.NameCustomer } into g
                                                  where g.Count() >= 2
                                                  orderby g.Key.NameCustomer
                                                  select new CustomerDebtorModels
                                                  {
                                                      CustomerName = g.Key.NameCustomer,
                                                  };

        return query;
    }

    public IEnumerable<CustomerDetailsModels> CustomerDetails(string customerName)
    {
        var customerDetails = context.Customers.Where(p => p.NameCustomer == customerName);
        ArgumentNullException.ThrowIfNull(customerDetails);
        var customerDetailsModel = new List<CustomerDetailsModels>();
        foreach (var item in customerDetails)
        {
            customerDetailsModel.Add(new CustomerDetailsModels
            {
                CustomerName = item.NameCustomer,
                CreditAmount = item.CreditAmount,
                BankName = context.Banks.FirstOrDefault(b => b.Idbank == item.Idbank)!.NameBank,
                CurrentAmount = item.CurrentAmount,
                DepositAmount = item.DepositAmount,
                Id = item.Idcustomer
            });
        }
        return customerDetailsModel;
    }

    public bool CreditRelocate(string customerName, string firstBank, string secondBank, long maxDebit)
    {
        Bank? stBank = context.Banks.FirstOrDefault(b => b.NameBank == firstBank);
        Bank? ndBank = context.Banks.FirstOrDefault(b => b.NameBank == secondBank);
        ArgumentNullException.ThrowIfNull(stBank);
        ArgumentNullException.ThrowIfNull(ndBank);

        Customer? firstCustomerCredit = context.Customers.FirstOrDefault(p => p.NameCustomer == customerName && p.Idbank == stBank.Idbank);
        ArgumentNullException.ThrowIfNull(firstCustomerCredit);


        Customer? secondCustomerCredit = context.Customers.FirstOrDefault(p => p.NameCustomer == customerName && p.Idbank == ndBank.Idbank);
        ArgumentNullException.ThrowIfNull(secondCustomerCredit);

        secondCustomerCredit.CreditAmount += firstCustomerCredit.CreditAmount == null ? 0 : firstCustomerCredit.CreditAmount;
        secondCustomerCredit.CurrentAmount += firstCustomerCredit.CurrentAmount;
        secondCustomerCredit.DepositAmount += firstCustomerCredit.DepositAmount == null ? 0 : firstCustomerCredit.DepositAmount;

        if (secondCustomerCredit.CreditAmount > maxDebit)
            return false;
        context.Remove(firstCustomerCredit);
        context.Customers.Update(secondCustomerCredit);
        context.SaveChangesAsync();
        return true;

    }
}
