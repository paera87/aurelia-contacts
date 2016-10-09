using backendAPISQL.Data;
using backendAPISQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace backendAPISQL.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactContext _contactContext;

        public ContactsController(ContactContext contactContext)
        {
            _contactContext = contactContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Contact>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _contactContext.Contacts.OrderBy(p => p.LastName).ToListAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Contact), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _contactContext.Contacts.SingleOrDefaultAsync(p => p.Id == id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Contact), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody]Contact contact)
        {
            _contactContext.Add(contact);
            await _contactContext.SaveChangesAsync();
            return Created("api/contacts/" + contact.Id, contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest("Id is incorrect");
            }
            _contactContext.Entry(contact).State = EntityState.Modified;
            await _contactContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _contactContext.Entry(new Contact { Id = id }).State = EntityState.Deleted;
            await _contactContext.SaveChangesAsync();
            return Ok();
        }
    }
}