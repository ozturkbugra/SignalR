using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categorDal;

        public CategoryManager(ICategoryDal categorDal)
        {
            _categorDal = categorDal;
        }

        public int TActiveCategoryCount()
        {
            return _categorDal.ActiveCategoryCount();
        }

        public void TAdd(Category entity)
        {
            _categorDal.Add(entity);
        }

        public int TCategoryCount()
        {
            return _categorDal.CategoryCount();
        }

        public void TDelete(Category entity)
        {
            _categorDal.Delete(entity);
        }

        public Category TGetById(int id)
        {
            return _categorDal.GetById(id);
        }

        public List<Category> TGetListAll()
        {
           return _categorDal.GetListAll();
        }

        public int TPassiveCategoryCount()
        {
           return _categorDal.PassiveCategoryCount();
        }

        public void TUpdate(Category entity)
        {
            _categorDal.Update(entity);
        }
    }
}
