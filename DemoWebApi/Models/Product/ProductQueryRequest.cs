using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebApi.Models.Product
{
    public class ProductQueryRequest: QueryRequest
    {
        public int? CategoryId { get; set; }
    }
}