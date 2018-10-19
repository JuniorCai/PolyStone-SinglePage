
namespace PolyStone.CustomDomain.Modules
{
	
			//TODO:Angular后端的导航栏目设计

	/*
	//无次级导航属性
	   var module=new MenuItemDefinition(
                ModuleAppPermissions.Module,
                L("Module"),
				url:"modules",
				icon:"icon-grid",
					 				 requiredPermissionName: ModuleAppPermissions.Module
				  				);

*/
				//有下级菜单
            /*

			   var module=new MenuItemDefinition(
                ModuleAppPermissions.Module,
                L("Module"),			
				icon:"icon-grid"				
				);

				module.AddItem(
			new MenuItemDefinition(
			ModuleAppPermissions.Module,
			L("Module"),
			"icon-star",
			url:"modules",
			 			requiredPermissionName: ModuleAppPermissions.Module));
	

			
			*/
	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到CustomDomainApplicationModule
 //   
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/CustomDomainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 模块表管理 -->
	    <text name="Module" value="模块表" />
	    <text name="ModuleHeaderInfo" value="模块表管理列表" />
		    <text name="CreateModule" value="新增模块表" />
    <text name="EditModule" value="编辑模块表" />
    <text name="DeleteModule" value="删除模块表" />

	  
		

		    <text name="ModuleDeleteWarningMessage" value="模块表名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="ModuleCode" value="编码" />
				 	<text name="Name" value="名称" />
				 	<text name="IsActive" value="是否启用" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/CustomDomain.xml
/*
    <!-- 模块表english管理 -->
		    <text name="	ModuleHeaderInfo" value="模块表List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="ModuleCode" value="编码" />
				 	<text name="Name" value="名称" />
				 	<text name="IsActive" value="是否启用" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="Module" value="ManagementModule" />
    <text name="CreateModule" value="CreateModule" />
    <text name="EditModule" value="EditModule" />
    <text name="DeleteModule" value="DeleteModule" />
*/




}