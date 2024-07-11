using System;
using System.Collections.Generic;

namespace LittleLearningSystem.Models;

public class Student
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Spassword { get; set; } = null!;

    public virtual ICollection<Enroll> Enrolls { get; set; } = new List<Enroll>();
}
