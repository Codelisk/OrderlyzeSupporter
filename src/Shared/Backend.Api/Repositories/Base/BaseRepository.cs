using Codelisk.GeneratorAttributes.WebAttributes.HttpMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Api.Repositories.Base
{
    public abstract class BaseRepository<TApi> where TApi : IBaseApi
    {
        protected readonly TApi _repositoryApi;

        private readonly ILogger _logger;
        private readonly IBaseRepositoryProvider _baseRepositoryProvider;

        protected BaseRepository(IBaseRepositoryProvider baseRepositoryProvider)
        {
            _repositoryApi = baseRepositoryProvider.GetApiBuilder().BuildRestService<TApi>(GetAuthorizationHeaderValueAsync);
            _logger = baseRepositoryProvider.GetLogger();

            _baseRepositoryProvider = baseRepositoryProvider;
        }


        /// <summary>
        /// Here we provide the Auth token for requests
        /// </summary>
        /// <returns>Current access token</returns>
        protected virtual Task<string> GetAuthorizationHeaderValueAsync(HttpRequestMessage message, CancellationToken token)
        {
            return Task.FromResult(_baseRepositoryProvider.GetTokenProvider().GetCurrentAccessToken());
        }

        /// <summary>
        /// Do an apu request with Try catch logic and resiciance policy
        /// </summary>
        /// <typeparam name="T">Result type</typeparam>
        /// <param name="func">Api request function</param>
        /// <param name="defaultValue">Default value</param>
        /// <returns>Request result or default value when exception handle</returns>
        [Save]
        [Add]
        [Codelisk.GeneratorAttributes.WebAttributes.HttpMethod.Get]
        [GetLast]
        [GetAll]
        [GetFull]
        [GetAllFull]
        protected virtual async Task<T> TryRequest<T>(Func<Task<T>> func, T defaultValue = default(T))
        {
            return await func().ConfigureAwait(false);
        }

        [Codelisk.GeneratorAttributes.WebAttributes.HttpMethod.Delete]
        [AddRange]
        protected virtual Task JustSend(Func<Task> task)
        {
            return task.Invoke();
        }
    }
}
