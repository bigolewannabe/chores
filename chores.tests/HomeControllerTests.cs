using System;
using NUnit.Framework;
using chores.Controllers;
using chores.Services;
using chores.Models;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace chores.tests 
{
    [TestFixture]
    public class HomeControllerTests 
    {
        [Test]
        public void HomeController_Index_ModelIsListOfChores() 
        {
            var fakeChoreService = Substitute.For<IChoreService>();
            fakeChoreService.GetChores().Returns(new List<Chore> { new Chore { Name = "First"}}.AsQueryable());

            var controller = new HomeController(fakeChoreService);
            var result = controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<string>;

            Assert.That(model.First(), Is.EqualTo("First"));
        }
    }
}