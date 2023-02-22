using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using One_to_Many_Relation_webAPI.Model;

namespace One_to_One__Relation_webAPI.Model
{
    public class StudentCourse
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public List<Student>? Student { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public List<Course>? Courses { get; set; }
    }
}
