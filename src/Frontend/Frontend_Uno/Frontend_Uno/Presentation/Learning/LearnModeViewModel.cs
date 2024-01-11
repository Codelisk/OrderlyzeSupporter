using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Api;
using BaseServicesModule.Services.Vms;
using Frontend_Uno.Services;
using ReactiveUI;
using Supporter.Foundation.Dtos;

namespace Frontend_Uno.Presentation.Learning;
public class LearnModeViewModel : RegionBaseViewModel
{
    private readonly IOrderlyzeChatService orderlyzeChatService;
    private readonly ICorrectConversationPartRepository correctConversationPartRepository;

    public LearnModeViewModel(IOrderlyzeChatService orderlyzeChatService,
        VmServices vmServices,
        Func<ICorrectConversationPartRepository> correctConversationPartRepository) : base(vmServices)
    {
        this.orderlyzeChatService = orderlyzeChatService;
        this.correctConversationPartRepository = correctConversationPartRepository();

        LoadConversationsAsync();
    }

    public ICommand SendCommand => this.LoadingCommand(async () => await OnSendAsync());

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

    public List<CorrectConversationPartDto> Conversations { get; set; }
    private async Task LoadConversationsAsync()
    {
        Conversations = (await this.correctConversationPartRepository.GetAll()).ToList();
        Conversations.Reverse();
        this.RaisePropertyChanged(nameof(Conversations));
    }
    private async Task OnSendAsync()
    {
        IsBusy = true;
        await correctConversationPartRepository.Add(new CorrectConversationPartDto() { Question = Question, Answer = Answer  });

        Question = null;
        Answer = null;

        IsBusy = false;
        //var result = await this.orderlyzeChatService.AddMessageAsync(Message);
    }
}
