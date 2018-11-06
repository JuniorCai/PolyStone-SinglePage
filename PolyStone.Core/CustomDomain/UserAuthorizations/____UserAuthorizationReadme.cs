
namespace PolyStone.CustomDomain.UserAuthorizations
{
	
			//TODO:Angular后端的导航栏目设计

	/*
	//无次级导航属性
	   var userAuthorization=new MenuItemDefinition(
                UserAuthorizationAppPermissions.UserAuthorization,
                L("UserAuthorization"),
				url:"userAuthorizations",
				icon:"icon-grid",
					 				 requiredPermissionName: UserAuthorizationAppPermissions.UserAuthorization
				  				);

*/
				//有下级菜单
            /*

			   var userAuthorization=new MenuItemDefinition(
                UserAuthorizationAppPermissions.UserAuthorization,
                L("UserAuthorization"),			
				icon:"icon-grid"				
				);

				userAuthorization.AddItem(
			new MenuItemDefinition(
			UserAuthorizationAppPermissions.UserAuthorization,
			L("UserAuthorization"),
			"icon-star",
			url:"userAuthorizations",
			 			requiredPermissionName: UserAuthorizationAppPermissions.UserAuthorization));
	

			
			*/
	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到CustomDomainApplicationModule
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/CustomDomainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 用户第三方绑定管理 -->
	    <text name="UserAuthorization" value="用户第三方绑定" />
	    <text name="UserAuthorizationHeaderInfo" value="用户第三方绑定管理列表" />
		    <text name="CreateUserAuthorization" value="新增用户第三方绑定" />
    <text name="EditUserAuthorization" value="编辑用户第三方绑定" />
    <text name="DeleteUserAuthorization" value="删除用户第三方绑定" />

	  
		

		    <text name="UserAuthorizationDeleteWarningMessage" value="用户第三方绑定名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="OpenId" value="第三方唯一标识" />
				 	<text name="UserId" value="用户ID" />
				 	<text name="ThirdName" value="第三方名称" />
				 	<text name="IsActive" value="是否启用" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/CustomDomain.xml
/*
    <!-- 用户第三方绑定english管理 -->
		    <text name="	UserAuthorizationHeaderInfo" value="用户第三方绑定List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="OpenId" value="第三方唯一标识" />
				 	<text name="UserId" value="用户ID" />
				 	<text name="ThirdName" value="第三方名称" />
				 	<text name="IsActive" value="是否启用" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="UserAuthorization" value="ManagementUserAuthorization" />
    <text name="CreateUserAuthorization" value="CreateUserAuthorization" />
    <text name="EditUserAuthorization" value="EditUserAuthorization" />
    <text name="DeleteUserAuthorization" value="DeleteUserAuthorization" />
*/




}