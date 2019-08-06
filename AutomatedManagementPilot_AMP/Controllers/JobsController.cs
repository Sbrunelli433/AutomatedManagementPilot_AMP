using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomatedManagementPilot_AMP.Data;
using AutomatedManagementPilot_AMP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutomatedManagementPilot_AMP.Controllers
{
    [Produces("application/json")]
    [Route("api/task")]
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/task
        [HttpGet]
        public IEnumerable<WebApiJob> Get()
        {
            return _context.Jobs
                .ToList()
                .Select(t => (WebApiJob)t);
        }

        // GET api/task/5
        [HttpGet("{id}")]
        public WebApiJob Get(int id)
        {
            return (WebApiJob)_context.Jobs.Find(id);
        }

        // POST api/task
        [Authorize(Roles = "Supervisor,Manager")]
        [HttpPost]
        public ObjectResult Post(WebApiJob apiJob)
        {
            var newJob = (Job)apiJob;
            
            newJob.SortOrder = _context.Jobs.Max(t => t.SortOrder) + 1;
            _context.Jobs.Add(newJob);
            _context.SaveChanges();
            return Ok(new
            {
                jid = newJob.Id,
                action = "inserted"
            });
        }

        // PUT api/task/5
        [Authorize(Roles = "Supervisor,Manager")]
        [HttpPut("{id}")]
        public ObjectResult Put(int id, WebApiJob apiJob)
        {
            var updatedJob = (Job)apiJob;
            var dbJob = _context.Jobs.Find(id);
            dbJob.Customer = updatedJob.Customer;
            dbJob.MachineId = updatedJob.MachineId;

            dbJob.Machine = updatedJob.Machine;
            dbJob.Employee = updatedJob.Employee;
            dbJob.EmployeeId = updatedJob.EmployeeId;

            dbJob.StartDate = updatedJob.StartDate;
            dbJob.Duration = updatedJob.Duration;
            dbJob.ParentId = updatedJob.ParentId;
            dbJob.Progress = updatedJob.Progress;
            dbJob.Type = updatedJob.Type;

            if (!string.IsNullOrEmpty(apiJob.target))
            {
                //reordering occurred
                this._UpdateOrders(dbJob, apiJob.target);
            }

            _context.SaveChanges();
            return Ok(new
            {
                action = "updated"
            });
        }

        // DELETE api/task/5
        [Authorize(Roles = "Supervisor,Manager")]
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

        //UPDATE api/task
        [Authorize(Roles = "Supervisor,Manager")]
        private void _UpdateOrders(Job updatedJob, string orderTarget)
        {
            int adjacentJobId;
            var nextSibling = false;

            var targetId = orderTarget;

            // adjacent job id is sent either as '{id}' or as 'next:{id}' depending 
            // on whether it's the next or the previous sibling
            if (targetId.StartsWith("next:"))
            {
                targetId = targetId.Replace("next:", "");
                nextSibling = true;
            }

            if (!int.TryParse(targetId, out adjacentJobId))
            {
                return;
            }

            var adjacentJob = _context.Jobs.Find(adjacentJobId);
            var startOrder = adjacentJob.SortOrder;

            if (nextSibling)
                startOrder++;

            updatedJob.SortOrder = startOrder;

            var updateOrders = _context.Jobs
                .Where(t => t.Id != updatedJob.Id)
                .Where(t => t.SortOrder >= startOrder)
                .OrderBy(t => t.SortOrder);

            var jobList = updateOrders.ToList();

            jobList.ForEach(t => t.SortOrder++);
        }
    }
}
