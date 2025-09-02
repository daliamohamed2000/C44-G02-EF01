﻿namespace R_EFcore.Data.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}
