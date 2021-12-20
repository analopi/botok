using BOT.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Bot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallbackController : Controller
    {
        private readonly IConfiguration _configuration;

        
        public CallbackController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // POST: CallbackController/Create
        [HttpPost]
        public IActionResult Callback([FromBody] Updates updates)
        {
            // Проверяем, что находится в поле "type"
            var webClient = new WebClient() { Encoding = Encoding.UTF8 };
            switch (updates.Type)
            {
                
                // Если это уведомление для подтверждения адреса
                case "confirmation":
                    // Отправляем строку для подтверждения 
                    return Ok("ae02c630");
                case "message_new":
                    //return Json(updates.Message);
                    return Content($"https://api.vk.com/method/messages.send?v=5.131&access_token=e954287faaa675dc6b387fe3ad1459ad89fba3235eaf0d02a4cd7dc2bdccd51c8881c0b23663593f22aca&user_id=70259283&message=тыеблан");
                    
                    
            }
            // Возвращаем "ok" серверу Callback API
            return Ok("ok");

        }
    }
}
