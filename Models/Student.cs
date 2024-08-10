using System.ComponentModel.DataAnnotations;

namespace CrudCore.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FatherName { get; set; }
        [Required]
        public string MotherName { get; set; }

        [Required]
        public string standerd {  get; set; }
    }
}
