using System.ComponentModel.DataAnnotations;
using StudentManager.Model.Model.ClassModels;
using StudentManager.Model.Model.StudentModels;

namespace StudentManager.Model.Model.StudentClassModels
{
    public class StudentClassModel
    {
        [Key]
        public int StudentClassId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public ClassModel Class { get; set; }
        public StudentModel Student { get; set; }
    }
}
