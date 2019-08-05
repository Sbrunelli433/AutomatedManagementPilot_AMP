using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomatedManagementPilot_AMP.Data;
using AutomatedManagementPilot_AMP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutomatedManagementPilot_AMP.Controllers
{
    [Produces("application/json")]
    [Route("api/link")]
    public class LinkController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LinkController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/link
        [HttpGet]
        public IEnumerable<WebApiLink> Get()
        {
            return _context.Links.ToList().Select(t => (WebApiLink)t);
        }

        // GET api/link/5
        [HttpGet("{id}")]
        public WebApiLink Get(int id)
        {
            return (WebApiLink)_context.Links.Find(id);
        }

        // POST api/<controller>
        [HttpPost]
        public ObjectResult Post(WebApiLink apiLink)
        {
            var newLink = (Link)apiLink;
            _context.Links.Add(newLink);
            _context.SaveChanges();

            return Ok(new
            {
                tid = newLink.Id,
                action = "inserted"
            });
        }

        // PUT api/link/5
        [HttpPut("{id}")]
        public ObjectResult Put(int id, WebApiLink apiLink)
        {
            var updatedLink = (Link)apiLink;
            updatedLink.Id = id;
            _context.Entry(updatedLink).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(new
                {
                Action = "updated"
            });
        }

        // DELETE api/link/5
        [HttpDelete("{id}")]
        public ObjectResult DeleteLink(int id)
        {

            var Link = _context.Links.Find(id);
            if (Link != null)
            {
                _context.Links.Remove(Link);
                _context.SaveChanges();
            }
            return Ok(new
            {
                action = "deleted"
            });
        }
    }
}
