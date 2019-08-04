//using Kendo.Mvc.Examples.Models.Gantt;
//using Kendo.Mvc.Extensions;
//using Kendo.Mvc.UI;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Kendo.Mvc.Examples.Controllers
//{
//    public partial class GanttController : Controller
//    {
//        private IGanttTaskService taskService;
//        private IGanttDependencyService dependencyService;
//        private IGanttAssignmentService assignmentService;
//        private IGanttResourceService resourceService;

//        public GanttController(
//            IGanttTaskService ganttTaskService,
//            IGanttDependencyService ganttDependencyService,
//            IGanttResourceService ganttResourceService,
//            IGanttAssignmentService ganttAssignmentService)
//        {
//            taskService = ganttTaskService;
//            dependencyService = ganttDependencyService;
//            resourceService = ganttResourceService;
//            assignmentService = ganttAssignmentService;
//        }

//        [Demo]
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public virtual JsonResult ReadTasks([DataSourceRequest] DataSourceRequest request)
//        {
//            return Json(taskService.GetAll().ToDataSourceResult(request));
//        }

//        public virtual JsonResult DestroyTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
//        {
//            if (ModelState.IsValid)
//            {
//                taskService.Delete(task, ModelState);
//            }

//            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
//        }

//        public virtual JsonResult CreateTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
//        {
//            if (ModelState.IsValid)
//            {
//                taskService.Insert(task, ModelState);
//            }

//            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
//        }

//        public virtual JsonResult UpdateTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
//        {
//            if (ModelState.IsValid)
//            {
//                taskService.Update(task, ModelState);
//            }

//            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
//        }

//        public virtual JsonResult ReadDependencies([DataSourceRequest] DataSourceRequest request)
//        {
//            return Json(dependencyService.GetAll().ToDataSourceResult(request));
//        }

//        public virtual JsonResult DestroyDependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel dependency)
//        {
//            if (ModelState.IsValid)
//            {
//                dependencyService.Delete(dependency);
//            }

//            return Json(new[] { dependency }.ToDataSourceResult(request, ModelState));
//        }

//        public virtual JsonResult CreateDependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel dependency)
//        {
//            if (ModelState.IsValid)
//            {
//                dependencyService.Insert(dependency);
//            }

//            return Json(new[] { dependency }.ToDataSourceResult(request, ModelState));
//        }
//    }
//}