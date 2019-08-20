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
    [Route("api/task")]
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/task
        [HttpGet]
        public IEnumerable<WebApiTask> Get()
        {
            return _context.Tasks
                .ToList()
                .Select(t => (WebApiTask)t);
        }

        // GET api/task/5
        [HttpGet("{id}")]
        public WebApiTask Get(int id)
        {
            return (WebApiTask)_context
                .Tasks
                .Find(id);
        }

        // POST api/task
        [HttpPost]
        public IActionResult Post(WebApiTask apiTask)
        {
            var newTask = (Models.Task)apiTask;

            newTask.SortOrder = _context.Tasks.Max(t => t.SortOrder) + 1;
            _context.Tasks.Add(newTask);
            _context.SaveChanges();

            return Ok(new
            {
                tid = newTask.Id,
                action = "inserted"
            });
        }

        // PUT api/task/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, WebApiTask apiTask)
        {
            var updatedTask = (Models.Task)apiTask;
            var dbTask = _context.Tasks.Find(id);
            dbTask.Text = updatedTask.Text;
            dbTask.StartDate = updatedTask.StartDate;
            dbTask.Duration = updatedTask.Duration;
            dbTask.ParentId = updatedTask.ParentId;
            dbTask.Progress = updatedTask.Progress;
            dbTask.Type = updatedTask.Type;
            dbTask.SortOrder = updatedTask.SortOrder;
            dbTask.Description = updatedTask.Description;
            dbTask.Machine = updatedTask.Machine;
            dbTask.Customer = updatedTask.Customer;
            dbTask.Employee = updatedTask.Employee;
            dbTask.PartName = updatedTask.PartName;

            if (!string.IsNullOrEmpty(apiTask.target))
            {
                //reordering occurred
                this._UpdateOrders(dbTask, apiTask.target);
            }

            _context.SaveChanges();

            return Ok(new
            {
                action = "updated"
            });
        }

        // DELETE api/task/5
        [HttpDelete("{id}")]
        public ObjectResult DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }

            return Ok(new
            {
                action = "deleted"
            });
        }


        private void _UpdateOrders(Models.Task updatedTask, string orderTarget)
        {
            int adjacentTaskId;
            var nextSibling = false;

            var targetId = orderTarget;

            // adjacent task id is sent either as '{id}' or as 'next:{id}' depending 
            // on whether it's the next or the previous sibling
            if (targetId.StartsWith("next:"))
            {
                targetId = targetId.Replace("next:", "");
                nextSibling = true;
            }

            if (!int.TryParse(targetId, out adjacentTaskId))
            {
                return;
            }

            var adjacentTask = _context.Tasks.Find(adjacentTaskId);
            var startOrder = adjacentTask.SortOrder;

            if (nextSibling)
                startOrder++;

            updatedTask.SortOrder = startOrder;

            var updateOrders = _context.Tasks
                .Where(t => t.Id != updatedTask.Id)
                .Where(t => t.SortOrder >= startOrder)
                .OrderBy(t => t.SortOrder);

            var taskList = updateOrders.ToList();

            taskList.ForEach(t => t.SortOrder++);
        }

    }
}
