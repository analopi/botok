using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallbackController : Controller
    {
        // GET: CallbackController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CallbackController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CallbackController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CallbackController/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            return Content("ae02c630");
        }

    }
}
