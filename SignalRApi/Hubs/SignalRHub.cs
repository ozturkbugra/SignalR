using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly SignalRContext _context;

        public SignalRHub(SignalRContext context)
        {
            _context = context;
        }

        public async Task SendCategoryCount()
        {
            var count = _context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", count);
        }
    }
}
