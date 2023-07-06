using System;
using System.Collections.Generic;

namespace PracticalExerciseBNR_DAL;

public partial class Employee
{
    public int Idemployee { get; set; }

    public string NameEmployee { get; set; } = null!;

    public int Iddepartment { get; set; }

    public virtual Department IddepartmentNavigation { get; set; } = null!;
}
