using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class CourseRepository : Repository<Course> ,ICourseRepository
    {
        public CourseRepository() : base(new SchoolDBEntities())
        {

        }
    }

    public interface ICourseRepository : IRepository<Course>
    {

    }
}
