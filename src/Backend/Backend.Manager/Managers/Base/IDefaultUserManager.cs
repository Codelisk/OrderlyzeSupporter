using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Manager.Managers.Base
{
    public interface IDefaultUserManager<TDto, TKey, TEntity> : IDefaultManager<TDto, TKey, TEntity> where TDto : BaseBaseIdDto where TEntity : BaseBaseIdDto
    {
        Task<List<TDto>> GetCompletelyAll();
    }
}
