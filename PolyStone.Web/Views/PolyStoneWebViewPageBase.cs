using Abp.Web.Mvc.Views;

namespace PolyStone.Web.Views
{
    public abstract class PolyStoneWebViewPageBase : PolyStoneWebViewPageBase<dynamic>
    {

    }

    public abstract class PolyStoneWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected PolyStoneWebViewPageBase()
        {
            LocalizationSourceName = PolyStoneConsts.LocalizationSourceName;
        }
    }
}