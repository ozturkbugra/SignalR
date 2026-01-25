using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;
        private readonly IProductService _productService;

        public BasketManager(IBasketDal basketDal, IProductService productService)
        {
            _basketDal = basketDal;
            _productService = productService;
        }

        public void TAdd(Basket entity)
        {
            int menuTableId = 1;

            
            var basket = _basketDal.GetBasketByProductAndTable(entity.ProductID, menuTableId);

            if (basket != null)
            {
                basket.Count += 1;
                basket.TotalPrice = basket.Price * basket.Count;

                _basketDal.Update(basket);
            }
            else
            {
                var product = _productService.TGetById(entity.ProductID);

                entity.MenuTableID = menuTableId;
                entity.Count = 1;
                entity.Price = product.Price;
                entity.TotalPrice = product.Price;

                _basketDal.Add(entity);
            }
        }



        public void TDelete(Basket entity)
        {
            throw new NotImplementedException();
        }

        public List<Basket> TGetBasketByMenuTableNumber(int id)
        {
            return _basketDal.GetBasketByMenuTableNumber(id);
        }

        public Basket TGetBasketByProductAndTable(int productId, int menuTableId)
        {
            throw new NotImplementedException();
        }

        public Basket TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Basket> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Basket entity)
        {
            _basketDal.Update(entity);
        }
    }
}
