using System.ComponentModel.DataAnnotations;

namespace StudentManager.DataAccess.Entities
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int Capatity { get; set; }
        public List<StudentClass> StudentClasses { get; set; }
    }
}
