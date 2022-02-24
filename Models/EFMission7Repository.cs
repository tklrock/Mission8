using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Models
{
    public class EFMission7Repository : IMission7Repository
    {
        private BookstoreContext context { get; set; }
        public EFMission7Repository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
