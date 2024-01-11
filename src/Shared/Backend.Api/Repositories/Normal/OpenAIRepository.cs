using Backend.Api.Apis.Normal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Repositories.Normal
{

    [Codelisk.GeneratorAttributes.GeneralAttributes.Registration.RegisterSingleton]
    public partial class OpenAIRepository : BaseAuthRepository<IOpenAiApi>, IOpenAIRepository
    {
        public OpenAIRepository(IAuthenticationService authenticationService, IBaseRepositoryProvider baseRepositoryProvider)
            : base(authenticationService, baseRepositoryProvider)
        {
        }
        public Task<string> AskQuestionAsync(string question)
        {
            return TryRequest(() => _repositoryApi.AskQuestion(question));
        }
        public Task AddUserInput(List<BaseConversationPart> baseConversationParts)
        {
            return JustSend(() => _repositoryApi.AddUserInput(baseConversationParts));
        }
    }
}
