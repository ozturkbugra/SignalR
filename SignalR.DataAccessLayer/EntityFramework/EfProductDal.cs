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
        private readonly SignalRContext _signalRcontext;

        public EfProductDal(SignalRContext context, SignalRContext signalRcontext) : base(context)
        {
            _signalRcontext = signalRcontext;
        }

        public decimal AvgPriceByCorba()
        {

            return _signalRcontext.Products.Where(p => p.Category.CategoryName == "Çorba").Average(p => p.Price);
        }

        public List<Product> GetProductsWithCategories()
        {

            var values = _signalRcontext.Products.Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {

            return _signalRcontext.Products.Count();
        }

        public int ProductCountByCategoryNameCorba()
        {


            return _signalRcontext.Products.Count(p => p.Category.CategoryName == "Çorba");

        }

        public int ProductCountByCategoryNameTatli()
        {


            return _signalRcontext.Products.Count(p => p.Category.CategoryName == "Tatlı");
        }

        public string ProductNameByMaxPrice()
        {

            var maxPrice = _signalRcontext.Products.Where(x=> x.Price == _signalRcontext.Products.Max(p => p.Price)).FirstOrDefault();
            return maxPrice.ProductName;

        }

        public string ProductNameByMinPrice()
        {

            var minPrice = _signalRcontext.Products.Where(x => x.Price == _signalRcontext.Products.Min(p => p.Price)).FirstOrDefault();
            return minPrice.ProductName;
        }

        public decimal ProductPriceAvg()
        {

            return _signalRcontext.Products.Average(p => p.Price);
        }
    }
}
