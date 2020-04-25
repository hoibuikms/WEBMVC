using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBMVC.Models;

namespace WEBMVC.Services
{
	public interface ICourse
	{
        IEnumerable<Course> GetCourses { get; }
        Course GetCourse(int? Id);
        void Add(Course _Course);
        void Remove(int? Id);
    }
}
