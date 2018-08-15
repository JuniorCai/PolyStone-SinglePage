using System.Linq;
using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using Swashbuckle.Application;

namespace PolyStone.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(PolyStoneApplicationModule))]
    public class PolyStoneWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(PolyStoneApplicationModule).Assembly, "app")
                .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));

            //调用SwaggerUI
            ConfigureSwaggerUi();
        }

        private void ConfigureSwaggerUi()
        {
            Configuration.Modules.AbpWebApi().HttpConfiguration.EnableSwagger(
                c =>
                {
                    c.SingleApiVersion("v1", "PolyStone.PolyStoneWebApi");
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                }).EnableSwaggerUi();
        }
    }
}
