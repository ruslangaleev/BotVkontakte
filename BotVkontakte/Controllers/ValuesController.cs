using BotVkontakte.ResourceModels;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BotVkontakte.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly string _secret = "qwe123rty456";

        private readonly string _token = "cc7ba246021002b1a046b952328d992fceb8d72de64da45d491ec3215afd9c331096e5b5d5fac94a29289";

        private readonly static HttpClient _httpClient = new HttpClient();

        // POST api/values
        [HttpPost]
        public async Task<object> Post([FromBody]Message message)
        {
            if (message.Type == "confirmation")
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent("f220d178", Encoding.UTF8, "text/plain");
                return response;
            }

            if (message.Secret != _secret)
            {
                return BadRequest("Не верный секретный ключ.");
            }

            if (message.Type == "message_new")
            {
                string responseMessage = "Привет, я бот. Чем могу помочь?";

                var request = $"https://api.vk.com/method/messages.send?user_id={message.ObjectMessage.UserId}&group_id={message.GroupId}&message={responseMessage}&v=5.80&access_token={_token}";

                await _httpClient.GetAsync(request);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent("ok", Encoding.UTF8, "text/plain");
                return response;
            }

            return BadRequest("тип события не распознан.");
        }
    }
}
