﻿
// 项目展示地址:"http://www.ddxc.org/"
 // 如果你有什么好的建议或者觉得可以加什么功能，请加QQ群：104390185大家交流沟通
// 项目展示地址:"http://www.yoyocms.com/"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>角落的白板笔</Author-作者>
// Copyright © YoYoCms@中国.2018-11-28T10:34:59. All Rights Reserved.
//<生成时间>2018-11-28T10:34:59</生成时间>
namespace PolyStone.CustomDomain.BusinessCard
{
	
			//TODO:Angular后端的导航栏目设计

	/*
	//无次级导航属性
	   var businessCard=new MenuItemDefinition(
                BusinessCardAppPermissions.BusinessCard,
                L("BusinessCard"),
				url:"businessCards",
				icon:"icon-grid",
					 				 requiredPermissionName: BusinessCardAppPermissions.BusinessCard
				  				);

*/
				//有下级菜单
            /*

			   var businessCard=new MenuItemDefinition(
                BusinessCardAppPermissions.BusinessCard,
                L("BusinessCard"),			
				icon:"icon-grid"				
				);

				businessCard.AddItem(
			new MenuItemDefinition(
			BusinessCardAppPermissions.BusinessCard,
			L("BusinessCard"),
			"icon-star",
			url:"businessCards",
			 			requiredPermissionName: BusinessCardAppPermissions.BusinessCard));
	

			
			*/
	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到CustomDomainApplicationModule
 //   Configuration.Authorization.Providers.Add<BusinessCardAppAuthorizationProvider>();
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/CustomDomainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 名片管理 -->
	    <text name="BusinessCard" value="名片" />
	    <text name="BusinessCardHeaderInfo" value="名片管理列表" />
		    <text name="CreateBusinessCard" value="新增名片" />
    <text name="EditBusinessCard" value="编辑名片" />
    <text name="DeleteBusinessCard" value="删除名片" />

	  
		

		    <text name="BusinessCardDeleteWarningMessage" value="名片名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="UserId" value="UserId" />
				 	<text name="WxNumber" value="WxNumber" />
				 	<text name="CompanyName" value="CompanyName" />
				 	<text name="Position" value="Position" />
				 	<text name="Introduction" value="Introduction" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/CustomDomain.xml
/*
    <!-- 名片english管理 -->
		    <text name="	BusinessCardHeaderInfo" value="名片List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="UserId" value="UserId" />
				 	<text name="WxNumber" value="WxNumber" />
				 	<text name="CompanyName" value="CompanyName" />
				 	<text name="Position" value="Position" />
				 	<text name="Introduction" value="Introduction" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="BusinessCard" value="ManagementBusinessCard" />
    <text name="CreateBusinessCard" value="CreateBusinessCard" />
    <text name="EditBusinessCard" value="EditBusinessCard" />
    <text name="DeleteBusinessCard" value="DeleteBusinessCard" />
*/




}