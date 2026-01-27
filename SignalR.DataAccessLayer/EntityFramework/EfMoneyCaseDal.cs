using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        private readonly SignalRContext _signalRcontext;

        public EfMoneyCaseDal(SignalRContext context, SignalRContext signalRcontext) : base(context)
        {
            _signalRcontext = signalRcontext;
        }

        public decimal TotalMoneyCaseAmount()
        {
           return _signalRcontext.MoneyCases.Select(x=> x.TotalAmount).FirstOrDefault();
        }
    }
}
