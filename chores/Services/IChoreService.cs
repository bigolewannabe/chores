using chores.Models;
using System.Collections.Generic;
using System.Linq;

namespace chores.Services 
    {
    public interface IChoreService {
        IQueryable<Chore> GetChores();
        void UpdateChores(Chore chore);
    }
}