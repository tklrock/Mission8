using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Models
{
    public interface IMission7Repository
    {
        IQueryable<Book> Books { get; }
    }
}
