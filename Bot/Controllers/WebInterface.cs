using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ChatBotLaundry.Controllers;
using System.Net.Http;
using System.Text;

namespace ChatBotLaundry.Controllers
{
    static public class WebInterface
    {
        static public async void poshel(string content)
        {
            var client = new HttpClient();
            var p = await client.PostAsync($"https://api.vk.com/method/messages.send?", new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded"));
        }
        static public void SendButtons(long id, string message, List<List<(string, string)>> buttons)
        {
            string nuts = "\\";
            StringBuilder content = new StringBuilder(@"{ ""one_time"":false, ""buttons"": [[");
            for (int i = 0; i < buttons.Count; ++i)
            {
                for (int j = 0; j < buttons[i].Count; j++)
                {
                    content.Append($"{{ \"action\": {{ \"type\": \"text\", \"payload\": \"{{{nuts}\"button{nuts}\": {nuts}\"{buttons[i][j].Item2}{nuts}\"}}\", \"label\": \"{buttons[i][j].Item1}\"}}, \"color\": \"secondary\" }},");
                    j++;
                    if (j == buttons[i].Count) content.Remove(content.Length - 1, 1);
                    else j--;
                }
                i++;
                if (i==buttons.Count) break;
                else i--;
                content.Append("],[");
            }
            content.Append("]]}");
            content.ToString();
            id.ToString();
            string alpha = $"v=5.131&access_token=e954287faaa675dc6b387fe3ad1459ad89fba3235eaf0d02a4cd7dc2bdccd51c8881c0b23663593f22aca&random_id=0&user_id={id}&message={message}&keyboard={content}";
            Console.WriteLine(alpha);
            poshel(alpha);
        }


        static public void SendMessage(long id, string message)
        {
            id.ToString();
            var content = $"v=5.131&access_token=e954287faaa675dc6b387fe3ad1459ad89fba3235eaf0d02a4cd7dc2bdccd51c8881c0b23663593f22aca&random_id=0&user_id={id}&message={message}";
            poshel(content);
        }
    }
}
