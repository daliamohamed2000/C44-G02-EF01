using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace R_EFcore.Data.Models
{
    [PrimaryKey(nameof(CrsId), nameof(StudId))]
    internal class StudentCourse
    {
        [ForeignKey(nameof(Course))]
        public int CrsId { get; set; }
        public Course Course { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudId { get; set; }
        public Student Student { get; set; }
    }
}
