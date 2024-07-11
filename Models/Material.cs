using System;
using System.Collections.Generic;

namespace LittleLearningSystem.Models;

public class Material
{
    public int MaterialId { get; set; }

    public int? CourseId { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime UpdateTime { get; set; }

    public string FileName { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public virtual Course? Course { get; set; }
}
