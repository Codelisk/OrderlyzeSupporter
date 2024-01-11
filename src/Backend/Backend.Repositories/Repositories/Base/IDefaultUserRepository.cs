using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Repositories.Repositories.Base;
using Supporter.Foundation.Dtos.Base;

namespace Backend.Repositories.Base
{
    public interface IDefaultUserRepository<TEntity, TKey> : IDefaultRepository<TEntity, TKey> where TEntity : BaseUserDto
    {
        Task<List<TEntity>> GetCompletelyAll();
    }
}
