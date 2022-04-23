using StudentManager.Model.Model.StudentClassModels;
using System.ComponentModel.DataAnnotations;


namespace StudentManager.Model.Model.StudentModels
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "This field is required !")]
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<StudentClassModel>? StudentClasses { get; set; }
    }
}
