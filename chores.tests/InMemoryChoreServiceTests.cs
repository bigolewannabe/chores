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
            var chore =  new Chore { ChoreId = 1};
            InMemoryChoreService.Chores = new List<Chore>{chore} ;

            var service = new InMemoryChoreService();

            var retrieved = service.GetChores().Single();

            Assert.That(retrieved, Is.EqualTo(chore));
        }

        [Test]
        public void InMemroyChoreService_UpdateChores_SetsNewChores() 
        {
            InMemoryChoreService.Chores = new List<Chore>{ new Chore { ChoreId = 1}};

            var service = new InMemoryChoreService();
            service.UpdateChores(new Chore { ChoreId = 1, TeethBrushed=true});

            var chore = service.GetChores().Single();

            Assert.That(chore.TeethBrushed, Is.True);
        }
    }
}