using System;
using System.ComponentModel.DataAnnotations;

namespace chores.Models
{
    public class Chore 
    {
        public int ChoreId {get; set;}

        [Display(Name = "Put on PJ's")]
        public bool PutOnPJs {get; set;}

        [Display(Name = "Dirty laundry put away")]
        public bool DirtyLaundry {get; set;}

        [Display(Name = "Teeth brushed")]
        public bool TeethBrushed {get; set;}
    }
}