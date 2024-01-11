using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Apis.Normal
{
    public interface IOpenAiApi : IBaseApi
    {
        [Post("/OpenAI/AskQuestion")]
        Task<string> AskQuestion(string question);

        [Post("/OpenAI/AddUserInput")]
        Task AddUserInput(List<BaseConversationPart> baseConversationParts);
    }
}
