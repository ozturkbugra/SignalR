using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        private readonly SignalRContext _signalRcontext;

        public EfMenuTableDal(SignalRContext context, SignalRContext signalRcontext) : base(context)
        {
            _signalRcontext = signalRcontext;
        }

        public int MenuTableCount()
        {
            return _signalRcontext.MenuTables.Count();
        }
    }
}
