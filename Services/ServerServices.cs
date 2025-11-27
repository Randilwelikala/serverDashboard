using serverDashboard.Models;
using System.Text.Json;
using System.IO;
using System.Linq;



namespace serverDashboard.Services
{
    public class ServerService
    {
        private readonly string _jsonFilePath = "wwwroot/data/clients.json";

        private Root LoadJson()
        {
            var json = File.ReadAllText(_jsonFilePath);
            return JsonSerializer.Deserialize<Root>(json);
        }

        public List<Client> GetClients() => LoadJson().Clients;
        public Client GetClientById(string clientId) => LoadJson().Clients.FirstOrDefault(c => c.ClientId == clientId);
        public Server GetServer(string clientId, string serverId) => GetClientById(clientId)?.Servers.FirstOrDefault(s => s.ServerId == serverId);
    }
}
