using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Model;
namespace WebApp.ViewModel
{
    public class ReviewsViewModel
    {
        public Person Person { get; set; }
        public IEnumerable<Quality> Qualities { get; set; } 
    }
}
