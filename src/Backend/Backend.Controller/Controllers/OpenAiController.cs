using Backend.Controller.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Controller.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [Produces("application/json")]
    public class OpenAiController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IOrderlyzeChatService _orderlyzeChatService;

        public OpenAiController(IOrderlyzeChatService orderlyzeChatService)
        {
            _orderlyzeChatService = orderlyzeChatService;
        }
        [Microsoft.AspNetCore.Mvc.HttpPost("AskQuestion")]
        public async Task<string> AskQuestion(string question)
        {
            _orderlyzeChatService.StartChat();
            return await _orderlyzeChatService.AddMessageAsync(question);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost("AddUserInput")]
        public async Task AddUserInput([FromBody] List<BaseConversationPart> baseConversationParts)
        {
            _orderlyzeChatService.AddUserInput(baseConversationParts);
        }
    }
}
