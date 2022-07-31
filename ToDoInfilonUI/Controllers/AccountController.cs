using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoInfilonUI.Repository.Interface;
using ToDoInfilonUI.ViewModels;

namespace ToDoInfilonUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                int userId = _accountRepository.IsUserAuthenticated(new Models.Login()
                {
                    Name = loginViewModel.Name,
                    Password = loginViewModel.Password
                });

                if (userId > 0)
                {
                    HttpContext.Session.SetString("IsAuthorized", "1");
                    HttpContext.Session.SetString("CurrentUserId", userId.ToString());

                    TempData["IsAuthorized"] = 1;
                    TempData["CurrentUserId"] = userId;
                    return RedirectToAction("index", "todo");
                }
                else
                {
                    HttpContext.Session.SetString("IsAuthorized", "0");
                    HttpContext.Session.SetString("CurrentUserId", userId.ToString());
                    ModelState.AddModelError(string.Empty, "Unauthorized");
                }
            }
            return View(loginViewModel);
        }
    }
}