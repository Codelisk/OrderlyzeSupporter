using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Api;
using Backend.Api.Repositories.Normal;
using BaseServicesModule.Services.Vms;
using Frontend_Uno.Services;
using ReactiveUI;
using Supporter.Foundation.Dtos;

namespace Frontend_Uno.Presentation.Asking;
public partial class AskingModeViewModel : RegionBaseViewModel
{
    private readonly IOpenAIRepository openAIRepository;
    private readonly IAiConversationPartRepository aiConversationPartRepository;
    private readonly ICorrectConversationPartRepository correctConversationPartRepository;

    public AskingModeViewModel(
        IOpenAIRepository openAIRepository,
        VmServices vmServices,
        IAiConversationPartRepository aiConversationPartRepository,
        ICorrectConversationPartRepository correctConversationPartRepository) : base(vmServices)
    {
        this.openAIRepository = openAIRepository;
        this.aiConversationPartRepository = aiConversationPartRepository;
        this.correctConversationPartRepository = correctConversationPartRepository;
    }

    public ICommand AskCommand => this.LoadingCommand(async () => await OnAskAsync());
    public ICommand SaveCommand => this.LoadingCommand(async () => await OnSaveAsync());

    private string question;
    public string Question
    {
        get { return question; }
        set { this.RaiseAndSetIfChanged(ref question, value); }
    }

    private string answer;
    public string Answer
    {
        get { return answer; }
        set { this.RaiseAndSetIfChanged(ref answer, value); }
    }

    private async Task OnAskAsync()
    {
        this.IsBusy = true;
        this.Answer = await this.openAIRepository.AskQuestionAsync(Question);
        await this.aiConversationPartRepository.Add(new AiConversationPartDto() { Question = Question, Answer = Answer });
        this.IsBusy = false;
    }
    private async Task OnSaveAsync()
    {
        await correctConversationPartRepository.Add(new CorrectConversationPartDto() { Question = Question, Answer = Answer });
        Answer = null;
        Question = null;
        //var result = await this.orderlyzeChatService.AddMessageAsync(Message);
    }
    public override async Task InitializeAsync(NavigationContext navContext)
    {
        await base.InitializeAsync(navContext);
        var conversations = await correctConversationPartRepository.GetAll();

        await openAIRepository.AddUserInput(conversations.Select(x => x as BaseConversationPart).ToList());
    }
}
