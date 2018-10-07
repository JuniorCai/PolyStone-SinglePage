
using System.Collections.Generic;
using PolyStone.CompanyAuthes.Dtos;
using PolyStone.CompanyContacts.Dtos;

namespace PolyStone.Companies.Dtos
{
    /// <summary>
    /// 企业表新增和编辑时用Dto
    /// </summary>
    
    public class CreateOrUpdateCompanyInput  
    {
    /// <summary>
    /// 企业表编辑Dto
    /// </summary>
		public CompanyEditDto  CompanyEditDto {get;set;}

        public CompanyAuthEditDto CompanyAuthEditDto { get; set; }

        public ContactEditDto ContactEdit { get; set; }
 
    }
}
