using System.ComponentModel.DataAnnotations;

namespace StudentManager.DataAccess.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<StudentClass> StudentClasses { get; set; }
    }
}
