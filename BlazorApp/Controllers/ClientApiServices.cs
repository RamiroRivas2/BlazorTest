using BlazorTest.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientApiController : ControllerBase
    {
        private static List<Client> _clients = new List<Client>
        {
            new Client { Id = 1, Name = "John Doe", Email = "john@example.com", Phone = "123-456-7890" },
            new Client { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Phone = "987-654-3210" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            return Ok(_clients);
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetClientById(int id)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public ActionResult<Client> AddClient(Client client)
        {
            client.Id = _clients.Count > 0 ? _clients.Max(c => c.Id) + 1 : 1;
            _clients.Add(client);
            return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, Client client)
        {
            if (id != client.Id)
                return BadRequest("ID mismatch.");

            var existingClient = _clients.FirstOrDefault(c => c.Id == id);
            if (existingClient == null)
                return NotFound();

            existingClient.Name = client.Name;
            existingClient.Email = client.Email;
            existingClient.Phone = client.Phone;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
                return NotFound();

            _clients.Remove(client);
            return NoContent();
        }
    }
}
