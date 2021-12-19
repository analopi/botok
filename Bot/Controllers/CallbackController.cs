using BOT.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            switch (updates.Type)
            {
                // Если это уведомление для подтверждения адреса
                case "confirmation":
                    // Отправляем строку для подтверждения 
                    return Ok("ae02c630");
                case "message_new":
                    var col = updates.Object;
                    string token = _configuration["Config:AccessToken"];
                    string urlresp = $"https://api.vk.com/method/messages.send?v=5.131&access_token={token}&user_id=";
                    string msg = col["message"]["body"].ToString();
                    var ready = (urlresp + "{0}&message={1}",col["message"]["from_id"].ToString(),$"Ну привет ботяра");
                    if (msg == "Привет")
                        return Ok(ready);
                    else return (null);
            }
            // Возвращаем "ok" серверу Callback API
            return Ok("ok");

        }
    }
}
