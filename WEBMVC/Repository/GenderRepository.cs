using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBMVC.Models;
using WEBMVC.Services;

namespace WEBMVC.Repository
{
	public class GenderRepository : IGender
	{
		private SchoolDbContext context;
		public GenderRepository(SchoolDbContext _context)
		{
			context = _context;
		}

		public IEnumerable<Gender> GetGenders => context.Genders;

		public void Add(Gender _Gender)
		{

			if (_Gender.GenderId == 0)
			{
				context.Genders.Add(_Gender);
				context.SaveChanges();
			}
			else
			{
				var dbEntity = context.Genders.Find(_Gender.GenderId);
				dbEntity.GenderId = _Gender.GenderId;
				dbEntity.GenderName = _Gender.GenderName;
				context.SaveChanges();
			}
		}

		public Gender GetGender(int? Id)
		{
			return context.Genders.Find(Id);
		}

		public void Remove(int? Id)
		{
			Gender dbEntity = context.Genders.Find(Id);
			context.Genders.Remove(dbEntity);
			context.SaveChanges();
		}
	}
}
