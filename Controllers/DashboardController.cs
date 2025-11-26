using Microsoft.AspNetCore.Mvc;
using serverDashboard.Models;
using serverDashboard.Services;

namespace serverDashboard.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ServerService _service;

        public DashboardController(ServerService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var clients = _service.GetClients();
            return View(clients);
        }

        [HttpGet]
        public IActionResult GetServers(string clientId)
        {
            var client = _service.GetClientById(clientId);
            var servers = client?.Servers ?? new List<Server>(); 
            return Json(servers);
        }

        [HttpGet]
        public IActionResult GetServerDetails(string clientId, string serverId)
        {
            var server = _service.GetServer(clientId, serverId);
            if (server == null)
                return Json(new Server()); 
            return Json(server);
        }

    }
}
