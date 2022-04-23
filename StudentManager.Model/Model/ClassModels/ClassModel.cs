using System.ComponentModel.DataAnnotations;
using StudentManager.Model.Model.StudentClassModels;

namespace StudentManager.Model.Model.ClassModels
{
    public class ClassModel
    {
        public int ClassId { get; set; }
        [Required(ErrorMessage = "This field is required !")]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "This field is required !")]
        public int Capatity { get; set; }
        public List<StudentClassModel> StudentClasses { get; set; }
    }
}
