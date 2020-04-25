using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBMVC.Models;
using WEBMVC.Services;

namespace WEBMVC.Controllers
{

	public class GenderController : Controller
	{
		private readonly IGender _Gender;
		public GenderController(IGender _IGender)
		{
			_Gender = _IGender;
		}
		public IActionResult Index()
		{
			return View(_Gender.GetGenders);
		}
		[HttpGet]
		public IActionResult Create(int id = 0)
		{
			if (id == 0)
			{
				return View();
			}
			else
				return View(_Gender.GetGender(id));
		}

		[HttpPost]
		public IActionResult Create(Gender model)
		{
			if (ModelState.IsValid)
			{
				_Gender.Add(model);
				return RedirectToAction("Index");
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult Delete(int? Id)
		{
			if (Id == null)
			{
				//Error 
				return NotFound();
			}

			else
			{
				Gender model = _Gender.GetGender(Id);
				return View(model);
			}
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirm(int? Id)
		{
			_Gender.Remove(Id);
			return RedirectToAction("Index");

		}

		public IActionResult Edit(int? Id)
		{
			var model = _Gender.GetGender(Id);
			return View("Edit", model);
		}

		[HttpPost]
		public IActionResult Edit(Gender model)
		{
			if (ModelState.IsValid)
			{
				_Gender.Add(model);
				return RedirectToAction("Index");
			}
			return View(model);
		}

	}
}
