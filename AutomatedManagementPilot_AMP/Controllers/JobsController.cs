using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomatedManagementPilot_AMP.Data;
using AutomatedManagementPilot_AMP.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutomatedManagementPilot_AMP.Controllers
{
    [Produces("application/json")]
    [Route("api/job")]
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<WebApiJob> Get()
        {
            return _context.Jobs
                .ToList()
                .Select(t => (WebApiJob)t);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public WebApiJob Get(int id)
        {
            return (WebApiJob)_context.Jobs.Find(id);
        }

        // POST api/job
        [HttpPost]
        public ObjectResult Post(WebApiJob apiJob)
        {
            var newJob = (Job)apiJob;
            _context.Jobs.Add(newJob);
            _context.SaveChanges();
            return Ok(new
            {
                jid = newJob.Id,
                action = "inserted"
            });
        }

        // PUT api/job/5
        [HttpPut("{id}")]
        public ObjectResult Put(int id, WebApiJob apiJob)
        {
            var updatedJob = (Job)apiJob;
            var dbJob = _context.Jobs.Find(id);
            dbJob.Text = updatedJob.Text;
            dbJob.StartDate = updatedJob.StartDate;
            dbJob.Duration = updatedJob.Duration;
            dbJob.ParentId = updatedJob.ParentId;
            dbJob.Progress = updatedJob.Progress;
            dbJob.Type = updatedJob.Type;

            _context.SaveChanges();
            return Ok(new
            {
                action = "updated"
            });
        }

        // DELETE api/job/5
        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            var job = _context.Jobs.Find(id);
            if (job!=null)
            {
                _context.Jobs.Remove(job);
                _context.SaveChanges();
            }
            return Ok(new
            {
                action = "deleted"
            });
        }
    }
}
