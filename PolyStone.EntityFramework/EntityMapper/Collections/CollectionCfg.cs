using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using PolyStone.CustomDomain.Collections;
using PolyStone.EntityFramework;


namespace PolyStone.CustomDomain.Collections.EntityMapper.Collections
{

    /// <summary>
    /// 用户收藏的数据配置文件
    /// </summary>
    public class CollectionCfg : EntityTypeConfiguration<Collection>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "PolyStoneDbContext" /> ]
        /// </summary>
        public CollectionCfg()
        {
            ToTable("Collection", PolyStoneConsts.SchemaName.Basic);

            //todo: 需要将以下文件注入到CustomDomainDbContext中

            //		public IDbSet<Collection> Collections { get; set; }
            //		 modelBuilder.Configurations.Add(new CollectionCfg());




            // Name
            Property(a => a.Name).HasMaxLength(200);
        }
    }
}