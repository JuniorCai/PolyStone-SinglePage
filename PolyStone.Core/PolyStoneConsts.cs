﻿namespace PolyStone
{
    public class PolyStoneConsts
    {
        public const string LocalizationSourceName = "PolyStone";

        public const bool MultiTenancyEnabled = true;

        /// <summary>
        /// 显示名称的最大长度
        /// </summary>
        public const int MaxDisplayNameLength = 64;

        /// <summary>
        /// 用户名的最大长度
        /// </summary>
        public const int MaxUserNameLength = 32;

        /// <summary>
        /// 默认分页大小
        /// </summary>
        public const int DefaultPageSize = 20;

        /// <summary>
        /// 最大分页大小
        /// </summary>
        public const int MaxPageSize = int.MaxValue;

        /// <summary>
        /// 数据库架构名
        /// </summary>
        public static class SchemaName
        {
            /// <summary>
            /// 基础设置
            /// </summary>
            public const string Basic = "";

            /// <summary>
            /// 模块管理
            /// </summary>
            public const string Moudle = "Moudle";

            /// <summary>
            /// 网站设置
            /// </summary>
            public const string WebSetting = "WebSetting";
            /// <summary>
            /// 用于对多对表关系的结构
            /// </summary>
            public const string HasMany = "HasMany";

            /// <summary>
            /// 业务
            /// </summary>
            public const string Business = "Business";

        }
    }
}