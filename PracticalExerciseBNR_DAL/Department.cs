using System;
using System.Collections.Generic;

namespace PracticalExerciseBNR_DAL;

public partial class Department
{
    public int Iddepartment { get; set; }

    public string NameDepartment { get; set; } = null!;

    public int? TenantId { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
