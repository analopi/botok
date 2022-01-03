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
using System.Net.Http;
using Microsoft.AspNetCore.Http.Extensions;

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

            //var cl = new WebClient { Encoding = Encoding.UTF8 };
            // Проверяем, что находится в поле "type"
            switch (updates.Type)
            {

                // Если это уведомление для подтверждения адреса
                case "confirmation":
                    // Отправляем строку для подтверждения 
                    return Ok("ae02c630");
                case "message_new":
                    //var ID = updates.Object["message"]["from_id"].ToString();
                    //var rand = updates.Object["message"]["random_id"].ToString();
                    //var ms = $"Ваш Id равен {ID}";
                    //return Json(updates.Object);
                    //return Content($"https://api.vk.com/method/messages.send?v=5.131&access_token=e954287faaa675dc6b387fe3ad1459ad89fba3235eaf0d02a4cd7dc2bdccd51c8881c0b23663593f22aca&user_id=70259283&message=тыеблан&random_id=1");
                    //cl.DownloadString($"https://api.vk.com/method/messages.send?v=5.131&access_token=e954287faaa675dc6b387fe3ad1459ad89fba3235eaf0d02a4cd7dc2bdccd51c8881c0b23663593f22aca&user_id={ID}&message={ms}&random_id={rand}");

                    this.poshel();
                    return Ok("ok");

            }
            // Возвращаем "ok" серверу Callback API
            return Ok("ok");

        }
        public async void poshel()
        {
          
            var client = new HttpClient();
           

            string l = "v=5.131&access_token=e954287faaa675dc6b387fe3ad1459ad89fba3235eaf0d02a4cd7dc2bdccd51c8881c0b23663593f22aca&random_id=0&user_id=70259283&message=123";
            var p = await client.PostAsync($"https://api.vk.com/method/messages.send?", new StringContent(l, Encoding.UTF8, "application/x-www-form-urlencoded"));
        }

    }
}
