using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskManagerWeb.Models.Dto;
using TaskManagerWeb.Services;

namespace TaskManagerWeb.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskApiClient _client;

        public TasksController(TaskApiClient client)
        {
            _client = client;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("JwtToken")))
                context.Result = RedirectToAction("Login", "Account");

            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var tasks = await _client.GetTasksAsync();
                if(tasks==null)
                {
                    HttpContext.Session.Clear();
                    return RedirectToAction("Login", "Account");
                }
                return View(tasks);
            }
            catch (HttpRequestException)
            {
                return View(new List<TaskItemDto>());

            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTaskDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            var ok = await _client.CreateTaskAsync(dto);
            if (!ok)
            {
                ModelState.AddModelError("", "Could not create a task");
                return View(dto);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _client.GetTaskByIdAsync(id);
            if (task == null)
                return NotFound();
            var dto = new UpdateTaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsDone = task.IsDone
            };
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( UpdateTaskDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            var task = await _client.UpdateTaskAsync( dto);
            if (!task)
            {
                ModelState.AddModelError("", "Could not update the task");
                return View(dto);
            }

            return RedirectToAction("Index");
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _client.DeleteTaskAsync(id);
            if (!ok)
                TempData["Error"] = "Could not delete the task";
            return RedirectToAction("Index");

        }
    }
}
