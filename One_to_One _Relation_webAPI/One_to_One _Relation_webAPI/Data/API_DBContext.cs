using Microsoft.EntityFrameworkCore;
using One_to_Many_Relation_webAPI.Model;

namespace One_to_Many_Relation_webAPI.Data
{
    public class API_DBContext:DbContext
    {
        public API_DBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
