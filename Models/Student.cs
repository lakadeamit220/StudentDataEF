using System;
using System.Collections.Generic;

namespace StudentDataEF.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Course { get; set; } = null!;
}
