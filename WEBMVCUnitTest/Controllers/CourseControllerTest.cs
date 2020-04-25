using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WEBMVC.Controllers;
using WEBMVC.Models;
using WEBMVC.Services;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WEBMVCUnitTest.Controllers
{
	public class CourseControllerTest
	{

		[Fact]
		public void Index()
		{
			// Arrange
			var mockRepo = new Mock<ICourse>();
			var controller = new CourseController(mockRepo.Object);

			// Act
			var viewResult = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(viewResult);
			Assert.IsNotNull(viewResult.Model);
			Assert.IsTrue(string.IsNullOrEmpty(viewResult.ViewName) || viewResult.ViewName == "Index");
		}
	}
}