using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Web;

namespace DemoWebApi.Services
{
    public class ProductService //:IProductService
    {
        private readonly NorthwindEntities _db;

        public ProductService()
        {
            // todo : DI
            _db = new NorthwindEntities();
        }
        public async Task<List<Products>> QueryAsync(int? categoryId, int pageNumber, int pageSize)
        {
            // todo : call sp
            var products = await _db.Products.Where(x => !categoryId.HasValue || x.CategoryID == categoryId.Value)
                                       .OrderBy(x=>x.ProductID)
                                       .Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();
            // todo : should use AutoMapper return new class
            return products;
        }
        public async Task<Products> InquiryAsync(int productId)
        {
            var p = await _db.Products.SingleOrDefaultAsync(x => x.ProductID == productId);
            // todo : null throw exception ? 
            return p;
        }
        public async Task UpdateProductAsync(int productId,string name)
        {
            var p = await _db.Products.SingleAsync(x => x.ProductID == productId);

            p.ProductName = name;

            await _db.SaveChangesAsync();
        }
        public async Task CreateAsync(int categoryID,string name)
        {
            _db.Products.Add(new Products()
            {
                CategoryID = categoryID,
                ProductName = name
                // todo : else...
            });
            await _db.SaveChangesAsync();
        }
        public async Task DeleteAsync(int productId)
        {
            if (!Check())
            {
                throw new Exception("This procust was userd in other orders.");
            }

            var p = await _db.Products.SingleAsync(x => x.ProductID == productId);
            _db.Products.Remove(p);

            await _db.SaveChangesAsync();
        }

        private bool Check()
        {
            // todo : do some check
            return false;
        }
    }
}