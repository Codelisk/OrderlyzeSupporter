using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Repositories.Normal
{
    public interface IOpenAIRepository
    {
        Task AddUserInput(List<BaseConversationPart> baseConversationParts);
        Task<string> AskQuestionAsync(string question);
    }
}
