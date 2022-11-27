using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ClientXML.Repositories.ClientRepository;
using System;
using ClientXML.Services.ClientService;
using ClientXML.Dto;

namespace ClientXML.Controllers
{
    [ApiController]
    [Route("api")]
    public class ClientController : Controller
    {
        private readonly IClientRepository clientRepository;
        private readonly IClientService clientService;

        public ClientController(IClientRepository clientRepository, IClientService clientService)
        {
            this.clientRepository = clientRepository;
            this.clientService = clientService;
        }

        [HttpPost("create")]
        async public Task<IActionResult> Create([FromBody] ClientCreateDto clientDto)
        {
            try
            {
                var client = clientService.MapCreateDtoToModel(clientDto);
                await clientRepository.CreateAsync(client);
                return Ok(new { success = true });
            }
            catch (Exception error)
            {
                return StatusCode(500, new 
                { 
                    success = false, 
                    errors = new[] 
                    { 
                        error.Message,
                        error.InnerException?.Message,
                    } 
                });
            }

        }

        [HttpPost("upload-xml-file")]
        async public Task<IActionResult> UploadXmlFile([FromBody] FileContentDto fileContent)
        {
            try
            {
                var clients = clientService.Parse(fileContent.Content);

                foreach (var client in clients)
                {
                    var existClient = await clientRepository.GetByCardCodeAsync(client.CardCode);
                    if (existClient != null)
                    {
                        clientService.Merge(existClient, client, (c) => new[] { nameof(c.Id) } );
                        await clientRepository.UpdateAsync(existClient);
                    } else 
                    {
                        await clientRepository.CreateAsync(client);
                    }
                }

                return Ok(new { success = true });
            }
            catch (Exception error)
            {
                return StatusCode(500, new
                {
                    success = false,
                    errors = new[]
                    {
                        error.Message,
                        error.InnerException?.Message,
                    }
                });
            }
        }

        [HttpPut("update")]
        async public Task<IActionResult> Update([FromBody] ClientUpdateDto clientDto)
        {


            try
            {
                var client = clientService.MapUpdateDtoToModel(clientDto);
                await clientRepository.UpdateAsync(client);
                return Ok(new { success = true });
            }
            catch (Exception error)
            {
                return StatusCode(500, new
                {
                    success = false,
                    errors = new[]
                    {
                        error.Message,
                        error.InnerException?.Message,
                    }
                });
            }

        }
    }
}
