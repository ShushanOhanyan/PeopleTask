using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using People.Data;
using People.Models;

namespace People.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;
        

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;


        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            _userRepository.AddUser(user);
            ModelState.Clear();
            return View(new User());
        }

        public IActionResult Edit(int id)
        {
           
            List<User> users = _userRepository.GetAllUsers().ToList();
            var user = users.FirstOrDefault(e => e.Id == id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            _userRepository.EditUser(user);

            return View(user);
        }

        public IActionResult AllUsers()
        {
            List<User> users = _userRepository.GetAllUsers().ToList();


            return View(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
