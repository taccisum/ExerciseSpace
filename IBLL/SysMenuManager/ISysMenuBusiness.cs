using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace IBLL.SysMenuManager
{
    public interface ISysMenuBusiness
    {
        IQueryable<SysMenu> Get();
    }
}
