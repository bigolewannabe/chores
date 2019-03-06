using System;
using NUnit.Framework;
using chores.Services;
using chores.Models;
using System.Collections.Generic;
using System.Linq;

namespace chores.tests
{
    [TestFixture]
    public class InMemoryChoreServiceTests 
    {
        [Test]
        public void InMemoryChoreRepository_GetChores_ReturnsChoresItHas()
        {
            InMemoryChoreService.Chores = new List<Chore>{ new Chore { ChoreId = 1, Name = "First"}};

            var service = new InMemoryChoreService();

            var chore = service.GetChores().Single();

            Assert.Multiple(() => 
            {
                Assert.That(chore.ChoreId, Is.EqualTo(1));
                Assert.That(chore.Name, Is.EqualTo("First"));
            });
        }

        [Test]
        public void InMemroyChoreService_UpdateChores_SetsNewChores() 
        {
            InMemoryChoreService.Chores = new List<Chore>{ new Chore { ChoreId = 1, Name = "First"}};

            var service = new InMemoryChoreService();
            service.UpdateChores(new List<Chore> { new Chore { ChoreId = 1, Name = "Second"}});

            var chore = service.GetChores().Single();

            Assert.Multiple(() => 
            {
                Assert.That(chore.ChoreId, Is.EqualTo(1));
                Assert.That(chore.Name, Is.EqualTo("Second"));
            });
        }
    }
}