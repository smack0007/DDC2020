using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class QueryParameters
    {
        private const int MAX_PAGE_COUNT = 50;

        private int _pageCount = 0;

        public int Page { get; set; } = 1;

        public int PageCount 
        {
            get { return _pageCount; }
            set { _pageCount = (value > MAX_PAGE_COUNT ? MAX_PAGE_COUNT : value); }
        }

        public string OrderBy { get; set; }

        public string Query { get; set; }
    }
}
