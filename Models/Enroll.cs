using System;
using System.Collections.Generic;

namespace LittleLearningSystem.Models;

public class Enroll
{
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public decimal? Score { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
