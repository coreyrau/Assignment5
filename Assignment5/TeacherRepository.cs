using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class TeacherRepository : Repository<Teacher> , ITeacherRepository
    {
        public TeacherRepository() : base(new SchoolDBEntities())
        {

        }
    }

    public interface ITeacherRepository : IRepository<Teacher>
    {

    }
}
