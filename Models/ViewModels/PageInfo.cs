using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Models.ViewModels
{
    //Holds Pagination/index book list navigation information
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Figure out how many apges we need
        public int TotalPages => (int)Math.Ceiling((double)TotalNumBooks / BooksPerPage);
    }
}
