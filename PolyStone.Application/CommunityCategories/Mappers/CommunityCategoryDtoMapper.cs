using AutoMapper;



namespace PolyStone.CommunityCategories.Mappers
{
    /// <summary>
    /// CommunityCategoryDto映射配置
    /// </summary>
    public class CommunityCategoryDtoMapper
    {

        private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();



        /// <summary>
        /// 初始化映射
        /// </summary>
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {

            lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }

                CreateMappingsInternal(configuration);

                _mappedBefore = true;
            }

        }





        /// <summary>
        ///    Configuration.Modules.AbpAutoMapper().Configurators.Add(CommunityCategoryDtoMapper.CreateMappings);
        ///注入位置    < see cref = "CustomDomainApplicationModule" /> 
        /// <param name="configuration"></param>
        /// </summary>       
        private static void CreateMappingsInternal(IMapperConfigurationExpression configuration)
        {

            //默认ABP功能已经实现了，如果你要单独对DTO进行拓展，可以在此处放开注释文件。

            // Configuration.Modules.AbpAutoMapper().Configurators.Add(CommunityCategoryDtoMapper.CreateMappings);

            //    Mapper.CreateMap<CommunityCategory,CommunityCategoryEditDto>();
            //     Mapper.CreateMap<CommunityCategory, CommunityCategoryListDto>();

            //       Mapper.CreateMap<CommunityCategoryEditDto, CommunityCategory>();
            //        Mapper.CreateMap<CommunityCategoryListDto,CommunityCategory>();


        }


    }
}