using ApplicationCheikh.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelegramController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public TelegramController(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] TelegramUserViewModel user)
        {
            var botToken = _config["Telegram:BotToken"];
            var chatId = _config["Telegram:GroupChatId"];

            var message = $"👤 *Nouvelle demande d'entretien* :\n" +
                          $"- Nom : {user.LastName}\n" +
                          $"- Prénom : {user.FirstName}\n" +
                          $"- Email : {user.mail}\n" +
                          $"- Téléphone : {user.PhoneNumbber}";

            var url = $"https://api.telegram.org/bot{botToken}/sendMessage";

            var payload = new Dictionary<string, string>
        {
            { "chat_id", chatId },
            { "text", message },
            { "parse_mode", "Markdown" }
        };

            var response = await _httpClient.PostAsync(url, new FormUrlEncodedContent(payload));

            if (response.IsSuccessStatusCode)
                return Ok("Message envoyé");
            else
                return StatusCode((int)response.StatusCode, "Erreur Telegram");
        }
    }
}
