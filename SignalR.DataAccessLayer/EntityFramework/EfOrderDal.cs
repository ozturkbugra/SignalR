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
        private readonly SignalRContext _signalRcontext;

        public EfOrderDal(SignalRContext context, SignalRContext signalRcontext) : base(context)
        {
            _signalRcontext = signalRcontext;
        }

        public int ActiveOrderCount()
        {
            return _signalRcontext.Orders.Count(o => o.Description == "MÜŞTERİ MASADA");
        }

        public decimal LastOrderPrice()
        {

            return _signalRcontext.Orders.Take(1).OrderByDescending(o => o.OrderID).Select(o => o.TotalPrice).FirstOrDefault();
        }

        public int PassiveOrderCount()
        {

            return _signalRcontext.Orders.Count(o => o.Description != "MÜŞTERİ MASADA");
        }

        public decimal TodayTotalPrice()
        {
            var start = DateTime.Today;              // Bugün 00:00:00
            var end = start.AddDays(1);              // Yarın 00:00:00

            return _signalRcontext.Orders
                .Where(o => o.Date >= start && o.Date < end)
                .Sum(o => o.TotalPrice);
        }

        public int TotalOrderCount()
        {

            return _signalRcontext.Orders.Count();
        }
    }
}
