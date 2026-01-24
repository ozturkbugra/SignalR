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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        private readonly SignalRContext _context;

        public EfBasketDal(SignalRContext context) : base(context)
        {
            _context = context; // Constructor'dan gelen context'i yerel değişkene atıyoruz
        }
       

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            
            var values = _context.Baskets.Where(b => b.MenuTableID == id).Include(x=> x.Product).Include(x=> x.MenuTable).ToList();
            return values;
        }
    }
}
