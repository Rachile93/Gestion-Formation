using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestionFormation.Controllers
{
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;

        public MessageController(ILogger<MessageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetMessageAlert(string message = "")
        {
            if (string.IsNullOrWhiteSpace(message))
                message = Guid.NewGuid().ToString();
            
            return PartialView("_Message", message);
        }
    }
}
