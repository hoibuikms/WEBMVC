using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBMVC.Models;
using WEBMVC.Services;

namespace WEBMVC.Repository
{
    public class EnrollmentRepository : IEnrollment
    {
        private SchoolDbContext context;
        public EnrollmentRepository(SchoolDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Enrollment> GetEnrollments => context.Enrollments.Include(s => s.Students).Include(c => c.Courses);

        public void Add(Enrollment _Enrollment)
        {
            context.Enrollments.Add(_Enrollment);
            context.SaveChanges();
        }

        public Enrollment GetEnrollment(int? Id)
        {
            return context.Enrollments.Find(Id);
        }

        public void Remove(int? Id)
        {
            Enrollment dbEntity = context.Enrollments.Find(Id);
            context.Enrollments.Remove(dbEntity);
            context.SaveChanges();
        }
    }
}
