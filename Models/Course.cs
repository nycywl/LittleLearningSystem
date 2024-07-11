using System;
using System.Collections.Generic;

namespace LittleLearningSystem.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; } = null!;

        public int AmountLimit { get; set; }

        public string CourseWeek { get; set; } = null!;

        public TimeOnly CourseTime { get; set; }

        public virtual ICollection<Enroll> Enrolls { get; set; } = new List<Enroll>();

        public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}
