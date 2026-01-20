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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count(o => o.Description == "MÜŞTERİ MASADA");
        }

        public decimal LastOrderPrice()
        {
            using var context = new SignalRContext();
            return context.Orders.Take(1).OrderByDescending(o => o.OrderID).Select(o => o.TotalPrice).FirstOrDefault();
        }

        public int PassiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count(o => o.Description != "MÜŞTERİ MASADA");
        }

        public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();

            var start = DateTime.Today;              // Bugün 00:00:00
            var end = start.AddDays(1);              // Yarın 00:00:00

            return context.Orders
                .Where(o => o.Date >= start && o.Date < end)
                .Sum(o => o.TotalPrice);
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }
    }
}
