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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly SignalRContext _signalRcontext;
        public EfCategoryDal(SignalRContext context, SignalRContext signalRcontext) : base(context)
        {
            _signalRcontext = signalRcontext;
        }

        public int ActiveCategoryCount()
        {
            return _signalRcontext.Categories.Count(c => c.CategoryStatus == true);
        }

        public int CategoryCount()
        {
            return _signalRcontext.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            return _signalRcontext.Categories.Count(c => c.CategoryStatus == false);

        }
    }
}
