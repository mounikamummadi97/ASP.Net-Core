using Microsoft.EntityFrameworkCore;
using One_to_Many_Relation_webAPI.Data;
using One_to_Many_Relation_webAPI.Model;
using One_to_One__Relation_webAPI.IDataRepository;

namespace One_to_One__Relation_webAPI.DataManager
{
    public class StudentCourseManager : IDataRepository<Student>
    {
        readonly API_DBContext _DBContext;
        public StudentCourseManager(API_DBContext dbcontext)
        {
            _DBContext = dbcontext;
        }
        public void Add(Student entity)
        {
            var result = new Student
            {
                StudentName = entity.StudentName,
                StudentAddress = entity.StudentAddress,
                StudentAge = entity.StudentAge,

            };

            _DBContext.Add(result);
            _DBContext.SaveChanges();


        }

        public void Delete(Student entity)
        {
            _DBContext.Students.Remove(entity);
            _DBContext.SaveChanges();
        }
        public Student Get(long id)
            {
            return _DBContext.Students
                  .FirstOrDefault(e => e.StudentId == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _DBContext.Students.Include("Courses").ToList();
        }

        public void Update(Student dbEntity, Student entity)
        {
            
        }
    }
}
