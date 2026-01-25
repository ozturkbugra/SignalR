using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        int clientcount = 0;
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendStatistic()
        {
            var count = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", count);

            var count2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", count2);

            var count3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", count3);

            var count4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", count4);

            var count5 = _productService.TProductCountByCategoryNameCorba();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameCorba", count5);

            var count6 = _productService.TProductCountByCategoryNameTatli();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameTatli", count6);

            var count7 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", count7.ToString("N2") + " ₺");

            var count8 = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", count8);

            var count9 = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", count9);

            var count10 = _productService.TAvgPriceByCorba();
            await Clients.All.SendAsync("ReceiveAvgPriceByCorba", count10.ToString("N2") + " ₺");

            var count11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", count11.ToString("N0"));

            var count12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", count12.ToString("N0"));

            var count13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", count13.ToString("N2") + " ₺");

            var count14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", count14.ToString("N2") + " ₺");
            
            var count15 = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", count15.ToString("N2") + " ₺");
        
            var count16 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", count16.ToString("N0"));
        
        
        
        }

        public async Task SendProgress()
        {
            var count = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", count.ToString("N2") + " ₺");

            var count12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", count12.ToString("N0"));

            var count16 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", count16.ToString("N0"));

        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

        public async Task SendNotification()
        {
            var values = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", values);
        
            var falselist = _notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse", falselist);


        }

        public async Task GetMenuTableStatus()
        {
            var value = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableStatus",value);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);

        }

        public override async Task OnConnectedAsync()
        {
            clientcount++;
            await Clients.All.SendAsync("ReceiveClientCount",clientcount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientcount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientcount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
