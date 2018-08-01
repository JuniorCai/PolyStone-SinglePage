

namespace PolyStone.CustomDomain.Regions
{
	
			//TODO:Angular后端的导航栏目设计

	/*
	//无次级导航属性
	   var region=new MenuItemDefinition(
                RegionAppPermissions.Region,
                L("Region"),
				url:"regions",
				icon:"icon-grid",
					 				 requiredPermissionName: RegionAppPermissions.Region
				  				);

*/
				//有下级菜单
            /*

			   var region=new MenuItemDefinition(
                RegionAppPermissions.Region,
                L("Region"),			
				icon:"icon-grid"				
				);

				region.AddItem(
			new MenuItemDefinition(
			RegionAppPermissions.Region,
			L("Region"),
			"icon-star",
			url:"regions",
			 			requiredPermissionName: RegionAppPermissions.Region));
	

			
			*/
	
			
	
          //配置权限模块初始化
 //TODO:★需要到请将以下内容剪切到CustomDomainApplicationModule
 //   Configuration.Authorization.Providers.Add<RegionAppAuthorizationProvider>();
		 
 	
	


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/CustomDomainzh-cn.xml
//第一次加载建议复制他
// <text name="MustBe_Required" value="不能为空" />


/*
    <!-- 地区表管理 -->
	    <text name="Region" value="地区表" />
	    <text name="RegionHeaderInfo" value="地区表管理列表" />
		    <text name="CreateRegion" value="新增地区表" />
    <text name="EditRegion" value="编辑地区表" />
    <text name="DeleteRegion" value="删除地区表" />

	  
		

		    <text name="RegionDeleteWarningMessage" value="地区表名称: {0} 将被删除,是否确定删除它。" />
<!--//用于表格展示的数据信息的标题-->
					<text name="RegionName" value="地区名称" />
				 	<text name="ParentId" value="父类ID" />
				 	<text name="Sort" value="排序" />
				 	<text name="IsShow" value="是否显示" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
*/


//TODO:★请将以下内容剪切到CORE类库的Localization/Source/CustomDomain.xml
/*
    <!-- 地区表english管理 -->
		    <text name="	RegionHeaderInfo" value="地区表List" />
			<!--//用于表格展示的数据信息的标题-->
					<text name="RegionName" value="地区名称" />
				 	<text name="ParentId" value="父类ID" />
				 	<text name="Sort" value="排序" />
				 	<text name="IsShow" value="是否显示" />
				 	<text name="LastModificationTime" value="最后编辑时间" />
				 	<text name="CreationTime" value="创建时间" />
				 
    <text name="Region" value="ManagementRegion" />
    <text name="CreateRegion" value="CreateRegion" />
    <text name="EditRegion" value="EditRegion" />
    <text name="DeleteRegion" value="DeleteRegion" />
*/




}