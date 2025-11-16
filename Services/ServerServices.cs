using System.Text.Json;
using serverDashboard.Models;

namespace serverDashboard.Services
{
    public class ServerService
    {
        private readonly Root _data;

        public ServerService()
        {
            string json = File.ReadAllText("Data/serverData.json");
            _data = JsonSerializer.Deserialize<Root>(json);
        }

        public List<Client> GetClients() => _data.Clients;
        public Client GetClient(string clientId) => _data.Clients.FirstOrDefault(c => c.ClientId == clientId);
    }
}
