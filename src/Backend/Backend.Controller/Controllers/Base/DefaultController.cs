using Backend.Manager.Managers.Base;
using Codelisk.GeneratorAttributes.WebAttributes.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Controller.Controllers.Base
{
    [DefaultController]
    [Authorize]
    [Route("[controller]")]
    [Produces("application/json")]
    public class DefaultController<T, TKey, TEntity> : Microsoft.AspNetCore.Mvc.Controller
        where T : BaseBaseIdDto
        where TEntity : BaseBaseIdDto
        where TKey : IComparable
    {
        protected readonly IDefaultManager<T, TKey, TEntity> _manager;

        public DefaultController(IDefaultManager<T, TKey, TEntity> manager)
        {
            _manager = manager;
        }
    }
}
