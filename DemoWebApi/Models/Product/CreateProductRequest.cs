using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebApi.Models.Product
{
    public class CreateProductRequest
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}