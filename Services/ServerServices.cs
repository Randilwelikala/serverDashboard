using serverDashboard.Models;
using System.Text.Json;

namespace serverDashboard.Services
{
    public class ServerService
    {
        private readonly Root _root;

        public ServerService()
        {           
            var json = System.IO.File.ReadAllText("wwwroot/data/clients.json");
            _root = JsonSerializer.Deserialize<Root>(json);
        }

        public List<Client> GetClients() => _root.Clients;
        public Client GetClientById(string clientId) => _root.Clients.FirstOrDefault(c => c.ClientId == clientId);
        public Server GetServer(string clientId, string serverId) => GetClientById(clientId)?.Servers.FirstOrDefault(s => s.ServerId == serverId);
    }
}
