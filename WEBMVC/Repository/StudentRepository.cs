using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBMVC.Models;
using WEBMVC.Services;

namespace WEBMVC.Repository
{
	public class StudentRepository : IStudent
	{
		private SchoolDbContext context;
		public StudentRepository(SchoolDbContext _context)
		{
			context = _context;
		}
		public IEnumerable<Student> GetStudents => context.Students.Include(g => g.Genders);

		public void Add(Student _Student)
		{
			if (_Student.StudentId == 0)
			{
				context.Students.Add(_Student);
				context.SaveChanges();

			}
			else
			{
				var dbEntity = context.Students.Find(_Student.StudentId);
				dbEntity.FirstName = _Student.FirstName;
				dbEntity.LastName = _Student.LastName;
				dbEntity.DOB = _Student.DOB;
				dbEntity.Enrollments = _Student.Enrollments;
				dbEntity.GenderId = _Student.GenderId;
				dbEntity.Genders = _Student.Genders;
				dbEntity.Status = _Student.Status;
				dbEntity.RegistrationDate = _Student.RegistrationDate;
				context.SaveChanges();
			}
		}

		public Student GetStudent(int? Id)
		{
			Student dbEntity = context.Students.Include(e => e.Enrollments)
										  .ThenInclude(c => c.Courses)
										  .Include(g => g.Genders)
										  .SingleOrDefault(m => m.StudentId == Id);
			return dbEntity;
		}

		public void Remove(int? Id)
		{
			Student dbEntity = context.Students.Find(Id);
			context.Students.Remove(dbEntity);
			context.SaveChanges();
		}
	}
}
