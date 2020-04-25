using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBMVC.Models;

namespace WEBMVC.Services
{
	public interface IGender
	{
		IEnumerable<Gender> GetGenders { get; }
		Gender GetGender(int? Id);
		void Add(Gender _Gender);
		void Remove(int? Id);
	}
}
