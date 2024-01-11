using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Azure;
using Supporter.Foundation.Dtos;

namespace Frontend_Uno.Services;
internal class OrderlyzeChatService : IOrderlyzeChatService
{
    private readonly OpenAIClient openAIClient;

    public OrderlyzeChatService(OpenAIClient openAIClient)
    {
        this.openAIClient = openAIClient;
    }

    ChatCompletionsOptions completionsOptions;
    public void StartChat()
    {
        if(completionsOptions != null)
        {
            return;
        }
        completionsOptions = new();
        completionsOptions.DeploymentName = "gpt-3.5-turbo";
        completionsOptions.Messages.Add(new ChatRequestSystemMessage("Ich spreche deutsch. Ich bin spezialisiert auf Support für das Orderlyze Kassensystem. (www.orderlyze.com)"));
        completionsOptions.Messages.Add(new ChatRequestSystemMessage("Ich prioritisiere Antworten die mir am schluss manuell mitgegeben worden sind mehr und schaue zuerst auf sie."));
        completionsOptions.MaxTokens = 150;
        completionsOptions.Temperature = 0.3f;
    }

    public void AddUserInput(List<BaseConversationPart> baseConversationParts)
    {
        StartChat();
        foreach (var item in baseConversationParts)
        {
            completionsOptions.Messages.Add(new ChatRequestUserMessage(item.Question) { Name = "Orderlyze" });
            completionsOptions.Messages.Add(new ChatRequestAssistantMessage(item.Answer) { Name="Orderlyze" });
        }
    }

    public async Task<string> AddMessageAsync(string message)
    {
        completionsOptions.Messages.Add(new ChatRequestUserMessage(message));
        // Asynchronously getting chat completions from an AI client
        Response<ChatCompletions> completions = await openAIClient.GetChatCompletionsAsync(completionsOptions);
        if (completions.Value.Choices.Count == 0)
        {
            return null;
        }

        List<string> result = new();
        int i = 0;
        // Iterating through the available choices
        foreach (ChatChoice choice in completions.Value.Choices)
        {
            // Extracting the content of the message
            string content = choice.Message.Content;

            completionsOptions.Messages.Add(new ChatRequestAssistantMessage(content));
            content = $"Version {i}:\n" + content;
            result.Add(content);
            i++;
        }

        return string.Join("\n,\n",result);
    }
}
