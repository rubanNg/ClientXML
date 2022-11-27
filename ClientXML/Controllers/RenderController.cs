using ClientXML.Repositories.ClientRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientXML.Controllers
{
    [ApiController]
    [Route("/")]
    public class RenderController : Controller
    {
        readonly private IClientRepository clientRepository;

        public RenderController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        [HttpGet("/")]
        public IActionResult Index() 
        {
            return View();
        }

        [HttpGet("/clients")]
        async public Task<IActionResult> Clients()
        {
            var clients = await clientRepository.GetAllAsync();
            return View(clients); 
        }

        [HttpGet("/upload")]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpGet("/edit/{clientId}")]
        async public Task<IActionResult> Edit(Guid clientId)
        {
            var client = await clientRepository.GetAsync(clientId);
            return View(client);
        }
    }
}
