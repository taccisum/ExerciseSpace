using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL.SysMenuManager;
using Model.Entity;

namespace BLL.SysMenuManager
{
    public class SysMenuBusiness : BaseBusiness, ISysMenuBusiness
    {
        public IQueryable<SysMenu> Get()
        {
            var menus = RepositoryFactory.At<SysMenu>().Get(m => m.EnabledState);

            return menus;
        }
    }
}
