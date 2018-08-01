﻿using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using PolyStone.CustomDomain.CommunityCategories;


namespace PolyStone.CustomDomain.CommunityCategories.EntityMapper.CommunityCategories
{

    /// <summary>
    /// 圈子类别表的数据配置文件
    /// </summary>
    public class CommunityCategoryCfg : EntityTypeConfiguration<CommunityCategory>
    {
        /// <summary>
        ///  构造方法[默认链接字符串< see cref = "CustomDomainDbContext" /> ]
        /// </summary>
        public CommunityCategoryCfg()
        {
            ToTable("CommunityCategory", PolyStoneConsts.SchemaName.Basic);


            // 类别名称
            Property(a => a.CategoryName).HasMaxLength(50);
        }
    }
}