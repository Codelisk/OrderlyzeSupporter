using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supporter.Foundation.Dtos;

namespace Frontend_Uno.Services;
public interface IOrderlyzeChatService
{
    Task<string> AddMessageAsync(string message);
    void AddUserInput(List<BaseConversationPart> baseConversationParts);
    void StartChat();
}
