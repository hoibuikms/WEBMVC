using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WEBMVC.Models;
using WEBMVC.Services;

namespace WEBMVCUnitTest.Model
{
	class InMemoryCourseRepository : ICourse, IDisposable
	{
		private List<Course> _db = new List<Course>();

		public Exception ExceptionToThrow
		{
			get;
			set;
		}

		public IEnumerable<Course> GetCourses => _db.ToList();

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					//Dispose Object Here    
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public Course GetCourse(int? Id)
		{
			return _db.FirstOrDefault(c => c.CourseId == Id);
		}

		public void Add(Course _Course)
		{
			_db.Add(_Course);
		}

		public void Remove(int? Id)
		{
			_db.Remove(GetCourse(Id));
		}
	}
}
