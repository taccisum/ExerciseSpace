using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;
using HelperUnit.Extend;
using IBLL;
using IBLL.UserManager;
using Model.Models;

namespace BLL.UserManager
{
    public class UserBusiness : BaseBusiness, IUserBusiness
    {
        public Guid LoginVerify(SysUser info)
        {
            var md5Psd = info.Psd.ToMD5();
            var users = RepositoryFactory.Create<SysUser>();
            var user = users.Get(u => u.Uid == info.Uid && u.Psd == md5Psd).FirstOrDefault();

            return user != null ? user.ID : Guid.Empty;
        }

        public Guid LoginVerify(string uid, string psd)
        {
            return LoginVerify(new SysUser()
            {
                Uid = uid,
                Psd = psd
            });
        }

        public Guid GenerateAutoLoginToken()
        {
            return Guid.NewGuid();
        }

        public SysUser GetById(Guid id)
        {
            return RepositoryFactory.Create<SysUser>().GetById(id);
        }
    }
}
