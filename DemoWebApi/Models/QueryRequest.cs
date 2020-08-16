using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebApi.Models
{
    public  class QueryRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 100000;
    }
}