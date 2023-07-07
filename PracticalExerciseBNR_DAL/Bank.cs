using System;
using System.Collections.Generic;

namespace PracticalExerciseBNR_DAL;

public partial class Bank
{
    public int Idbank { get; set; }

    public string NameBank { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
