using System;
using NUnit.Framework;
using chores.Controllers;
using chores.Services;
using chores.Models;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace chores.tests 
{
    [TestFixture]
    public class HomeControllerTests 
    {
        [Test]
        public void HomeController_Index_ModelIsChore() 
        {
            var chore =new Chore { ChoreId = 1};
            var fakeChoreService = Substitute.For<IChoreService>();
            fakeChoreService.GetChores().Returns(new List<Chore> {chore} .AsQueryable());

            var controller = new HomeController(fakeChoreService, Substitute.For<ILogger<HomeController>>());
            var result = controller.Index() as ViewResult;
            var model = result.Model as Chore;

            Assert.That(model, Is.EqualTo(chore));
        }

        [Test]
        public void HomeController_PostToIndex_UpdatesAndRedirectsToIndex() 
        {
            var fakeChoreService = Substitute.For<IChoreService>();
            var controller = new HomeController(fakeChoreService, Substitute.For<ILogger<HomeController>>());

            var result = controller.Index(new Chore{ChoreId=1});

            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
            fakeChoreService.Received(1).UpdateChores(Arg.Any<Chore>());
        }
    }
}