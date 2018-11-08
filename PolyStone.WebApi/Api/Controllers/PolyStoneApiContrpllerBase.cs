using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.IdentityFramework;
using Abp.UI;
using Abp.WebApi.Controllers;
using Microsoft.AspNet.Identity;

namespace PolyStone.Api.Controllers
{
    
    public abstract class PolyStoneApiControllerBase : AbpApiController
    {
        protected PolyStoneApiControllerBase()
        {
            LocalizationSourceName = PolyStoneConsts.LocalizationSourceName;
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }

}
