using System;
using System.Collections.Generic;
using System.Linq;
using chores.Models;

namespace chores.Services 
{
    public class InMemoryChoreService : IChoreService 
    {
        public static List<Chore> Chores {get; set;}

        public IQueryable<Chore> GetChores() => Chores.AsQueryable();

        public void UpdateChores(Chore chore)
        {
            var toUpdate = Chores.Single(c => c.ChoreId == chore.ChoreId);
            toUpdate.DirtyLaundry = chore.DirtyLaundry;
            toUpdate.PutOnPJs = chore.PutOnPJs;
            toUpdate.TeethBrushed = chore.TeethBrushed;
        }
    }
}