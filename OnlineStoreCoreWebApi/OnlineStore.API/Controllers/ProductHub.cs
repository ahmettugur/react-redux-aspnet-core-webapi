using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using OnlineStore.Entity.Concrete;

namespace OnlineStore.API.Controllers
{
    public class ProductHub: Hub
    {
        public override Task OnConnectedAsync()
        {
            return Clients.Client(Context.ConnectionId).SendAsync("SetConnectionId", Context.ConnectionId);
            
        }
        public async Task<string> ConnectGroup(string stocName,string connectionId)
        {
            await Groups.AddToGroupAsync(connectionId,stocName);
            return $"{connectionId} is added {stocName}";
        }        
        public Task PushNotify(Product product)
        {
            return Clients.Group(product.Id.ToString()).SendAsync("ChangeProductValue", product);
        }        
    }
}
