using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBMVC.Models;
using WEBMVC.Services;

namespace WEBMVC.Repository
{
	public class CourseRepository : ICourse
	{
		private SchoolDbContext context;
		
		public CourseRepository(SchoolDbContext _context)
		{
			context = _context;
		}
		
		public IEnumerable<Course> GetCourses => context.Courses;

		public void Add(Course _Course)
		{
			if (_Course.CourseId == 0)
			{
				context.Courses.Add(_Course);
				context.SaveChanges();
			}
			else
			{
				var dbEntity = context.Courses.Find(_Course.CourseId);
				dbEntity.CourseName = _Course.CourseName;
				dbEntity.Credits = _Course.Credits;
				context.SaveChanges();
			}


		}

		public Course GetCourse(int? Id)
		{
			return context.Courses.Include(e => e.Enrollments).ThenInclude(s => s.Students).SingleOrDefault(a => a.CourseId == Id);
		}

		public void Remove(int? Id)
		{
			Course dbEntity = context.Courses.Find(Id); ;
			context.Courses.Remove(dbEntity);
			context.SaveChanges();
		}
	}
}
