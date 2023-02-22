using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace One_to_Many_Relation_webAPI.Model
{
    public class Student
    {
        [Key]
       
        

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public string StudentAddress { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public List<Course> Courses { get; set; }
    }
    public class  Course 
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public List<Student> Students { get; set; }
    }
   
}
