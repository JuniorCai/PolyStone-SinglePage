
namespace PolyStone.CustomDomain.UserVerifies
{
	
			//TODO:Angular后端的导航栏目设计

	/*
	//无次级导航属性
	   var userVerify=new MenuItemDefinition(
                UserVerifyAppPermissions.UserVerify,
                L("UserVerify"),
				url:"userVerifys",
				icon:"icon-grid",
					 				 requiredPermissionName: UserVerifyAppPermissions.UserVerify
				  				);

*/
				//有下级菜单
            /*

			   var userVerify=new MenuItemDefinition(
                UserVerifyAppPermissions.UserVerify,
                L("UserVerify"),			
				icon:"icon-grid"				
				);

				userVerify.AddItem(
			new MenuItemDefinition(
			UserVerifyAppPermissions.UserVerify,
			L("UserVerify"),
			"icon-star",
			url:"userVerifys",
			 			requiredPermissionName: UserVerifyAppPermissions.UserVerify));
	

			
			*/
	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到CustomDomainApplicationModule
 //   Configuration.Authorization.Providers.Add<UserVerifyAppAuthorizationProvider>();
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/CustomDomainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 用户验证码管理 -->
	    <text name="UserVerify" value="用户验证码" />
	    <text name="UserVerifyHeaderInfo" value="用户验证码管理列表" />
		    <text name="CreateUserVerify" value="新增用户验证码" />
    <text name="EditUserVerify" value="编辑用户验证码" />
    <text name="DeleteUserVerify" value="删除用户验证码" />

	  
		

		    <text name="UserVerifyDeleteWarningMessage" value="用户验证码名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="PhoneNumber" value="手机号" />
				 	<text name="Code" value="验证码" />
				 	<text name="CodeType" value="验证码类型" />
				 	<text name="Ip" value="IP地址" />
				 	<text name="ExpirationTime" value="失效时间" />
				 	<text name="VerifyStatus" value="验证状态" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/CustomDomain.xml
/*
    <!-- 用户验证码english管理 -->
		    <text name="	UserVerifyHeaderInfo" value="用户验证码List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="PhoneNumber" value="手机号" />
				 	<text name="Code" value="验证码" />
				 	<text name="CodeType" value="验证码类型" />
				 	<text name="Ip" value="IP地址" />
				 	<text name="ExpirationTime" value="失效时间" />
				 	<text name="VerifyStatus" value="验证状态" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="UserVerify" value="ManagementUserVerify" />
    <text name="CreateUserVerify" value="CreateUserVerify" />
    <text name="EditUserVerify" value="EditUserVerify" />
    <text name="DeleteUserVerify" value="DeleteUserVerify" />
*/




}