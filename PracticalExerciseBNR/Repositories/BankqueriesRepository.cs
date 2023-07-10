﻿using System.Linq;

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
}
