using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoInfilonUI.Models.DB;
using ToDoInfilonUI.Repository.Interface;
using ToDoInfilonUI.ViewModels;

namespace ToDoInfilonUI.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public IActionResult Index()
        {
            List<ToDoViewModel> models = new List<ToDoViewModel>();
            if(int.TryParse(HttpContext.Session.GetString("CurrentUserId").ToString(), out int id) && id > 0)
            {
                var dlModels = _toDoRepository.GetToDos(id);

                if (dlModels.Any())
                {
                    dlModels.ForEach(x =>
                    {
                        models.Add(new ToDoViewModel()
                        {
                            Id = x.Id,
                            UserId = x.UserId,
                            Title = x.Title,
                            Completed = x.Completed
                        });
                    });
                }
            }
            return View(models);
        }

        [HttpGet]
        public IActionResult Edit(int itemId)
        {
            var item = _toDoRepository.GetItem(itemId);
            var model = new ToDoViewModel()
            {
                Id = item.Id,
                UserId = item.UserId,
                Title = item.Title,
                Completed = item.Completed
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int itemId, ToDoViewModel model)
        {
            if (ModelState.IsValid)
            {
                ToDo toDo = new ToDo()
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    Title = model.Title,
                    Completed = false,
                    UpdateDate = DateTime.UtcNow
                };
                _toDoRepository.UpdateItem(toDo);
                return RedirectToAction("index");
            }
            return View();
        }
    }
}