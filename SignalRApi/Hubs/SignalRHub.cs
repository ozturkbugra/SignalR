using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public SignalRHub(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task SendCategoryCount()
        {
            var count = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", count);
        }

        public async Task SendProductCount()
        {
            var count = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", count);
        }

        public async Task ActiveCategoryCount()
        {
            var count = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", count);
        }

        public async Task PassiveCategoryCount()
        {
            var count = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", count);
        }
    }
}
