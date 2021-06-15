using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THELDALUXURYECOMMERCE.Models
{
    public class CombinedModels
    {
        public IEnumerable<tb_AdminRole> adminrolemodel { get; set; }
        public IEnumerable<tb_AdminUser> adminusermodel { get; set; }
        public IEnumerable<CountryModel> countrymodel { get; set; }
        public IEnumerable<ErrorLogModel> errorlogmodel { get; set; }
        public IEnumerable<ItemCategoryModel> itemcategorymodel { get; set; }
        public IEnumerable<tb_Item> itemmodel { get; set; }
        public IEnumerable<tb_ItemStatus> itemstatusmodel { get; set; }
        public IEnumerable<tb_LGA> lgamodel { get; set; }
        public IEnumerable<tb_Sales> salesmodel { get; set; }
        public IEnumerable<tb_State> statemodel { get; set; }
        public IEnumerable<tb_Users> usersmodel { get; set; }
    }
}
