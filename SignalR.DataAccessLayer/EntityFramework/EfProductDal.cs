using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            using var context = new SignalRContext();
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameCorba()
        {
            using var context = new SignalRContext();

            return context.Products.Count(p => p.Category.CategoryName == "Çorba");

        }

        public int ProductCountByCategoryNameTatli()
        {
            using var context = new SignalRContext();

            return context.Products.Count(p => p.Category.CategoryName == "Tatlı");
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new SignalRContext();
            var maxPrice = context.Products.Where(x=> x.Price == context.Products.Max(p => p.Price)).FirstOrDefault();
            return maxPrice.ProductName;

        }

        public string ProductNameByMinPrice()
        {
            using var context = new SignalRContext();
            var minPrice = context.Products.Where(x => x.Price == context.Products.Min(p => p.Price)).FirstOrDefault();
            return minPrice.ProductName;
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SignalRContext();
            return context.Products.Average(p => p.Price);
        }
    }
}
